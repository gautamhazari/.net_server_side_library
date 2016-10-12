using GSMA.MobileConnect.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSMA.MobileConnect.Authentication
{
    /// <summary>
    /// Class to hold the response of <see cref="IAuthenticationService.RevokeToken(string, string, string, string, string)"/>
    /// Will contain either an error response or success indicator
    /// </summary>
    public class RevokeTokenResponse
    {
        /// <summary>
        /// True if token revoke succeeded
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// The response if the network request returned an error
        /// </summary>
        public ErrorResponse ErrorResponse { get; set; }

        /// <summary>
        /// Creates a valid token response from the raw RestResponse
        /// </summary>
        /// <param name="rawResponse">RestResponse returned from RestClient</param>
        public RevokeTokenResponse(RestResponse rawResponse)
        {
            if (HttpUtils.IsHttpErrorCode((int)rawResponse.StatusCode))
            {
                this.ErrorResponse = JsonConvert.DeserializeObject<ErrorResponse>(rawResponse.Content);
            }
            else
            {
                this.Success = true;
            }
        }
    }
}
