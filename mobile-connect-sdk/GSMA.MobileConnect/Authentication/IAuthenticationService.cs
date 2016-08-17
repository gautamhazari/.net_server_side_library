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
        StartAuthenticationResponse StartAuthentication(string clientId, string authorizeUrl, string redirectUrl, string state, string nonce, string encryptedMSISDN, SupportedVersions versions, AuthenticationOptions options);

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
        /// <param name="cancellationToken">Cancellation token that can be used to cancel long running requests</param>
        /// <returns>Token if headless authentication is successful</returns>
        Task<RequestTokenResponse> RequestHeadlessAuthentication(string clientId, string clientSecret, string authorizeUrl, string tokenUrl, string redirectUrl,
            string state, string nonce, string encryptedMSISDN, SupportedVersions versions, AuthenticationOptions options, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Synchronous wrapper for <see cref="IAuthenticationService.RequestTokenAsync(string, string, string, string, string)"/>
        /// </summary>
        /// <param name="clientId">The registered application ClientId (Required)</param>
        /// <param name="clientSecret">The registered application ClientSecret (Required)</param>
        /// <param name="requestTokenUrl">The url for token requests recieved from the discovery process (Required)</param>
        /// <param name="redirectUrl">Confirms the redirectURI that the application used when the authorization request (Required)</param>
        /// <param name="code">The authorization code provided to the application via the call to the authentication/authorization API (Required)</param>
        RequestTokenResponse RequestToken(string clientId, string clientSecret, string requestTokenUrl, string redirectUrl, string code);

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
        Task<RequestTokenResponse> RequestTokenAsync(string clientId, string clientSecret, string requestTokenUrl, string redirectUrl, string code);

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
        /// <returns>TokenValidationResult indicating the token response is valid or why the token response is invalid</returns>
        TokenValidationResult ValidateTokenResponse(RequestTokenResponse tokenResponse, string clientId, string issuer, string nonce, int? maxAge, JWKeyset keyset);
    }
}
