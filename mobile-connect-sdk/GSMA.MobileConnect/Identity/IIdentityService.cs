using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    }
}
