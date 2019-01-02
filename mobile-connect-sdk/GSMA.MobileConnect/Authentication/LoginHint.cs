using GSMA.MobileConnect.Constants;
using GSMA.MobileConnect.Discovery;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GSMA.MobileConnect.Authentication
{
    /// <summary>
    /// Utility methods for working with login hints for the auth login hint parameter
    /// </summary>
    public static class LoginHint
    {
        private static readonly List<string> RecognisedHints = new List<string> { LoginHintPrefixes.EncryptedMSISDN, LoginHintPrefixes.MSISDN, LoginHintPrefixes.PCR };

        /// <summary>
        /// Generates login hint for MSISDN value
        /// </summary>
        /// <param name="msisdn">MSISDN value</param>
        /// <exception cref="Exceptions.MobileConnectInvalidArgumentException">msisdn is null or empty</exception>
        /// <returns>Correctly formatted login hint parameter for MSISDN</returns>
        public static string GenerateForMsisdn(string msisdn)
        {
            return GenerateFor(LoginHintPrefixes.MSISDN, msisdn.TrimStart('+'));
        }

        /// <summary>
        /// Generates login hint for Encrypted MSISDN (SubscriberId) value
        /// </summary>
        /// <param name="encryptedMsisdn">Encrypted MSISDN (SubscriberId) value</param>
        /// <exception cref="Exceptions.MobileConnectInvalidArgumentException">encryptedMSISDN is null or empty</exception>
        /// <returns>Correctly formatted login hint parameter for Encrypted MSISDN (SubscriberId)</returns>
        public static string GenerateForEncryptedMsisdn(string encryptedMsisdn)
        {
            return GenerateFor(LoginHintPrefixes.EncryptedMSISDN, encryptedMsisdn);
        }

        /// <summary>
        /// Generates login hint for PCR (Pseudonymous Customer Reference) value
        /// </summary>
        /// <param name="pcr">PCR (Pseudonymous Customer Reference) value</param>
        /// <exception cref="Exceptions.MobileConnectInvalidArgumentException">pcr is null or empty</exception>
        /// <returns>Correctly formatted login hint parameter for PCR (Pseudonymous Customer Reference)</returns>
        public static string GenerateForPcr(string pcr)
        {
            return GenerateFor(LoginHintPrefixes.PCR, pcr);
        }

        /// <summary>
        /// Generates a login hint for the specified prefix with the specified value. 
        /// This method will not check that the prefix is recognised or supported, it is assumed that it is supported.
        /// </summary>
        /// <param name="prefix">Prefix to use</param>
        /// <param name="value">Value to use</param>
        /// <exception cref="Exceptions.MobileConnectInvalidArgumentException">value is null or empty</exception>
        /// <seealso cref="LoginHintPrefixes"/>
        /// <returns>Correctly formatted login hint for prefix and value</returns>
        public static string GenerateFor(string prefix, string value)
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrEmpty(prefix))
            {
                return null;
            }

            return $"{prefix}:{value}";
        }
    }
}
