using System.Threading.Tasks;

namespace GSMA.MobileConnect.Identity
{
    /// <summary>
    /// Interface for Mobile Connect UserInfo and Identity related requests
    /// </summary>
    /// <seealso cref="IdentityService"/>
    public interface IIdentityService
    {
        /// <summary>
        /// Request the user info for the provided access token. Some of the information returned by the user info service requires the authorization/authentication to be 
        /// executed with additional scope values e.g. email => openid email
        /// </summary>
        /// <param name="userInfoUrl">Url for accessing user info (Returned in discovery response)</param>
        /// <param name="accessToken">Access token for authorising user info request</param>
        /// <returns>UserInfo object if request succeeds</returns>
        Task<IdentityResponse> RequestUserInfo(string userInfoUrl, string accessToken);

        /// <summary>
        /// Request the identity for the provided access token. Information returned by the identity service requires the authorization to be 
        /// executed with additional scope values e.g. phone number <see cref="MobileConnectConstants.MOBILECONNECTIDENTITYPHONE"/>
        /// </summary>
        /// <param name="premiumInfoUrl">Url for accessing premium info identity services (Returned in discovery response)</param>
        /// <param name="accessToken">Access token for authorising identity request</param>
        /// <returns>UserInfo object if request succeeds</returns>
        Task<IdentityResponse> RequestPremiumInfo(string premiumInfoUrl, string accessToken);
    }
}
