using GSMA.MobileConnect.Authentication;
using GSMA.MobileConnect.Discovery;
using GSMA.MobileConnect.Exceptions;
using GSMA.MobileConnect.Utils;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GSMA.MobileConnect.Identity;
using System.Threading;
using GSMA.MobileConnect.Constants;

namespace GSMA.MobileConnect
{
    internal static class MobileConnectInterfaceHelper
    {
        internal static async Task<MobileConnectStatus> AttemptDiscovery(
            IDiscoveryService discovery,
            string msisdn,
            string mcc,
            string mnc,
            IEnumerable<BasicKeyValuePair> cookies,
            MobileConnectConfig config,
            MobileConnectRequestOptions options)
        {
            DiscoveryResponse response = null;
            try
            {
                DiscoveryOptions discoveryOptions = options?.DiscoveryOptions ?? new DiscoveryOptions();
                discoveryOptions.MSISDN = msisdn;
                discoveryOptions.IdentifiedMCC = mcc;
                discoveryOptions.IdentifiedMNC = mnc;
                discoveryOptions.RedirectUrl = config.RedirectUrl;
                discoveryOptions.XRedirect = config.XRedirect;

                response = await discovery.StartAutomatedOperatorDiscoveryAsync(config, config.RedirectUrl, discoveryOptions, cookies);
            }
            catch (MobileConnectInvalidArgumentException e)
            {
                Log.Error(() => $"An invalid argument was passed to AttemptDiscovery arg={e.Argument}");
                return MobileConnectStatus.Error(ErrorCodes.InvalidArgument, 
                    string.Format("An argument was found to be invalid during the process. The argument was {0}.", 
                    e.Argument), e);
            }
            catch (MobileConnectEndpointHttpException e)
            {
                Log.Error(() => $"A general http error occurred in AttemptDiscovery msisdn={!string.IsNullOrEmpty(msisdn)} mcc={mcc} mnc={mnc} discoveryUrl={config.DiscoveryUrl}");
                return MobileConnectStatus.Error(ErrorCodes.HttpFailure, 
                    "An HTTP failure occured while calling the discovery endpoint, the endpoint may be inaccessible",
                    e);
            }
            catch (Exception e)
            {
                Log.Error(() => $"A general error occurred in AttemptDiscovery msisdn={!string.IsNullOrEmpty(msisdn)} mcc={mcc} mnc={mnc} discoveryUrl={config.DiscoveryUrl}");
                return MobileConnectStatus.Error(ErrorCodes.Unknown, 
                    "An unknown error occured while calling the Discovery service to obtain operator details", 
                    e);
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
                Log.Error(() => $"An invalid argument was passed to AttemptDiscoveryAfterOperatorSelection arg={e.Argument}");
                return MobileConnectStatus.Error(ErrorCodes.InvalidArgument, string.Format("An argument was found to be invalid during the process. The argument was {0}.", e.Argument), e);
            }
            catch (MobileConnectEndpointHttpException e)
            {
                Log.Error(() => $"A general http error occurred in AttemptDiscoveryAfterOperatorSelection redirectedUrl={redirectedUrl} discoveryUrl={config.DiscoveryUrl}");
                return MobileConnectStatus.Error(ErrorCodes.HttpFailure, "An HTTP failure occured while calling the discovery endpoint, the endpoint may be inaccessible", e);
            }
            catch (Exception e)
            {
                Log.Error(() => $"A general error occurred in AttemptDiscoveryAfterOperatorSelection redirectedUrl={redirectedUrl} discoveryUrl={config.DiscoveryUrl}");
                return MobileConnectStatus.Error(ErrorCodes.Unknown, "An unknown error occured while calling the Discovery service to obtain operator details", e);
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
                Log.Error(() => $"An invalid argument was passed to StartAuthentication arg={e.Argument}");
                return MobileConnectStatus.Error(ErrorCodes.InvalidArgument, string.Format("An argument was found to be invalid during the process. The argument was {0}.", e.Argument), e);
            }
            catch (Exception e)
            {
                Log.Error(() => $"A general error occurred in AttemptDiscoveryAfterOperatorSelection state={state} nonce={nonce} authUrl={discoveryResponse.OperatorUrls.AuthorizationUrl}");
                return MobileConnectStatus.Error(ErrorCodes.Unknown, "An unknown error occured while generating an authorization url", e);
            }

            return MobileConnectStatus.Authentication(response.Url, state, nonce);
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

                status = HandleTokenResponse(authentication, response, clientId, issuer, nonce,
                    discoveryResponse.ProviderMetadata.MobileConnectVersionSupported.MaxSupportedVersionString, jwksTask.Result, options);
            }
            catch (MobileConnectInvalidArgumentException e)
            {
                Log.Error(() => $"An invalid argument was passed to RequestHeadlessAuthentication arg={e.Argument}");
                return MobileConnectStatus.Error(ErrorCodes.InvalidArgument, string.Format("An argument was found to be invalid during the process. The argument was {0}.", e.Argument), e);
            }
            catch (MobileConnectEndpointHttpException e)
            {
                Log.Error(() => $"A general http error occurred in RequestHeadlessAuthentication state={state} nonce={nonce} authUrl={discoveryResponse.OperatorUrls.AuthorizationUrl} tokenUrl={discoveryResponse.OperatorUrls.RequestTokenUrl}");
                return MobileConnectStatus.Error(ErrorCodes.HttpFailure, "An HTTP failure occured while calling the discovery endpoint, the endpoint may be inaccessible", e);
            }
            catch (Exception e)
            {
                Log.Error(() => $"A general error occurred in RequestHeadlessAuthentication state={state} nonce={nonce} authUrl={discoveryResponse.OperatorUrls.AuthorizationUrl} tokenUrl={discoveryResponse.OperatorUrls.RequestTokenUrl}");
                return MobileConnectStatus.Error(ErrorCodes.Unknown, "An unknown error occured while generating an authorization url", e);
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
                return MobileConnectStatus.Error(ErrorCodes.InvalidArgument, "ExpectedState argument was not supplied, this is needed to prevent Cross-Site Request Forgery", null);
            }

