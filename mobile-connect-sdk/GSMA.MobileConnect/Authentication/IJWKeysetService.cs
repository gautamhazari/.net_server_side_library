using System.Threading.Tasks;

namespace GSMA.MobileConnect.Authentication
{
    /// <summary>
    /// Service for retrieving, caching and managing JWKS keysets for JWT validation
    /// </summary>
    public interface IJWKeysetService
    {
        /// <summary>
        /// Retrieve the JSON Web Keyset from the specified url utilising caching if configured
        /// </summary>
        /// <param name="url">JWKS URL</param>
        /// <returns>JSON Web Keyset if successfully retrieved</returns>
        Task<JWKeyset> RetrieveJWKSAsync(string url);

        /// <summary>
        /// Synchronous wrapper for <see cref="RetrieveJWKSAsync(string)"/>
        /// </summary>
        /// <param name="url">JWKS URL</param>
        /// <returns>JSON Web Keyset if successfully retrieved</returns>
        JWKeyset RetrieveJWKS(string url);
    }
}
