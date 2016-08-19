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

        /// <summary>
        /// Creates a new instance of the class IdentityService using the specified RestClient for all HTTP requests
        /// </summary>
        /// <param name="client">RestClient for handling HTTP requests</param>
        public IdentityService(RestClient client)
        {
            this._client = client;
        }

        /// <inheritdoc/>
        public async Task<IdentityResponse> RequestIdentity(string premiumInfoUrl, string accessToken)
        {
            Validate.RejectNullOrEmpty(premiumInfoUrl, "premiumInfoUrl");
            return await RequestUserInfo(premiumInfoUrl, accessToken);
        }

        /// <inheritdoc/>
        public async Task<IdentityResponse> RequestUserInfo(string userInfoUrl, string accessToken)
        {
            Validate.RejectNullOrEmpty(userInfoUrl, "userInfoUrl");
            Validate.RejectNullOrEmpty(accessToken, "accessToken");

            try
            {
                RestResponse response;
                var auth = RestAuthentication.Bearer(accessToken);
                response = await _client.GetAsync(userInfoUrl, auth, null, null, null);

                return new IdentityResponse(response);
            }
            catch (Exception e) when (e is HttpRequestException || e is System.Net.WebException || e is TaskCanceledException)
            {
                Log.Error(() => $"Error occurred while requesting identity url={userInfoUrl}", e);
                throw new MobileConnectEndpointHttpException(e.Message, e);
            }
        }
    }
}