            if (string.IsNullOrEmpty(expectedNonce))
            {
                return MobileConnectStatus.Error(ErrorCodes.InvalidArgument, "expectedNonce argument was not supplied, this is needed to prevent Replay Attacks", null);
            }

            var actualState = HttpUtils.ExtractQueryValue(redirectedUrl.Query, "state");
            if (expectedState != actualState)
            {
                return MobileConnectStatus.Error(ErrorCodes.InvalidState, "State values do not match, this could suggest an attempted Cross-Site Request Forgery", null);
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
  
                var maxSupportedVersion = discoveryResponse.ProviderMetadata?.MobileConnectVersionSupported == null ? "mc_v1.1" : discoveryResponse.ProviderMetadata.MobileConnectVersionSupported.MaxSupportedVersionString;

                return HandleTokenResponse(authentication, response, clientId, issuer, expectedNonce,
                    maxSupportedVersion, jwksTask.Result, options);
            }
            catch (MobileConnectInvalidArgumentException e)
            {
                Log.Error(() => $"An invalid argument was passed to RequestToken arg={e.Argument}");
                return MobileConnectStatus.Error(ErrorCodes.InvalidArgument, string.Format("An argument was found to be invalid during the process. The argument was {0}.", e.Argument), e);
            }
            catch (MobileConnectEndpointHttpException e)
            {
                Log.Error(() => $"A general http error occurred in RequestToken redirectedUrl={redirectedUrl} requestTokenUrl={discoveryResponse.OperatorUrls.RequestTokenUrl} jwksUrl={discoveryResponse.OperatorUrls.JWKSUrl}");
                return MobileConnectStatus.Error(ErrorCodes.HttpFailure, "An HTTP failure occured while calling the operator token endpoint, the endpoint may be inaccessible", e);
            }
            catch (Exception e)
            {
                Log.Error(() => $"A general error occurred in RequestToken redirectedUrl={redirectedUrl} requestTokenUrl={discoveryResponse.OperatorUrls.RequestTokenUrl} jwksUrl={discoveryResponse.OperatorUrls.JWKSUrl}");
                return MobileConnectStatus.Error(ErrorCodes.Unknown, "A failure occured while requesting a token", e);
            }
        }

        private static MobileConnectStatus HandleTokenResponse(IAuthenticationService authentication, RequestTokenResponse response, string clientId, string issuer, string expectedNonce, 
            string version, JWKeyset jwks, MobileConnectRequestOptions options)
        {
            if (response.ErrorResponse != null)
            {
                return MobileConnectStatus.Error(response.ErrorResponse.Error, response.ErrorResponse.ErrorDescription, null, response);
            }

            response.ValidationResult = authentication.ValidateTokenResponse(response, clientId, issuer, expectedNonce, options?.MaxAge, jwks, version);
            var validationOptions = options?.TokenValidationOptions ?? new TokenValidationOptions();
            if (!validationOptions.AcceptedValidationResults.HasFlag(response.ValidationResult))
            {
                Log.Error(() => $"A generated tokenResponse was invalid issuer={issuer} version={version} result={response.ValidationResult}");
                return MobileConnectStatus.Error(ErrorCodes.InvalidToken, $"The token was found to be invalid with the validation result {response.ValidationResult}", null, response);
            }
            else if(response.ValidationResult != TokenValidationResult.Valid)
            {
                Log.Warning(() => $"A generated tokenResponse was invalid but accepted issuer={issuer} version={version} result={response.ValidationResult}");
            }

            return MobileConnectStatus.Complete(response);
        }

