using GSMA.MobileConnect.Utils;
using Newtonsoft.Json;

namespace GSMA.MobileConnect
{
    /// <summary>
    /// Class to hold a Rest error response
    /// </summary>
    public class ErrorResponse
    {
        /// <summary>
        /// The error code
        /// </summary>
        [JsonProperty("error")]
        public string Error { get; set; }

        /// <summary>
        /// The error description
        /// </summary>
        [JsonProperty("error_description")]
        public string ErrorDescription { get; set; }

        /// <summary>
        /// The error URI
        /// </summary>
        [JsonProperty("error_uri")]
        public string ErrorUri { get; set; }

        public static ErrorResponse CreateFromUrl(string url)
        {
            if(string.IsNullOrEmpty(url))
            {
                return null;
            }

            string error = HttpUtils.ExtractQueryValue(url, "error");

            if(string.IsNullOrEmpty(error))
            {
                return null;
            }

            return new ErrorResponse { Error = error, ErrorDescription = HttpUtils.ExtractQueryValue(url, "error_description") };
        }
    }
}
