using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSMA.MobileConnect.Json
{
    /// <summary>
    /// Object for deserialization of Discovery Response content
    /// </summary>
    public class Response
    {
        /// <summary>
        /// Parsed from JSON response
        /// </summary>
        public string serving_operator { get; set; }
        /// <summary>
        /// Parsed from JSON response
        /// </summary>
        public string country { get; set; }
        /// <summary>
        /// Parsed from JSON response
        /// </summary>
        public string currency { get; set; }
        /// <summary>
        /// Parsed from JSON response
        /// </summary>
        public Apis apis { get; set; }
        /// <summary>
        /// Parsed from JSON response
        /// </summary>
        public string client_id { get; set; }
        /// <summary>
        /// Parsed from JSON response
        /// </summary>
        public string client_secret { get; set; }
        /// <summary>
        /// Parsed from JSON response
        /// </summary>
        public string subscriber_id { get; set; }
    }
}
