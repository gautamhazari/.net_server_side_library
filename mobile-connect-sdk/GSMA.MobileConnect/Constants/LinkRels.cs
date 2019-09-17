namespace GSMA.MobileConnect.Constants
{
    /// <summary>
    /// Constants for links provided from the discovery process
    /// </summary>
    public static class LinkRels
    {
        /// <summary>
        /// Key for authorization url
        /// </summary>
        public const string AUTHORIZATION = "authorization";

        /// <summary>
        /// Key for token url
        /// </summary>
        public const string TOKEN = "token";

        /// <summary>
        /// Key for userinfo url
        /// </summary>
        public const string USERINFO = "userinfo";

        /// <summary>
        /// Key for premiuminfo url
        /// </summary>
        public const string PREMIUMINFO = "premiuminfo";

        /// <summary>
        /// Key for jwks url
        /// </summary>
        public const string JWKS = "jwks";

        /// <summary>
        /// Key for token refresh url
        /// </summary>
        public const string TOKENREFRESH = "tokenrefresh";

        /// <summary>
        /// Key for token revoke url
        /// </summary>
        public const string TOKENREVOKE = "tokenrevoke";

        /// <summary>
        /// Key for openid-configuration
        /// </summary>
        public const string OPENID_CONFIGURATION = "openid-configuration";
        public const string ISSUER = "issuer";
        public const string PROVIDER_METADATA_POSTFIX = ".well-known/openid-configuration";

        public const string SCOPE = "scope";

        public const string VALUE = "value";
    }
}
