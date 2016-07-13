using GSMA.MobileConnect.Cache;
using GSMA.MobileConnect.Constants;
using GSMA.MobileConnect.Utils;
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
        /// The version of provider metadata
        /// </summary>
        [JsonProperty("version")]
        public string Version { get; set; }

        /// <summary>
        /// The name of the issuer the provider metadata is related to. This value is used when validating the returned ID Token
        /// </summary>
        [JsonProperty("issuer")]
        public string Issuer { get; set; }

        /// <summary>
        /// Authorization endpoint to use if different from url returned by discovery
        /// </summary>
        [JsonProperty("authorization_endpoint")]
        public string AuthorizationEndpoint { get; set; }

        /// <summary>
        /// Token endpoint to use if different from url returned by discovery
        /// </summary>
        [JsonProperty("token_endpoint")]
        public string TokenEndpoint { get; set; }

        /// <summary>
        /// UserInfo endpoint to use if different from url returned by discovery
        /// </summary>
        [JsonProperty("userinfo_endpoint")]
        public string UserInfoEndpoint { get; set; }

        /// <summary>
        /// PremiumInfo endpoint to use if different from url returned by discovery
        /// </summary>
        [JsonProperty("premiuminfo_endpoint")]
        public string PremiumInfoEndpoint { get; set; }

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
        /// Revoke Token endpoint to use if different from url returned by discovery
        /// </summary>
        [JsonProperty("revoke_endpoint")]
        public string RevokeEndpoint { get; set; }

        /// <summary>
        /// Registration endpoint to use if different from url returned by discovery
        /// </summary>
        [JsonProperty("registration_endpoint")]
        public string RegistrationEndpoint { get; set; }

        /// <summary>
        /// JWKS endpoint to use if different from url returned by discovery
        /// </summary>
        [JsonProperty("jwks_uri")]
        public string JwksUri { get; set; }

        /// <summary>
        /// A list of OAuth 2.0 scope values that the issuer supports, these can be easily queried using <see cref="DiscoveryResponse.IsMobileConnectServiceSupported(string)"/>
        /// </summary>
        [JsonProperty("scopes_supported")]
        public List<string> ScopesSupported { get; set; }

        /// <summary>
        /// Array containing OAuth 2.0 response_type values that the issuer supports
        /// </summary>
        [JsonProperty("response_types_supported")]
        public List<string> ResponseTypesSupported { get; set; }

        /// <summary>
        /// Array containing OAuth 2.0 response_mode values that the issuer supports, as specified in OAuth 2.0 Multiple Response Type Encoding Practices
        /// </summary>
        [JsonProperty("response_modes_supported")]
        public List<string> ResponseModesSupported { get; set; }

        /// <summary>
        /// Array containing OAuth 2.0 grant_type values that the issuer supports
        /// </summary>
        [JsonProperty("grant_types_supported")]
        public List<string> GrantTypesSupported { get; set; } = new List<string> { "authorization_code", "implicit" };

        /// <summary>
        /// Array containing Authentication Context Class References that the issuer supports
        /// </summary>
        [JsonProperty("acr_values_supported")]
        public List<string> ACRValuesSupported { get; set; }

        /// <summary>
        /// Array containing a list of the Subject Identifier Types that the issuer supports
        /// </summary>
        [JsonProperty("subject_types_supported")]
        public List<string> SubjectTypesSupported { get; set; }

        /// <summary>
        /// Array containing the JWS signing algorithms [JWA] supported by the issuer for the UserInfo Endpoint to encode the claims in a JWT
        /// </summary>
        [JsonProperty("userinfo_signing_alg_values_supported")]
        public List<string> UserInfoSigningAlgValuesSupported { get; set; }

        /// <summary>
        /// Array containing a list of the JWE encryption algorithms (alg values) [JWA] supported by the issuer for the UserInfo Endpoint to encode the claims in a JWT
        /// </summary>
        [JsonProperty("userinfo_encryption_alg_values_supported")]
        public List<string> UserInfoEncryptionAlgValuesSupported { get; set; }

        /// <summary>
        /// Array containing a list of the JWE encryption algorithms (enc values) [JWE] supported by the issuer for the UserInfo Endpoint to encode the claims in a JWT
        /// </summary>
        [JsonProperty("userinfo_encryption_enc_values_supported")]
        public List<string> UserInfoEncryptionEncValuesSupported { get; set; }

        /// <summary>
        /// Array containing the JWS signing algorithms [JWA] supported by the issuer for the ID Token to encode the claims in a JWT
        /// </summary>
        [JsonProperty("id_token_signing_alg_values_supported")]
        public List<string> IdTokenSigningAlgValuesSupported { get; set; } = new List<string> { "RS256" };

        /// <summary>
        /// Array containing a list of the JWE encryption algorithms (alg values) [JWA] supported by the issuer for the ID Token to encode the claims in a JWT
        /// </summary>
        [JsonProperty("id_token_encryption_alg_values_supported")]
        public List<string> IdTokenEncryptionAlgValuesSupported { get; set; }

        /// <summary>
        /// Array containing a list of the JWE encryption algorithms (enc values) [JWE] supported by the issuer for the ID Token to encode the claims in a JWT
        /// </summary>
        [JsonProperty("id_token_encryption_enc_values_supported")]
        public List<string> IdTokenEncryptionEncValuesSupported { get; set; }

        /// <summary>
        /// Array containing the JWS signing algorithms [JWA] supported by the issuer for Request Objects which are described in Section 6.1 of OpenID Connect Core 1.0
        /// </summary>
        [JsonProperty("request_object_signing_alg_values_supported")]
        public List<string> RequestObjectSigningAlgValuesSupported { get; set; }

        /// <summary>
        /// Array containing the JWE encryption algorithms (alg values) [JWA] supported by the issuer for Request Objects which are described in Section 6.1 of OpenID Connect Core 1.0
        /// </summary>
        [JsonProperty("request_object_encryption_alg_values_supported")]
        public List<string> RequestObjectEncryptionAlgValuesSupported { get; set; }

        /// <summary>
        /// Array containing the JWE encryption algorithms (enc values) [JWE] supported by the issuer for Request Objects which are described in Section 6.1 of OpenID Connect Core 1.0
        /// </summary>
        [JsonProperty("request_object_encryption_enc_values_supported")]
        public List<string> RequestObjectEncryptionEncValuesSupported { get; set; }

        /// <summary>
        /// Array containing the Client Authentication methods suppoorted by the Token Endpoint
        /// </summary>
        [JsonProperty("token_endpoint_auth_methods_supported")]
        public List<string> TokenEndpointAuthMethodsSupported { get; set; }

        /// <summary>
        /// Array containing the JWS signing algorithms (alg values) supported by the Token Endpoint for the signature on the JWT used to authenticate the client at the 
        /// Token Endpoint for the private_key_jwt and client_secret_jwt authentication methods
        /// </summary>
        [JsonProperty("token_endpoint_auth_signing_alg_values_supported")]
        public List<string> TokenEndpointAuthSigningAlgValuesSupported { get; set; }

        /// <summary>
        /// Array containing the display parameter values that the issuer supports
        /// </summary>
        [JsonProperty("display_values_supported")]
        public List<string> DisplayValuesSupported { get; set; }

        /// <summary>
        /// Array containing the Claim Types that the issuer supports. These Claim Types are described inn Section 5.6 of OpenID Connect Core 1.0
        /// </summary>
        [JsonProperty("claim_types_supported")]
        public List<string> ClaimTypesSupported { get; set; } = new List<string> { "normal" };

        /// <summary>
        /// Array containing the Claim Names of the Claims that the issuer MAY be able to supply values for. Note that for privacy or other reasons this may not be an exhaustive list
        /// </summary>
        [JsonProperty("claims_supported")]
        public List<string> ClaimsSupported { get; set; }

        /// <summary>
        /// URL of a page containing human readable information that developers might want or need to know when using the issuing service
        /// </summary>
        [JsonProperty("service_documentation")]
        public string ServiceDocumentation { get; set; }

        /// <summary>
        /// Array containing languages and scripts supported for values in Claims being returned as an array of BCP47 [RFC5646] language tag values. 
        /// Not all languages and scripts are necessarily supported for all Claim values
        /// </summary>
        [JsonProperty("claims_locales_supported")]
        public List<string> ClaimsLocalesSupported { get; set; }

        /// <summary>
        /// Array containing the languages and scripts supported for the user interface, represented as an array of BCP47 [RFC5646] language tag values
        /// </summary>
        [JsonProperty("ui_locales_supported")]
        public List<string> UiLocalesSupported { get; set; }

        /// <summary>
        /// Boolean value specifying whether the issuer requires any request_uri values used to be pre-registered using the request_uris registration parameter. Pre-registration is required when the value is true
        /// </summary>
        [JsonProperty("require_request_uri_registration")]
        public bool RequireRequestUriRegistration { get; set; } = false;

        /// <summary>
        /// URL that the OpenID Provider provides to the person registering the Client to read about the issuer requirements on how the Relying Party can use the data provided by the issuer.
        /// The registration process SHOULD display this URL to the person registering the Client if it is given
        /// </summary>
        [JsonProperty("op_policy_uri")]
        public string OperatorPolicyUri { get; set; }

        /// <summary>
        /// URL that the issuer provides to the person registering the Client to read about the issuers terms of service. The registration process SHOULD display this URL to the person registering the client if it is given
        /// </summary>
        [JsonProperty("op_tos_uri")]
        public string OperatorTermsOfServiceUri { get; set; }

        /// <summary>
        /// Boolean value specifying whether the issuer supports use of the claims parameter, with true indicating support
        /// </summary>
        [JsonProperty("claims_parameter_supported")]
        public bool ClaimsParameterSupported { get; set; } = false;

        /// <summary>
        /// Boolean value specifying whether the issuer supports use of the request parameter, with true indicating support
        /// </summary>
        [JsonProperty("request_parameter_supported")]
        public bool RequestParameterSupported { get; set; } = false;

        /// <summary>
        /// Boolean value specifying whether the issuer supports use of the request uri parameter, with true indicating support
        /// </summary>
        [JsonProperty("request_uri_parameter_supported")]
        public bool RequestUriParameterSupported { get; set; } = true;

        /// <summary>
        /// Dictionary of values that represent the supported versions for different mobile connect services from this provider. These versions are used when constructing calls to the services.
        /// </summary>
        [JsonProperty("mobile_connect_version_supported")]
        [JsonConverter(typeof(Json.Converters.SupportedVersionsConverter))]
        public SupportedVersions MobileConnectVersionSupported { get; set; }

        /// <summary>
        /// Array containing a list of the login hint methods supported by the issuer ID Gateway
        /// </summary>
        [JsonProperty("login_hint_methods_supported")]
        public List<string> LoginHintMethodsSupported { get; set; }

        /// <summary>
        /// Default ProviderMetadata instance used if an instance is not available
        /// </summary>
        public static ProviderMetadata Default
        {
            get { return new ProviderMetadata(null); }
        }

        /// <summary>
        /// Creates a new instance of the Provider Metadata class
        /// </summary>
        public ProviderMetadata() { }

        /// <summary>
        /// Creates a new intance of ProviderMetadata using the input dictionary for MobileConnectVersionSupported. This is used to construct the object when deserializing from JSON
        /// </summary>
        /// <param name="mobileConnectVersionSupported">Dictionary of version supported, if null will default to a populated dictionary</param>
        [JsonConstructor]
        public ProviderMetadata(SupportedVersions mobileConnectVersionSupported)
        {
            MobileConnectVersionSupported = mobileConnectVersionSupported ?? new SupportedVersions(null);
        }

        /// <inheritdoc/>
        public void MarkExpired(bool isExpired)
        {
            HasExpired = HasExpired || isExpired;
        }
    }
}
