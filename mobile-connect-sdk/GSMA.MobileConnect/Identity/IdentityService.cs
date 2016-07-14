using GSMA.MobileConnect.Exceptions;
using GSMA.MobileConnect.Utils;
using System;
using System.Net.Http;
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
            Validation.RejectNullOrEmpty(userInfoUrl, "userInfoUrl");
            Validation.RejectNullOrEmpty(accessToken, "accessToken");

            try
            {
                RestResponse response;
                var auth = RestAuthentication.Bearer(accessToken);
                if(string.IsNullOrEmpty(claims))
                {
                    response = await _client.GetAsync(userInfoUrl, auth, null, null, null);
                }
                else
                {
                    response = await _client.PostAsync(userInfoUrl, auth, claims, null, null);
                }

                return new UserInfoResponse(response);
            }
            catch (Exception e) when (e is HttpRequestException || e is System.Net.WebException || e is TaskCanceledException)
            {
                throw new MobileConnectEndpointHttpException(e.Message, e);
            }
        }
    }
}
