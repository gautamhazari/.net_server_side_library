using GSMA.MobileConnect.Authentication;
using GSMA.MobileConnect.Cache;
using GSMA.MobileConnect.Discovery;
using GSMA.MobileConnect.Identity;
using GSMA.MobileConnect.Utils;
using System;
using System.Threading.Tasks;

namespace GSMA.MobileConnect
{
    /// <summary>
    /// Convenience wrapper for <see cref="IDiscoveryService"/> and <see cref="IAuthenticationService"/> methods for use with non-web .Net targets
    /// </summary>
    /// <seealso cref="MobileConnectWebInterface"/>
    /// <seealso cref="MobileConnectStatus"/>
    /// <seealso cref="MobileConnectConfig"/>
    public class MobileConnectInterface
    {
        private readonly IDiscoveryService _discovery;
        private readonly IAuthenticationService _authentication;
        private readonly IIdentityService _identity;
        private readonly IJWKeysetService _jwks;
        private readonly MobileConnectConfig _config;

        /// <summary>
        /// Initializes a new instance of the MobileConnectInterface class
        /// </summary>
        /// <param name="config">Configuration options</param>
        /// <param name="discovery">Instance of IDiscovery concrete implementation</param>
        /// <param name="authentication">Instance of IAuthentication concrete implementation</param>
        /// <param name="identity">Instance of IIdentityService concrete implementation</param>
        /// <param name="jwks">Instance of IJWKeysetService concrete implementation</param>
        public MobileConnectInterface(MobileConnectConfig config, IDiscoveryService discovery, IAuthenticationService authentication, IIdentityService identity, IJWKeysetService jwks)
        {
            this._discovery = discovery;
            this._authentication = authentication;
            this._identity = identity;
            this._jwks = jwks;
            this._config = config;
        }

        /// <summary>
        /// Initializes a new instance of the MobileConnectInterface class using default concrete implementations
        /// </summary>
        /// <param name="config">Configuration options</param>
        /// <param name="cache">Concrete implementation of ICache</param>
        public MobileConnectInterface(MobileConnectConfig config, ICache cache)
            : this(config, cache, new RestClient()) { }

        /// <summary>
        /// Initializes a new instance of the MobileConnectInterface class using default concrete implementations
        /// </summary>
        /// <param name="config">Configuration options</param>
        /// <param name="cache">Concrete implementation of ICache</param>
        /// <param name="client">Restclient for all http requests. Will default if null.</param>
        public MobileConnectInterface(MobileConnectConfig config, ICache cache, RestClient client)
            : this(config, new DiscoveryService(cache, client), new AuthenticationService(client), new IdentityService(client), new JWKeysetService(client, cache)) { }

        /// <summary>
        /// R1 supporting constructor, identity and jwks services will be defaulted
        /// </summary>
        /// <param name="discovery">Instance of IDiscovery concrete implementation</param>
        /// <param name="authentication">Instance of IAuthentication concrete implementation</param>
        /// <param name="config">Configuration options</param>
        [Obsolete("Constructor will be removed in v3")]
        public MobileConnectInterface(IDiscoveryService discovery, IAuthenticationService authentication, MobileConnectConfig config)
        {
            var cache = discovery.Cache;
            var client = new Utils.RestClient();
            this._discovery = discovery;
            this._authentication = authentication;
            this._identity = new IdentityService(client);
            this._jwks = new JWKeysetService(client, cache);
            this._config = config;
        }

        /// <summary>
        /// Attempt discovery using the supplied parameters. If msisdn, mcc and mnc are null the result will be operator selection, otherwise valid parameters will result in a StartAuthorization status
        /// </summary>
        /// <param name="msisdn">MSISDN from user</param>
        /// <param name="mcc">Mobile Country Code</param>
        /// <param name="mnc">Mobile Network Code</param>
        /// <param name="options">Optional parameters</param>
        /// <returns>MobileConnectStatus object with required information for continuing the mobileconnect process</returns>
        public async Task<MobileConnectStatus> AttemptDiscoveryAsync(string msisdn, string mcc, string mnc, MobileConnectRequestOptions options)
        {
            return await MobileConnectInterfaceHelper.AttemptDiscovery(_discovery, msisdn, mcc, mnc, null, _config, options);
        }

        /// <summary>
        /// Allows an application to create discovery object manually without call to discovery service
        /// </summary>
        /// <param name="clientId">Client id</param>
        /// <param name="clientSecret">Client secret</param>
        /// <param name="subscriberId">Subscriber id</param>
        /// <param name="appName">Application name</param>
        /// <param name="operatorsUrls">Operators url</param>
        /// <returns>Manually generated discovery response</returns>
        public async Task<DiscoveryResponse> GenerateDiscoveryManuallyAsync(string clientId, string clientSecret, string subscriberId,
            string appName, OperatorUrls operatorsUrls)
        {
            return await _authentication.MakeDiscoveryForAuthorization(clientId, clientSecret, subscriberId, appName,
                operatorsUrls);
        }

