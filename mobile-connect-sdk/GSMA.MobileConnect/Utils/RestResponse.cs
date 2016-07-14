using System.Collections.Generic;
using System.Net;

namespace GSMA.MobileConnect.Utils
{
    /// <summary>
    /// Simple response object to represent a http response
    /// </summary>
    public class RestResponse
    {
        /// <summary>
        /// Status code returned by Http response
        /// </summary>
        public HttpStatusCode StatusCode { get; set; }

        /// <summary>
        /// Headers set on the http response
        /// </summary>
        public List<BasicKeyValuePair> Headers { get; set; }

        /// <summary>
        /// Content returned by the http response
        /// </summary>
        public string Content { get; set; }

        /// <inheritdoc/>
        public RestResponse()
        {

        }

        /// <inheritdoc/>
        public RestResponse(HttpStatusCode code, string content)
        {
            this.StatusCode = code;
            this.Content = content;
        }
    }
}
