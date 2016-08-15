using GSMA.MobileConnect.Constants;
using GSMA.MobileConnect.Discovery;
using GSMA.MobileConnect.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSMA.MobileConnect.Authentication
{
    /// <summary>
    /// Utility methods for working with login hints for the auth login hint parameter
    /// </summary>
    public static class LoginHint
    {
        private static readonly SupportedVersions _defaultVersions = new SupportedVersions(null);
        private static readonly List<string> _recognisedHints = new List<string> { LoginHintPrefixes.EncryptedMSISDN, LoginHintPrefixes.MSISDN, LoginHintPrefixes.PCR };

        /// <summary>
        /// Is login hint with MSISDN supported by the target provider
        /// </summary>
        /// <param name="metadata">Provider Metadata received during the discovery phase</param>
        /// <returns>True if format MSISDN:xxxxxxxxxx is supported</returns>
        public static bool IsSupportedForMSISDN(ProviderMetadata metadata)
        {
            return IsSupportedFor(metadata, LoginHintPrefixes.MSISDN);
        }

        /// <summary>
        /// Is login hint with Encrypted MSISDN (SubscriberId) supported by the target provider
        /// </summary>
        /// <param name="metadata">Provider Metadata received during the discovery phase</param>
        /// <returns>True if format ENCR_MSISDN:xxxxxxxxxx is supported</returns>
        public static bool IsSupportedForEncryptedMSISDN(ProviderMetadata metadata)
        {
            return IsSupportedFor(metadata, LoginHintPrefixes.EncryptedMSISDN);
        }

        /// <summary>
        /// Is login hint with PCR (Pseudonymous Customer Reference) supported by the target provider
        /// </summary>
        /// <param name="metadata">Provider Metadata received during the discovery phase</param>
        /// <returns>True if format PCR:xxxxxxxxxx is supported</returns>
        public static bool IsSupportedForPCR(ProviderMetadata metadata)
        {
            return IsSupportedFor(metadata, LoginHintPrefixes.PCR);
        }

        /// <summary>
        /// Is login hint with specified prefix supported by the target provider
        /// </summary>
        /// <param name="metadata">Provider Metadata received during the discovery phase</param>
        /// <param name="prefix">Prefix to check for login hint support</param>
        /// <seealso cref="LoginHintPrefixes"/>
        /// <returns>True if format ${prefix}:xxxxxxxxxx is supported</returns>
        public static bool IsSupportedFor(ProviderMetadata metadata, string prefix)
        {
            if(metadata == null || metadata.LoginHintMethodsSupported == null || metadata.LoginHintMethodsSupported.Count == 0)
            {
                var supportedVersions = metadata?.MobileConnectVersionSupported ?? _defaultVersions;

                // If not a recognised prefix then it is not supported if no data to state it is supported
                if(_recognisedHints.FirstOrDefault(x => string.Equals(x, prefix, StringComparison.OrdinalIgnoreCase)) == null)
                {
                    return false;
                }

                // If we are on 1.2 or greater then currently all recognised prefixes are assumed supported
                if(supportedVersions.IsVersionSupported("1.2"))
                {
                    return true;
                }

                // If we aren't at 1.2 or greater then we must be on 1.1 and therefore only MSISDN and encrypted are supported
                if(prefix != LoginHintPrefixes.EncryptedMSISDN && prefix != LoginHintPrefixes.MSISDN)
                {
                    return false;
                }

                return true;
            }

            return metadata.LoginHintMethodsSupported.FirstOrDefault(x => string.Equals(x, prefix, StringComparison.OrdinalIgnoreCase)) != null;
        }

        /// <summary>
        /// Generates login hint for MSISDN value
        /// </summary>
        /// <param name="msisdn">MSISDN value</param>
        /// <exception cref="Exceptions.MobileConnectInvalidArgumentException">msisdn is null or empty</exception>
        /// <returns>Correctly formatted login hint parameter for MSISDN</returns>
        public static string GenerateForMSISDN(string msisdn)
        {
            Validate.RejectNullOrEmpty(msisdn, nameof(msisdn));

            return GenerateFor(LoginHintPrefixes.MSISDN, msisdn.TrimStart('+'));
        }

        /// <summary>
        /// Generates login hint for Encrypted MSISDN (SubscriberId) value
        /// </summary>
        /// <param name="encryptedMSISDN">Encrypted MSISDN (SubscriberId) value</param>
        /// <exception cref="Exceptions.MobileConnectInvalidArgumentException">encryptedMSISDN is null or empty</exception>
        /// <returns>Correctly formatted login hint parameter for Encrypted MSISDN (SubscriberId)</returns>
        public static string GenerateForEncryptedMSISDN(string encryptedMSISDN)
        {
            Validate.RejectNullOrEmpty(encryptedMSISDN, nameof(encryptedMSISDN));

            return GenerateFor(LoginHintPrefixes.EncryptedMSISDN, encryptedMSISDN);
        }

        /// <summary>
        /// Generates login hint for PCR (Pseudonymous Customer Reference) value
        /// </summary>
        /// <param name="pcr">PCR (Pseudonymous Customer Reference) value</param>
        /// <exception cref="Exceptions.MobileConnectInvalidArgumentException">pcr is null or empty</exception>
        /// <returns>Correctly formatted login hint parameter for PCR (Pseudonymous Customer Reference)</returns>
        public static string GenerateForPCR(string pcr)
        {
            Validate.RejectNullOrEmpty(pcr, nameof(pcr));

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
            return $"{prefix}:{value}";
        }
    }
}
