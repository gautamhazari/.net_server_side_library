using GSMA.MobileConnect.Cache;
using GSMA.MobileConnect.Constants;
using GSMA.MobileConnect.Exceptions;
using GSMA.MobileConnect.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace GSMA.MobileConnect.Discovery
{
    /// <summary>
    /// Class to hold a discovery response. This potentially holds cached data as indicated by the cached property.
    /// </summary>
    /// <seealso cref="IDiscoveryService"/>
    public class DiscoveryResponse : ICacheable
    {
        private bool _cached;
        private bool _markedExpiredByCache;
        private ProviderMetadata _providerMetadata;

        /// <summary>
        /// True if the data came from the local cache
        /// </summary>
        [JsonIgnore]
        public bool Cached
        {
            get { return _cached; }
            set
            {
                _cached = value;

                // if this was cached we don't want to return someone elses subscriber id, so we clear it
                if(_cached && ResponseData?.subscriber_id != null)
                {
                    ResponseData.subscriber_id = null;
                }
            }
        }

        /// <inheritdoc/>
        public DateTime? TimeCachedUtc { get; set; }

        /// <summary>
        /// Time to live from the response
        /// </summary>
        [JsonProperty]
        public DateTime? Ttl { get; private set; }

        /// <summary>
        /// Has the reponse expired?
        /// If no Ttl is specified then it is assumed that the response has not expired
        /// </summary>
        [JsonIgnore]
        public bool HasExpired
        {
            get { return _markedExpiredByCache || (Ttl.HasValue && Ttl.Value.CompareTo(DateTime.UtcNow) <= 0); }
        }

        /// <summary>
        /// Returns the Http response code or 0 if the data is cached
        /// </summary>
        [JsonProperty]
        public int ResponseCode { get; private set; }

        /// <summary>
        /// Returns the list of Http headers in the response
        /// </summary>
        [JsonProperty]
        public List<BasicKeyValuePair> Headers { get; private set; }

        /// <summary>
        /// The response if the network request returned an error
        /// </summary>
        [JsonIgnore]
        public ErrorResponse ErrorResponse { get; set; }

        /// <summary>
        /// The parsed json response data
        /// </summary>
        [JsonProperty]
        public Json.DiscoveryResponseData ResponseData { get; private set; }

        /// <summary>
        /// The returned operator urls for authentication
        /// </summary>
        [JsonIgnore]
        public OperatorUrls OperatorUrls { get; private set; }

        /// <summary>
        /// The provider metadata associated with this response
        /// </summary>
        [JsonProperty]
        public ProviderMetadata ProviderMetadata
        {
            get { return _providerMetadata; }
            set
            {
                _providerMetadata = value;
                OverrideOperatorUrls(_providerMetadata);
            }
        }

        /// <summary>
        /// The 16 byte name which is pre-registered by the developer and returned from the API Exchange during Discovery
        /// </summary>
        [JsonProperty]
        public string ApplicationShortName { get; private set; }

        /// <summary>
        /// Creates an instance of the DiscoveryResponse class
        /// </summary>
        [JsonConstructor]
        public DiscoveryResponse(Json.DiscoveryResponseData responseData)
        {
            ParseResponseData(responseData);
            this.ResponseData = responseData;
        }

        /// <summary>
        /// Creates an instance of the DiscoveryResponse using data from a RestResponse instance
        /// </summary>
        /// <param name="rawResponse">RestResponse with discovery response content</param>
        public DiscoveryResponse(RestResponse rawResponse)
        {
            this.Cached = false;
            this.ResponseCode = (int)rawResponse.StatusCode;
            this.Headers = rawResponse.Headers;

            this.ResponseData = rawResponse.Content == null ? null : JsonConvert.DeserializeObject<Json.DiscoveryResponseData>(rawResponse.Content);
            ParseResponseData(ResponseData);
        }

        private void ParseResponseData(Json.DiscoveryResponseData responseData)
        {
            this.Ttl = Ttl.HasValue ? Ttl : CalculateTTL(responseData?.ttl);

            if (responseData == null)
            {
                return;
            }

            this.OperatorUrls = OperatorUrls.Parse(responseData);
            this.ApplicationShortName = responseData.response?.client_name;

            if (responseData.error != null)
            {
                this.ErrorResponse = new ErrorResponse() { Error = responseData.error, ErrorDescription = responseData.description, CorrelationId = responseData.correlation_id};
            }
        }

        private void OverrideOperatorUrls(ProviderMetadata metadata)
        {
            if(OperatorUrls == null)
            {
                return;
            }

            OperatorUrls.OverrideUrls(metadata);
        }

        /// <inheritdoc/>
        public void MarkExpired(bool isExpired)
        {
            _markedExpiredByCache = isExpired;
        }

        /// <summary>
        /// Check to see if provided scopes are supported by the operator linked to the discovery response
        /// </summary>
        /// <param name="scope">A space or comma delimited string of required scope values, if empty or null true will be returned</param>
        /// <exception cref="MobileConnectProviderMetadataUnavailableException">Throws if ProviderMetadata or ScopesSupported is unavailable</exception>
        /// <returns>True if all scope values requested are supported by the operator, false otherwise</returns>
        public bool IsMobileConnectServiceSupported(string scope)
        {
            if (string.IsNullOrEmpty(scope))
            {
                return true;
            }

            if(ProviderMetadata == null)
            {
                throw new MobileConnectProviderMetadataUnavailableException();
            }
            else if (ProviderMetadata.ScopesSupported == null || ProviderMetadata.ScopesSupported.Count == 0)
            {
                throw new MobileConnectProviderMetadataUnavailableException("ScopesSupported");
            }

            return ProviderMetadata.ScopesSupported.ContainsAllValues(scope, StringComparison.OrdinalIgnoreCase, ' ', ',');
        }

        private static DateTime CalculateTTL(long? responseTtl)
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
