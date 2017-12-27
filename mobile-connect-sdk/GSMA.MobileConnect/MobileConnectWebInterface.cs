using GSMA.MobileConnect.Authentication;
using GSMA.MobileConnect.Cache;
using GSMA.MobileConnect.Constants;
using GSMA.MobileConnect.Discovery;
using GSMA.MobileConnect.Identity;
using GSMA.MobileConnect.Utils;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace GSMA.MobileConnect
{
    /// <summary>
    /// Convenience wrapper for <see cref="IDiscoveryService"/> and <see cref="IAuthenticationService"/> methods for use with ASP.NET
    /// </summary>
    /// <seealso cref="MobileConnectInterface"/>
    /// <seealso cref="MobileConnectStatus"/>
    /// <seealso cref="MobileConnectConfig"/>
    /// <seealso cref="Web.ResponseConverter"/>
    public class MobileConnectWebInterface
    {
        private readonly IDiscoveryService _discovery;
        private readonly IAuthenticationService _authentication;
        private readonly IIdentityService _identity;
        private readonly IJWKeysetService _jwks;
        private readonly MobileConnectConfig _config;
        private readonly bool _cacheWithSessionId;

        /// <summary>
        /// Initializes a new instance of the MobileConnectWebInterface class
        /// </summary>
        /// <param name="discovery">Instance of IDiscovery concrete implementation</param>
        /// <param name="authentication">Instance of IAuthentication concrete implementation</param>
        /// <param name="identity">Instance of IIdentityService concrete implementation</param>
        /// <param name="jwks">Instance of IJWKeysetService concrete implementation</param>
        /// <param name="config">Configuration options</param>
        public MobileConnectWebInterface(IDiscoveryService discovery, IAuthenticationService authentication, IIdentityService identity, IJWKeysetService jwks, MobileConnectConfig config)
        {
            this._discovery = discovery;
            this._authentication = authentication;
            this._identity = identity;
            this._jwks = jwks;
            this._config = config;
            this._cacheWithSessionId = config.CacheResponsesWithSessionId && discovery.Cache != null;

            Log.Debug(() => _cacheWithSessionId ? $"MobileConnectWebInterface caching enabled with type={discovery.Cache.GetType().AssemblyQualifiedName}" : "MobileConnectWebInterface caching disabled");
        }

        /// <summary>
        /// Initializes a new instance of the MobileConnectWebInterface class using default concrete implementations
        /// </summary>
        /// <param name="config">Configuration options</param>
        /// <param name="cache">Concrete implementation of ICache</param>
        public MobileConnectWebInterface(MobileConnectConfig config, ICache cache)
            : this(config, cache, new RestClient()) { }

        /// <summary>
        /// Initializes a new instance of the MobileConnectWebInterface class using default concrete implementations
        /// </summary>
        /// <param name="config">Configuration options</param>
        /// <param name="cache">Concrete implementation of ICache</param>
        /// <param name="client">Restclient for all http requests. Will default if null.</param>
        public MobileConnectWebInterface(MobileConnectConfig config, ICache cache, RestClient client)
            : this(new DiscoveryService(cache, client), new AuthenticationService(client), new IdentityService(client), new JWKeysetService(client, cache), config) { }

        /// <summary>
        /// R1 supporting constructor, identity and jwks services will be defaulted
        /// </summary>
        /// <param name="discovery">Instance of IDiscovery concrete implementation</param>
        /// <param name="authentication">Instance of IAuthentication concrete implementation</param>
        /// <param name="config">Configuration options</param>
        [Obsolete("Constructor will be removed in v3")]
        public MobileConnectWebInterface(IDiscoveryService discovery, IAuthenticationService authentication, MobileConnectConfig config)
        {
            var cache = discovery.Cache;
            var client = new Utils.RestClient();
            this._discovery = discovery;
            this._authentication = authentication;
            this._identity = new IdentityService(client);
            this._jwks = new JWKeysetService(client, cache);
            this._config = config;
            this._cacheWithSessionId = config.CacheResponsesWithSessionId && _discovery.Cache != null;

            Log.Debug(() => _cacheWithSessionId ? $"MobileConnectWebInterface caching enabled with type={cache.GetType().AssemblyQualifiedName}" : "MobileConnectWebInterface caching disabled");
        }

        /// <summary>
        /// Attempt discovery using the supplied parameters. If msisdn, mcc and mnc are null the result will be operator selection, otherwise valid parameters will result in a StartAuthorization status
        /// </summary>
        /// <param name="request">Originating web request</param>
        /// <param name="msisdn">MSISDN from user</param>
        /// <param name="mcc">Mobile Country Code</param>
        /// <param name="mnc">Mobile Network Code</param>
        /// <param name="shouldProxyCookies">If cookies from the original request should be sent onto the discovery service</param>
        /// <param name="includeRequestIp">Including of remote ip address</param>
        /// <param name="options">Optional parameters</param>
        /// <returns>MobileConnectStatus object with required information for continuing the mobileconnect process</returns>
        public async Task<MobileConnectStatus> AttemptDiscoveryAsync(HttpRequestMessage request, string msisdn, string mcc, string mnc, bool shouldProxyCookies, bool includeRequestIp, MobileConnectRequestOptions options)
        {
            options.ClientIP = includeRequestIp ? HttpUtils.GetClientIp(request) : null;

            var cookies = shouldProxyCookies ? request.GetCookies() : null;

            return await CacheIfRequired(await MobileConnectInterfaceHelper.AttemptDiscovery(_discovery, msisdn, mcc, mnc, cookies, _config, options));
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
        public async Task<DiscoveryResponse> GenerateDiscoveryManually(string clientId, string clientSecret, string subscriberId,
            string appName, OperatorUrls operatorsUrls)
        {
            return await _authentication.MakeDiscoveryForAuthorization(clientId, clientSecret, subscriberId, appName,
                operatorsUrls);
        }

        /// <summary>
        /// Generate Status From Discovery Response
        /// </summary>
        /// <param name="discoveryResponse"></param>
        /// <returns></returns>
        public async Task<MobileConnectStatus> GenerateStatusFromDiscoveryResponse(DiscoveryResponse discoveryResponse)
        {
            return await CacheIfRequired(MobileConnectInterfaceHelper.GenerateStatusFromDiscoveryResponse(_discovery, discoveryResponse));
        }

        /// <summary>
        /// Attempt discovery using the values returned from the operator selection redirect
        /// </summary>
        /// <param name="request">Originating web request</param>
        /// <param name="redirectedUrl">Uri redirected to by the completion of the operator selection UI</param>
        /// <returns>MobileConnectStatus object with required information for continuing the mobileconnect process</returns>
        public async Task<MobileConnectStatus> AttemptDiscoveryAfterOperatorSelectionAsync(HttpRequestMessage request, Uri redirectedUrl)
        {
            return await CacheIfRequired(await MobileConnectInterfaceHelper.AttemptDiscoveryAfterOperatorSelection(_discovery, redirectedUrl, _config));
        }

        /// <summary>
        /// Creates an authorization url with parameters to begin the authetication process
        /// </summary>
        /// <param name="request">Originating web request</param>
        /// <param name="discoveryResponse">The response returned by the discovery process</param>
        /// <param name="encryptedMSISDN">Encrypted MSISDN/Subscriber Id returned from the Discovery process</param>
        /// <param name="state">Unique string to be used to prevent Cross Site Forgery Request attacks during request token process (defaults to guid if not supplied, value will be returned in MobileConnectStatus object)</param>
        /// <param name="nonce">Unique string to be used to prevent replay attacks during request token process (defaults to guid if not supplied, value will be returned in MobileConnectStatus object)</param>
        /// <param name="options">Optional parameters</param>
        /// <returns>MobileConnectStatus object with required information for continuing the mobileconnect process</returns>
        public MobileConnectStatus StartAuthentication(HttpRequestMessage request, DiscoveryResponse discoveryResponse, string encryptedMSISDN, string state, string nonce, MobileConnectRequestOptions options)
        {
            state = string.IsNullOrEmpty(state) ? Security.GenerateSecureNonce() : state;
            nonce = string.IsNullOrEmpty(nonce) ? Security.GenerateSecureNonce() : nonce;

            return MobileConnectInterfaceHelper.StartAuthentication(_authentication, discoveryResponse, encryptedMSISDN, state, nonce, _config, options);
        }

        /// <summary>
        /// Creates an authorization url with parameters to begin the authetication process, the SDKSession id is used to fetch the discovery response
        /// </summary>
        /// <param name="request">Originating web request</param>
        /// <param name="sdkSession">SDKSession id used to fetch the discovery response with additional parameters that are required to generate the url</param>
        /// <param name="encryptedMSISDN">Encrypted MSISDN/Subscriber Id returned from the Discovery process</param>
        /// <param name="state">Unique string to be used to prevent Cross Site Forgery Request attacks during request token process (defaults to guid if not supplied, value will be returned in MobileConnectStatus object)</param>
        /// <param name="nonce">Unique string to be used to prevent replay attacks during request token process (defaults to guid if not supplied, value will be returned in MobileConnectStatus object)</param>
        /// <param name="options">Optional parameters</param>
        /// <returns>MobileConnectStatus object with required information for continuing the mobileconnect process</returns>
        public async Task<MobileConnectStatus> StartAuthentication(HttpRequestMessage request, string sdkSession, string encryptedMSISDN, string state, string nonce, MobileConnectRequestOptions options)
        {
            var discoveryResponse = await GetSessionFromCache(sdkSession);

            if (discoveryResponse == null)
            {
                return GetCacheError();
            }

            return StartAuthentication(request, discoveryResponse, encryptedMSISDN, state, nonce, options);
        }

        /// <summary>
        /// Performs headless authentication followed by request token if successful. Tokens will be validated before being returned.
        /// This may be a long running method as it waits for the authenticating user to respond using their authenticating device.
        /// </summary>
        /// <param name="request">Originating web request</param>
        /// <param name="discoveryResponse">The response returned by the discovery process</param>
        /// <param name="encryptedMSISDN">Encrypted MSISDN/Subscriber Id returned from the Discovery process</param>
        /// <param name="state">Unique string to be used to prevent Cross Site Forgery Request attacks during request token process (defaults to guid if not supplied, value will be returned in MobileConnectStatus object)</param>
        /// <param name="nonce">Unique string to be used to prevent replay attacks during request token process (defaults to guid if not supplied, value will be returned in MobileConnectStatus object)</param>
        /// <param name="options">Optional parameters</param>
        /// <param name="cancellationToken">Cancellation token that can be used to cancel long running requests</param>
        /// <returns>MobileConnectStatus object with required information for continuing the mobileconnect process</returns>
        public async Task<MobileConnectStatus> RequestHeadlessAuthenticationAsync(HttpRequestMessage request, DiscoveryResponse discoveryResponse, string encryptedMSISDN, string state, string nonce, 
            MobileConnectRequestOptions options, CancellationToken cancellationToken = default(CancellationToken))
        {
            state = string.IsNullOrEmpty(state) ? Security.GenerateSecureNonce() : state;
            nonce = string.IsNullOrEmpty(nonce) ? Security.GenerateSecureNonce() : nonce;

            return await MobileConnectInterfaceHelper.RequestHeadlessAuthentication(_authentication, _jwks, _identity, discoveryResponse, encryptedMSISDN, state, nonce, _config, options, cancellationToken);
        }

        /// <summary>
        /// Performs headless authentication followed by request token if successful. Tokens will be validated before being returned.
        /// This may be a long running method as it waits for the authenticating user to respond using their authenticating device.
        /// </summary>
        /// <param name="request">Originating web request</param>
        /// <param name="sdkSession">SDKSession id used to fetch the discovery response with additional parameters that are required to generate the url</param>
        /// <param name="encryptedMSISDN">Encrypted MSISDN/Subscriber Id returned from the Discovery process</param>
        /// <param name="state">Unique string to be used to prevent Cross Site Forgery Request attacks during request token process (defaults to guid if not supplied, value will be returned in MobileConnectStatus object)</param>
        /// <param name="nonce">Unique string to be used to prevent replay attacks during request token process (defaults to guid if not supplied, value will be returned in MobileConnectStatus object)</param>
        /// <param name="options">Optional parameters</param>
        /// <param name="cancellationToken">Cancellation token that can be used to cancel long running requests</param>
        /// <returns>MobileConnectStatus object with required information for continuing the mobileconnect process</returns>
        public async Task<MobileConnectStatus> RequestHeadlessAuthenticationAsync(HttpRequestMessage request, string sdkSession, string encryptedMSISDN, string state, string nonce, 
            MobileConnectRequestOptions options, CancellationToken cancellationToken = default(CancellationToken))
        {
            var discoveryResponse = await GetSessionFromCache(sdkSession);

            if (discoveryResponse == null)
            {
                return GetCacheError();
            }

            return await RequestHeadlessAuthenticationAsync(request, discoveryResponse, encryptedMSISDN, state, nonce, options, cancellationToken);
        }

        /// <summary>
        /// Request token using the values returned from the authorization redirect
        /// </summary>
        /// <param name="request">Originating web request</param>
        /// <param name="discoveryResponse">The response returned by the discovery process</param>
        /// <param name="redirectedUrl">Uri redirected to by the completion of the authorization UI</param>
        /// <param name="expectedState">The state value returned from the StartAuthorization call should be passed here, it will be used to validate the authenticity of the authorization process</param>
        /// <param name="expectedNonce">The nonce value returned from the StartAuthorization call should be passed here, it will be used to ensure the token was not requested using a replay attack</param>
        /// <param name="options">Optional parameters</param>
        /// <returns>MobileConnectStatus object with required information for continuing the mobileconnect process</returns>
        public async Task<MobileConnectStatus> RequestTokenAsync(HttpRequestMessage request, DiscoveryResponse discoveryResponse, Uri redirectedUrl, string expectedState, string expectedNonce, MobileConnectRequestOptions options)
        {
            return await MobileConnectInterfaceHelper.RequestToken(_authentication, _jwks, discoveryResponse, redirectedUrl, expectedState, expectedNonce, _config, options);
        }

        /// <summary>
        /// Request token using the values returned from the authorization redirect
        /// </summary>
        /// <param name="request">Originating web request</param>
        /// <param name="sdkSession">SDKSession id used to fetch the discovery response with additional parameters that are required to request a token</param>
        /// <param name="redirectedUrl">Uri redirected to by the completion of the authorization UI</param>
        /// <param name="expectedState">The state value returned from the StartAuthorization call should be passed here, it will be used to validate the authenticity of the authorization process</param>
        /// <param name="expectedNonce">The nonce value returned from the StartAuthorization call should be passed here, it will be used to ensure the token was not requested using a replay attack</param>
        /// <param name="options">Optional parameters</param>
        /// <returns>MobileConnectStatus object with required information for continuing the mobileconnect process</returns>
        public async Task<MobileConnectStatus> RequestTokenAsync(HttpRequestMessage request, string sdkSession, Uri redirectedUrl, string expectedState, string expectedNonce, MobileConnectRequestOptions options)
        {
            var discoveryResponse = await GetSessionFromCache(sdkSession);

            if (discoveryResponse == null)
            {
                return GetCacheError();
            }

            return await RequestTokenAsync(request, discoveryResponse, redirectedUrl, expectedState, expectedNonce, options);
        }

        /// <summary>
        /// Refresh token using using the refresh token provided in the RequestToken response
        /// </summary>
        /// <param name="request">Originating web request</param>
        /// <param name="refreshToken">Refresh token returned from RefreshToken request</param>
        /// <param name="discoveryResponse">The response returned by the discovery process</param>
        /// <returns>Object with required information for continuing the mobile connect process</returns>
        public async Task<MobileConnectStatus> RefreshTokenAsync(HttpRequestMessage request, string refreshToken, DiscoveryResponse discoveryResponse)
        {
            return await MobileConnectInterfaceHelper.RefreshToken(_authentication, refreshToken, discoveryResponse, _config);
        }

        /// <summary>
        /// Refresh token using using the refresh token provided in the RequestToken response
        /// </summary>
        /// <param name="request">Originating web request</param>
        /// <param name="refreshToken">Refresh token returned from RefreshToken request</param>
        /// <param name="sdkSession">SDKSession id used to fetch the discovery response with additional parameters that are required to refresh a token</param>
        /// <returns>Object with required information for continuing the mobile connect process</returns>
        public async Task<MobileConnectStatus> RefreshTokenAsync(HttpRequestMessage request, string refreshToken, string sdkSession)
        {
            var discoveryResponse = await GetSessionFromCache(sdkSession);

            if (discoveryResponse == null)
            {
                return GetCacheError();
            }

            return await RefreshTokenAsync(request, refreshToken, discoveryResponse);
        }

        /// <summary>
        /// Revoke token using using the access / refresh token provided in the RequestToken response
        /// </summary>
        /// <param name="request">Originating web request</param>
        /// <param name="token">Access/Refresh token returned from RequestToken request</param>
        /// <param name="tokenTypeHint">Hint to indicate the type of token being passed in</param>
        /// <param name="discoveryResponse">The response returned by the discovery process</param>
        /// <returns>Object with required information for continuing the mobile connect process</returns>
        public async Task<MobileConnectStatus> RevokeTokenAsync(HttpRequestMessage request, string token, string tokenTypeHint, DiscoveryResponse discoveryResponse)
        {
            return await MobileConnectInterfaceHelper.RevokeToken(_authentication, token, tokenTypeHint, discoveryResponse, _config);
        }

        /// <summary>
        /// Revoke token using using the access / refresh token provided in the RequestToken response
        /// </summary>
        /// <param name="request">Originating web request</param>
        /// <param name="token">Access/Refresh token returned from RequestToken request</param>
        /// <param name="tokenTypeHint">Hint to indicate the type of token being passed in</param>
        /// <param name="sdkSession">SDKSession id used to fetch the discovery response with additional parameters that are required to revoke a token</param>
        /// <returns>Object with required information for continuing the mobile connect process</returns>
        public async Task<MobileConnectStatus> RevokeTokenAsync(HttpRequestMessage request, string token, string tokenTypeHint, string sdkSession)
        {
            var discoveryResponse = await GetSessionFromCache(sdkSession);

            if (discoveryResponse == null)
            {
                return GetCacheError();
            }

            return await RevokeTokenAsync(request, token, tokenTypeHint, discoveryResponse);
        }

        /// <summary>
        /// Handles continuation of the process following a completed redirect, the request token url must be provided if it has been returned by the discovery process.
        /// Only the request and redirectedUrl are required, however if the redirect being handled is the result of calling the Authorization URL then the remaining parameters are required.
        /// </summary>
        /// <param name="request">Originating web request</param>
        /// <param name="redirectedUrl">Url redirected to by the completion of the previous step</param>
        /// <param name="discoveryResponse">The response returned by the discovery process</param>
        /// <param name="expectedState">The state value returned from the StartAuthorization call should be passed here, it will be used to validate the authenticity of the authorization process</param>
        /// <param name="expectedNonce">The nonce value returned from the StartAuthorization call should be passed here, it will be used to ensure the token was not requested using a replay attack</param>
        /// <param name="options">Optional parameters</param>
        /// <returns>MobileConnectStatus object with required information for continuing the mobileconnect process</returns>
        public async Task<MobileConnectStatus> HandleUrlRedirectAsync(HttpRequestMessage request, Uri redirectedUrl, DiscoveryResponse discoveryResponse = null, string expectedState = null, string expectedNonce = null, MobileConnectRequestOptions options = null)
        {
            return await CacheIfRequired(await MobileConnectInterfaceHelper.HandleUrlRedirect(_discovery, _authentication, _jwks, redirectedUrl, discoveryResponse, expectedState, expectedNonce, _config, options));
        }

        /// <summary>
        /// Handles continuation of the process following a completed redirect, the request token url must be provided if it has been returned by the discovery process.
        /// Only the request and redirectedUrl are required, however if the redirect being handled is the result of calling the Authorization URL then the remaining parameters are required.
        /// </summary>
        /// <param name="request">Originating web request</param>
        /// <param name="redirectedUrl">Url redirected to by the completion of the previous step</param>
        /// <param name="sdkSession">SDKSession id used to fetch the discovery response with additional parameters that are required to request a token</param>
        /// <param name="expectedState">The state value returned from the StartAuthorization call should be passed here, it will be used to validate the authenticity of the authorization process</param>
        /// <param name="expectedNonce">The nonce value returned from the StartAuthorization call should be passed here, it will be used to ensure the token was not requested using a replay attack</param>
        /// <param name="options">Optional parameters</param>
        /// <returns>MobileConnectStatus object with required information for continuing the mobileconnect process</returns>
        public async Task<MobileConnectStatus> HandleUrlRedirectAsync(HttpRequestMessage request, Uri redirectedUrl, string sdkSession = null, string expectedState = null, string expectedNonce = null, MobileConnectRequestOptions options = null)
        {
            var discoveryResponse = await GetSessionFromCache(sdkSession);

            if (discoveryResponse == null && (expectedNonce != null || expectedState != null || sdkSession != null))
            {
                return GetCacheError();
            }

            return await CacheIfRequired(await MobileConnectInterfaceHelper.HandleUrlRedirect(_discovery, _authentication, _jwks, redirectedUrl, discoveryResponse, expectedState, expectedNonce, _config, options));
        }

        /// <summary>
        /// Request user info using the access token returned by <see cref="RequestTokenAsync(HttpRequestMessage, DiscoveryResponse, Uri, string, string, MobileConnectRequestOptions)"/>
        /// </summary>
        /// <param name="request">Originating web request</param>
        /// <param name="discoveryResponse">The response returned by the discovery process</param>
        /// <param name="accessToken">Access token returned from RequestToken required to authenticate the request</param>
        /// <param name="options">Optional parameters</param>
        /// <returns>MobileConnectStatus object with requested UserInfo information</returns>
        public async Task<MobileConnectStatus> RequestUserInfoAsync(HttpRequestMessage request, DiscoveryResponse discoveryResponse, string accessToken, MobileConnectRequestOptions options)
        {
            return await MobileConnectInterfaceHelper.RequestUserInfo(_identity, discoveryResponse, accessToken, _config, options);
        }

        /// <summary>
        /// Request user info using the access token returned by <see cref="RequestTokenAsync(HttpRequestMessage, DiscoveryResponse, Uri, string, string, MobileConnectRequestOptions)"/>
        /// </summary>
        /// <param name="request">Originating web request</param>
        /// <param name="sdkSession">SDKSession id used to fetch the discovery response with additional parameters that are required to request a user info</param>
        /// <param name="accessToken">Access token returned from RequestToken required to authenticate the request</param>
        /// <param name="options">Additional optional parameters</param>
        /// <returns>MobileConnectStatus object with requested UserInfo information</returns>
        public async Task<MobileConnectStatus> RequestUserInfoAsync(HttpRequestMessage request, string sdkSession, string accessToken, MobileConnectRequestOptions options)
        {
            var discoveryResponse = await GetSessionFromCache(sdkSession);

            if (discoveryResponse == null)
            {
                return GetCacheError();
            }

            return await RequestUserInfoAsync(request, discoveryResponse, accessToken, options);
        }

        /// <summary>
        /// Request identity using the access token returned by <see cref="RequestTokenAsync(HttpRequestMessage, DiscoveryResponse, Uri, string, string, MobileConnectRequestOptions)"/>
        /// </summary>
        /// <param name="request">Originating web request</param>
        /// <param name="discoveryResponse">The response returned by the discovery process</param>
        /// <param name="accessToken">Access token returned from RequestToken required to authenticate the request</param>
        /// <param name="options">Optional parameters</param>
        /// <returns>MobileConnectStatus object with requested Identity information</returns>
        public async Task<MobileConnectStatus> RequestIdentityAsync(HttpRequestMessage request, DiscoveryResponse discoveryResponse, string accessToken, MobileConnectRequestOptions options)
        {
            return await MobileConnectInterfaceHelper.RequestIdentity(_identity, discoveryResponse, accessToken, _config, options);
        }

        /// <summary>
        /// Request identity using the access token returned by <see cref="RequestTokenAsync(HttpRequestMessage, DiscoveryResponse, Uri, string, string, MobileConnectRequestOptions)"/>
        /// </summary>
        /// <param name="request">Originating web request</param>
        /// <param name="sdkSession">SDKSession id used to fetch the discovery response with additional parameters that are required to request a user info</param>
        /// <param name="accessToken">Access token returned from RequestToken required to authenticate the request</param>
        /// <param name="options">Additional optional parameters</param>
        /// <returns>MobileConnectStatus object with requested Identity information</returns>
        public async Task<MobileConnectStatus> RequestIdentityAsync(HttpRequestMessage request, string sdkSession, string accessToken, MobileConnectRequestOptions options)
        {
            var discoveryResponse = await GetSessionFromCache(sdkSession);

            if (discoveryResponse == null)
            {
                return GetCacheError();
            }

            return await RequestIdentityAsync(request, discoveryResponse, accessToken, options);
        }

        private async Task<MobileConnectStatus> CacheIfRequired(MobileConnectStatus status)
        {
            if (!_cacheWithSessionId || status.ResponseType != MobileConnectResponseType.StartAuthentication || status.DiscoveryResponse == null)
            {
                return status;
            }

            var sessionId = Security.GenerateSecureNonce();
            await _discovery.Cache.Add(sessionId, status.DiscoveryResponse).ConfigureAwait(false);
            status.SDKSession = sessionId;

            return status;
        }

        private async Task<DiscoveryResponse> GetSessionFromCache(string sessionId)
        {
            if (!_cacheWithSessionId || string.IsNullOrEmpty(sessionId))
            {
                return null;
            }

            return await _discovery.Cache.Get<DiscoveryResponse>(sessionId);
        }

        private MobileConnectStatus GetCacheError()
        {
            if (!_cacheWithSessionId)
            {
                return MobileConnectStatus.Error(ErrorCodes.CacheDisabled, "cache is not enabled for session id caching of discovery responses", null);
            }

            return MobileConnectStatus.Error(ErrorCodes.InvalidSdkSession, "session not found or expired, please try again", null);
        }
    }
}
