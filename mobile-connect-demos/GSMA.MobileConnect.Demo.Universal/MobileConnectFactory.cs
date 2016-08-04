using GSMA.MobileConnect.Authentication;
using GSMA.MobileConnect.Demo.Config;
using GSMA.MobileConnect.Discovery;
using GSMA.MobileConnect.Identity;
using GSMA.MobileConnect.Utils;

namespace GSMA.MobileConnect.Demo.Universal
{
    public static class MobileConnectFactory
    {
        private static RestClient _client;
        private static IDiscoveryService _discovery;
        private static IAuthenticationService _authentication;
        private static IIdentityService _identity;
        private static IJWKeysetService _jwks;
        private static MobileConnectConfig _config;
        private static MobileConnectInterface _mobileConnect;

        static MobileConnectFactory()
        {
            _client = new RestClient();
            _discovery = new DiscoveryService(null, _client);
            _authentication = new AuthenticationService(_client);
            _identity = new IdentityService(_client);
            _jwks = new JWKeysetService(_client, null);
            _config = CreateConfig();
            _mobileConnect = new MobileConnectInterface(_discovery, _authentication, _identity, _jwks, _config);
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
