using NUnit.Framework;
using System.Collections.Generic;

namespace GSMA.MobileConnect.Test
{
    internal static class TestConfig
    {
        private const string INVALID_MSISDN = "+447700900987";
        private const string VALID_MSISDN = "447700200200";

        private const string REDIRECT_URL = "http://localhost:8001/mobileconnect.html";

        public static string DEFAULT_TEST_CONFIG = "SandboxR2";

        private static Dictionary<string, TestConfigurationData> _availablesConfigs;
        private static List<string> _availableTestEnvironments = new List<string>
        {
            "SandboxV1",
            "SandboxV2",
            "SandboxR2",
            "R2"
        };

        public static TestConfigurationData GetConfig(string environment)
        {
            TestConfigurationData data;
            if(!_availablesConfigs.TryGetValue(environment, out data))
            { 
                Assert.Inconclusive($"Test cancelled as config was not found for {environment}, one or more of the following environment variables are missing, GSMADemo{environment}ClientId, GSMADemo{environment}ClientSecret, GSMADemo{environment}DiscoveryUrl, GSMADemoRedirectUrl.");
            }

            return _availablesConfigs[environment];
        }

        public static void LoadConfig()
        {
            _availablesConfigs = new Dictionary<string, TestConfigurationData>();

            foreach (var environment in _availableTestEnvironments)
            {
                var config = CreateConfig(environment);

                if(config != null)
                {
                    _availablesConfigs.Add(environment, config);
                }
            }
        }

        private static TestConfigurationData CreateConfig(string environment)
        {
            string clientIdVar = $"GSMADemo{environment}ClientId";
            string clientSecretVar = $"GSMADemo{environment}ClientSecret";
            string discoveryVar = $"GSMADemo{environment}DiscoveryUrl";
            string redirectVar = "GSMADemoRedirectUrl";

            string clientId = System.Environment.GetEnvironmentVariable(clientIdVar);
            string clientSecret = System.Environment.GetEnvironmentVariable(clientSecretVar);
            string discoveryUrl = System.Environment.GetEnvironmentVariable(discoveryVar);
            string redirectUrl = System.Environment.GetEnvironmentVariable(redirectVar);

            if(clientId == null || clientSecret == null || discoveryUrl == null || redirectUrl == null)
            {
                return null;
            }

            return new TestConfigurationData
            {
                ClientId = clientId,
                ClientSecret = clientSecret,
                DiscoveryUrl = discoveryUrl,
                RedirectUrl = redirectUrl,
                ValidMSISDN = VALID_MSISDN,
                InvalidMSISDN = INVALID_MSISDN,
                ValidSubscriberId = "c1e711386bf7165a00e1496aa1b68d4a2c1a1003211a1b7d5f17066cbb337a2c2469ef20eabd03192d6454a6a8a1d5da3b12eb3ce6f6c8048621f64c0d47378cfa330f010ff26eec8d649df2277bdf471ded8dd9254f6d27d911b9525ca194815a88876c2234f5341dff354601df64d7e3a5df2f368114ed8b944de95952aa1fa2fea4dc01ccadeb340642e5b5442d4afe3c3d02827e8a04ca9d1c2d2eea6ddf16e453def115f9b76e7b0934e1eebe18b5dc3d196e398c68ce2764cda08d1af3c9f18056e1dc28e40089eed9bc4f73a220ce70de38f6e6d45717bf5072e12d8a712c6aa49a3357c35ff339e2a525a7c2b199bafe1db9d9bca2d2129ac9611907",
                ValidMCC = "901",
                ValidMNC = "01",
                InvalidMCC = "101",
                InvalidMNC = "99",
            };
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
