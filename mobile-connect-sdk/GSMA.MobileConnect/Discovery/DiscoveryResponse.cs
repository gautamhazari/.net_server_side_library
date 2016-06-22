using GSMA.MobileConnect.Constants;
using GSMA.MobileConnect.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSMA.MobileConnect.Discovery
{
    /// <summary>
    /// Class to hold a discovery response. This potentially holds cached data as indicated by the cached property.
    /// </summary>
    /// <seealso cref="IDiscovery"/>
    public class DiscoveryResponse
    {
        /// <summary>
        /// True if the data came from the local cache
        /// </summary>
        public bool Cached { get; private set; }

        /// <summary>
        /// Time to live from the response
        /// </summary>
        public DateTime? Ttl { get; private set; }

        /// <summary>
        /// Has the reponse expired?
        /// If no Ttl is specified then it is assumed that the response has not expired
        /// </summary>
        public bool HasExpired
        {
            get { return Ttl.HasValue && Ttl.Value.CompareTo(DateTime.UtcNow) <= 0; }
        }

        /// <summary>
        /// Returns the Http response code or 0 if the data is cached
        /// </summary>
        public int ResponseCode { get; private set; }

        /// <summary>
        /// Returns the list of Http headers in the response
        /// </summary>
        public List<BasicKeyValuePair> Headers { get; private set; }

        /// <summary>
        /// The response if the network request returned an error
        /// </summary>
        public ErrorResponse ErrorResponse { get; set; }

        /// <summary>
        /// The parsed json response data
        /// </summary>
        public Json.DiscoveryResponseData ResponseData { get; private set; }

        /// <summary>
        /// The returned operator urls for authentication
        /// </summary>
        public OperatorUrls OperatorUrls { get; set; }

        /// <summary>
        /// Creates an instance of the DiscoveryResponse class by copying an existing DiscoveryResponse instance
        /// </summary>
        /// <param name="response">DiscoveryResponse to copy</param>
        public DiscoveryResponse(DiscoveryResponse response)
        {
            this.Cached = true;
            this.Ttl = response.Ttl;
            this.ResponseCode = response.ResponseCode;
            this.Headers = response.Headers;
            this.ErrorResponse = response.ErrorResponse;
            this.OperatorUrls = response.OperatorUrls;

            // Serialize/Deserialize to clone the cached data
            var cachedJson = JsonConvert.SerializeObject(response.ResponseData);
            this.ResponseData = JsonConvert.DeserializeObject<Json.DiscoveryResponseData>(cachedJson);
            //Remove subscriber id from the cached response
            this.ResponseData.subscriber_id = null;
        }

        /// <summary>
        /// Creates an instance of the DiscoveryResponse using data from a RestResponse instance
        /// </summary>
        /// <param name="rawResponse">RestResponse with discovery response content</param>
        public DiscoveryResponse(RestResponse rawResponse)
        {
            this.Cached = false;
            this.ResponseCode = (int)rawResponse.StatusCode;
            this.ResponseData = rawResponse.Content == null ? null : JsonConvert.DeserializeObject<Json.DiscoveryResponseData>(rawResponse.Content);
            this.Headers = rawResponse.Headers;
            this.Ttl = CalculateTTL(this.ResponseData?.ttl);

            this.OperatorUrls = OperatorUrls.Parse(this.ResponseData);

            if(this.ResponseData.error != null)
            {
                this.ErrorResponse = new ErrorResponse() { Error = ResponseData.error, ErrorDescription = ResponseData.description };
            }
        }

        private DateTime CalculateTTL(long? responseTtl)
        {
            DateTime now = DateTime.UtcNow;
            DateTime epoch = new DateTime(1970, 1, 1);
            DateTime min = now.AddMilliseconds(DefaultOptions.MIN_TTL_MS);
            DateTime max = now.AddMilliseconds(DefaultOptions.MAX_TTL_MS);

            if(responseTtl == null)
            {
                return min;
            }

            DateTime currentTtl = epoch.AddMilliseconds(responseTtl.Value);
            return currentTtl.CompareTo(min) == -1 ? min : currentTtl.CompareTo(max) == 1 ? max : currentTtl;
        }
    }
}
