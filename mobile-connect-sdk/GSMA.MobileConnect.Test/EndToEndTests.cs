using GSMA.MobileConnect.Authentication;
using GSMA.MobileConnect.Cache;
using GSMA.MobileConnect.Discovery;
using GSMA.MobileConnect.Identity;
using GSMA.MobileConnect.Utils;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace GSMA.MobileConnect.Test
{
    [TestFixture]
    [Category("EndToEnd")]
    public class EndToEndTests
    {
        [TestCase("SandboxR2")]
        public async Task MobileConnectWebInterfaceShouldWorkEndToEndHeadlessAuthentication(string configKey)
        {
            RestClient restClient = new RestClient();
            ICache cache = null;
            IDiscoveryService discovery = new GSMA.MobileConnect.Discovery.DiscoveryService(cache, restClient);
            IAuthenticationService authentication = new GSMA.MobileConnect.Authentication.AuthenticationService(restClient);
            IIdentityService identity = new GSMA.MobileConnect.Identity.IdentityService(restClient);
            IJWKeysetService jwks = new GSMA.MobileConnect.Authentication.JWKeysetService(restClient, cache);

            var testConfig = TestConfig.GetConfig(configKey);
            MobileConnectConfig config = new MobileConnectConfig()
            {
                DiscoveryUrl = testConfig.DiscoveryUrl,
                ClientId = testConfig.ClientId,
                ClientSecret = testConfig.ClientSecret,
                RedirectUrl = testConfig.RedirectUrl
            };

            MobileConnectRequestOptions blankOptions = new MobileConnectRequestOptions();
            MobileConnectWebInterface mobileConnect = new MobileConnectWebInterface(discovery, authentication, identity, jwks, config);

            //Attempt discovery
            var request = new HttpRequestMessage();
            var status = await mobileConnect.AttemptDiscoveryAsync(request, testConfig.ValidMSISDN, null, null, true, blankOptions);

            Assert.AreEqual(MobileConnectResponseType.StartAuthentication, status.ResponseType);

            var discoveryResponse = status.DiscoveryResponse;
            var encryptedMsisdn = status.DiscoveryResponse.ResponseData.subscriber_id;
            var state = "zmxncbvalskdjfhgqpwoeiruty";
            var nonce = "qpwoeirutyalskdjfhgzmxncbv";

            //Start Authorization
            request = new HttpRequestMessage();
            status = await mobileConnect.RequestHeadlessAuthenticationAsync(request, discoveryResponse, encryptedMsisdn, state, nonce, blankOptions);

            Assert.AreEqual(MobileConnectResponseType.Complete, status.ResponseType);
            Assert.IsNotEmpty(status.TokenResponse.ResponseData.AccessToken);
            Assert.IsNotEmpty(status.TokenResponse.ResponseData.IdToken);
        }

        [TestCase("SandboxR2")]
        public async Task MobileConnectWebInterfaceShouldWorkEndToEndHeadlessWithAuthorization(string configKey)
        {
            RestClient restClient = new RestClient();
            ICache cache = null;
            IDiscoveryService discovery = new GSMA.MobileConnect.Discovery.DiscoveryService(cache, restClient);
            IAuthenticationService authentication = new GSMA.MobileConnect.Authentication.AuthenticationService(restClient);
            IIdentityService identity = new GSMA.MobileConnect.Identity.IdentityService(restClient);
            IJWKeysetService jwks = new GSMA.MobileConnect.Authentication.JWKeysetService(restClient, cache);

            var testConfig = TestConfig.GetConfig(configKey);
            MobileConnectConfig config = new MobileConnectConfig()
            {
                DiscoveryUrl = testConfig.DiscoveryUrl,
                ClientId = testConfig.ClientId,
                ClientSecret = testConfig.ClientSecret,
                RedirectUrl = testConfig.RedirectUrl
            };

            MobileConnectRequestOptions blankOptions = new MobileConnectRequestOptions();
            MobileConnectWebInterface mobileConnect = new MobileConnectWebInterface(discovery, authentication, identity, jwks, config);

            //Attempt discovery
            var request = new HttpRequestMessage();
            var status = await mobileConnect.AttemptDiscoveryAsync(request, testConfig.ValidMSISDN, null, null, true, blankOptions);

            Assert.AreEqual(MobileConnectResponseType.StartAuthentication, status.ResponseType);

            var discoveryResponse = status.DiscoveryResponse;
            var encryptedMsisdn = status.DiscoveryResponse.ResponseData.subscriber_id;
            var state = "zmxncbvalskdjfhgqpwoeiruty";
            var nonce = "qpwoeirutyalskdjfhgzmxncbv";

            //Start Authorization
            var authOptions = new MobileConnectRequestOptions { Scope = "mc_authz", BindingMessage = "auth test", Context = "test" };
            request = new HttpRequestMessage();
            status = await mobileConnect.RequestHeadlessAuthenticationAsync(request, discoveryResponse, encryptedMsisdn, state, nonce, authOptions);

            Assert.AreEqual(MobileConnectResponseType.Complete, status.ResponseType);
            Assert.IsNotEmpty(status.TokenResponse.ResponseData.AccessToken);
            Assert.IsNotEmpty(status.TokenResponse.ResponseData.IdToken);
        }

        [TestCase("SandboxR2")]
        public async Task MobileConnectWebInterfaceShouldWorkEndToEndHeadlessWithCache(string configKey)
        {
            RestClient restClient = new RestClient();
            ICache cache = new ConcurrentCache();
            IDiscoveryService discovery = new GSMA.MobileConnect.Discovery.DiscoveryService(cache, restClient);
            IAuthenticationService authentication = new GSMA.MobileConnect.Authentication.AuthenticationService(restClient);
            IIdentityService identity = new GSMA.MobileConnect.Identity.IdentityService(restClient);
            IJWKeysetService jwks = new GSMA.MobileConnect.Authentication.JWKeysetService(restClient, cache);

            var testConfig = TestConfig.GetConfig(configKey);
            MobileConnectConfig config = new MobileConnectConfig()
            {
                DiscoveryUrl = testConfig.DiscoveryUrl,
                ClientId = testConfig.ClientId,
                ClientSecret = testConfig.ClientSecret,
                RedirectUrl = testConfig.RedirectUrl
            };

            MobileConnectRequestOptions blankOptions = new MobileConnectRequestOptions();
            MobileConnectWebInterface mobileConnect = new MobileConnectWebInterface(discovery, authentication, identity, jwks, config);

            //Attempt discovery
            var request = new HttpRequestMessage();
            var status = await mobileConnect.AttemptDiscoveryAsync(request, testConfig.ValidMSISDN, null, null, true, blankOptions);

            Assert.AreEqual(MobileConnectResponseType.StartAuthentication, status.ResponseType);

            var sdksession = status.SDKSession;
            var encryptedMsisdn = status.DiscoveryResponse.ResponseData.subscriber_id;
            var state = "zmxncbvalskdjfhgqpwoeiruty";
            var nonce = "qpwoeirutyalskdjfhgzmxncbv";

            //Start Authorization
            request = new HttpRequestMessage();
            status = await mobileConnect.RequestHeadlessAuthenticationAsync(request, sdksession, encryptedMsisdn, state, nonce, blankOptions);

            Assert.AreEqual(MobileConnectResponseType.Complete, status.ResponseType);
            Assert.IsNotEmpty(status.TokenResponse.ResponseData.AccessToken);
            Assert.IsNotEmpty(status.TokenResponse.ResponseData.IdToken);
        }

        [TestCase("SandboxR2")]
        public async Task MobileConnectWebInterfaceShouldWorkEndToEndHeadlessWithAutoIdentity(string configKey)
        {
            RestClient restClient = new RestClient();
            ICache cache = null;
            IDiscoveryService discovery = new GSMA.MobileConnect.Discovery.DiscoveryService(cache, restClient);
            IAuthenticationService authentication = new GSMA.MobileConnect.Authentication.AuthenticationService(restClient);
            IIdentityService identity = new GSMA.MobileConnect.Identity.IdentityService(restClient);
            IJWKeysetService jwks = new GSMA.MobileConnect.Authentication.JWKeysetService(restClient, cache);

            var testConfig = TestConfig.GetConfig(configKey);
            MobileConnectConfig config = new MobileConnectConfig()
            {
                DiscoveryUrl = testConfig.DiscoveryUrl,
                ClientId = testConfig.ClientId,
                ClientSecret = testConfig.ClientSecret,
                RedirectUrl = testConfig.RedirectUrl
            };

            MobileConnectRequestOptions blankOptions = new MobileConnectRequestOptions();
            MobileConnectWebInterface mobileConnect = new MobileConnectWebInterface(discovery, authentication, identity, jwks, config);

            //Attempt discovery
            var request = new HttpRequestMessage();
            var status = await mobileConnect.AttemptDiscoveryAsync(request, testConfig.ValidMSISDN, null, null, true, blankOptions);

            Assert.AreEqual(MobileConnectResponseType.StartAuthentication, status.ResponseType);

            var discoveryResponse = status.DiscoveryResponse;
            var encryptedMsisdn = status.DiscoveryResponse.ResponseData.subscriber_id;
            var state = "zmxncbvalskdjfhgqpwoeiruty";
            var nonce = "qpwoeirutyalskdjfhgzmxncbv";

            //Start Authorization
            var authOptions = new MobileConnectRequestOptions { Scope = "mc_authz mc_identity_phonenumber mc_identity_signup", BindingMessage = "auth test", Context = "test", AutoRetrieveIdentityHeadless = true };
            request = new HttpRequestMessage();
            status = await mobileConnect.RequestHeadlessAuthenticationAsync(request, discoveryResponse, encryptedMsisdn, state, nonce, authOptions);

            Assert.AreEqual(MobileConnectResponseType.Complete, status.ResponseType);
            Assert.IsNotEmpty(status.TokenResponse.ResponseData.AccessToken);
            Assert.IsNotNull(status.IdentityResponse);
            Assert.IsNotEmpty(status.IdentityResponse.ResponseJson);
        }
    }
}
