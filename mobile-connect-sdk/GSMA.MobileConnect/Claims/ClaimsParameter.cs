using Newtonsoft.Json;

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

        /// <summary>
        /// Returns true if no claims will be requested using this claims parameter
        /// </summary>
        [JsonIgnore]
        public bool IsEmpty
        {
            get { return UserInfo.Count == 0 && IdToken.Count == 0; }
        }
    }
}
