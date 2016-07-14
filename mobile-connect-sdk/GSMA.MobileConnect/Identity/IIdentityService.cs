using GSMA.MobileConnect.Claims;
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
        /// executed with additional scope values e.g. phone number <see cref="MobileConnectConstants.MOBILECONNECTIDENTITYPHONE"/>
        /// </summary>
        /// <param name="userInfoUrl">Url for accessing user info (Returned in discovery response)</param>
        /// <param name="accessToken">Access token for authorising user info request</param>
        /// <param name="claims">List of claims to request (optional)</param>
        /// <returns>UserInfo object if request succeeds</returns>
        Task<UserInfoResponse> RequestUserInfo(string userInfoUrl, string accessToken, string claims);

        /// <summary>
        /// Convenience method alternative to <see cref="RequestUserInfo(string, string, string)"/> so claims can be specified using a ClaimsParameter
        /// which will be serialized to JSON
        /// </summary>
        /// <param name="userInfoUrl">Url for accessing user info (Returned in discovery response)</param>
        /// <param name="accessToken">Access token for authorising user info request</param>
        /// <param name="claims">Claims parameter with requested claims (optional)</param>
        /// <returns>UserInfo object if request succeeds</returns>
        Task<UserInfoResponse> RequestUserInfo(string userInfoUrl, string accessToken, ClaimsParameter claims);
    }
}
