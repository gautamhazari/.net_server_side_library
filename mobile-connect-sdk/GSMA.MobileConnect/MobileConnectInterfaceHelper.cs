using GSMA.MobileConnect.Authentication;
using GSMA.MobileConnect.Discovery;
using GSMA.MobileConnect.Exceptions;
using GSMA.MobileConnect.Utils;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GSMA.MobileConnect.Identity;
using System.Threading;

namespace GSMA.MobileConnect
{
    internal static class MobileConnectInterfaceHelper
    {
        internal static async Task<MobileConnectStatus> AttemptDiscovery(IDiscoveryService discovery, string msisdn, string mcc, string mnc, IEnumerable<BasicKeyValuePair> cookies, MobileConnectConfig config, MobileConnectRequestOptions options)
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

        internal static async Task<MobileConnectStatus> AttemptDiscoveryAfterOperatorSelection(IDiscoveryService discovery, Uri redirectedUrl, MobileConnectConfig config)
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

                if (response.ResponseData?.subscriber_id == null)
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

        internal static MobileConnectStatus StartAuthentication(IAuthenticationService authentication, DiscoveryResponse discoveryResponse, string encryptedMSISDN,
            string state, string nonce, MobileConnectConfig config, MobileConnectRequestOptions options)
        {
            if (!IsUsableDiscoveryResponse(discoveryResponse))
            {
                return MobileConnectStatus.StartDiscovery();
            }

            StartAuthenticationResponse response;
            try
            {
                string clientId = discoveryResponse.ResponseData.response.client_id ?? config.ClientId;
                string authorizationUrl = discoveryResponse.OperatorUrls.AuthorizationUrl;
                SupportedVersions supportedVersions = discoveryResponse.ProviderMetadata?.MobileConnectVersionSupported;
                AuthenticationOptions authOptions = options?.AuthenticationOptions ?? new AuthenticationOptions();
                authOptions.ClientName = discoveryResponse.ApplicationShortName;

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

        internal static async Task<MobileConnectStatus> RequestHeadlessAuthentication(IAuthenticationService authentication, IJWKeysetService jwks, IIdentityService identity, DiscoveryResponse discoveryResponse, string encryptedMSISDN,
            string state, string nonce, MobileConnectConfig config, MobileConnectRequestOptions options, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (!IsUsableDiscoveryResponse(discoveryResponse))
            {
                return MobileConnectStatus.StartDiscovery();
            }

            MobileConnectStatus status;
            try
            {
                string clientId = discoveryResponse.ResponseData.response.client_id ?? config.ClientId;
                string clientSecret = discoveryResponse.ResponseData.response.client_secret;
                string authorizationUrl = discoveryResponse.OperatorUrls.AuthorizationUrl;
                string tokenUrl = discoveryResponse.OperatorUrls.RequestTokenUrl;
                string issuer = discoveryResponse.ProviderMetadata.Issuer;
                SupportedVersions supportedVersions = discoveryResponse.ProviderMetadata.MobileConnectVersionSupported;
                AuthenticationOptions authOptions = options?.AuthenticationOptions ?? new AuthenticationOptions();
                authOptions.ClientName = discoveryResponse.ApplicationShortName;

                var jwksTask = jwks.RetrieveJWKSAsync(discoveryResponse.OperatorUrls.JWKSUrl);
                var tokenTask = authentication.RequestHeadlessAuthentication(clientId, clientSecret, authorizationUrl, tokenUrl, config.RedirectUrl, state, nonce, 
                    encryptedMSISDN, supportedVersions, authOptions, cancellationToken);

                // execute both tasks in parallel
                await Task.WhenAll(tokenTask, jwksTask).ConfigureAwait(false);

                RequestTokenResponse response = tokenTask.Result;

                status = HandleTokenResponse(authentication, response, clientId, issuer, nonce, jwksTask.Result, options);
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
                return MobileConnectStatus.Error("unknown_error", "An unknown error occured while generating an authorization url", e);
            }

            if(status.ResponseType == MobileConnectResponseType.Error
                || !options.AutoRetrieveIdentityHeadless || string.IsNullOrEmpty(discoveryResponse.OperatorUrls.PremiumInfoUrl))
            {
                return status;
            }

            var identityStatus = await RequestIdentity(identity, discoveryResponse, status.TokenResponse.ResponseData.AccessToken, config, options);
            status.IdentityResponse = identityStatus.IdentityResponse;

            return status;
        }

        internal static async Task<MobileConnectStatus> RequestToken(IAuthenticationService authentication, IJWKeysetService jwks, DiscoveryResponse discoveryResponse, Uri redirectedUrl, string expectedState,
            string expectedNonce, MobileConnectConfig config, MobileConnectRequestOptions options)
        {
            RequestTokenResponse response;

            if (!IsUsableDiscoveryResponse(discoveryResponse))
            {
                return MobileConnectStatus.StartDiscovery();
            }

            if (string.IsNullOrEmpty(expectedState))
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
                var clientId = discoveryResponse.ResponseData.response.client_id ?? config.ClientId;
                var clientSecret = discoveryResponse.ResponseData.response.client_secret ?? config.ClientSecret;
                var requestTokenUrl = discoveryResponse.OperatorUrls.RequestTokenUrl;
                var issuer = discoveryResponse.ProviderMetadata.Issuer;

                var tokenTask = authentication.RequestTokenAsync(clientId, clientSecret, requestTokenUrl, config.RedirectUrl, code);
                var jwksTask = jwks.RetrieveJWKSAsync(discoveryResponse.OperatorUrls.JWKSUrl);

                // execute both tasks in parallel
                await Task.WhenAll(tokenTask, jwksTask).ConfigureAwait(false);

                response = tokenTask.Result;

                return HandleTokenResponse(authentication, response, clientId, issuer, expectedNonce, jwksTask.Result, options);
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
        }

        private static MobileConnectStatus HandleTokenResponse(IAuthenticationService authentication, RequestTokenResponse response, string clientId, string issuer, string expectedNonce, JWKeyset jwks, MobileConnectRequestOptions options)
        {
            if (response.ErrorResponse != null)
            {
                return MobileConnectStatus.Error(response.ErrorResponse.Error, response.ErrorResponse.ErrorDescription, null, response);
            }

            response.ValidationResult = authentication.ValidateTokenResponse(response, clientId, issuer, expectedNonce, options?.MaxAge, jwks);
            var validationOptions = options?.TokenValidationOptions ?? new TokenValidationOptions();
            if (!validationOptions.AcceptedValidationResults.HasFlag(response.ValidationResult))
            {
                return MobileConnectStatus.Error("invalid_token", $"The token was found to be invalid with the validtion result {response.ValidationResult}", null, response);
            }

            return MobileConnectStatus.Complete(response);
        }

        internal static async Task<MobileConnectStatus> HandleUrlRedirect(IDiscoveryService discovery, IAuthenticationService authentication, IJWKeysetService jwks, Uri redirectedUrl, DiscoveryResponse discoveryResponse, string expectedState, string expectedNonce, MobileConnectConfig config, MobileConnectRequestOptions options)
        {
            if (HttpUtils.ExtractQueryValue(redirectedUrl.Query, "code") != null)
            {
                return await RequestToken(authentication, jwks, discoveryResponse, redirectedUrl, expectedState, expectedNonce, config, options);
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

            try
            {
                var response = await _identity.RequestUserInfo(userInfoUrl, accessToken);
                return MobileConnectStatus.UserInfo(response);
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
        }

        internal static async Task<MobileConnectStatus> RequestIdentity(IIdentityService _identity, DiscoveryResponse discoveryResponse, string accessToken, MobileConnectConfig _config, MobileConnectRequestOptions options)
        {
            string identityUrl = discoveryResponse?.OperatorUrls?.PremiumInfoUrl;
            if (string.IsNullOrEmpty(identityUrl))
            {
                return MobileConnectStatus.Error("not_supported", "Identity not supported with current operator", null);
            }

            try
            {
                var response = await _identity.RequestIdentity(identityUrl, accessToken);
                return MobileConnectStatus.Identity(response);
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
        }

        private static MobileConnectStatus GenerateStatusFromDiscoveryResponse(IDiscoveryService discovery, DiscoveryResponse response)
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

        private static bool IsUsableDiscoveryResponse(DiscoveryResponse response)
        {
            // if response is null or does not have operator urls then it isn't usable for the process after discovery
            return response != null && response.OperatorUrls != null && response.ResponseData != null && response.ResponseData.response != null;
        }
    }
}
