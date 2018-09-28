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
        /// Scope value for PROFILE 
        /// </summary>
        public static readonly string MOBILECONNECTPROFILE = $"{Scope.OPENID} {Scope.PROFILE }";
        
        /// <summary>
        /// Scope value for Email
        /// </summary>
        public static readonly string MOBILECONNECTEMAIL = $"{Scope.OPENID} {Scope.EMAIL}";
        
        /// <summary>
        /// Scope value for Address
        /// </summary>
        public static readonly string MOBILECONNECTADDRESS = $"{Scope.OPENID} {Scope.ADDRESS}";


        /// <summary>
        /// Scope value for PHONE
        /// </summary>
        public static readonly string MOBILECONNECTPHONE = $"{Scope.OPENID} {Scope.PHONE}";


        /// <summary>
        /// Scope value for OFFLINEACCESS
        /// </summary>
        public static readonly string MOBILECONNECTOFFLINEACCESS = $"{Scope.OPENID} {Scope.OFFLINEACCESS}";


        /// <summary>
        /// Scope value for Identity 
        /// </summary>
        public static readonly string MOBILECONNECTIDENTITY = $"{Scope.OPENID} {Scope.IDENTITY}";


        /// <summary>
        /// Scope value for Identity Phone Number
        /// </summary>
        public static readonly string MOBILECONNECTIDENTITYPHONE = $"{Scope.OPENID} {Scope.IDENTITYPHONE}";

     
        /// <summary>
        /// Scope value for Identity Signup
        /// </summary>
        public static readonly string MOBILECONNECTIDENTITYSIGNUP = $"{Scope.OPENID} {Scope.IDENTITYSIGNUP}";

        /// <summary>
        /// Scope value for Identity Signup Plus
        /// </summary>
        public static readonly string MOBILECONNECTIDENTITYSIGNUPPLUS = $"{Scope.OPENID} {Scope.IDENTITYSIGNUPPLUS}";

        /// <summary>
        /// Scope value for Identity National ID
        /// </summary>
        public static readonly string MOBILECONNECTIDENTITYNATIONALID = $"{Scope.OPENID} {Scope.IDENTITYNATIONALID}";
    }
}
