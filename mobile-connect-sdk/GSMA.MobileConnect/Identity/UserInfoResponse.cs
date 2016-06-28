using GSMA.MobileConnect.Json;
using GSMA.MobileConnect.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSMA.MobileConnect.Identity
{
    /// <summary>
    /// Class to hold response from UserInfo service
    /// </summary>
    public class UserInfoResponse
    {
        /// <summary>
        /// Returns the Http response code or 0 if the data is cached
        /// </summary>
        [JsonProperty]
        public int ResponseCode { get; private set; }

        /// <summary>
        /// The response if the network request returned an error
        /// </summary>
        public ErrorResponse ErrorResponse { get; set; }

        /// <summary>
        /// The parsed json response data
        /// </summary>
        public UserInfoResponseData ResponseData {get;set;}

        /// <summary>
        /// Creates a new instance of the UserInfoResponse class
        /// </summary>
        [JsonConstructor]
        public UserInfoResponse(UserInfoResponseData responseData)
        {
            ParseResponseData(responseData);
            this.ResponseData = responseData;
        }

        /// <summary>
        /// Creates a new instance of the UserInfoResponse class using a the json content of a RestResponse for construction
        /// </summary>
        /// <param name="rawResponse">Response from UserInfo endpoint</param>
        public UserInfoResponse(RestResponse rawResponse)
        {
            this.ResponseCode = (int)rawResponse.StatusCode;
            if (this.ResponseCode < 400)
            {
                this.ResponseData = rawResponse.Content == null ? null : JsonConvert.DeserializeObject<UserInfoResponseData>(rawResponse.Content);
                ParseResponseData(ResponseData);
                return;
            }

            var authenticationError = rawResponse.Headers.FirstOrDefault(x => x.Key == "WWW-Authenticate")?.Value;
            this.ErrorResponse = HttpUtils.GenerateAuthenticationError(authenticationError);
        }

        private void ParseResponseData(UserInfoResponseData responseData)
        {
            if (responseData == null)
            {
                return;
            }

            if (responseData.error != null)
            {
                this.ErrorResponse = new ErrorResponse() { Error = responseData.error, ErrorDescription = responseData.description };
            }
        }
    }
}
