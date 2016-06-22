using GSMA.MobileConnect.Constants;
using GSMA.MobileConnect.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSMA.MobileConnect.Discovery
{
    /// <summary>
    /// Object to hold the operator specific urls returned from a successful discovery process call
    /// </summary>
    public class OperatorUrls
    {
        /// <summary>
        /// Url for authorization call
        /// </summary>
        public string AuthorizationUrl { get; set; }

        /// <summary>
        /// Url for token request call
        /// </summary>
        public string RequestTokenUrl { get; set; }

        /// <summary>
        /// Parses the operator urls from the parsed DiscoveryResponseData
        /// </summary>
        /// <param name="data">Data from the successful discovery response</param>
        /// <returns>Parsed operator urls or null if no urls found</returns>
        public static OperatorUrls Parse(DiscoveryResponseData data)
        {
            var links = data?.response?.apis?.operatorid?.link;
            if (links == null)
            {
                return null;
            }

            var authorize = links.FirstOrDefault(x => x.rel == LinkRels.AUTHORIZATION).href;
            var token = links.FirstOrDefault(x => x.rel == LinkRels.TOKEN).href;

            return new OperatorUrls() { AuthorizationUrl = authorize, RequestTokenUrl = token };
        }
    }
}
