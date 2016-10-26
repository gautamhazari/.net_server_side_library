using GSMA.MobileConnect.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace GSMA.MobileConnect.Discovery
{
    /// <summary>
    /// Storage for supported mobile connect versions in <see cref="ProviderMetadata.MobileConnectVersionSupported"/>
    /// </summary>
    public class SupportedVersions
    {
        private static readonly Regex _versionRegex = new Regex(@"(?:\d+\.?){1,4}");
        private static readonly List<string> _recognisedScopes = new List<string>
        {
            MobileConnectConstants.MOBILECONNECT,
            MobileConnectConstants.MOBILECONNECTAUTHENTICATION,
            MobileConnectConstants.MOBILECONNECTAUTHORIZATION,
            MobileConnectConstants.MOBILECONNECTIDENTITYNATIONALID,
            MobileConnectConstants.MOBILECONNECTIDENTITYPHONE,
            MobileConnectConstants.MOBILECONNECTIDENTITYSIGNUP,
            MobileConnectConstants.MOBILECONNECTIDENTITYSIGNUPPLUS
        };

        private readonly Dictionary<string, string> _initialValuesDict;
        private readonly Version _maxSupportedVersion;
        private readonly string _maxSupportedVersionString;

        internal static string R1Version = "mc_v1.1";

        internal Dictionary<string, string> InitialValues
        {
            get { return _initialValuesDict; }
        }

        internal string MaxSupportedVersionString
        {
            get { return _maxSupportedVersionString; }
        }

        /// <summary>
        /// Creates a new instance of the SupportedVersions class using the versionSupport dictionary to generate initial values
        /// </summary>
        /// <param name="versionSupport"></param>
        public SupportedVersions(Dictionary<string, string> versionSupport)
        {
            _initialValuesDict = versionSupport ?? new Dictionary<string, string>();
            _maxSupportedVersionString = CalculateMaxSupportedVersion(_initialValuesDict);
            _maxSupportedVersion = GetAsVersion(_maxSupportedVersionString);
        }

        private static string CalculateMaxSupportedVersion(Dictionary<string, string> versionSupport)
        {
            // Use default scope as default max version
            string maxString = Utils.MobileConnectVersions.CoerceVersion(null, MobileConnectConstants.MOBILECONNECT);
            Version max = GetAsVersion(maxString);
            foreach (var kvp in versionSupport)
            {
                var version = GetAsVersion(kvp.Value);
                if(version > max)
                {
                    max = version;
                    maxString = kvp.Value;
                }
            }

            return maxString;
        }

        private static Version GetAsVersion(string version)
        {
            var match = _versionRegex.Match(version);
            if(match.Captures.Count == 0)
            {
                return null;
            }

            return new Version(match.Captures[0].Value.TrimEnd('.'));
        }

        /// <summary>
        /// Gets the available mobile connect version for the specified scope value.
        /// If versions aren't available then configured default versions will be used.
        /// </summary>
        /// <param name="scope">Scope value to retrieve supported version for</param>
        public string GetSupportedVersion(string scope)
        {
            if (_recognisedScopes.FirstOrDefault(x => string.Equals(x, scope, StringComparison.OrdinalIgnoreCase)) == null)
            {
                return null;
            }

            string version;
            if (!InitialValues.TryGetValue(scope, out version))
            {
                InitialValues.TryGetValue(MobileConnectConstants.MOBILECONNECT, out version);
            }

            return Utils.MobileConnectVersions.CoerceVersion(version, scope);
        }

        /// <summary>
        /// Test for support of the specified version or a greater version
        /// </summary>
        /// <param name="version">Version to test support</param>
        /// <returns>True if version or higher is supported</returns>
        public bool IsVersionSupported(string version)
        {
            if(string.IsNullOrEmpty(version))
            {
                return false;
            }

            var trueVersion = GetAsVersion(version);
            return _maxSupportedVersion >= trueVersion;
        }
    }
}
