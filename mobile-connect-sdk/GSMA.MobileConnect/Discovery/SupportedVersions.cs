using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSMA.MobileConnect.Discovery
{
    /// <summary>
    /// Storage for supported mobile connect versions in <see cref="ProviderMetadata.MobileConnectVersionSupported"/>
    /// </summary>
    public class SupportedVersions
    {
        private readonly Dictionary<string, string> _initialValuesDict;

        internal Dictionary<string, string> InitialValues
        {
            get { return _initialValuesDict; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="versionSupport"></param>
        public SupportedVersions(Dictionary<string, string> versionSupport)
        {
            _initialValuesDict = versionSupport ?? new Dictionary<string, string>();
        }

        /// <summary>
        /// Gets the available mobile connect version for the specified scope value.
        /// If versions aren't available then configured default versions will be used.
        /// </summary>
        /// <param name="scope">Scope value to retrieve supported version for</param>
        public string GetSupportedVersion(string scope)
        {
            string version;
            if (!InitialValues.TryGetValue(scope, out version))
            {
                InitialValues.TryGetValue(MobileConnectConstants.MOBILECONNECT, out version);
            }

            return Utils.MobileConnectVersions.CoerceVersion(version, scope);
        }
    }
}