        internal static async Task<MobileConnectStatus> HandleUrlRedirect(IDiscoveryService discovery, IAuthenticationService authentication, IJWKeysetService jwks, Uri redirectedUrl, DiscoveryResponse discoveryResponse, 
            string expectedState, string expectedNonce, MobileConnectConfig config, MobileConnectRequestOptions options)
        {
            if (HttpUtils.ExtractQueryValue(redirectedUrl.Query, "code") != null)
            {
                return await RequestToken(authentication, jwks, discoveryResponse, redirectedUrl, expectedState, expectedNonce, config, options);
            }
            else if (HttpUtils.ExtractQueryValue(redirectedUrl.Query, "mcc_mnc") != null)
            {
                return await AttemptDiscoveryAfterOperatorSelection(discovery, redirectedUrl, config);
            }

            string errorCode = HttpUtils.ExtractQueryValue(redirectedUrl.Query, "error") ?? ErrorCodes.InvalidRedirect;
            string errorDesc = HttpUtils.ExtractQueryValue(redirectedUrl.Query, "error_description") ?? HttpUtils.ExtractQueryValue(redirectedUrl.Query, "description") ?? string.Format("Unable to parse next step using {0}", redirectedUrl.AbsoluteUri);
            return MobileConnectStatus.Error(errorCode, errorDesc, null);
        }

        internal static async Task<MobileConnectStatus> RequestUserInfo(IIdentityService _identity, DiscoveryResponse discoveryResponse, string accessToken, MobileConnectConfig _config, MobileConnectRequestOptions options)
        {
            string userInfoUrl = discoveryResponse?.OperatorUrls?.UserInfoUrl;
            if (string.IsNullOrEmpty(userInfoUrl))
            {
                Log.Error(() => $"UserInfo was not supported for issuer={discoveryResponse?.ProviderMetadata?.Issuer}");
                return MobileConnectStatus.Error(ErrorCodes.NotSupported, "UserInfo not supported with current operator", null);
            }

            try
            {
                var response = await _identity.RequestUserInfo(userInfoUrl, accessToken);
                return MobileConnectStatus.UserInfo(response);
            }
            catch (MobileConnectInvalidArgumentException e)
            {
                Log.Error(() => $"An invalid argument was passed to RequestUserInfo arg={e.Argument}");
                return MobileConnectStatus.Error(ErrorCodes.InvalidArgument, string.Format("An argument was found to be invalid during the process. The argument was {0}.", e.Argument), e);
            }
            catch (MobileConnectEndpointHttpException e)
            {
                Log.Error(() => $"A general http error occurred in RequestUserInfo userInfoUrl={userInfoUrl}");
                return MobileConnectStatus.Error(ErrorCodes.HttpFailure, "An HTTP failure occured while calling the operator token endpoint, the endpoint may be inaccessible", e);
            }
            catch (Exception e)
            {
                Log.Error(() => $"A general error occurred in RequestUserInfo userInfoUrl={userInfoUrl}");
                return MobileConnectStatus.Error(ErrorCodes.Unknown, "A failure occured while requesting a token", e);
            }
        }

        internal static async Task<MobileConnectStatus> RequestIdentity(IIdentityService _identity, DiscoveryResponse discoveryResponse, string accessToken, MobileConnectConfig _config, MobileConnectRequestOptions options)
        {
            string identityUrl = discoveryResponse?.OperatorUrls?.PremiumInfoUrl;

            var notSupported = IsSupported(identityUrl, "Identity", discoveryResponse?.ProviderMetadata?.Issuer);
            if (notSupported != null)
            {
                return notSupported;
            }

            try
            {
                var response = await _identity.RequestIdentity(identityUrl, accessToken);
                return MobileConnectStatus.Identity(response);
            }
            catch (MobileConnectInvalidArgumentException e)
            {
                Log.Error(() => $"An invalid argument was passed to RequestIdentity arg={e.Argument}");
                return MobileConnectStatus.Error(ErrorCodes.InvalidArgument, string.Format("An argument was found to be invalid during the process. The argument was {0}.", e.Argument), e);
            }
            catch (MobileConnectEndpointHttpException e)
            {
                Log.Error(() => $"A general http error occurred in RequestUserInfo identityUrl={identityUrl}");
                return MobileConnectStatus.Error(ErrorCodes.HttpFailure, "An HTTP failure occured while calling the operator token endpoint, the endpoint may be inaccessible", e);
            }
            catch (Exception e)
            {
                Log.Error(() => $"A general error occurred in RequestUserInfo identityUrl={identityUrl}");
                return MobileConnectStatus.Error(ErrorCodes.Unknown, "A failure occured while requesting a token", e);
            }
        }

