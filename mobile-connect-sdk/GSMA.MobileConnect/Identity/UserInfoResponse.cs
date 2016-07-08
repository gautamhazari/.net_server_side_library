using GSMA.MobileConnect.Json;
using GSMA.MobileConnect.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
        private object _convertedResponseData;

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
        public string ResponseJson {get;set;}

        /// <summary>
        /// Creates a new instance of the UserInfoResponse class
        /// </summary>
        [JsonConstructor]
        public UserInfoResponse(string responseJson)
        {
            ParseResponseData(responseJson);
            this.ResponseJson = responseJson;
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
                this.ResponseJson = ExtractJson(rawResponse.Content);
                ParseResponseData(ResponseJson);
                return;
            }

            var authenticationError = rawResponse.Headers.FirstOrDefault(x => x.Key == "WWW-Authenticate")?.Value;
            this.ErrorResponse = HttpUtils.GenerateAuthenticationError(authenticationError);
        }

        private string ExtractJson(string responseData)
        {
            if(string.IsNullOrEmpty(responseData))
            {
                return responseData;
            }

            if(responseData.IndexOf('{') > -1)
            {
                // Already JSON
                return responseData;
            }

            if (JsonWebToken.IsValidFormat(responseData))
            {
                return JsonWebToken.DecodePart(responseData, JWTPart.Payload);
            }

            return "{\"error\":\"invalid_format\",\"error_description\":\"Recieved UserInfo response that is not JSON or JWT format\"";
        }

        /// <summary>
        /// Converts response JSON to custom provided user info class
        /// </summary>
        /// <typeparam name="T">User info class with properties linking to keys in userinfo response json</typeparam>
        /// <seealso cref="UserInfoResponseData"/>
        /// <remarks>The last used object will be cached for subsequent method calls with the same type</remarks>
        /// <returns>JSON Deserialized to instance of Type T</returns>
        public T ResponseDataAs<T>() where T : class
        {
            if(string.IsNullOrEmpty(ResponseJson))
            {
                return default(T);
            }

            T convertedResponse = _convertedResponseData as T;

            if(convertedResponse != null)
            {
                return convertedResponse;
            }

            convertedResponse = JsonConvert.DeserializeObject<T>(ResponseJson);
            _convertedResponseData = convertedResponse;
            return convertedResponse;
        }

        private void ParseResponseData(string responseJson)
        {
            if (responseJson == null)
            {
                return;
            }

            JObject response = JObject.Parse(responseJson);

            if (response["error"] != null)
            {
                this.ErrorResponse = new ErrorResponse() { Error = (string)response["error"], ErrorDescription = (string)response["description"] };
            }
        }
    }
}
