using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        /// Key for jwks url
        /// </summary>
        public const string JWKS = "jwks";

        /// <summary>
        /// Key for applicationShortName
        /// </summary>
        public const string APPLICATION_SHORT_NAME = "applicationShortName";

        /// <summary>
        /// Key for openid-configuration
        /// </summary>
        public const string OPENID_CONFIGURATION = "openid-configuration";
    }
}
