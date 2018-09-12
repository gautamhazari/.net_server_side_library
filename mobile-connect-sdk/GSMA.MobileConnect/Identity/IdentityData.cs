using Newtonsoft.Json;

namespace GSMA.MobileConnect.Identity
{
    /// <summary>
    /// Class containing properties for all available Mobile Connect Identity Claims, can be used to retrieve <see cref="IdentityResponse.ResponseJson"/> as a concrete object.
    /// Use the <see cref="IdentityResponse.ResponseDataAs{T}"/> method with this type as the parameter T. 
    /// Alternatively a leaner type or type with additional custom properties can be provided for more control over the deserialization process.
    /// </summary>
    /// <seealso cref="IdentityResponse"/>
    public class IdentityData
    {
        /// <summary>
        /// Subject - Identifier for the End-User at the Issuer
        /// </summary>
        [JsonProperty("sub")]
        public string Sub { get; set; }

        #region Signup

        /// <summary>
        /// User's alternate/secondary telephone number
        /// </summary>
        [JsonProperty("phone_number_alternate")]
        public string PhoneNumberAlternate { get; set; }

        /// <summary>
        /// Users salutation/honorific
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// Given name(s)
        /// </summary>
        [JsonProperty("given_name")]
        public string GivenName { get; set; }

        /// <summary>
        /// Family name(s)
        /// </summary>
        [JsonProperty("family_name")]
        public string FamilyName { get; set; }

        /// <summary>
        /// Middle name(s)
        /// </summary>
        [JsonProperty("middle_name")]
        public string MiddleName { get; set; }

        /// <summary>
        /// User's street (incl. house name/number)
        /// </summary>
        [JsonProperty("street_address")]
        public string StreetAddress { get; set; }

        /// <summary>
        /// User's city
        /// </summary>
        [JsonProperty("city")]
        public string City { get; set; }

        /// <summary>
        /// User's State/County
        /// </summary>
        [JsonProperty("state")]
        public string State { get; set; }

        /// <summary>
        /// User's Zip/Postcode
        /// </summary>
        [JsonProperty("postal_code")]
        public string PostalCode { get; set; }

        /// <summary>
        /// User's postal country
        /// </summary>
        [JsonProperty("country")]
        public string Country { get; set; }

        /// <summary>
        /// User's email
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; set; }

        #endregion

        #region Phone

        /// <summary>
        /// User's Mobile Connect designated mobile number
        /// </summary>
        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }

        #endregion

        #region NationalId

        /// <summary>
        /// User's birthdate
        /// </summary>
        [JsonProperty("birthdate")]
        public string BirthDate { get; set; }

        /// <summary>
        /// User’s Identifier (eIDAS), any national identifier like Social Security Identifier, passport etc. (depends on the local regulations)
        /// </summary>
        [JsonProperty("national_identifier")]
        public string NationalIdentifier { get; set; }

        #endregion
    }
}
