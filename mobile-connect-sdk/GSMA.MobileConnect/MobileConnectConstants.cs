using GSMA.MobileConnect.Constants;

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
        public static readonly string MOBILECONNECT = Scope.OPENID;

        /// <summary>
        /// Scope value for Authentication
        /// </summary>
        public static readonly string MOBILECONNECTAUTHENTICATION = $"{Scope.OPENID} {Scope.AUTHN}";

        /// <summary>
        /// Scope value for Authorization
        /// </summary>
        public static readonly string MOBILECONNECTAUTHORIZATION = $"{Scope.OPENID} {Scope.AUTHZ}";

        /// <summary>
        /// Scope value for Identity Phone Number
        /// </summary>
        public static readonly string MOBILECONNECTIDENTITYPHONE = $"{Scope.OPENID} {Scope.MC_IDENTITY_PHONE}";

        /// <summary>
        /// Scope value for Identity Signup
        /// </summary>
        public static readonly string MOBILECONNECTIDENTITYSIGNUP = $"{Scope.OPENID} {Scope.MC_IDENTITY_SIGNUP}";

        /// <summary>
        /// Scope value for Identity Signup Plus
        /// </summary>
        public static readonly string MOBILECONNECTIDENTITYSIGNUPPLUS = $"{Scope.OPENID} {Scope.MC_IDENTITY_SIGNUP_PLUS}";

        /// <summary>
        /// Scope value for Identity National ID
        /// </summary>
        public static readonly string MOBILECONNECTIDENTITYNATIONALID = $"{Scope.OPENID} {Scope.MC_IDENTITY_NATIONALID}";
    }
}
