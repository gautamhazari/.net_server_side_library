using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GSMA.MobileConnect.Discovery;
using GSMA.MobileConnect.Utils;
using GSMA.MobileConnect.Exceptions;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Threading;

namespace GSMA.MobileConnect.Authentication
{
    /// <summary>
    /// Concrete implementation of <see cref="IAuthenticationService"/>
    /// </summary>
    public class AuthenticationService : IAuthenticationService
    {
        private readonly static JsonSerializerSettings _jsonSettings = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };
        private readonly RestClient _client;

        /// <summary>
        /// Creates a new instance of the class AuthenticationService using the specified RestClient for all HTTP requests
        /// </summary>
        /// <param name="client">RestClient for handling HTTP requests</param>
        public AuthenticationService(RestClient client)
        {
            this._client = client;
        }

        /// <inheritdoc/>
        public StartAuthenticationResponse StartAuthentication(string clientId, string authorizeUrl, string redirectUrl, string state, string nonce,
            string encryptedMSISDN, SupportedVersions versions, AuthenticationOptions options)
        {
            Validate.RejectNullOrEmpty(clientId, "clientId");
            Validate.RejectNullOrEmpty(authorizeUrl, "authorizeUrl");
            Validate.RejectNullOrEmpty(redirectUrl, "redirectUrl");
            Validate.RejectNullOrEmpty(state, "state");
            Validate.RejectNullOrEmpty(nonce, "nonce");

            options = options ?? new AuthenticationOptions();
            options.Scope = options.Scope ?? "";
            bool shouldUseAuthorize = ShouldUseAuthorize(options);

            if (shouldUseAuthorize)
            {
                Validate.RejectNullOrEmpty(options.Context, "options.Context");
                Validate.RejectNullOrEmpty(options.ClientName, "options.ClientName");
            }

            options.State = state;
            options.Nonce = nonce;
            options.LoginHint = options.LoginHint ?? LoginHint.GenerateForEncryptedMSISDN(encryptedMSISDN);
            options.RedirectUrl = redirectUrl;
            options.ClientId = clientId;

            string version;
            string coercedScope = CoerceAuthenticationScope(options.Scope, versions, shouldUseAuthorize, out version);
            Log.Info(() => $"scope={options.Scope} => coercedScope={coercedScope}");
            options.Scope = coercedScope;

            UriBuilder build = new UriBuilder(authorizeUrl);
            build.AddQueryParams(GetAuthenticationQueryParams(options, shouldUseAuthorize, version));

            Log.Info(() => $"Authentication URI={build.Uri.AbsoluteUri}");
            return new StartAuthenticationResponse() { Url = build.Uri.AbsoluteUri };
        }

        /// <inheritdoc/>
        public async Task<RequestTokenResponse> RequestHeadlessAuthentication(string clientId, string clientSecret, string authorizeUrl, string tokenUrl, string redirectUrl,
            string state, string nonce, string encryptedMSISDN, SupportedVersions versions, AuthenticationOptions options, CancellationToken cancellationToken = default(CancellationToken))
        {
            options = options ?? new AuthenticationOptions();

            bool shouldUseAuthorize = ShouldUseAuthorize(options);
            if (shouldUseAuthorize)
            {
                options.Prompt = "mobile";
            }

            string authUrl = StartAuthentication(clientId, authorizeUrl, redirectUrl, state, nonce, encryptedMSISDN, versions, options).Url;
            Uri finalRedirect = null;

            try
            {
                finalRedirect = await _client.GetFinalRedirect(authUrl, redirectUrl, options.PollFrequencyInMs, options.MaxRedirects, cancellationToken);
            }
            catch (Exception e) when (e is System.Net.WebException || e is TaskCanceledException)
            {
                Log.Error("Headless authentication was cancelled", e);
                return new RequestTokenResponse(new ErrorResponse { Error = Constants.ErrorCodes.AuthCancelled, ErrorDescription = "Headless authentication was cancelled or a timeout occurred" });
            }
            catch (HttpRequestException e)
            {
                Log.Error("Headless authentication failed", e);
                throw new MobileConnectEndpointHttpException(e.Message, e);
            }

            var error = ErrorResponse.CreateFromUrl(finalRedirect.AbsoluteUri);

            if (error != null)
            {
                return new RequestTokenResponse(error);
            }

            var code = HttpUtils.ExtractQueryValue(finalRedirect.AbsoluteUri, "code");
            return await RequestTokenAsync(clientId, clientSecret, tokenUrl, redirectUrl, code);
        }

