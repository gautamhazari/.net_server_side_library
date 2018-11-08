using System.Collections.Generic;
using GSMA.MobileConnect.Json;
using Newtonsoft.Json;

namespace GSMA.MobileConnect.Discovery
{
    /// <summary>
    /// Allows to store discovery response generated options.
    /// </summary>
    public class DiscoveryResponseGenerateOptions
    {
        /// <summary>
        /// Client secret option
        /// </summary>
        public string ClientSecret { get; }
        /// <summary>
        /// Client id option
        /// </summary>
        public string ClientId { get; }
        /// <summary>
        /// Client application name
        /// </summary>
        public string ClientApplicationName { get; }
        /// <summary>
        /// List of links for generate fake discovery response
        /// </summary>
        public List<string> LinkList { get; }
        /// <summary>
        /// List of rels for generate fake discovery response
        /// </summary>
        public List<string> Rel { get; }
        /// <summary>
        /// Fake discovery response
        /// </summary>
        public DiscoveryResponseData Response { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="clientSecret">Client secret</param>
        /// <param name="clientId">Client id</param>
        /// <param name="subId">Subscriber id</param>
        /// <param name="appName">Client application name</param>
        /// <param name="links">List of links</param>
        /// <param name="rel">List of rels</param>
        public DiscoveryResponseGenerateOptions(string clientSecret, string clientId, string appName,
            List<string> links, List<string> rel)
        {
            ClientSecret = clientSecret;
            ClientId = clientId;
            ClientApplicationName = appName;
            LinkList = links;
            Rel = rel;
            Response = new DiscoveryResponseData()
            {
                response = new Response()
                {
                    apis = new Apis()
                    {
                        operatorid = new Operatorid()
                        {
                            link = new List<Link>()
                        }
                    }
                }
            };

            Response.response.client_id = ClientId;
            Response.response.client_secret = ClientSecret;
            Response.response.client_name = ClientApplicationName;
            var listOfLinks = LinkList;
            var listOfRels = Rel;

            for (var i = 0; i < listOfLinks.Count; i++)
            {
                Response.response.apis.operatorid.link.Add(new Link() { href = listOfLinks[i], rel = listOfRels[i] });
            }
        }

        /// <summary>
        /// Get json representation of discovery manually generated response
        /// </summary>
        /// <returns>Manually generated discovery response</returns>
        public string GetJsonResponse()
        {
            return JsonConvert.SerializeObject(Response);
        }
    }
}