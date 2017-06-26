using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace GSMA.MobileConnect.Demo.Config
{
    public static class DemoConfiguration
    {
        // The following constants are substituted at build time with the values of the environment variables
        // defined in the BuildTimeEnvironmentVariable Attributes
        // This uses the project https://github.com/bonyjoe/EnvVariableInject
        // It is safe to remove the nuget package and attributes and manage the constants manually
        [BuildTimeEnvironmentVariable("GSMADemoClientId")]
        private static readonly string _clientId = "";
        [BuildTimeEnvironmentVariable("GSMADemoClientSecret")]
        private static readonly string _clientSecret = "";
        [BuildTimeEnvironmentVariable("GSMADemoRedirectUrl")]
        private static readonly string _redirectUrl = "";
        [BuildTimeEnvironmentVariable("GSMADemoDiscoveryUrl")]
        private static readonly string _discoveryUrl = "";

        private static MobileConnectConfig _config = new MobileConnectConfig
        {
            ClientId = _clientId,
            ClientSecret = _clientSecret,
            RedirectUrl = _redirectUrl,
            DiscoveryUrl = _discoveryUrl
        };

        public static MobileConnectConfig Config
        {
            get { return _config; }
        }
    }
}
