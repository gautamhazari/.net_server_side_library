using System.Collections.Generic;

namespace GSMA.MobileConnect.Json
{
    /// <summary>
    /// Object for deserialization of Discovery Response content
    /// </summary>
    public class DiscoveryResponseData
    {
        /// <summary>
        /// Parsed from JSON response
        /// </summary>
        public long ttl { get; set; }
        /// <summary>
        /// Parsed from JSON response
        /// </summary>
        public string subscriber_id { get; set; }
        /// <summary>
        /// Parsed from JSON response
        /// </summary>
        public string error { get; set; }
        /// <summary>
        /// Parsed from JSON response
        /// </summary>
        public string description { get; set; }
        /// <summary>
        /// Parsed from JSON response
        /// </summary>
        public List<Link> links { get; set; }
        /// <summary>
        /// Parsed from JSON response
        /// </summary>
        public Response response { get; set; }
    }
}
