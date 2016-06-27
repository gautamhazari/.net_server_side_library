using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSMA.MobileConnect.Identity
{
    /// <summary>
    /// Implementation of <see cref="IIdentityService"/> interface
    /// </summary>
    public class IdentityService : IIdentityService
    {
        public async Task<UserInfoResponse> RequestUserInfo(string accessToken, string claims)
        {
            throw new NotImplementedException();
        }
    }
}
