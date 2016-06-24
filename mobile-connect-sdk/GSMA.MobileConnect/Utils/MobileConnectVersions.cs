using GSMA.MobileConnect.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSMA.MobileConnect.Utils
{
    /// <summary>
    /// Class with static helpers relating to the difference in Mobile Connect Service versions
    /// </summary>
    public static class MobileConnectVersions
    {
        private static Dictionary<string, string> _supportedVersionsDict = CreateDefaultSupportedVersions();

        /// <summary>
        /// Creates a dictionary of supported versions populated with defaulted values
        /// </summary>
        /// <returns>Dictionary with supported versions populated</returns>
        public static Dictionary<string, string> CreateDefaultSupportedVersions()
        {
            return new Dictionary<string, string>
            {
                [MobileConnectConstants.MOBILECONNECT] = DefaultOptions.VERSION_MOBILECONNECT,
                [MobileConnectConstants.MOBILECONNECTAUTHENTICATION] = DefaultOptions.VERSION_MOBILECONNECTAUTHN,
                [MobileConnectConstants.MOBILECONNECTAUTHORIZATION] = DefaultOptions.VERSION_MOBILECONNECTAUTHZ,
                [MobileConnectConstants.MOBILECONNECTIDENTITYNATIONALID] = DefaultOptions.VERSION_MOBILECONNECTIDENTITY,
                [MobileConnectConstants.MOBILECONNECTIDENTITYPHONE] = DefaultOptions.VERSION_MOBILECONNECTIDENTITY,
                [MobileConnectConstants.MOBILECONNECTIDENTITYSIGNUP] = DefaultOptions.VERSION_MOBILECONNECTIDENTITY,
                [MobileConnectConstants.MOBILECONNECTIDENTITYSIGNUPPLUS] = DefaultOptions.VERSION_MOBILECONNECTIDENTITY,
            };
        }

        /// <summary>
        /// Coerces a version to the valid default for that version if null or empty is passed
        /// </summary>
        /// <param name="version">Version to coerce if required</param>
        /// <param name="scope">Scope to use for retrieving default values</param>
        /// <returns>A coerced version value</returns>
        public static string CoerceVersion(string version, string scope)
        {
            if(!string.IsNullOrEmpty(version))
            {
                return version;
            }

            string supportedVersion;
            if (_supportedVersionsDict.TryGetValue(scope, out supportedVersion))
            {
                return supportedVersion;
            }

            return _supportedVersionsDict[MobileConnectConstants.MOBILECONNECT];
        }
    }
}
