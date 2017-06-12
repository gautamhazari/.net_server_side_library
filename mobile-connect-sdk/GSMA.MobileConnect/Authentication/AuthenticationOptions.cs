using GSMA.MobileConnect.Claims;
using GSMA.MobileConnect.Constants;

namespace GSMA.MobileConnect.Authentication
{
    /// <summary>
    /// Holds required and optional options for <see cref="IAuthenticationService.StartAuthentication(string, string, string, string, string, string, Discovery.SupportedVersions, AuthenticationOptions)"/>
    /// </summary>
    /// <seealso cref="IAuthenticationService"/>
    public class AuthenticationOptions
    {
        /// <summary>
        /// The registered client id
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// The registered application redirect url
        /// </summary>
        public string RedirectUrl { get; set; }

        /// <summary>
        /// Authentication Context class Reference. Space separated string that specifies the Authentication Context Reference to be used during authentication processing. 
        /// Mobile Connect Authentication and Authorization support the values "2" and "3", 2 specifies authenticate/authorize and 3 specifies autthenticate/authorize plus.
        /// If required the server may override the ACR value passed to force a higher level of assurance or if the required level of assurance is temporarily unavailable, 
        /// if this happens the ID Token will contain the actual acr value used
        /// </summary>
        public string AcrValues { get; set; } = DefaultOptions.AUTHENTICATION_ACR_VALUES;

        /// <summary>
        /// Space delimited and case-sensitive list of ASCII strings for OAuth 2.0 scope values. 
        /// OIDC Authorisation request MUST contain the scope value “openid”. 
        /// The other optional values for scope in OIDC are: "profile", "email", "address", "phone" and "offline_access".
        /// </summary>
        public string Scope { get; set; } = DefaultOptions.AUTHENTICATION_SCOPE;

        /// <summary>
        /// String value used to associate a client session with the ID Token. It is passed unmodified from Authorisation Request to ID Token. The value SHOULD be unique per session to mitigate replay attacks.
        /// </summary>
        public string Nonce { get; set; }

        /// <summary>
        /// Value used by the client to maintain state between request and callback. A security mechanism as well, if a cryptographic binding is done with the browser cookie, to prevent Cross-Site Request Forgery.
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// Specifies the maximum elapsed time in seconds since last authentication of the user. 
        /// If the elapsed time is greater than this value, a reauthentication MUST be done. 
        /// When this parameter is used in the request, the ID Token MUST contain the auth_time claim value.
        /// </summary>
        public int MaxAge { get; set; } = DefaultOptions.AUTHENTICATION_MAX_AGE;

        /// <summary>
        /// ASCII String value to specify the user interface display for the Authentication and Consent flow.
        /// See remarks form more information.
        /// </summary>
        /// <remarks>
        /// The values can be:
        /// <para>- "page": Default value, if the display parameter is not added. The UI SHOULD be consistent with a full page view of the User-Agent.</para>
        /// <para>- "popup": The popup window SHOULD be 450px X 500px [wide X tall].</para>
        /// <para>- "touch": The Authorization Server SHOULD display the UI consistent with a "touch" based interface.</para>
        /// <para>- "wap": The UI SHOULD be consistent with a "feature-phone" device display.</para>
        /// </remarks>
        public string Display { get; set; } = DefaultOptions.DISPLAY;

        /// <summary>
        /// Space delimited, case-sensitive ASCII string values to specify to the Authorization Server whether to prompt or
        /// not for reauthentication and consent.
        /// See remarks for more information.
        /// </summary>
        /// <remarks>
        /// The values can be:
        /// <para>
        /// - "none": MUST NOT display any UI for reauthentication or consent to the user. If the user is not authenticated already, or authentication or consent is needed to process the Authorization Request, 
        /// a login_required error is returned. This can be used as a mechanism to check existing authentication or consent.
        /// </para>
        /// <para>- "login": SHOULD prompt the user for reauthentication or consent. In case it cannot be done, an error MUST be returned.</para>
        /// <para>- "consent": SHOULD display a UI to get consent from the user.</para>
        /// <para>- "select_account": In the situations, where the user has multiple accounts with the IDP/Authorization Server, this SHOULD prompt the user to select the account.If it cannot be done, an error MUST be returned.</para>
        /// </remarks>
        public string Prompt { get; set; }

