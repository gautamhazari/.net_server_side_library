using Newtonsoft.Json;

namespace GSMA.MobileConnect.Identity
{
    /// <summary>
    /// Stores data related to an Address Claim received from UserInfo/PremiumInfo
    /// </summary>
    public class AddressData
    {
        /// <summary>
        /// Full mailing address, formatted for display or use on a mailing label.
        /// May contain multiple lines, separated by newlines (either "\r\n" or "\n")
        /// </summary>
        [JsonProperty("formatted")]
        public string Formatted { get; set; }

        /// <summary>
        /// Full street address component, which MAY include house number, street name, Post Office Box and multi line extended street address information.
        /// May contain multiple lines, separated by newlines (either "\r\n" or "\n")
        /// </summary>
        [JsonProperty("street_address")]
        public string StreetAddress { get; set; }

        /// <summary>
        /// City or locality
        /// </summary>
        [JsonProperty("locality")]
        public string Locality { get; set; }

        /// <summary>
        /// State, province, prefecture or region
        /// </summary>
        [JsonProperty("region")]
        public string Region { get; set; }

        /// <summary>
        /// Zip or postal code
        /// </summary>
        [JsonProperty("postal_code")]
        public string PostalCode { get; set; }

        /// <summary>
        /// Country name
        /// </summary>
        [JsonProperty("country")]
        public string Country { get; set; }
    }
}
