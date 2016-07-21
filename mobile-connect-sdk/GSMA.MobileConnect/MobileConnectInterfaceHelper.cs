using GSMA.MobileConnect.Authentication;
using GSMA.MobileConnect.Discovery;
using GSMA.MobileConnect.Exceptions;
using GSMA.MobileConnect.Utils;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GSMA.MobileConnect.Identity;

namespace GSMA.MobileConnect
{
    internal static class MobileConnectInterfaceHelper
    {
        internal static async Task<MobileConnectStatus> AttemptDiscovery(IDiscovery discovery, string msisdn, string mcc, string mnc, IEnumerable<BasicKeyValuePair> cookies, MobileConnectConfig config, MobileConnectRequestOptions options)
        {
            DiscoveryResponse response = null;
            try
            {
                DiscoveryOptions discoveryOptions = options?.DiscoveryOptions ?? new DiscoveryOptions();
                discoveryOptions.MSISDN = msisdn;
                discoveryOptions.IdentifiedMCC = mcc;
                discoveryOptions.IdentifiedMNC = mnc;
                discoveryOptions.RedirectUrl = config.RedirectUrl;

                response = await discovery.StartAutomatedOperatorDiscoveryAsync(config, config.RedirectUrl, discoveryOptions, cookies);
            }
            catch(MobileConnectInvalidArgumentException e)
            {
                return MobileConnectStatus.Error("invalid_argument", string.Format("An argument was found to be invalid during the process. The argument was {0}.", e.Argument), e);
            }
            catch (MobileConnectEndpointHttpException e)
            {
                return MobileConnectStatus.Error("http_failure", "An HTTP failure occured while calling the discovery endpoint, the endpoint may be inaccessible", e);
            }
            catch (Exception e)
            {
                return MobileConnectStatus.Error("unknown_error", "An unknown error occured while calling the Discovery service to obtain operator details", e);
            }

            return GenerateStatusFromDiscoveryResponse(discovery, response);
        }

        internal static async Task<MobileConnectStatus> AttemptDiscoveryAfterOperatorSelection(IDiscovery discovery, Uri redirectedUrl, MobileConnectConfig config)
        {
            var parsedRedirect = discovery.ParseDiscoveryRedirect(redirectedUrl);

            if (!parsedRedirect.HasMCCAndMNC)
            {
                return MobileConnectStatus.StartDiscovery();
            }

            DiscoveryResponse response;
            try
            {
                response = await discovery.CompleteSelectedOperatorDiscoveryAsync(config, config.RedirectUrl, parsedRedirect.SelectedMCC, parsedRedirect.SelectedMNC);

                if(response.ResponseData?.subscriber_id == null)
                {
                    response.ResponseData.subscriber_id = parsedRedirect.EncryptedMSISDN;
                }
            }
            catch (MobileConnectInvalidArgumentException e)
            {
                return MobileConnectStatus.Error("invalid_argument", string.Format("An argument was found to be invalid during the process. The argument was {0}.", e.Argument), e);
            }
            catch (MobileConnectEndpointHttpException e)
            {
                return MobileConnectStatus.Error("http_failure", "An HTTP failure occured while calling the discovery endpoint, the endpoint may be inaccessible", e);
            }
            catch (Exception e)
            {
                return MobileConnectStatus.Error("unknown_error", "An unknown error occured while calling the Discovery service to obtain operator details", e);
            }

            return GenerateStatusFromDiscoveryResponse(discovery, response);
        }

        internal static MobileConnectStatus StartAuthentication(IAuthentication authentication, DiscoveryResponse discoveryResponse, string encryptedMSISDN, 
            string state, string nonce, MobileConnectConfig config, MobileConnectRequestOptions options)
        {
            StartAuthenticationResponse response;
            try
            {
                string clientId = discoveryResponse?.ResponseData?.response?.client_id ?? config.ClientId;
                string authorizationUrl = discoveryResponse?.OperatorUrls?.AuthorizationUrl;
                SupportedVersions supportedVersions = discoveryResponse?.ProviderMetadata?.MobileConnectVersionSupported;
                AuthenticationOptions authOptions = options?.AuthenticationOptions ?? new AuthenticationOptions();
                authOptions.ClientName = discoveryResponse?.ApplicationShortName;

                response = authentication.StartAuthentication(clientId, authorizationUrl, config.RedirectUrl, state, nonce, encryptedMSISDN, supportedVersions, authOptions);
            }
            catch (MobileConnectInvalidArgumentException e)
            {
                return MobileConnectStatus.Error("invalid_argument", string.Format("An argument was found to be invalid during the process. The argument was {0}.", e.Argument), e);
            }
            catch (Exception e)
            {
                return MobileConnectStatus.Error("unknown_error", "An unknown error occured while generating an authorization url", e);
            }

            return MobileConnectStatus.Authorization(response.Url, state, nonce);
        }

