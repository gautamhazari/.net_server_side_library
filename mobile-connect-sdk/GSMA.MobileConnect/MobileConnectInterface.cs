using GSMA.MobileConnect.Authentication;
using GSMA.MobileConnect.Claims;
using GSMA.MobileConnect.Discovery;
using GSMA.MobileConnect.Exceptions;
using GSMA.MobileConnect.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GSMA.MobileConnect
{
    /// <summary>
    /// Convenience wrapper for <see cref="IDiscovery"/> and <see cref="IAuthentication"/> methods for use with non-web .Net targets
    /// </summary>
    /// <seealso cref="MobileConnectWebInterface"/>
    /// <seealso cref="MobileConnectStatus"/>
    /// <seealso cref="MobileConnectConfig"/>
    public class MobileConnectInterface
    {
        private readonly IDiscovery _discovery;
        private readonly IAuthentication _authentication;
        private readonly IIdentityService _identity;
        private readonly MobileConnectConfig _config;

        /// <summary>
        /// Initializes a new instance of the MobileConnectInterface class
        /// </summary>
        /// <param name="discovery">Instance of IDiscovery concrete implementation</param>
        /// <param name="authentication">Instance of IAuthentication concrete implementation</param>
        /// <param name="identity">Instance of IIdentityService concrete implementation</param>
        /// <param name="config">Configuration options</param>
        public MobileConnectInterface(IDiscovery discovery, IAuthentication authentication, IIdentityService identity, MobileConnectConfig config)
        {
            this._discovery = discovery;
            this._authentication = authentication;
            this._identity = identity;
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
        /// <returns>MobileConnectStatus object with required information for continuing the mobileconnect process</returns>
        public async Task<MobileConnectStatus> RequestTokenAsync(DiscoveryResponse discoveryResponse, Uri redirectedUrl, string expectedState, string expectedNonce)
        {
            return await MobileConnectInterfaceHelper.RequestToken(_authentication, discoveryResponse, redirectedUrl, expectedState, expectedNonce, _config);
        }

        /// <summary>
        /// Synchronous wrapper for <see cref="MobileConnectInterface.RequestTokenAsync(DiscoveryResponse, Uri, string, string)"/>
        /// </summary>
        /// <param name="discoveryResponse">The response returned by the discovery process</param>
        /// <param name="redirectedUrl">Uri redirected to by the completion of the authorization UI</param>
        /// <param name="expectedState">The state value returned from the StartAuthorization call should be passed here, it will be used to validate the authenticity of the authorization process</param>
        /// <param name="expectedNonce">The nonce value returned from the StartAuthorization call should be passed here, it will be used to ensure the token was not requested using a replay attack</param>
        /// <returns>MobileConnectStatus object with required information for continuing the mobileconnect process</returns>
        public MobileConnectStatus RequestToken(DiscoveryResponse discoveryResponse, Uri redirectedUrl, string expectedState, string expectedNonce)
        {
            return MobileConnectInterfaceHelper.RequestToken(_authentication, discoveryResponse, redirectedUrl, expectedState, expectedNonce, _config).Result;
        }

        /// <summary>
        /// Handles continuation of the process following a completed redirect. 
        /// Only the redirectedUrl is required, however if the redirect being handled is the result of calling the Authorization URL then the remaining parameters are required.
        /// </summary>
        /// <param name="redirectedUrl">Url redirected to by the completion of the previous step</param>
        /// <param name="discoveryResponse">The response returned by the discovery process</param>
        /// <param name="expectedState">The state value returned from the StartAuthorization call should be passed here, it will be used to validate the authenticity of the authorization process</param>
        /// <param name="expectedNonce">The nonce value returned from the StartAuthorization call should be passed here, it will be used to ensure the token was not requested using a replay attack</param>
        /// <returns>MobileConnectStatus object with required information for continuing the mobileconnect process</returns>
        public async Task<MobileConnectStatus> HandleUrlRedirectAsync(Uri redirectedUrl, DiscoveryResponse discoveryResponse = null, string expectedState = null, string expectedNonce = null)
        {
            return await MobileConnectInterfaceHelper.HandleUrlRedirect(_discovery, _authentication, redirectedUrl, discoveryResponse, expectedState, expectedNonce, _config);
        }

        /// <summary>
        /// Synchronous wrapper for <see cref="MobileConnectInterface.HandleUrlRedirectAsync(Uri, DiscoveryResponse, string, string)"/>
        /// </summary>
        /// <param name="redirectedUrl">Url redirected to by the completion of the previous step</param>
        /// <param name="discoveryResponse">The response returned by the discovery process</param>
        /// <param name="expectedState">The state value returned from the StartAuthorization call should be passed here, it will be used to validate the authenticity of the authorization process</param>
        /// <param name="expectedNonce">The nonce value returned from the StartAuthorization call should be passed here, it will be used to ensure the token was not requested using a replay attack</param>
        /// <param name="requestTokenUrl">Url for token request, this is returned by the discovery process. An error status will be returned if the redirected url triggers a token request and this parameter has not been provided.</param>
        /// <returns>MobileConnectStatus object with required information for continuing the mobileconnect process</returns>
        public MobileConnectStatus HandleUrlRedirect(Uri redirectedUrl, DiscoveryResponse discoveryResponse = null, string expectedState = null, string expectedNonce = null, string requestTokenUrl = null)
        {
            return MobileConnectInterfaceHelper.HandleUrlRedirect(_discovery, _authentication, redirectedUrl, discoveryResponse, expectedState, expectedNonce, _config).Result;
        }

        /// <summary>
        /// Request user info using the access token returned by <see cref="RequestTokenAsync(DiscoveryResponse, Uri, string, string)"/>
        /// </summary>
        /// <param name="discoveryResponse">The response returned by the discovery process</param>
        /// <param name="accessToken">Access token from RequestToken stage</param>
        /// <param name="claims">Claims requested from UserInfo service (Optional)</param>
        /// <param name="options">Additional optional parameters</param>
        /// <returns>MobileConnectStatus object with UserInfo information</returns>
        public async Task<MobileConnectStatus> RequestUserInfoAsync(DiscoveryResponse discoveryResponse, string accessToken, ClaimsParameter claims, MobileConnectRequestOptions options)
        {
            return await MobileConnectInterfaceHelper.RequestUserInfo(_identity, discoveryResponse, accessToken, claims, _config, options);
        }

        /// <summary>
        /// Syncronous wrapper for <see cref="RequestTokenAsync(DiscoveryResponse, Uri, string, string)"/>
        /// </summary>
        /// <param name="discoveryResponse">The response returned by the discovery process</param>
        /// <param name="accessToken">Access token from RequestToken stage</param>
        /// <param name="claims">Claims requested from UserInfo service (Optional)</param>
        /// <param name="options">Additional optional parameters</param>
        /// <returns>MobileConnectStatus object with UserInfo information</returns>
        public MobileConnectStatus RequestUserInfo(DiscoveryResponse discoveryResponse, string accessToken, ClaimsParameter claims, MobileConnectRequestOptions options)
        {
            return MobileConnectInterfaceHelper.RequestUserInfo(_identity, discoveryResponse, accessToken, claims, _config, options).Result;
        }
    }
}