        /// <summary>
        /// Space separated list of user preferred languages and scripts for the UI being returned as per RFC5646.
        /// </summary>
        /// <remarks>
        /// This parameter is for guidance only and in case the locales are not supported, error SHOULD NOT be returned.
        /// </remarks>
        public string UiLocales { get; set; }

        /// <summary>
        /// Space separated list of user preferred languages and scripts for the Claims being returned as per RFC5646.
        /// </summary>
        /// <remarks>
        /// This parameter is for guidance only and in case the locales are not supported, error SHOULD NOT be returned.
        /// </remarks>
        public string ClaimsLocales { get; set; }

        /// <summary>
        /// Correlation id
        /// </summary>
        public string CorrelationId { get; set; }

        /// <summary>
        /// is Using Correlation id
        /// </summary>
        public bool IsUsingCorrelationId { get; set; }
        
        /// <summary>
        /// Generally used in conjunction with prompt=none to pass the previously issued ID Token as a hint for the current
        /// or past authentication session.
        /// See remarks for more information.
        /// </summary>
        /// <remarks>
        /// If the ID Token is still valid and the user is logged in then the server returns
        /// a positive response, otherwise SHOULD return a login_error response.For the ID Token, the server need not be
        /// listed as audience, when included in the id_token_hint.
        /// </remarks>
        public string IdTokenHint { get; set; }

        /// <summary>
        /// An indication to the IDP/Authorization Server on what ID to use for login.
        /// If known this will default to the encrypted MSISDN value.
        /// See remarks for more information.
        /// </summary>
        /// <remarks>
        /// The login_hint can contain the MSISDN or the Encrypted MSISDN and SHOULD be tagged as MSISDN:&lt;Value&gt;
        /// and ENCR_MSISDN:&lt;Value&gt; respectively - in case MSISDN or Encrypted MSISDN is passed in login_hint.
        /// Encrypted MSISDN value is returned by Discovery API in the form of "subscriber_id"
        /// </remarks>
        public string LoginHint { get; set; }

        /// <summary>
        /// The "login_hint_token" produced by the Discovery service is an encrypted 
        /// JSON Web Token JWT [RFC7519] that contains a user hint for an individual OP.
        /// </summary>
        /// <remarks>
        /// This token is typically created by an MODRNA discovery service if a user 
        /// has entered an MSISDN during the discovery process.  The "login_hint_token" 
        /// SHALL be used by the client as login hint with the particular OP. (future scope)
        /// </remarks>
        public string LoginHintToken { get; set; }

        /// <summary>
        /// The Data to be signed by the private key owned by the end user.
        /// The signed data in the ID Claim as private JWT claims for this profile.
        /// </summary>
        public string Dtbs { get; set; }

        /// <summary>
        /// ApplicationShortName for the registered application, this must be correct for the application client id
        /// when authorizing with mc_authz or authentication will fail
        /// </summary>
        public string ClientName { get; set; }

        /// <summary>
        /// Context of the action being authorized, when authorizing using mc_authz this will be displayed
        /// to the user along with the <see cref="ClientName"/> and <see cref="BindingMessage"/> to allow
        /// the user to identify the authorization request
        /// </summary>
        public string Context { get; set; }

        /// <summary>
        /// Binding message to be displayed to the user when authorizing using mc_authz this will be displayed
        /// to the user along with the <see cref="ClientName"/> and <see cref="Context"/> to allow
        /// the user to identify the authorization request. This is optional.
        /// </summary>
        public string BindingMessage { get; set; }

        /// <summary>
        /// JSON claims to be requested during authentication/authorization as specified in openid-connect-core-1_0 section 5.5.
        /// </summary>
        public string ClaimsJson { get; set; }

        /// <summary>
        /// Claims to be requested during authentication/authorization, this will be serialized as JSON that conforms to the required claims format.
        /// If <see cref="ClaimsJson"/> is specified then this property will be ignored
        /// </summary>
        public ClaimsParameter Claims { get; set; }

        /// <summary>
        /// Time in ms to wait between each poll for new redirect url when in headless mode.
        /// </summary>
        public int PollFrequencyInMs { get; set; } = 100;

        /// <summary>
        /// The number of redirects to allow during headless mode before aborting.
        /// </summary>
        public int MaxRedirects { get; set; } = 50;

        /// <summary>
        /// Constructor
        /// </summary>
        public AuthenticationOptions()
        {
            IsUsingCorrelationId = false;
        }
    }
}
