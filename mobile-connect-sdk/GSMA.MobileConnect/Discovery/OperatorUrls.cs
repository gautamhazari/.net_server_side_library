using GSMA.MobileConnect.Constants;
using GSMA.MobileConnect.Json;
using System.Collections.Generic;
using System.Linq;

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
        /// Url for user info call
        /// </summary>
        public string UserInfoUrl { get; set; }

        /// <summary>
        /// Url for JWKS info
        /// </summary>
        public string JWKSUrl { get; set; }

        /// <summary>
        /// Url for Provider Metadata
        /// </summary>
        public string ProviderMetadataUrl { get; set; }

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

            return new OperatorUrls()
            {
                AuthorizationUrl = GetUrl(links, LinkRels.AUTHORIZATION),
                RequestTokenUrl = GetUrl(links, LinkRels.TOKEN),
                UserInfoUrl = GetUrl(links, LinkRels.USERINFO),
                JWKSUrl = GetUrl(links, LinkRels.JWKS),
                ProviderMetadataUrl = GetUrl(links, LinkRels.OPENID_CONFIGURATION),
            };
        }

        /// <summary>
        /// Replaces URLs from the discovery response with URLs from the provider metadata.
        /// This allows providers to use temporary urls while the main url is down for maintenance.
        /// </summary>
        /// <param name="metadata">Metadata to get overriding urls from</param>
        internal void OverrideUrls(ProviderMetadata metadata)
        {
            if(metadata == null)
            {
                return;
            }

            AuthorizationUrl = metadata.AuthorizationEndpoint ?? AuthorizationUrl;
            RequestTokenUrl = metadata.TokenEndpoint ?? RequestTokenUrl;
            UserInfoUrl = metadata.UserInfoEndpoint ?? UserInfoUrl;
            JWKSUrl = metadata.JwksUri ?? JWKSUrl;
        }

        private static string GetUrl(IEnumerable<Link> links, string rel)
        {
            return links.FirstOrDefault(x => x.rel == rel)?.href;
        }
    }
}
