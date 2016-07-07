using GSMA.MobileConnect.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSMA.MobileConnect.Authentication
{
    /// <summary>
    /// Class to hold the response of <see cref="IAuthentication.RequestTokenAsync(string, string, string, string, string)"/>
    /// Will contain either an error response or request data
    /// </summary>
    /// <seealso cref="IAuthentication"/>
    public class RequestTokenResponse
    {
        /// <summary>
        /// The http response code returned by the network request
        /// </summary>
        public int ResponseCode { get; set; }

        /// <summary>
        /// A list of http headers
        /// </summary>
        public List<BasicKeyValuePair> Headers { get; set; }

        /// <summary>
        /// The response if the network request did not return an error
        /// </summary>
        public RequestTokenResponseData ResponseData { get; set; }

        /// <summary>
        /// Decoded JWT payload from IdToken in standard JSON string format
        /// </summary>
        public string DecodedIdTokenPayload { get; set; }

        /// <summary>
        /// The response if the network request returned an error
        /// </summary>
        public ErrorResponse ErrorResponse { get; set; }

        /// <summary>
        /// Creates a valid token response from the raw RestResponse
        /// </summary>
        /// <param name="rawResponse">RestResponse returned from RestClient</param>
        public RequestTokenResponse(RestResponse rawResponse)
        {
            this.ResponseCode = (int)rawResponse.StatusCode;
            this.Headers = rawResponse.Headers;

            if(HttpUtils.IsHttpErrorCode(this.ResponseCode))
            {
                this.ErrorResponse = JsonConvert.DeserializeObject<ErrorResponse>(rawResponse.Content);
            }
            else
            {
                this.ResponseData = JsonConvert.DeserializeObject<RequestTokenResponseData>(rawResponse.Content);
                this.DecodedIdTokenPayload = JsonWebToken.DecodePart(this.ResponseData.IdToken, JWTPart.Payload);
            }
        }
    }
}