        private bool ShouldUseAuthorize(AuthenticationOptions options)
        {
            int authnIndex = options.Scope.IndexOf(Constants.Scope.AUTHN, StringComparison.OrdinalIgnoreCase);
            bool authnRequested = authnIndex > -1;
            bool mcProductRequested = options.Scope.LastIndexOf(Constants.Scope.MCPREFIX, StringComparison.OrdinalIgnoreCase) != authnIndex;

            if (mcProductRequested)
            {
                return true;
            }

            // If context is passed and authn not specifically requested then use authorize
            if (!authnRequested && !string.IsNullOrEmpty(options.Context))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Returns a modified scope value based on the version required. Depending on the version the value mc_authn may be added or removed
        /// </summary>
        /// <param name="scopeRequested">Request scope value</param>
        /// <param name="versions">SupportedVersions from ProviderMetadata, used for finding the supported version for the requested auth type</param>
        /// <param name="shouldUseAuthorize">If mc_authz should be used over mc_authn</param>
        /// <param name="version">Supported version of the scope selected to use</param>
        /// <returns>Returns a modified scope value with mc_authn removed or added</returns>
        private string CoerceAuthenticationScope(string scopeRequested, SupportedVersions versions, bool shouldUseAuthorize, out string version)
        {
            var requiredScope = shouldUseAuthorize ? MobileConnectConstants.MOBILECONNECTAUTHORIZATION : MobileConnectConstants.MOBILECONNECTAUTHENTICATION;
            var disallowedScope = shouldUseAuthorize ? Constants.Scope.AUTHN : Constants.Scope.AUTHZ;

            versions = versions ?? new SupportedVersions(null);
            version = versions.GetSupportedVersion(requiredScope);

            var splitScope = scopeRequested.Split().ToList();
            splitScope = Scope.CoerceOpenIdScope(splitScope, requiredScope);

            splitScope.RemoveAll(x => x.Equals(disallowedScope, StringComparison.OrdinalIgnoreCase));

            if (!shouldUseAuthorize && version == Constants.DefaultOptions.VERSION_MOBILECONNECTAUTHN)
            {
                splitScope.RemoveAll(x => x.Equals(Constants.Scope.AUTHN, StringComparison.OrdinalIgnoreCase));
            }

            return Scope.CreateScope(splitScope);
        }

        /// <inheritdoc/>
        public async Task<RequestTokenResponse> RequestTokenAsync(string clientId, string clientSecret, string requestTokenUrl, string redirectUrl, string code)
        {
            Validate.RejectNullOrEmpty(clientId, "clientId");
            Validate.RejectNullOrEmpty(clientSecret, "clientSecret");
            Validate.RejectNullOrEmpty(requestTokenUrl, "requestTokenUrl");
            Validate.RejectNullOrEmpty(redirectUrl, "redirectUrl");
            Validate.RejectNullOrEmpty(code, "code");

            try
            {
                var formData = new List<BasicKeyValuePair>()
                {
                    new BasicKeyValuePair(Constants.Parameters.AUTHENTICATION_REDIRECT_URI, redirectUrl),
                    new BasicKeyValuePair(Constants.Parameters.CODE, code),
                    new BasicKeyValuePair(Constants.Parameters.GRANT_TYPE, Constants.DefaultOptions.GRANT_TYPE)
                };

                RestResponse response = await _client.PostAsync(requestTokenUrl, RestAuthentication.Basic(clientId, clientSecret), formData, null, null);
                var tokenResponse = new RequestTokenResponse(response);

                return tokenResponse;
            }
            catch (Exception e) when (e is HttpRequestException || e is System.Net.WebException || e is TaskCanceledException)
            {
                Log.Error(() => $"Error occurred while requesting token url={requestTokenUrl}", e);
                throw new MobileConnectEndpointHttpException(e.Message, e);
            }
        }

        /// <inheritdoc/>
        public RequestTokenResponse RequestToken(string clientId, string clientSecret, string requestTokenUrl, string redirectUrl, string code)
        {
            return RequestTokenAsync(clientId, clientSecret, requestTokenUrl, redirectUrl, code).Result;
        }

        /// <inheritdoc/>
        public async Task<RequestTokenResponse> RefreshTokenAsync(string clientId, string clientSecret, string refreshTokenUrl, string refreshToken)
        {
            Validate.RejectNullOrEmpty(clientId, "clientId");
            Validate.RejectNullOrEmpty(clientSecret, "clientSecret");
            Validate.RejectNullOrEmpty(refreshTokenUrl, "refreshTokenUrl");
            Validate.RejectNullOrEmpty(refreshToken, "refreshToken");

            var formData = new List<BasicKeyValuePair>()
            {
                new BasicKeyValuePair(Constants.Parameters.REFRESH_TOKEN, refreshToken),
                new BasicKeyValuePair(Constants.Parameters.GRANT_TYPE, Constants.GrantTypes.REFRESH_TOKEN),
            };
            var authentication = RestAuthentication.Basic(clientId, clientSecret);

            RestResponse restResponse;
            try
            {
                restResponse = await _client.PostAsync(refreshTokenUrl, authentication, formData, null, null);
            }
            catch (Exception e) when (e is HttpRequestException || e is System.Net.WebException || e is TaskCanceledException)
            {
                Log.Error(() => $"Error occurred while refreshing token url={refreshTokenUrl}", e);
                throw new MobileConnectEndpointHttpException(e.Message, e);
            }

            return new RequestTokenResponse(restResponse);
        }

        /// <inheritdoc/>
        public RequestTokenResponse RefreshToken(string clientId, string clientSecret, string refreshTokenUrl, string refreshToken)
        {
            return RefreshTokenAsync(clientId, clientSecret, refreshTokenUrl, refreshToken).Result;
        }

        /// <inheritdoc/>
        public async Task<RevokeTokenResponse> RevokeTokenAsync(string clientId, string clientSecret, string revokeTokenUrl, string token, string tokenTypeHint)
        {
            Validate.RejectNullOrEmpty(clientId, "clientId");
            Validate.RejectNullOrEmpty(clientSecret, "clientSecret");
            Validate.RejectNullOrEmpty(revokeTokenUrl, "revokeTokenUrl");
            Validate.RejectNullOrEmpty(token, "token");

            var formData = new List<BasicKeyValuePair>()
            {
                new BasicKeyValuePair(Constants.Parameters.TOKEN, token)
            };

            if (tokenTypeHint != null)
            {
                formData.Add(new BasicKeyValuePair(Constants.Parameters.TOKEN_TYPE_HINT, tokenTypeHint));
            }

            var authentication = RestAuthentication.Basic(clientId, clientSecret);
            var restResponse = await _client.PostAsync(revokeTokenUrl, authentication, formData, null, null);
            return new RevokeTokenResponse(restResponse);
        }

        /// <inheritdoc/>
        public RevokeTokenResponse RevokeToken(string clientId, string clientSecret, string revokeTokenUrl, string token, string tokenTypeHint)
        {
            return RevokeTokenAsync(clientId, clientSecret, revokeTokenUrl, token, tokenTypeHint).Result;
        }

        /// <inheritdoc/>
        public TokenValidationResult ValidateTokenResponse(RequestTokenResponse tokenResponse, string clientId, string issuer, string nonce, int? maxAge, JWKeyset keyset, string version)
        {
            if (tokenResponse?.ResponseData == null)
            {
                Log.Warning(() => $"Token was incomplete from issuer={issuer}");
                return TokenValidationResult.IncompleteTokenResponse;
            }

            TokenValidationResult result = TokenValidation.ValidateAccessToken(tokenResponse.ResponseData);
            if (result != TokenValidationResult.Valid)
            {
                Log.Warning(() => $"Access token was invalid from issuer={issuer}");
                return result;
            }

            result = TokenValidation.ValidateIdToken(tokenResponse.ResponseData.IdToken, clientId, issuer, nonce, maxAge, keyset, version);
            if (result != TokenValidationResult.Valid)
            {
                Log.Warning(() => $"IDToken was invalid from issuer={issuer} for reason={result}");
            }

            return result;
        }

        /// <inheritdoc/>
        private List<BasicKeyValuePair> GetAuthenticationQueryParams(AuthenticationOptions options, bool useAuthorize, string version)
        {
            var authParameters = new List<BasicKeyValuePair>
            {
                new BasicKeyValuePair(Constants.Parameters.AUTHENTICATION_REDIRECT_URI, options.RedirectUrl),
                new BasicKeyValuePair(Constants.Parameters.CLIENT_ID, options.ClientId),
                new BasicKeyValuePair(Constants.Parameters.RESPONSE_TYPE, Constants.DefaultOptions.AUTHENTICATION_RESPONSE_TYPE),
                new BasicKeyValuePair(Constants.Parameters.SCOPE, options.Scope),
                new BasicKeyValuePair(Constants.Parameters.ACR_VALUES, options.AcrValues),
                new BasicKeyValuePair(Constants.Parameters.STATE, options.State),
                new BasicKeyValuePair(Constants.Parameters.NONCE, options.Nonce),
                new BasicKeyValuePair(Constants.Parameters.DISPLAY, options.Display),
                new BasicKeyValuePair(Constants.Parameters.PROMPT, options.Prompt),
                new BasicKeyValuePair(Constants.Parameters.MAX_AGE, options.MaxAge.ToString()),
                new BasicKeyValuePair(Constants.Parameters.UI_LOCALES, options.UiLocales),
                new BasicKeyValuePair(Constants.Parameters.CLAIMS_LOCALES, options.ClaimsLocales),
                new BasicKeyValuePair(Constants.Parameters.ID_TOKEN_HINT, options.IdTokenHint),
                new BasicKeyValuePair(Constants.Parameters.LOGIN_HINT, options.LoginHint),
                new BasicKeyValuePair(Constants.Parameters.DTBS, options.Dtbs),
                new BasicKeyValuePair(Constants.Parameters.CLAIMS, GetClaimsString(options)),
                new BasicKeyValuePair(Constants.Parameters.VERSION, version),
            };

            if (useAuthorize)
            {
                authParameters.Add(new BasicKeyValuePair(Constants.Parameters.CLIENT_NAME, options.ClientName));
                authParameters.Add(new BasicKeyValuePair(Constants.Parameters.CONTEXT, options.Context));
                authParameters.Add(new BasicKeyValuePair(Constants.Parameters.BINDING_MESSAGE, options.BindingMessage));
            }

            return authParameters;
        }

        private string GetClaimsString(AuthenticationOptions options)
        {
            if (!string.IsNullOrEmpty(options.ClaimsJson))
            {
                return options.ClaimsJson;
            }

            return options.Claims != null && !options.Claims.IsEmpty ? JsonConvert.SerializeObject(options.Claims, _jsonSettings) : null;
        }
    }
}