        /// <summary>
        /// Attempt manually discovery using the supplied parameters.
        /// </summary>
        /// <param name="response">Discovery response</param>
        /// <returns></returns>
        public MobileConnectStatus AttemptManuallyDiscovery(DiscoveryResponse response)
        {

            return MobileConnectInterfaceHelper.GenerateStatusFromDiscoveryResponse(_discovery, response);
        }

        /// <summary>
        /// Synchronous wrapper for <see cref="MobileConnectInterface.AttemptDiscoveryAsync(string, string, string, MobileConnectRequestOptions)"/>
        /// </summary>
        /// <param name="msisdn">MSISDN from user</param>
        /// <param name="mcc">Mobile Country Code</param>
        /// <param name="mnc">Mobile Network Code</param>
        /// <param name="options">Optional parameters</param>
        /// <returns>MobileConnectStatus object with required information for continuing the mobileconnect process</returns>
        public MobileConnectStatus AttemptDiscovery(string msisdn, string mcc, string mnc, MobileConnectRequestOptions options)
        {
            return AttemptDiscoveryAsync(msisdn, mcc, mnc, options).Result;
        }


        /// <summary>
        /// Attempt discovery using the values returned from the operator selection redirect
        /// </summary>
        /// <param name="redirectedUrl">Uri redirected to by the completion of the operator selection UI</param>
        /// <returns>MobileConnectStatus object with required information for continuing the mobileconnect process</returns>
        public async Task<MobileConnectStatus> AttemptDiscoveryAfterOperatorSelectionAsync(Uri redirectedUrl)
        {
            return await MobileConnectInterfaceHelper.AttemptDiscoveryAfterOperatorSelection(_discovery, redirectedUrl, _config);
        }

        /// <summary>
        /// Synchronous wrapper for <see cref="MobileConnectInterface.AttemptDiscoveryAfterOperatorSelectionAsync(Uri)"/>
        /// </summary>
        /// <param name="redirectedUrl">Uri redirected to by the completion of the operator selection UI</param>
        /// <returns>MobileConnectStatus object with required information for continuing the mobileconnect process</returns>
        public MobileConnectStatus AttemptDiscoveryAfterOperatorSelection(Uri redirectedUrl)
        {
            return AttemptDiscoveryAfterOperatorSelectionAsync(redirectedUrl).Result;
        }

        /// <summary>
        /// Creates an authorization url with parameters to begin the authorization process
        /// </summary>
        /// <param name="discoveryResponse">The response returned by the discovery process</param>
        /// <param name="encryptedMSISDN">Encrypted MSISDN/Subscriber Id returned from the Discovery process</param>
        /// <param name="state">Unique state value, this will be returned by the authorization process and should be checked for equality as a security measure</param>
        /// <param name="nonce">Unique value to associate a client session with an id token</param>
        /// <param name="options">Optional parameters</param>
        /// <returns>MobileConnectStatus object with required information for continuing the mobileconnect process</returns>
        public MobileConnectStatus StartAuthentication(DiscoveryResponse discoveryResponse, string encryptedMSISDN, string state, string nonce, MobileConnectRequestOptions options)
        {
            return MobileConnectInterfaceHelper.StartAuthentication(_authentication, discoveryResponse, encryptedMSISDN, state, nonce, _config, options);
        }

        /// <summary>
        /// Request token using the values returned from the authorization redirect
        /// </summary>
        /// <param name="discoveryResponse">The response returned by the discovery process</param>
        /// <param name="redirectedUrl">Uri redirected to by the completion of the authorization UI</param>
        /// <param name="expectedState">The state value returned from the StartAuthorization call should be passed here, it will be used to validate the authenticity of the authorization process</param>
        /// <param name="expectedNonce">The nonce value returned from the StartAuthorization call should be passed here, it will be used to ensure the token was not requested using a replay attack</param>
        /// <param name="options">Optional parameters</param>
        /// <returns>MobileConnectStatus object with required information for continuing the mobileconnect process</returns>
        public async Task<MobileConnectStatus> RequestTokenAsync(DiscoveryResponse discoveryResponse, Uri redirectedUrl, string expectedState, string expectedNonce, MobileConnectRequestOptions options)
        {
            return await MobileConnectInterfaceHelper.RequestToken(_authentication, _jwks, discoveryResponse, redirectedUrl, expectedState, expectedNonce, _config, options);
        }

