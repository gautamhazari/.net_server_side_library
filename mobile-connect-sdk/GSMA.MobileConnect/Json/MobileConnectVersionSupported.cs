using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSMA.MobileConnect.Json
{
    public class MobileConnectVersionSupported
    {
        /// <summary>
        /// The supported version for all requests if specific values have not been provided
        /// </summary>
        [JsonProperty("openid")]
        public string OpenId { get; set; }

        /// <summary>
        /// The supported version for Mobile Connect Authentication requests
        /// </summary>
        [JsonProperty("openid mc_authn")]
        public string Authentication { get; set; }

        /// <summary>
        /// The supported version for Mobile Connect Authorization requests
        /// </summary>
        [JsonProperty("openid mc_authz")]
        public string Authorization { get; set; }

        /// <summary>
        /// The supported version for Mobile Connect Identity requests
        /// </summary>
        [JsonProperty("openid mc_identity_phonenumber")]
        public string IdentityPhoneNumber { get; set; }

        /// <summary>
        /// The supported version for Mobile Connect Identity requests
        /// </summary>
        [JsonProperty("openid mc_identity_signup")]
        public string IdentitySignup { get; set; }

        /// <summary>
        /// The supported version for Mobile Connect Identity requests
        /// </summary>
        [JsonProperty("openid mc_identity_signupplus")]
        public string IdentitySignupPlus { get; set; }

        /// <summary>
        /// The supported version for Mobile Connect Identity requests
        /// </summary>
        [JsonProperty("openid mc_identity_nationalid")]
        public string IdentityNationalId { get; set; }
    }
}
