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

        /// <summary>
        /// Creates a new instance of the RestResponse class
        /// </summary>
        public RestResponse()
        {

        }

        /// <summary>
        /// Creates a new instance of the RestResponse class with the specified status code and content
        /// </summary>
        /// <param name="code">Response HttpStatusCode</param>
        /// <param name="content">Response content</param>
        public RestResponse(HttpStatusCode code, string content)
        {
            this.StatusCode = code;
            this.Content = content;
        }
    }
}
