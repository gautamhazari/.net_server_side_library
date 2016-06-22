using GSMA.MobileConnect.Cache;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSMA.MobileConnect.Discovery
{
    /// <summary>
    /// Parsed Provider Metadata returned from openid-configuration url
    /// </summary>
    public class ProviderMetadata : ICacheable
    {
        /// <inheritdoc/>
        public bool Cached { get; set; }

        /// <inheritdoc/>
        [JsonIgnore]
        public bool HasExpired { get; private set; }

        /// <inheritdoc/>
        public DateTime? TimeCachedUtc { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("version")]
        public string Version { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("issuer")]
        public string Issuer { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("authorization_endpoint")]
        public string AuthorizationEndpoint { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("token_endpoint")]
        public string TokenEndpoint { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("userinfo_endpoint")]
        public string UserInfoEndpoint { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("check_session_iframe")]
        public string CheckSessionIframe { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("end_session_endpoint")]
        public string EndSessionEndpoint { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("jwks_uri")]
        public string JwksUri { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("scopes_supported")]
        public List<string> ScopesSupported { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("response_types_supported")]
        public List<string> ResponseTypesSupported { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("grant_types_supported")]
        public List<string> GrantTypesSupported { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("acr_values_supported")]
        public List<string> ACRValuesSupported { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("subject_types_supported")]
        public List<string> SubjectTypesSupported { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("userinfo_signing_alg_values_supported")]
        public List<string> UserInfoSigningAlgValuesSupported { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("userinfo_encryption_alg_values_supported")]
        public List<string> UserInfoEncryptionAlgValuesSupported { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("userinfo_encryption_enc_values_supported")]
        public List<string> UserInfoEncryptionEncValuesSupported { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("id_token_signing_alg_values_supported")]
        public List<string> IdTokenSigningAlgValuesSupported { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("id_token_encryption_alg_values_supported")]
        public List<string> IdTokenEncryptionAlgValuesSupported { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("id_token_encryption_enc_values_supported")]
        public List<string> IdTokenEncryptionEncValuesSupported { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("request_object_signing_alg_values_supported")]
        public List<string> RequestObjectSigningAlgValuesSupported { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("request_object_encryption_alg_values_supported")]
        public List<string> RequestObjectEncryptionAlgValuesSupported { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("request_object_encryption_enc_values_supported")]
        public List<string> RequestObjectEncryptionEncValuesSupported { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("token_endpoint_auth_methods_supported")]
        public List<string> TokenEndpointAuthMethodsSupported { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("token_endpoint_auth_signing_alg_values_supported")]
        public List<string> TokenEndpointAuthSigningAlgValuesSupported { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("display_values_supported")]
        public List<string> DisplayValuesSupported { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("claim_types_supported")]
        public List<string> ClaimTypesSupported { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("claims_supported")]
        public List<string> ClaimsSupported { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("service_documentation")]
        public string ServiceDocumentation { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("claims_locales_supported")]
        public List<string> ClaimsLocalesSupported { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("ui_locales_supported")]
        public List<string> UiLocalesSupported { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("require_request_uri_registration")]
        public bool RequireRequestUriRegistration { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("op_policy_uri")]
        public string OperatorPolicyUri { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("op_tos_uri")]
        public string OperatorTermsOfServiceUri { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("claims_parameter_supported")]
        public bool ClaimsParameterSupported { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("request_parameter_supported")]
        public bool RequestParameterSupported { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("request_uri_parameter_supported")]
        public bool RequestUriParameterSupported { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("mobile_connect_version_supported")]
        public List<Json.MobileConnectVersionSupported> MobileConnectVersionSupported { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("login_hint_methods_supported")]
        public List<string> LoginHintMethodsSupported { get; set; }

        /// <inheritdoc/>
        public void MarkExpired(bool isExpired)
        {
            HasExpired = HasExpired || isExpired;
        }
    }
}