        /// <summary>
        /// Synchronous wrapper for <see cref="MobileConnectInterface.RequestTokenAsync(DiscoveryResponse, Uri, string, string, MobileConnectRequestOptions)"/>
        /// </summary>
        /// <param name="discoveryResponse">The response returned by the discovery process</param>
        /// <param name="redirectedUrl">Uri redirected to by the completion of the authorization UI</param>
        /// <param name="expectedState">The state value returned from the StartAuthorization call should be passed here, it will be used to validate the authenticity of the authorization process</param>
        /// <param name="expectedNonce">The nonce value returned from the StartAuthorization call should be passed here, it will be used to ensure the token was not requested using a replay attack</param>
        /// <param name="options">Optional parameters</param>
        /// <returns>MobileConnectStatus object with required information for continuing the mobileconnect process</returns>
        public MobileConnectStatus RequestToken(DiscoveryResponse discoveryResponse, Uri redirectedUrl, string expectedState, string expectedNonce, MobileConnectRequestOptions options)
        {
            return MobileConnectInterfaceHelper.RequestToken(_authentication, _jwks, discoveryResponse, redirectedUrl, expectedState, expectedNonce, _config, options).Result;
        }

        /// <summary>
        /// Refresh token using using the refresh token provided in the RequestToken response
        /// </summary>
        /// <param name="refreshToken">Refresh token returned from RefreshToken request</param>
        /// <param name="discoveryResponse">The response returned by the discovery process</param>
        /// <returns>Object with required information for continuing the mobile connect process</returns>
        public async Task<MobileConnectStatus> RefreshTokenAsync(string refreshToken, DiscoveryResponse discoveryResponse)
        {
            return await MobileConnectInterfaceHelper.RefreshToken(_authentication, refreshToken, discoveryResponse, _config);
        }

        /// <summary>
        /// Synchronous wrapper for <see cref="RefreshTokenAsync(string, DiscoveryResponse)"/>
        /// </summary>
        /// <param name="refreshToken">Refresh token returned from RefreshToken request</param>
        /// <param name="discoveryResponse">The response returned by the discovery process</param>
        /// <returns>Object with required information for continuing the mobile connect process</returns>
        public MobileConnectStatus RefreshToken(string refreshToken, DiscoveryResponse discoveryResponse)
        {
            return MobileConnectInterfaceHelper.RefreshToken(_authentication, refreshToken, discoveryResponse, _config).Result;
        }

        /// <summary>
        /// Revoke token using using the access / refresh token provided in the RequestToken response
        /// </summary>
        /// <param name="token">Access/Refresh token returned from RequestToken request</param>
        /// <param name="tokenTypeHint">Hint to indicate the type of token being passed in</param>
        /// <param name="discoveryResponse">The response returned by the discovery process</param>
        /// <returns>Object with required information for continuing the mobile connect process</returns>
        public async Task<MobileConnectStatus> RevokeTokenAsync(string token, string tokenTypeHint, DiscoveryResponse discoveryResponse)
        {
            return await MobileConnectInterfaceHelper.RevokeToken(_authentication, token, tokenTypeHint, discoveryResponse, _config);
        }

        /// <summary>
        /// Synchronous wrapper for <see cref="RevokeTokenAsync(string, string, DiscoveryResponse)"/>
        /// </summary>
        /// <param name="token">Access/Refresh token returned from RequestToken request</param>
        /// <param name="tokenTypeHint">Hint to indicate the type of token being passed in</param>
        /// <param name="discoveryResponse">The response returned by the discovery process</param>
        /// <returns>Object with required information for continuing the mobile connect process</returns>
        public MobileConnectStatus RevokeToken(string token, string tokenTypeHint, DiscoveryResponse discoveryResponse)
        {
            return MobileConnectInterfaceHelper.RevokeToken(_authentication, token, tokenTypeHint, discoveryResponse, _config).Result;
        }

        /// <summary>
        /// Handles continuation of the process following a completed redirect. 
        /// Only the redirectedUrl is required, however if the redirect being handled is the result of calling the Authorization URL then the remaining parameters are required.
        /// </summary>
        /// <param name="redirectedUrl">Url redirected to by the completion of the previous step</param>
        /// <param name="discoveryResponse">The response returned by the discovery process</param>
        /// <param name="expectedState">The state value returned from the StartAuthorization call should be passed here, it will be used to validate the authenticity of the authorization process</param>
        /// <param name="expectedNonce">The nonce value returned from the StartAuthorization call should be passed here, it will be used to ensure the token was not requested using a replay attack</param>
        /// <param name="options">Optional parameters</param>
        /// <returns>MobileConnectStatus object with required information for continuing the mobileconnect process</returns>
        public async Task<MobileConnectStatus> HandleUrlRedirectAsync(Uri redirectedUrl, DiscoveryResponse discoveryResponse = null, string expectedState = null, string expectedNonce = null, MobileConnectRequestOptions options = null)
        {
            return await MobileConnectInterfaceHelper.HandleUrlRedirect(_discovery, _authentication, _jwks, redirectedUrl, discoveryResponse, expectedState, expectedNonce, _config, options);
        }

