using GSMA.MobileConnect.Demo.Config;

namespace GSMA.MobileConnect.Demo.Universal
{
    public static class MobileConnectFactory
    {
        private static MobileConnectConfig _config;
        private static MobileConnectInterface _mobileConnect;

        static MobileConnectFactory()
        {
            _config = CreateConfig();
            _mobileConnect = new MobileConnectInterface(_config, null);
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
