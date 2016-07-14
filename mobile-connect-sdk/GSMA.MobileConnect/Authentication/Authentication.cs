using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GSMA.MobileConnect.Discovery;
using GSMA.MobileConnect.Utils;
using GSMA.MobileConnect.Exceptions;
using System.Net.Http;

namespace GSMA.MobileConnect.Authentication
{
    /// <summary>
    /// Concrete implementation of <see cref="IAuthentication"/>
    /// </summary>
    public class Authentication : IAuthentication
    {
        private readonly RestClient _client;

        /// <inheritdoc/>
        public Authentication(RestClient client)
        {
            this._client = client;
        }

        /// <inheritdoc/>
        public StartAuthenticationResponse StartAuthentication(string clientId, string authorizeUrl, string redirectUrl, string state, string nonce,
            string encryptedMSISDN, SupportedVersions versions, AuthenticationOptions options)
        {
            Validation.RejectNullOrEmpty(clientId, "clientId");
            Validation.RejectNullOrEmpty(authorizeUrl, "authorizeUrl");
            Validation.RejectNullOrEmpty(redirectUrl, "redirectUrl");
            Validation.RejectNullOrEmpty(state, "state");
            Validation.RejectNullOrEmpty(nonce, "nonce");

            options = options ?? new AuthenticationOptions();
            options.Scope = options.Scope ?? "";
            bool shouldUseAuthorize = ShouldUseAuthorize(options);

            if(shouldUseAuthorize)
            {
                Validation.RejectNullOrEmpty(options.Context, "options.Context");
                Validation.RejectNullOrEmpty(options.ClientName, "options.ClientName");
            }

            options.State = state;
            options.Nonce = nonce;
            options.LoginHint = options.LoginHint ?? (string.IsNullOrEmpty(encryptedMSISDN) ? null : string.Format("ENCR_MSISDN:{0}", encryptedMSISDN));
            options.RedirectUrl = redirectUrl;
            options.ClientId = clientId;

            options.Scope = CoerceAuthenticationScope(options.Scope, versions, shouldUseAuthorize);

            UriBuilder build = new UriBuilder(authorizeUrl);
            build.AddQueryParams(GetAuthenticationQueryParams(options, shouldUseAuthorize));

            return new StartAuthenticationResponse() { Url = build.Uri.AbsoluteUri };
        }

        private bool ShouldUseAuthorize(AuthenticationOptions options)
        {
            // If a mobile connect product is requested and it isn't authn then use authorize
            if (options.Scope.IndexOf(Constants.Scope.MCPREFIX, StringComparison.OrdinalIgnoreCase) > -1 
                && options.Scope.IndexOf(Constants.Scope.AUTHN, StringComparison.OrdinalIgnoreCase) == -1)
            {
                return true;
            }

            // If context is passed then use authorize
            if(!string.IsNullOrEmpty(options.Context))
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
        /// <returns>Returns a modified scope value with mc_authn removed or added</returns>
        private string CoerceAuthenticationScope(string scopeRequested, SupportedVersions versions, bool shouldUseAuthorize)
        {
            var requiredScope = shouldUseAuthorize ? MobileConnectConstants.MOBILECONNECTAUTHORIZATION : MobileConnectConstants.MOBILECONNECTAUTHENTICATION;
            var disallowedScope = shouldUseAuthorize ? Constants.Scope.AUTHN : Constants.Scope.AUTHZ;

            versions = versions ?? new SupportedVersions(null);
            string version = versions.GetSupportedVersion(requiredScope);

            var splitScope = scopeRequested.Split().ToList();
            splitScope = Scope.CoerceOpenIdScope(splitScope, requiredScope);

            splitScope.RemoveAll(x => x.Equals(disallowedScope, StringComparison.OrdinalIgnoreCase));

            if(!shouldUseAuthorize && version == Constants.DefaultOptions.VERSION_MOBILECONNECTAUTHN)
            {
                splitScope.RemoveAll(x => x.Equals(Constants.Scope.AUTHN, StringComparison.OrdinalIgnoreCase));
            }

            return Scope.CreateScope(splitScope);
        }

        /// <inheritdoc/>
        public async Task<RequestTokenResponse> RequestTokenAsync(string clientId, string clientSecret, string requestTokenUrl, string redirectUrl, string code)
        {
            Validation.RejectNullOrEmpty(clientId, "clientId");
            Validation.RejectNullOrEmpty(clientSecret, "clientSecret");
            Validation.RejectNullOrEmpty(requestTokenUrl, "requestTokenUrl");
            Validation.RejectNullOrEmpty(redirectUrl, "redirectUrl");
            Validation.RejectNullOrEmpty(code, "code");

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
                throw new MobileConnectEndpointHttpException(e.Message, e);
            }
        }

        /// <inheritdoc/>
        public RequestTokenResponse RequestToken(string clientId, string clientSecret, string requestTokenUrl, string redirectUrl, string code)
        {
            return RequestTokenAsync(clientId, clientSecret, requestTokenUrl, redirectUrl, code).Result;
        }

        /// <inheritdoc/>
        private List<BasicKeyValuePair> GetAuthenticationQueryParams(AuthenticationOptions options, bool useAuthorize)
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
            };

            if(useAuthorize)
            {
                authParameters.Add(new BasicKeyValuePair(Constants.Parameters.CLIENT_NAME, options.ClientName));
                authParameters.Add(new BasicKeyValuePair(Constants.Parameters.CONTEXT, options.Context));
                authParameters.Add(new BasicKeyValuePair(Constants.Parameters.BINDING_MESSAGE, options.BindingMessage));
            }

            return authParameters;
        }
    }
}
