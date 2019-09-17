using System;
using GSMA.MobileConnect.Discovery;
using System.Threading;
using System.Threading.Tasks;

namespace GSMA.MobileConnect.Authentication
{
    /// <summary>
    /// Interface for the Mobile Connect Requests
    /// </summary>
    /// <seealso cref="AuthenticationService"/>
    public interface IAuthenticationService
    {
        /// <summary>
        /// Generates an authorisation url based on the supplied options and previous discovery response
        /// </summary>
        /// <param name="clientId">The registered application ClientId (Required)</param>
        /// <param name="authorizeUrl">The authorization url returned by the discovery process (Required)</param>
        /// <param name="redirectUrl">On completion or error where the result information is sent using a HTTP 302 redirect (Required)</param>
        /// <param name="state">Application specified unique scope value</param>
        /// <param name="nonce">Application specified nonce value. (Required)</param>
        /// <param name="encryptedMSISDN">Encrypted MSISDN for user if returned from discovery service</param>
        /// <param name="versions">SupportedVersions from <see cref="ProviderMetadata"/> if null default supported versions will be used to generate the auth url</param>
        /// <param name="options">Optional parameters</param>
        StartAuthenticationResponse StartAuthentication(string clientId, string correlationId, string authorizeUrl,
            string redirectUrl,
            string state, string nonce, string encryptedMSISDN, AuthenticationOptions options, string version);

        /// <summary>
        /// Allows an application to create discovery object manually without call to discovery service
        /// </summary>
        /// <param name="clientId">clientId The registered application clientKey (consumer key) (Required)</param>
        /// <param name="clientSecret">clientSecret The registered application secretKey (Required)</param>
        /// <param name="subscriberId">subscriberId subscriber id (Required)</param>
        /// <param name="appName">application name (Required)</param>
        /// <param name="operatorsUrl">operator specific urls returned from a successful discovery process call</param>
        /// <returns></returns>
        Task<DiscoveryResponse> MakeDiscoveryForAuthorization(string clientId, string clientSecret,
            string appName, OperatorUrls operatorsUrl);