        internal static async Task<MobileConnectStatus> RequestToken(IAuthentication authentication, DiscoveryResponse discoveryResponse, Uri redirectedUrl, string expectedState, string expectedNonce, MobileConnectConfig config)
        {
            RequestTokenResponse response;

            if(string.IsNullOrEmpty(expectedState))
            {
                return MobileConnectStatus.Error("required_arg_missing", "ExpectedState argument was not supplied, this is needed to prevent Cross-Site Request Forgery", null);
            }

            if (string.IsNullOrEmpty(expectedNonce))
            {
                return MobileConnectStatus.Error("required_arg_missing", "expectedNonce argument was not supplied, this is needed to prevent Replay Attacks", null);
            }

            var actualState = HttpUtils.ExtractQueryValue(redirectedUrl.Query, "state");
            if (expectedState != actualState)
            {
                return MobileConnectStatus.Error("invalid_state", "State values do not match, this could suggest an attempted Cross-Site Request Forgery", null);
            }

            try
            {
                var code = HttpUtils.ExtractQueryValue(redirectedUrl.Query, "code");
                var clientId = discoveryResponse?.ResponseData?.response?.client_id ?? config.ClientId;
                var clientSecret = discoveryResponse?.ResponseData?.response?.client_secret ?? config.ClientSecret;
                var requestTokenUrl = discoveryResponse?.OperatorUrls?.RequestTokenUrl;
                response = await authentication.RequestTokenAsync(clientId, clientSecret, requestTokenUrl, config.RedirectUrl, code);

                if(response.ErrorResponse != null)
                {
                    return MobileConnectStatus.Error(response.ErrorResponse.Error, response.ErrorResponse.ErrorDescription, null, response);
                }

                if(!Validation.IsExpectedNonce(response.ResponseData.IdToken, expectedNonce))
                {
                    return MobileConnectStatus.Error("invalid_nonce", "Nonce values do not match, this could suggest an attempted Replay Attack", null);
                }
            }
            catch (MobileConnectInvalidArgumentException e)
            {
                return MobileConnectStatus.Error("invalid_argument", string.Format("An argument was found to be invalid during the process. The argument was {0}.", e.Argument), e);
            }
            catch (MobileConnectEndpointHttpException e)
            {
                return MobileConnectStatus.Error("http_failure", "An HTTP failure occured while calling the operator token endpoint, the endpoint may be inaccessible", e);
            }
            catch (Exception e)
            {
                return MobileConnectStatus.Error("unknown_error", "A failure occured while requesting a token", e);
            }

            return MobileConnectStatus.Complete(response);
        }

        internal static async Task<MobileConnectStatus> HandleUrlRedirect(IDiscovery discovery, IAuthentication authentication, Uri redirectedUrl, DiscoveryResponse discoveryResponse, string expectedState, string expectedNonce, MobileConnectConfig config)
        {
            if (HttpUtils.ExtractQueryValue(redirectedUrl.Query, "code") != null)
            {
                return await RequestToken(authentication, discoveryResponse, redirectedUrl, expectedState, expectedNonce, config);
            }
            else if (HttpUtils.ExtractQueryValue(redirectedUrl.Query, "mcc_mnc") != null)
            {
                return await AttemptDiscoveryAfterOperatorSelection(discovery, redirectedUrl, config);
            }

            string errorCode = HttpUtils.ExtractQueryValue(redirectedUrl.Query, "error") ?? "invalid_request";
            string errorDesc = HttpUtils.ExtractQueryValue(redirectedUrl.Query, "error_description") ?? string.Format("Unable to parse next step using {0}", redirectedUrl.AbsoluteUri);
            return MobileConnectStatus.Error(errorCode, errorDesc, null);
        }

        internal static async Task<MobileConnectStatus> RequestUserInfo(IIdentityService _identity, DiscoveryResponse discoveryResponse, string accessToken, MobileConnectConfig _config, MobileConnectRequestOptions options)
        {
            string userInfoUrl = discoveryResponse?.OperatorUrls?.UserInfoUrl;
            if (string.IsNullOrEmpty(userInfoUrl))
            {
                return MobileConnectStatus.Error("not_supported", "UserInfo not supported with current operator", null);
            }

            var response = await _identity.RequestUserInfo(userInfoUrl, accessToken);
            return MobileConnectStatus.UserInfo(response);
        }

        internal static async Task<MobileConnectStatus> RequestIdentity(IIdentityService _identity, DiscoveryResponse discoveryResponse, string accessToken, MobileConnectConfig _config, MobileConnectRequestOptions options)
        {
            string identityUrl = discoveryResponse?.OperatorUrls?.PremiumInfoUrl;
            if (string.IsNullOrEmpty(identityUrl))
            {
                return MobileConnectStatus.Error("not_supported", "Identity not supported with current operator", null);
            }

            var response = await _identity.RequestIdentity(identityUrl, accessToken);
            return MobileConnectStatus.Identity(response);
        }

        private static MobileConnectStatus GenerateStatusFromDiscoveryResponse(IDiscovery discovery, DiscoveryResponse response)
        {
            if (!response.Cached && response.ErrorResponse != null)
            {
                return MobileConnectStatus.Error(response.ResponseData?.error, response.ResponseData?.description ?? "Failure at discovery endpoint, see response for more information", null, response);
            }

            var operatorSelectionUrl = discovery.ExtractOperatorSelectionURL(response);
            if (!string.IsNullOrEmpty(operatorSelectionUrl))
            {
                return MobileConnectStatus.OperatorSelection(operatorSelectionUrl);
            }

            return MobileConnectStatus.StartAuthorization(response);
        }
    }
}
