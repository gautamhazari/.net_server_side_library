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
        /// Request the user info for the provided access token
        /// </summary>
        /// <param name="accessToken">Access token for authorising user info request</param>
        /// <param name="claims">List of claims to request (optional)</param>
        /// <returns>UserInfo object if request succeeds</returns>
        Task<UserInfoResponse> RequestUserInfo(string accessToken, string claims);
    }
}
