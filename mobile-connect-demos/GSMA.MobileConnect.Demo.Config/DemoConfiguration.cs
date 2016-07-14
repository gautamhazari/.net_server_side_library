using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace GSMA.MobileConnect.Demo.Config
{
    public static class DemoConfiguration
    {
        private static string _myConfig = "r2-ref";
        // Replace the values here with values for your mobileconnect application
        public static MobileConnectConfig Config
        {
            get
            {
                EnsureConfigLoaded();
                return new MobileConnectConfig
                {
                    ClientId = _configurations[_myConfig].ClientId,
                    ClientSecret = _configurations[_myConfig].ClientSecret,
                    RedirectUrl = _configurations[_myConfig].RedirectUrl,
                    DiscoveryUrl = _configurations[_myConfig].DiscoveryUrl
                };
            }
        }

        // The following code is to load config from config.json
        // If the values above are replaced with string the following code is not needed
        // Otherwise any configuration will be taken from config.json which is embedded in the assembly at compile time to allow all platforms to access easily
        private static string _defaultConfig;
        private static Dictionary<string, MobileConnectConfig> _configurations;

        private static void EnsureConfigLoaded()
        {
            if(_configurations != null)
            {
                return;
            }

            var assembly = typeof(DemoConfiguration).GetTypeInfo().Assembly;
            var resources = assembly.GetManifestResourceNames();

            JObject json;
            using (Stream stream = assembly.GetManifestResourceStream(resources[0]))
            using (StreamReader reader = new StreamReader(stream))
            {
                string result = reader.ReadToEnd();
                json = JObject.Parse(result);
            }

            _configurations = new Dictionary<string, MobileConnectConfig>();
            foreach (var item in json)
            {
                if(item.Key == "default")
                {
                    _defaultConfig = (string)item.Value;
                    continue;
                }

                _configurations.Add(item.Key, CreateConfig(item.Value));
            }

            if (string.IsNullOrEmpty(_defaultConfig))
            {
                _defaultConfig = _configurations.First().Key;
            }
        }

        private static MobileConnectConfig CreateConfig(JToken node)
        {
            return new MobileConnectConfig
            {
                ClientId = (string)node["ClientId"],
                ClientSecret = (string)node["ClientSecret"],
                RedirectUrl = (string)node["RedirectUrl"],
                DiscoveryUrl = (string)node["DiscoveryUrl"],
            };
        }
    }
}
