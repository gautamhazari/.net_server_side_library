using GSMA.MobileConnect.Exceptions;
using GSMA.MobileConnect.Utils;
using System;
using System.Net.Http;
using System.Threading.Tasks;

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
        public async Task<IdentityResponse> RequestIdentity(string premiumInfoUrl, string accessToken)
        {
            Validation.RejectNullOrEmpty(premiumInfoUrl, "premiumInfoUrl");
            return await RequestUserInfo(premiumInfoUrl, accessToken);
        }

        /// <inheritdoc/>
        public async Task<IdentityResponse> RequestUserInfo(string userInfoUrl, string accessToken)
        {
            Validation.RejectNullOrEmpty(userInfoUrl, "userInfoUrl");
            Validation.RejectNullOrEmpty(accessToken, "accessToken");

            try
            {
                RestResponse response;
                var auth = RestAuthentication.Bearer(accessToken);
                response = await _client.GetAsync(userInfoUrl, auth, null, null, null);

                return new IdentityResponse(response);
            }
            catch (Exception e) when (e is HttpRequestException || e is System.Net.WebException || e is TaskCanceledException)
            {
                throw new MobileConnectEndpointHttpException(e.Message, e);
            }
        }
    }
}
