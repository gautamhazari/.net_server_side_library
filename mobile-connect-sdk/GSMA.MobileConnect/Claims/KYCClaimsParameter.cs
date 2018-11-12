using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GSMA.MobileConnect.Claims
{
    /// <summary>
    /// Class to construct required kyc claims for the mobile connect process
    /// </summary>
    class KYCClaimsParameter
    {
        /// <summary>
        /// Concatenated given_name and family_name. 
        /// </summary>
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        /// <summary>
        /// Given name(s) or first name(s) of the End-User.
        /// </summary>
        [JsonProperty("given_name", NullValueHandling = NullValueHandling.Ignore)]
        public string GivenName { get; set; }

        /// <summary>
        /// Family name(s), surname(s) or last name(s) of the End-User.
        /// </summary>
        [JsonProperty("family_name", NullValueHandling = NullValueHandling.Ignore)]
        public string FamilyName { get; set; }

        /// <summary>
        /// Concatenated houseno_or_housename, postal_code and optionally town and country. 
        /// </summary>
        [JsonProperty("address", NullValueHandling = NullValueHandling.Ignore)]
        public string Address { get; set; }

        /// <summary>
        /// Registered house number or house name.
        /// </summary>
        [JsonProperty("houseno_or_housename", NullValueHandling = NullValueHandling.Ignore)]
        public string HousenoOrHouseName { get; set; }

        /// <summary>
        /// Registered Zip code or post code.
        /// </summary>
        [JsonProperty("postal_code", NullValueHandling = NullValueHandling.Ignore)]
        public string PostalCode { get; set; }

        /// <summary>
        /// Registered city or town name.
        /// </summary>
        [JsonProperty("town", NullValueHandling = NullValueHandling.Ignore)]
        public string Town { get; set; }

        /// <summary>
        /// Registered country.
        /// </summary>
        [JsonProperty("country", NullValueHandling = NullValueHandling.Ignore)]
        public string Country { get; set; }

        /// <summary>
        /// End-User's birthday.
        /// </summary>
        [JsonProperty("birthdate", NullValueHandling = NullValueHandling.Ignore)]
        public string Birthdate { get; set; }

        /// <summary>
        /// Concatenated given_name and family_name. 
        /// </summary>
        [JsonProperty("name_hashed", NullValueHandling = NullValueHandling.Ignore)]
        public string NameHashed { get; set; }

        /// <summary>
        /// Given name(s) or first name(s) of the End-User.
        /// </summary>
        [JsonProperty("given_name_hashed", NullValueHandling = NullValueHandling.Ignore)]
        public string GivenNameHashed { get; set; }

        /// <summary>
        /// Family name(s), surname(s) or last name(s) of the End-User.
        /// </summary>
        [JsonProperty("family_name_hashed", NullValueHandling = NullValueHandling.Ignore)]
        public string FamilyNameHashed { get; set; }

        /// <summary>
        /// Concatenated houseno_or_housename, postal_code and optionally town and country. 
        /// </summary>
        [JsonProperty("address_hashed", NullValueHandling = NullValueHandling.Ignore)]
        public string AddressHashed { get; set; }

        /// <summary>
        /// Registered house number or house name.
        /// </summary>
        [JsonProperty("houseno_or_housename_hashed", NullValueHandling = NullValueHandling.Ignore)]
        public string HousenoOrHouseNameHashed { get; set; }

        /// <summary>
        /// Registered Zip code or post code.
        /// </summary>
        [JsonProperty("postal_code_hashed", NullValueHandling = NullValueHandling.Ignore)]
        public string PostalCodeHashed { get; set; }

        /// <summary>
        /// Registered city or town name.
        /// </summary>
        [JsonProperty("town_hashed", NullValueHandling = NullValueHandling.Ignore)]
        public string TownHashed { get; set; }

        /// <summary>
        /// Registered country.
        /// </summary>
        [JsonProperty("country_hashed", NullValueHandling = NullValueHandling.Ignore)]
        public string CountryHashed { get; set; }

        /// <summary>
        /// End-User's birthday.
        /// </summary>
        [JsonProperty("birthdate_hashed", NullValueHandling = NullValueHandling.Ignore)]
        public string BirthdateHashed { get; set; }
    }
}