        /// <summary>
        /// Synchronous wrapper for <see cref="MobileConnectInterface.HandleUrlRedirectAsync(Uri, DiscoveryResponse, string, string, MobileConnectRequestOptions)"/>
        /// </summary>
        /// <param name="redirectedUrl">Url redirected to by the completion of the previous step</param>
        /// <param name="discoveryResponse">The response returned by the discovery process</param>
        /// <param name="expectedState">The state value returned from the StartAuthorization call should be passed here, it will be used to validate the authenticity of the authorization process</param>
        /// <param name="expectedNonce">The nonce value returned from the StartAuthorization call should be passed here, it will be used to ensure the token was not requested using a replay attack</param>
        /// <param name="options">Optional parameters</param>
        /// <returns>MobileConnectStatus object with required information for continuing the mobileconnect process</returns>
        public MobileConnectStatus HandleUrlRedirect(Uri redirectedUrl, DiscoveryResponse discoveryResponse = null, string expectedState = null, string expectedNonce = null, MobileConnectRequestOptions options = null)
        {
            return MobileConnectInterfaceHelper.HandleUrlRedirect(_discovery, _authentication, _jwks, redirectedUrl, discoveryResponse, expectedState, expectedNonce, _config, options).Result;
        }

        /// <summary>
        /// Request user info using the access token returned by <see cref="RequestTokenAsync(DiscoveryResponse, Uri, string, string, MobileConnectRequestOptions)"/>
        /// </summary>
        /// <param name="discoveryResponse">The response returned by the discovery process</param>
        /// <param name="accessToken">Access token from RequestToken stage</param>
        /// <param name="options">Additional optional parameters</param>
        /// <returns>MobileConnectStatus object with UserInfo information</returns>
        public async Task<MobileConnectStatus> RequestUserInfoAsync(DiscoveryResponse discoveryResponse, string accessToken, MobileConnectRequestOptions options)
        {
            return await MobileConnectInterfaceHelper.RequestUserInfo(_identity, discoveryResponse, accessToken, _config, options);
        }

        /// <summary>
        /// Syncronous wrapper for <see cref="RequestUserInfoAsync(DiscoveryResponse, string, MobileConnectRequestOptions)"/>
        /// </summary>
        /// <param name="discoveryResponse">The response returned by the discovery process</param>
        /// <param name="accessToken">Access token from RequestToken stage</param>
        /// <param name="options">Additional optional parameters</param>
        /// <returns>MobileConnectStatus object with UserInfo information</returns>
        public MobileConnectStatus RequestUserInfo(DiscoveryResponse discoveryResponse, string accessToken, MobileConnectRequestOptions options)
        {
            return MobileConnectInterfaceHelper.RequestUserInfo(_identity, discoveryResponse, accessToken, _config, options).Result;
        }

        /// <summary>
        /// Request user info using the access token returned by <see cref="RequestTokenAsync(DiscoveryResponse, Uri, string, string, MobileConnectRequestOptions)"/>
        /// </summary>
        /// <param name="discoveryResponse">The response returned by the discovery process</param>
        /// <param name="accessToken">Access token from RequestToken stage</param>
        /// <param name="options">Additional optional parameters</param>
        /// <returns>MobileConnectStatus object with UserInfo information</returns>
        public async Task<MobileConnectStatus> RequestIdentityAsync(DiscoveryResponse discoveryResponse, string accessToken, MobileConnectRequestOptions options)
        {
            return await MobileConnectInterfaceHelper.RequestIdentity(_identity, discoveryResponse, accessToken, _config, options);
        }

        /// <summary>
        /// Syncronous wrapper for <see cref="RequestIdentityAsync(DiscoveryResponse, string, MobileConnectRequestOptions)"/>
        /// </summary>
        /// <param name="discoveryResponse">The response returned by the discovery process</param>
        /// <param name="accessToken">Access token from RequestToken stage</param>
        /// <param name="options">Additional optional parameters</param>
        /// <returns>MobileConnectStatus object with UserInfo information</returns>
        public MobileConnectStatus RequestIdentity(DiscoveryResponse discoveryResponse, string accessToken, MobileConnectRequestOptions options)
        {
            return MobileConnectInterfaceHelper.RequestIdentity(_identity, discoveryResponse, accessToken, _config, options).Result;
        }
    }
}