        /// <summary>
        /// Initiates headless authentication, if authentication is successful a token will be returned. 
        /// This may be a long running operation as response from the user on their authentication device is required.
        /// </summary>
        /// <param name="clientId">The application ClientId returned by the discovery process (Required)</param>
        /// <param name="clientSecret">The ClientSecret returned by the discovery response (Required)</param>
        /// <param name="authorizeUrl">The authorization url returned by the discovery process (Required)</param>
        /// <param name="tokenUrl">The token url returned by the discovery process (Required)</param>
        /// <param name="redirectUrl">On completion or error where the result information is sent using a HTTP 302 redirect (Required)</param>
        /// <param name="state">Application specified unique state value (Required)</param>
        /// <param name="nonce">Application specified nonce value. (Required)</param>
        /// <param name="encryptedMSISDN">Encrypted MSISDN for user if returned from discovery service</param>
        /// <param name="versions">SupportedVersions from <see cref="ProviderMetadata"/> if null default supported versions will be used to generate the auth url</param>
        /// <param name="options">Optional parameters</param>
        /// <param name="version">Current version</param>
        /// <param name="cancellationToken">Cancellation token that can be used to cancel long running requests</param>
        /// <returns>Token if headless authentication is successful</returns>
        Task<RequestTokenResponse> RequestHeadlessAuthentication(string clientId, string correlationId, string clientSecret,
            string authorizeUrl, string tokenUrl, string redirectUrl,
            string state, string nonce, string encryptedMSISDN, AuthenticationOptions options, string version,
            CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Synchronous wrapper for <see cref="IAuthenticationService.RequestTokenAsync(string, string, string, string, string, bool)"/>
        /// </summary>
        /// <param name="clientId">The registered application ClientId (Required)</param>
        /// <param name="clientSecret">The registered application ClientSecret (Required)</param>
        /// <param name="requestTokenUrl">The url for token requests recieved from the discovery process (Required)</param>
        /// <param name="redirectUrl">Confirms the redirectURI that the application used when the authorization request (Required)</param>
        /// <param name="code">The authorization code provided to the application via the call to the authentication/authorization API (Required)</param>
        RequestTokenResponse RequestToken(string clientId, string correlationId, string clientSecret,
            string requestTokenUrl, string redirectUrl, string code);

        /// <summary>
        /// Allows an application to use the authorization code obtained from authentication/authorization to obtain an access token
        /// and related information from the authorization server.
        /// </summary>
        /// <remarks>
        /// This function requires a valid token url from the discovery process and a valid code from the initial authorization call
        /// </remarks>
        /// <param name="clientId">The registered application ClientId (Required)</param>
        /// <param name="clientSecret">The registered application ClientSecret (Required)</param>
        /// <param name="requestTokenUrl">The url for token requests recieved from the discovery process (Required)</param>
        /// <param name="redirectUrl">Confirms the redirectURI that the application used when the authorization request (Required)</param>
        /// <param name="code">The authorization code provided to the application via the call to the authentication/authorization API (Required)</param>
        Task<RequestTokenResponse> RequestTokenAsync(string clientId, string correlationId, string clientSecret,
            string requestTokenUrl, string redirectUrl, string code, bool isBasicAuth);

        /// <summary>
        /// Allows an application to use the refresh token obtained from request token response and request for a token refresh. 
        /// This function requires a valid refresh token to be provided
        /// </summary>
        /// <param name="clientId">The application ClientId returned by the discovery process</param>
        /// <param name="clientSecret">The ClientSecret returned by the discovery response</param>
        /// <param name="refreshTokenUrl">The url for token refresh received from the discovery process</param>
        /// <param name="refreshToken">Refresh token returned from RequestToken request</param>
        /// <returns></returns>
        Task<RequestTokenResponse> RefreshTokenAsync(string clientId, string clientSecret, string refreshTokenUrl, string refreshToken, bool isBasicAuth);

        /// <summary>
        /// Synchronous wrapper for <see cref="RefreshTokenAsync(string, string, string, string, bool)"/>
        /// </summary>
        /// <param name="clientId">The application ClientId returned by the discovery process</param>
        /// <param name="clientSecret">The ClientSecret returned by the discovery response</param>
        /// <param name="refreshTokenUrl">The url for token refresh received from the discovery process</param>
        /// <param name="refreshToken">Refresh token returned from RequestToken request</param>
        /// <returns></returns>
        RequestTokenResponse RefreshToken(string clientId, string clientSecret, string refreshTokenUrl, string refreshToken);


        /// <summary>
        /// Allows an application to use the access token or the refresh token obtained from request token response and request for a token revocation
        /// This function requires either a valid access token or a refresh token to be provided
        /// </summary>
        /// <param name="clientId">The application ClientId returned by the discovery process</param>
        /// <param name="clientSecret">The ClientSecret returned by the discovery response</param>
        /// <param name="revokeTokenUrl">The url for token refresh received from the discovery process</param>
        /// <param name="token">Access/Refresh token returned from RequestToken request</param>
        /// <param name="tokenTypeHint">Hint to indicate the type of token being passed in</param>
        /// <returns></returns>
        Task<RevokeTokenResponse> RevokeTokenAsync(string clientId, string clientSecret, string revokeTokenUrl, string token, string tokenTypeHint, bool isBasicAuth);

        /// <summary>
        /// Synchronous wrapper for <see cref="RevokeToken(string, string, string, string, string)"/>
        /// </summary>
        /// <param name="clientId">The application ClientId returned by the discovery process</param>
        /// <param name="clientSecret">The ClientSecret returned by the discovery response</param>
        /// <param name="revokeTokenUrl">The url for token refresh received from the discovery process</param>
        /// <param name="token">Access/Refresh token returned from RequestToken request</param>
        /// <param name="tokenTypeHint">Hint to indicate the type of token being passed in</param>
        /// <returns></returns>
        RevokeTokenResponse RevokeToken(string clientId, string clientSecret, string revokeTokenUrl, string token, string tokenTypeHint);

        /// <summary>
        /// Executes a series of validation methods on the token response, if the access token or id token are invalid the result will indicate what 
        /// validation criteria was not met
        /// </summary>
        /// <param name="tokenResponse">Token response to validate</param>
        /// <param name="clientId">Client id required for validating Id token claims</param>
        /// <param name="issuer">Token issuer value required for validating Id token claims</param>
        /// <param name="nonce">Nonce value required for validating Id token claims</param>
        /// <param name="maxAge">MaxAge value required for validating Id token claims</param>
        /// <param name="keyset">Keyset required for validating Id token signature</param>
        /// <param name="version">Max version of mobile connect services supported by current provider, used to skip some unsupported validation steps</param>
        /// <returns>TokenValidationResult indicating the token response is valid or why the token response is invalid</returns>
        TokenValidationResult ValidateTokenResponse(RequestTokenResponse tokenResponse, string clientId, string issuer, string nonce, int? maxAge, JWKeyset keyset, string version);
    }
}