        internal static async Task<MobileConnectStatus> RefreshToken(IAuthenticationService authentication, string refreshToken, DiscoveryResponse discoveryResponse, MobileConnectConfig config)
        {
            Validate.RejectNull(discoveryResponse, "discoveryResponse");
            Validate.RejectNullOrEmpty(refreshToken, "refreshToken");

            if (!IsUsableDiscoveryResponse(discoveryResponse))
            {
                return MobileConnectStatus.StartDiscovery();
            }

            string refreshTokenUrl = discoveryResponse.OperatorUrls.RefreshTokenUrl ?? discoveryResponse.OperatorUrls.RequestTokenUrl;

            var notSupported = IsSupported(refreshTokenUrl, "Refresh", discoveryResponse.ProviderMetadata?.Issuer);
            if (notSupported != null)
            {
                return notSupported;
            }

            string clientId = discoveryResponse.ResponseData.response.client_id ?? config.ClientId;
            string clientSecret = discoveryResponse.ResponseData.response.client_secret ?? config.ClientSecret;

            try
            {
                RequestTokenResponse requestTokenResponse = await authentication.RefreshTokenAsync(clientId, clientSecret, refreshTokenUrl, refreshToken);
                ErrorResponse errorResponse = requestTokenResponse.ErrorResponse;
                if (errorResponse != null)
                {
                    Log.Error(() => $"Responding with responseType={MobileConnectResponseType.Error} for refreshToken for authentication service responded with error={errorResponse.Error}");
                    return MobileConnectStatus.Error(errorResponse);
                }
                else
                {
                    Log.Info(() => $"Refresh token success");
                    return MobileConnectStatus.Complete(requestTokenResponse);
                }
            }
            catch (Exception e)
            {
                Log.Error(() => $"RefreshToken failed", e);
                return MobileConnectStatus.Error(ErrorCodes.Unknown, "Refresh token error", e);
            }
        }

        internal static async Task<MobileConnectStatus> RevokeToken(IAuthenticationService authentication, string token, string tokenTypeHint, DiscoveryResponse discoveryResponse, MobileConnectConfig config)
        {
            Validate.RejectNull(discoveryResponse, "discoveryResponse");
            Validate.RejectNullOrEmpty(token, "token");

            string revokeTokenUrl = discoveryResponse.OperatorUrls.RevokeTokenUrl;

            var notSupported = IsSupported(revokeTokenUrl, "Revoke", discoveryResponse.ProviderMetadata?.Issuer);
            if (notSupported != null)
            {
                return notSupported;
            }

            string clientId = discoveryResponse.ResponseData.response.client_id;
            string clientSecret = discoveryResponse.ResponseData.response.client_secret;

            try
            {
                var response = await authentication.RevokeTokenAsync(clientId, clientSecret, revokeTokenUrl, token, tokenTypeHint);
                return MobileConnectStatus.TokenRevoked(response);
            }
            catch (Exception e)
            {
                Log.Error(() => $"RevokeToken failed", e);
                return MobileConnectStatus.Error(ErrorCodes.Unknown, "Revoke token error", e);
            }
        }

        public static MobileConnectStatus GenerateStatusFromDiscoveryResponse(IDiscoveryService discovery, DiscoveryResponse response)
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

            return MobileConnectStatus.StartAuthentication(response);
        }

        private static bool IsUsableDiscoveryResponse(DiscoveryResponse response)
        {
            // if response is null or does not have operator urls then it isn't usable for the process after discovery
            var usable = response != null && response.OperatorUrls != null && response.ResponseData != null && response.ResponseData.response != null;

            if(!usable)
            {
                Log.Warning("Discovery response was unusable");
                Log.Debug(() => $"Unusable response={Newtonsoft.Json.JsonConvert.SerializeObject(response)}");
            }

            return usable;
        }

        private static MobileConnectStatus IsSupported(string serviceUrl, string service, string issuer)
        {
            if (string.IsNullOrEmpty(serviceUrl))
            {
                Log.Error(() => $"{service} was not supported for issuer={issuer}");
                return MobileConnectStatus.Error(ErrorCodes.NotSupported, $"{service} not supported with current operator", null);
            }

            return null;
        }
    }
}
