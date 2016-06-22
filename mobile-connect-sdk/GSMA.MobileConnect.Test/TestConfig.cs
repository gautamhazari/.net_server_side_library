using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSMA.MobileConnect.Test
{
    internal static class TestConfig
    {
        private const string VALID_MSISDN = "+447700900250";
        private const string INVALID_MSISDN = "+447700900987";
        private const string REDIRECT_URL = "http://localhost:8001/mobileconnect.html";

        public static string DEFAULT_TEST_CONFIG = "sandbox-v2";

        private static Dictionary<string, TestConfigurationData> _availablesConfigs;

        public static TestConfigurationData GetConfig(string key)
        {
            TestConfigurationData data;
            if(!_availablesConfigs.TryGetValue(key, out data))
            {
                Assert.Inconclusive($"Test cancelled as config was not found for {key}, if you are an SDK developer you need secret-config.json");
            }

            return _availablesConfigs[key];
        }

        public static void LoadConfig()
        {
            _availablesConfigs = new Dictionary<string, TestConfigurationData>();

            var dir = Path.GetDirectoryName(typeof(TestConfig).Assembly.Location);
            var path = Path.Combine(dir, "../../secret-config.json");

            if(!File.Exists(path))
            {
                return;
            }

            var content = File.ReadAllText(path);
            var json = JObject.Parse(content);
            foreach (var item in json)
            {
                if (item.Key == "default")
                {
                    DEFAULT_TEST_CONFIG = (string)item.Value;
                    continue;
                }

                _availablesConfigs.Add(item.Key, CreateConfig(item.Value));
            }
        }

        private static TestConfigurationData CreateConfig(JToken node)
        {
            return node.ToObject<TestConfigurationData>();
        }
    }

    internal class TestConfigurationData
    {
        public string DiscoveryUrl { get; set; }
        public string RedirectUrl { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string ValidMSISDN { get; set; }
        public string InvalidMSISDN { get; set; }
        public string ValidSubscriberId { get; set; }
        public string ValidMCC { get; set; }
        public string ValidMNC { get; set; }
        public string InvalidMCC { get; set; }
        public string InvalidMNC { get; set; }
    }
}
