using GSMA.MobileConnect.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSMA.MobileConnect.Authentication
{
    /// <summary>
    /// Holds required and optional options for <see cref="IAuthentication.StartAuthentication(string, string, string, string, string, string, int?, string, string, AuthenticationOptions)"/>
    /// </summary>
    /// <seealso cref="IAuthentication"/>
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
        /// The LOA required by the RP/Client for the use case can be used here. The values appear as order of preference. The acr satisfied during authentication is returned as acr claim value.
        /// The recommended values are the LOAs as specified in ISO/IEC 29115 Clause 6 – 1, 2, 3, 4 – representing the LOAs of LOW, MEDIUM, HIGH and VERY HIGH.
        /// The acr_values are indication of what authentication methods to used by the IDP. 
        /// The authentication methods to be used are linked to the LOA value passed in the acr_values. The IDP configures the authentication method selection logic based on the acr_values.
        /// </summary>
        public string AcrValues { get; set; }

        /// <summary>
        /// Space delimited and case-sensitive list of ASCII strings for OAuth 2.0 scope values. 
        /// OIDC Authorisation request MUST contain the scope value “openid”. 
        /// The other optional values for scope in OIDC are: "profile", "email", "address", "phone" and "offline_access".
        /// </summary>
        public string Scope { get; set; }

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
        public int MaxAge { get; set; }

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
        public string Display { get; set; }

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
        /// The Data to be signed by the private key owned by the end user.
        /// The signed data in the ID Claim as private JWT claims for this profile.
        /// </summary>
        public string Dtbs { get; set; }

        /// <inheritdoc/>
        public AuthenticationOptions()
        {
            this.Display = DefaultOptions.DISPLAY;
            this.AcrValues = DefaultOptions.AUTHENTICATION_ACR_VALUES;
            this.Scope = DefaultOptions.AUTHENTICATION_SCOPE;
            this.MaxAge = DefaultOptions.AUTHENTICATION_MAX_AGE;
        }
    }
}
