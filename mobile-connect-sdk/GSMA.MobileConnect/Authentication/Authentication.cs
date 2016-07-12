using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            string encryptedMSISDN, string supportedVersion, AuthenticationOptions options)
        {
            Validation.RejectNullOrEmpty(clientId, "clientId");
            Validation.RejectNullOrEmpty(authorizeUrl, "authorizeUrl");
            Validation.RejectNullOrEmpty(redirectUrl, "redirectUrl");
            Validation.RejectNullOrEmpty(state, "state");
            Validation.RejectNullOrEmpty(nonce, "nonce");

            options = options ?? new AuthenticationOptions();
            options.Scope = CoerceAuthenticationScope(options.Scope, supportedVersion);
            options.State = state;
            options.Nonce = nonce;
            options.LoginHint = options.LoginHint ?? (string.IsNullOrEmpty(encryptedMSISDN) ? null : string.Format("ENCR_MSISDN:{0}", encryptedMSISDN));
            options.RedirectUrl = redirectUrl;
            options.ClientId = clientId;

            UriBuilder build = new UriBuilder(authorizeUrl);
            build.AddQueryParams(GetAuthenticationQueryParams(options));

            return new StartAuthenticationResponse() { Url = build.Uri.AbsoluteUri };
        }

        /// <summary>
        /// Returns a modified scope value based on the version required. Depending on the version the value mc_authn may be added or removed
        /// </summary>
        /// <param name="scopeRequested">Request scope value</param>
        /// <param name="version">Version of the mobileconnect service being called</param>
        /// <returns>Returns a modified scope value with mc_authn removed or added</returns>
        private string CoerceAuthenticationScope(string scopeRequested, string version)
        {
            version = MobileConnectVersions.CoerceVersion(version, MobileConnectConstants.MOBILECONNECTAUTHENTICATION);

            if (string.IsNullOrEmpty(version) || version == Constants.DefaultOptions.VERSION_MOBILECONNECTAUTHN)
            {
                // remove mc_authn if it exists in the scope
                return scopeRequested.IndexOf(Constants.Scope.AUTHN, StringComparison.OrdinalIgnoreCase) < 0 ? Scope.CoerceOpenIdScope(scopeRequested, MobileConnectConstants.MOBILECONNECT) : 
                    scopeRequested.RemoveFromDelimitedString(Constants.Scope.AUTHN, StringComparison.OrdinalIgnoreCase);
            }

            // add mc_authn if it doesn't already exist
            return Scope.CoerceOpenIdScope(scopeRequested, MobileConnectConstants.MOBILECONNECTAUTHENTICATION);
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
        private List<BasicKeyValuePair> GetAuthenticationQueryParams(AuthenticationOptions options)
        {
            return new List<BasicKeyValuePair>
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
        }
    }
}
