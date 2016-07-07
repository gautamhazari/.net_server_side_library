using GSMA.MobileConnect.Exceptions;
using GSMA.MobileConnect.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using GSMA.MobileConnect.Claims;
using Newtonsoft.Json;

namespace GSMA.MobileConnect.Identity
{
    /// <summary>
    /// Implementation of <see cref="IIdentityService"/> interface
    /// </summary>
    public class IdentityService : IIdentityService
    {
        private readonly RestClient _client;

        /// <inheritdoc/>
        public IdentityService(RestClient client)
        {
            this._client = client;
        }

        /// <inheritdoc/>
        public async Task<UserInfoResponse> RequestUserInfo(string userInfoUrl, string accessToken, ClaimsParameter claims)
        {
            string claimsJson = JsonConvert.SerializeObject(claims);
            return await RequestUserInfo(userInfoUrl, accessToken, claimsJson);
        }

        /// <inheritdoc/>
        public async Task<UserInfoResponse> RequestUserInfo(string userInfoUrl, string accessToken, string claims)
        {
            // TODO: handle recieving JWT vs standard JSON

            Validation.RejectNullOrEmpty(userInfoUrl, "userInfoUrl");
            Validation.RejectNullOrEmpty(accessToken, "accessToken");

            try
            {
                var response = await _client.GetAsync(userInfoUrl, RestAuthentication.Bearer(accessToken), null, null, null);
                return new UserInfoResponse(response);
            }
            catch (Exception e) when (e is HttpRequestException || e is System.Net.WebException || e is TaskCanceledException)
            {
                throw new MobileConnectEndpointHttpException(e.Message, e);
            }
        }
    }
}
