using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSMA.MobileConnect.Constants
{
    /// <summary>
    /// Constants relating to headers such as possible Header keys
    /// </summary>
    public static class Headers
    {
        /// <summary>
        /// Key for Source Ip Header
        /// </summary>
        public const string X_SOURCE_IP = "X-Source-IP";

        /// <summary>
        /// Key for Set Cookie Header
        /// </summary>
        public const string SET_COOKIE = "Set-Cookie";

        /// <summary>
        /// Key for Forwarded For Header
        /// </summary>
        public const string X_FORWARDED_FOR = "X-Forwarded-For";
    }
}
