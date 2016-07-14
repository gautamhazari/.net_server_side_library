namespace GSMA.MobileConnect
{
    /// <summary>
    /// Constants relating to Mobile Connect such as available scope values
    /// </summary>
    public static class MobileConnectConstants
    {
        /// <summary>
        /// Default required scope value
        /// </summary>
        public const string MOBILECONNECT = "openid";

        /// <summary>
        /// Scope value for Authentication
        /// </summary>
        public const string MOBILECONNECTAUTHENTICATION = "openid mc_authn";

        /// <summary>
        /// Scope value for Authorization
        /// </summary>
        public const string MOBILECONNECTAUTHORIZATION = "openid mc_authz";

        /// <summary>
        /// Scope value for Identity Phone Number
        /// </summary>
        public const string MOBILECONNECTIDENTITYPHONE = "openid mc_identity_phonenumber";

        /// <summary>
        /// Scope value for Identity Signup
        /// </summary>
        public const string MOBILECONNECTIDENTITYSIGNUP = "openid mc_identity_signup";

        /// <summary>
        /// Scope value for Identity Signup Plus
        /// </summary>
        public const string MOBILECONNECTIDENTITYSIGNUPPLUS = "openid mc_identity_signupplus";

        /// <summary>
        /// Scope value for Identity National ID
        /// </summary>
        public const string MOBILECONNECTIDENTITYNATIONALID = "openid mc_identity_nationalid";
    }
}
