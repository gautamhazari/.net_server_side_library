using GSMA.MobileConnect.Authentication;
using GSMA.MobileConnect.Demo.Config;
using GSMA.MobileConnect.Discovery;
using GSMA.MobileConnect.Identity;
using GSMA.MobileConnect.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSMA.MobileConnect.Demo.Universal
{
    public static class MobileConnectFactory
    {
        private static RestClient _client;
        private static IDiscovery _discovery;
        private static IAuthentication _authentication;
        private static IIdentityService _identity;
        private static MobileConnectConfig _config;
        private static MobileConnectInterface _mobileConnect;

        static MobileConnectFactory()
        {
            _client = new RestClient();
            _discovery = new Discovery.Discovery(null, _client);
            _authentication = new Authentication.Authentication(_client);
            _identity = new Identity.IdentityService(_client);
            _config = CreateConfig();
            _mobileConnect = new MobileConnectInterface(_discovery, _authentication, _identity, _config);
        }

        private static MobileConnectConfig CreateConfig()
        {
            return DemoConfiguration.Config;
        }

        public static MobileConnectConfig Config
        {
            get { return _config; }
        }

        public static MobileConnectInterface MobileConnect
        {
            get { return _mobileConnect; }
        }
    }
}
