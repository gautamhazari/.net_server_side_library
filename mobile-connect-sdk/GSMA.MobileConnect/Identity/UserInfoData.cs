using GSMA.MobileConnect.Json.Converters;
using Newtonsoft.Json;
using System;

namespace GSMA.MobileConnect.Identity
{
    /// <summary>
    /// Class containing properties for all available openid connect 1.0 UserInfo claims, can be used to retrieve <see cref="IdentityResponse.ResponseJson"/> as a concrete object.
    /// Use the <see cref="IdentityResponse.ResponseDataAs{T}"/> method with this type as the parameter T. 
    /// Alternatively a leaner type or type with additional custom properties can be provided for more control over the deserialization process.
    /// </summary>
    /// <seealso cref="IdentityResponse"/>
    public class UserInfoData
    {
        /// <summary>
        /// Subject - Identifier for the End-User at the Issuer
        /// </summary>
        [JsonProperty("sub")]
        public string Sub { get; set; }

        #region Profile

        /// <summary>
        /// End-User's full name in a displayable form including all name parts, possibly including titles and suffixes, ordered according to the End-User's locale and preferences.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Surname(s) or last name(s) of the End-User. Note that in some cultures, people can have multiple family names or no family name; 
        /// all can be present with the names being separated by space characters
        /// </summary>
        [JsonProperty("family_name")]
        public string FamilyName { get; set; }

        /// <summary>
        /// Given name(s) or first name(s) of the End-User. Note that in some cultures, people can have multiple given names;
        /// all can be present, with the names being separated by space characters
        /// </summary>
        [JsonProperty("given_name")]
        public string GivenName { get; set; }

        /// <summary>
        /// Middle name(s) of the End-User. Note that in some cultures, people can have multiple middle names;
        /// all can be present, with the names being separated by space characters
        /// </summary>
        [JsonProperty("middle_name")]
        public string MiddleName { get; set; }

        /// <summary>
        /// Casual name of the End-User that may or may not be the same as the <see cref="GivenName"/>. For instance a Nickname value of Mike may return
        /// alongside a <see cref="GivenName"/> of Michael
        /// </summary>
        [JsonProperty("nickname")]
        public string Nickname { get; set; }

        /// <summary>
        /// Shorthand name by which the End-User wishes to be referred to at the RP, such as janedoe or j.doe. This value MAY be any valid JSON string including special characters such as @, /, or whitespace. 
        /// The RP MUST NOT rely upon this value being unique, as discussed in open-id-connect-core-1_0 Section 5.7
        /// </summary>
        [JsonProperty("preferred_username")]
        public string PreferredUsername { get; set; }

        /// <summary>
        /// URL of the End-User's profile page. The contents of this Web page SHOULD be about the End-User.
        /// </summary>
        [JsonProperty("profile")]
        public string Profile { get; set; }

        /// <summary>
        /// URL of the End-User's profile picture. 
        /// This URL MUST refer to an image file (for example, a PNG, JPEG, or GIF image file), rather than to a Web page containing an image. 
        /// Note that this URL SHOULD specifically reference a profile photo of the End-User suitable for displaying when describing the End-User, rather than an arbitrary photo taken by the End-User.
        /// </summary>
        [JsonProperty("picture")]
        public string Picture { get; set; }

        /// <summary>
        /// URL of the End-User's Web page or blog. This Web page SHOULD contain information published by the End-User or an organization that the End-User is affiliated with.
        /// </summary>
        [JsonProperty("website")]
        public string Website { get; set; }

        /// <summary>
        /// End-User's gender. Values defined by this specification are female and male. Other values MAY be used when neither of the defined values are applicable.
        /// </summary>
        [JsonProperty("gender")]
        public string Gender { get; set; }

        /// <summary>
        /// End-User's birthday
        /// </summary>
        [JsonProperty("birthdate")]
        [JsonConverter(typeof(IsoDateConverter))]
        public DateTime? Birthdate { get; set; }

        /// <summary>
        /// String from zoneinfo time zone database representing the End-User's time zone. For example, Europe/Paris or America/Los_Angeles.
        /// </summary>
        [JsonProperty("zoneinfo")]
        public string ZoneInfo { get; set; }

        /// <summary>
        /// End-User's locale, represented as a BCP47 [RFC5646] language tag. 
        /// This is typically an ISO 639-1 Alpha-2 [ISO639‑1] language code in lowercase and an ISO 3166-1 Alpha-2 [ISO3166‑1] country code in uppercase, separated by a dash. 
        /// For example, en-US or fr-CA. As a compatibility note, some implementations have used an underscore as the separator rather than a dash, for example, en_US; 
        /// Relying Parties MAY choose to accept this locale syntax as well.
        /// </summary>
        [JsonProperty("locale")]
        public string Locale { get; set; }

        /// <summary>
        /// Time the End-User's information was last updated in UTC time
        /// </summary>
        [JsonProperty("updated_at")]
        [JsonConverter(typeof(UnixTimestampConverter))]
        public DateTime? UpdatedAt { get; set; }

        #endregion

        #region Email

        /// <summary>
        /// End-User's preferred e-mail address. Its value MUST conform to the RFC 5322 [RFC5322] addr-spec syntax. 
        /// The RP MUST NOT rely upon this value being unique, as discussed in open-id-connect-core-1_0 Section 5.7
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; set; }

        /// <summary>
        /// True if the End-User's e-mail address has been verified; otherwise false.
        /// When this Claim Value is true, this means that the OP took affirmative steps to ensure that this e-mail address was controlled by the End-User at the time the verification was performed.
        /// The means by which an e-mail address is verified is context-specific, and dependent upon the trust framework or contractual agreements within which the parties are operating.
        /// </summary>
        [JsonProperty("email_verified")]
        public bool EmailVerified { get; set; }

        #endregion

        #region Address

        /// <summary>
        /// End-User's preferred postal address.
        /// </summary>
        [JsonProperty("address")]
        public AddressData Address { get; set; }

        #endregion

        #region Phone

        /// <summary>
        /// End-User's preferred telephone number. E.164 [E.164] is RECOMMENDED as the format of this Claim, for example, +1 (425) 555-1212 or +56 (2) 687 2400. 
        /// If the phone number contains an extension, it is RECOMMENDED that the extension be represented using the RFC 3966 [RFC3966] extension syntax, for example, +1 (604) 555-1234;ext=5678.
        /// </summary>
        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// True if the End-User's phone number has been verified; otherwise false. 
        /// When this Claim Value is true, this means that the OP took affirmative steps to ensure that this phone number was controlled by the End-User at the time the verification was performed. 
        /// The means by which a phone number is verified is context-specific, and dependent upon the trust framework or contractual agreements within which the parties are operating. 
        /// When true, the phone_number Claim MUST be in E.164 format and any extensions MUST be represented in RFC 3966 format.
        /// </summary>
        [JsonProperty("phone_number_verified")]
        public bool PhoneNumberVerified { get; set; }

        #endregion
    }
}
