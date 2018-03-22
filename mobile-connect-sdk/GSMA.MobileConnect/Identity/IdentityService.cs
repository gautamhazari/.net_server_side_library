using GSMA.MobileConnect.Exceptions;
using GSMA.MobileConnect.Utils;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace GSMA.MobileConnect.Identity
{
    /// <summary>
    /// Implementation of <see cref="IIdentityService"/> interface
    /// </summary>
    public class IdentityService : IIdentityService
    {
        /// <summary>
        /// The types of info request.
        /// </summary>
        public enum InfoType
        {
            /// <summary>
            /// Identity info
            /// </summary>
            PremiumInfo,
            /// <summary>
            /// Basic user info
            /// </summary>
            UserInfo

        }
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
            Validate.RejectNullOrEmpty(premiumInfoUrl, nameof(premiumInfoUrl));
            Validate.RejectNullOrEmpty(accessToken, nameof(accessToken));
            return await RequestInfoInternal(premiumInfoUrl, accessToken, InfoType.PremiumInfo);
        }

        /// <inheritdoc/>
        public async Task<IdentityResponse> RequestUserInfo(string userInfoUrl, string accessToken)
        {
            Validate.RejectNullOrEmpty(userInfoUrl, nameof(userInfoUrl));
            Validate.RejectNullOrEmpty(accessToken, nameof(accessToken));
            return await RequestInfoInternal(userInfoUrl, accessToken, InfoType.UserInfo);
        }

        /// <inheritdoc/>
        private async Task<IdentityResponse> RequestInfoInternal(string infoUrl, string accessToken, InfoType infoType)
        {
            try
            {
                RestResponse response;
                var auth = RestAuthentication.Bearer(accessToken);
                response = await _client.GetAsync(infoUrl, auth, null, null, null);

                return new IdentityResponse(response, infoType);
            }
            catch (Exception e) when (e is HttpRequestException || e is WebException || e is TaskCanceledException)
            {
                Log.Error(() => $"Error occurred while requesting identity url={infoUrl}", e);
                throw new MobileConnectEndpointHttpException(e.Message, e);
            }
        }
    }
}
