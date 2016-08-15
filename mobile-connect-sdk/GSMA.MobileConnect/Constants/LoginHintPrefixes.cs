using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSMA.MobileConnect.Constants
{
    /// <summary>
    /// Constants for login hint prefixes
    /// </summary>
    public static class LoginHintPrefixes
    {
        /// <summary>
        /// Login hint prefix for MSISDN
        /// </summary>
        public const string MSISDN = "MSISDN";
        /// <summary>
        /// Login hint prefix for Encrypted MSISSN
        /// </summary>
        public const string EncryptedMSISDN = "ENCR_MSISDN";
        /// <summary>
        /// Login hint prefix for PCR (Pseudonymous Customer Reference)
        /// </summary>
        public const string PCR = "PCR";
    }
}
