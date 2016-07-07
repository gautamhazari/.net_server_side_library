using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSMA.MobileConnect.Claims
{
    /// <summary>
    /// Class to construct required claims for the mobile connect process
    /// </summary>
    public class ClaimsParameter
    {
        /// <summary>
        /// Claims that are requested to be included in the returned UserInfo/Premium info response
        /// </summary>
        [JsonProperty("userinfo", NullValueHandling = NullValueHandling.Ignore)]
        public ClaimsDictionary UserInfo { get; set; } = new ClaimsDictionary();

        /// <summary>
        /// Claims that are requested to be included in the returned IdToken from Authentication and Authorization
        /// </summary>
        [JsonProperty("id_token", NullValueHandling = NullValueHandling.Ignore)]
        public ClaimsDictionary IdToken { get; set; } = new ClaimsDictionary();
    }
}
