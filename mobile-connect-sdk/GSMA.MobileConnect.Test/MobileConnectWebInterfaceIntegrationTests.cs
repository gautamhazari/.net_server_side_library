using GSMA.MobileConnect.Authentication;
using GSMA.MobileConnect.Cache;
using GSMA.MobileConnect.Discovery;
using GSMA.MobileConnect.Identity;
using GSMA.MobileConnect.Utils;
using NUnit.Framework;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace GSMA.MobileConnect.Test
{
    [TestFixture]
    [Category("Integration")]
    public class MobileConnectWebInterfaceIntegrationTests
    {
        //        private const string validEncryptedMSISDN = "33bf6c6172098e9521dee0cb86df822354745a2fd25a74caab18461d7477787a203d144e386f1458707a383acba9f248bf07b245c26f54386039f8943ef19578ad94a4307b633e5e4343cc63510199541d4bb3f2c1dd0a843ce80e825f48f9465476a0c11ff277261cdb1b98495855e3e781611f72aa32ff4dc6078b6d15de233304b17d335f299552a2c3d8e208429d0eb9a3b0ffe131717b393205b45d8ce6f6a43cb30331ebd02291f5ee7ca245630d54fcc29cfe907ba1eb237faadbf8ceb2f9aa936173ab48e8aa05d6f35d71e4164d5a94d8476d616fe3972d43fa97f70d7109456e36fd7f5809a980e98e86ead1643c93f80b2e92f8f599b29bb132a4";
        private string responseJson = "{\"ttl\":1461169322705,\"subscriber_id\":\"e06a09de399ae6c6798c2126e531775ddf3cfe00367af1842534be709fef25e199157c49cc44adf661d286a29afa09c017747fb4383db22b2eaf33db5f878b3ea261c8f342b234e998757e83de23f4a637ce2390453d5d578c76cd65aae99332ee7fbdbd4a140c99babc4e700eae6aa44d3e17ac050771c1fd784fef0214bf770cd0854ea6f4cff87b3ea1e4b25dccd1d340f00eb66c0f041f90596f5236c1017b2541606fff5165320fc4b3381ebfe1fdb848ab04fbedc550bc575ca385b44695a0a9917a368552ee9f8e2178553318a17c32284197631f74f293f30fe6c04f7a77115ec0d2e8ab2a522db88c60263ec1b690ca22540b916e8a9d2c3d820ec1\",\"response\":{\"serving_operator\":\"Example Operator A\",\"country\":\"US\",\"currency\":\"USD\",\"apis\":{\"operatorid\":{\"link\":[{\"href\":\"http://operator_a.sandbox2.mobileconnect.io/oidc/authorize\",\"rel\":\"authorization\"},{\"href\":\"http://operator_a.sandbox2.mobileconnect.io/oidc/accesstoken\",\"rel\":\"token\"},{\"href\":\"http://operator_a.sandbox2.mobileconnect.io/oidc/userinfo\",\"rel\":\"userinfo\"},{\"href\":\"openid profile email\",\"rel\":\"scope\"}]}},\"client_id\":\"66742a85-2282-4747-881d-ed5b7bd74d2d\",\"client_secret\":\"f15199f4-b658-4e58-8bb3-e40998873392\",\"subscriber_id\":\"e06a09de399ae6c6798c2126e531775ddf3cfe00367af1842534be709fef25e199157c49cc44adf661d286a29afa09c017747fb4383db22b2eaf33db5f878b3ea261c8f342b234e998757e83de23f4a637ce2390453d5d578c76cd65aae99332ee7fbdbd4a140c99babc4e700eae6aa44d3e17ac050771c1fd784fef0214bf770cd0854ea6f4cff87b3ea1e4b25dccd1d340f00eb66c0f041f90596f5236c1017b2541606fff5165320fc4b3381ebfe1fdb848ab04fbedc550bc575ca385b44695a0a9917a368552ee9f8e2178553318a17c32284197631f74f293f30fe6c04f7a77115ec0d2e8ab2a522db88c60263ec1b690ca22540b916e8a9d2c3d820ec1\"}}";

        private Uri validOperatorSelectionCallback = new Uri("http://localhost:8001/?mcc_mnc=901_01&subscriber_id=33bf6c6172098e9521dee0cb86df822354745a2fd25a74caab18461d7477787a203d144e386f1458707a383acba9f248bf07b245c26f54386039f8943ef19578ad94a4307b633e5e4343cc63510199541d4bb3f2c1dd0a843ce80e825f48f9465476a0c11ff277261cdb1b98495855e3e781611f72aa32ff4dc6078b6d15de233304b17d335f299552a2c3d8e208429d0eb9a3b0ffe131717b393205b45d8ce6f6a43cb30331ebd02291f5ee7ca245630d54fcc29cfe907ba1eb237faadbf8ceb2f9aa936173ab48e8aa05d6f35d71e4164d5a94d8476d616fe3972d43fa97f70d7109456e36fd7f5809a980e98e86ead1643c93f80b2e92f8f599b29bb132a4");
        private Uri noMCCOperatorSelectionCallback = new Uri("http://localhost:8001/?subscriber_id=33bf6c6172098e9521dee0cb86df822354745a2fd25a74caab18461d7477787a203d144e386f1458707a383acba9f248bf07b245c26f54386039f8943ef19578ad94a4307b633e5e4343cc63510199541d4bb3f2c1dd0a843ce80e825f48f9465476a0c11ff277261cdb1b98495855e3e781611f72aa32ff4dc6078b6d15de233304b17d335f299552a2c3d8e208429d0eb9a3b0ffe131717b393205b45d8ce6f6a43cb30331ebd02291f5ee7ca245630d54fcc29cfe907ba1eb237faadbf8ceb2f9aa936173ab48e8aa05d6f35d71e4164d5a94d8476d616fe3972d43fa97f70d7109456e36fd7f5809a980e98e86ead1643c93f80b2e92f8f599b29bb132a4");
        private Uri noQueryOperatorSelectionCallback = new Uri("http://localhost:8001/");

        private const string requestUrl = "http://localhost:8080/mobileconnect";

        private TestConfigurationData _testConfig;
        private RestClient _restClient;
        private IDiscoveryCache _cache;
        private IDiscovery _discovery;
        private IAuthentication _authentication;
        private IIdentityService _identity;
        private MobileConnectConfig _config;
        private MobileConnectWebInterface _mobileConnect;

        [SetUp]
        public void Setup()
        {
            _restClient = new RestClient();
            _cache = new ConcurrentDiscoveryCache();
            _discovery = new GSMA.MobileConnect.Discovery.Discovery(_cache, _restClient);
            _authentication = new GSMA.MobileConnect.Authentication.Authentication(_restClient);
            _identity = new GSMA.MobileConnect.Identity.IdentityService(_restClient);

            _testConfig = TestConfig.GetConfig(TestConfig.DEFAULT_TEST_CONFIG);
            _config = new MobileConnectConfig()
            {
                DiscoveryUrl = _testConfig.DiscoveryUrl,
                ClientId = _testConfig.ClientId,
                ClientSecret = _testConfig.ClientSecret,
                RedirectUrl = _testConfig.RedirectUrl,
            };

            _mobileConnect = new MobileConnectWebInterface(_discovery, _authentication, _identity, _config);
        }

        [Test]
        public async Task AttemptDiscoveryShouldSucceedWithTestMSISDN()
        {
            var requestOptions = new MobileConnectRequestOptions();
            var request = new HttpRequestMessage(HttpMethod.Get, requestUrl);
            var response = await _mobileConnect.AttemptDiscoveryAsync(request, _testConfig.ValidMSISDN, null, null, true, requestOptions);

            Assert.AreEqual(MobileConnectResponseType.StartAuthentication, response.ResponseType);
            Assert.IsNotNull(response.DiscoveryResponse);
        }

        [Test]
        public async Task AttemptDiscoveryShouldFailWithNonExistentMSISDN()
        {
            var requestOptions = new MobileConnectRequestOptions();
            var request = new HttpRequestMessage(HttpMethod.Get, requestUrl);
            var response = await _mobileConnect.AttemptDiscoveryAsync(request, _testConfig.InvalidMSISDN, null, null, true, requestOptions);

            Assert.AreEqual(MobileConnectResponseType.Error, response.ResponseType);
            Assert.IsNotNull(response.DiscoveryResponse);
        }

        [Test]
        public async Task AttemptDiscoveryShouldSucceedWithTestMCCMNC()
        {
            var requestOptions = new MobileConnectRequestOptions();
            var request = new HttpRequestMessage(HttpMethod.Get, requestUrl);
            var response = await _mobileConnect.AttemptDiscoveryAsync(request, null, _testConfig.ValidMCC, _testConfig.ValidMNC, true, requestOptions);

            Assert.AreEqual(MobileConnectResponseType.StartAuthentication, response.ResponseType);
            Assert.IsNotNull(response.DiscoveryResponse);
        }

        [Test]
        public async Task AttemptDiscoveryShouldFailWithNonExistentMCCMNC()
        {
            var requestOptions = new MobileConnectRequestOptions();
            var request = new HttpRequestMessage(HttpMethod.Get, requestUrl);
            var response = await _mobileConnect.AttemptDiscoveryAsync(request, null, _testConfig.InvalidMCC, _testConfig.InvalidMNC, true, requestOptions);

            Assert.AreEqual(MobileConnectResponseType.Error, response.ResponseType);
            Assert.IsNotNull(response.DiscoveryResponse);
        }

        [Test]
        public async Task AttemptDiscoveryShouldFailWithInvalidFormatMCCMNC()
        {
            var requestOptions = new MobileConnectRequestOptions();
            var request = new HttpRequestMessage(HttpMethod.Get, requestUrl);
            var response = await _mobileConnect.AttemptDiscoveryAsync(request, null, "99999", "99", true, requestOptions);

            Assert.AreEqual(MobileConnectResponseType.Error, response.ResponseType);
            Assert.IsNotNull(response.DiscoveryResponse);
        }

        [Test]
        public async Task AttemptDiscoveryShouldResolveToOperatorSelectionWithNoArguments()
        {
            var requestOptions = new MobileConnectRequestOptions();
            var request = new HttpRequestMessage(HttpMethod.Get, requestUrl);
            var response = await _mobileConnect.AttemptDiscoveryAsync(request, null, null, null, true, requestOptions);

            Assert.AreEqual(MobileConnectResponseType.OperatorSelection, response.ResponseType);
            Assert.IsNotEmpty(response.Url);
        }

        [Test]
        public async Task AttemptDiscoveryAterOperatorSelectionShouldSucceedWithValidCallback()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, requestUrl);
            var response = await _mobileConnect.AttemptDiscoveryAfterOperatorSelectionAsync(request, validOperatorSelectionCallback);

            Assert.AreEqual(MobileConnectResponseType.StartAuthentication, response.ResponseType);
            Assert.IsNotNull(response.DiscoveryResponse);
        }

        [Test]
        public async Task AttemptDiscoveryAfterOperatorSelectionWithNoMCCShouldIndicateStartDiscovery()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, requestUrl);
            var response = await _mobileConnect.AttemptDiscoveryAfterOperatorSelectionAsync(request, noMCCOperatorSelectionCallback);

            Assert.AreEqual(MobileConnectResponseType.StartDiscovery, response.ResponseType);
        }

        [Test]
        public async Task AttemptDiscoveryAfterOperatorSelectionWithQueryShouldIndicateStartDiscovery()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, requestUrl);
            var response = await _mobileConnect.AttemptDiscoveryAfterOperatorSelectionAsync(request, noQueryOperatorSelectionCallback);

            Assert.AreEqual(MobileConnectResponseType.StartDiscovery, response.ResponseType);
        }

        [Test]
        public void StartAuthenticationShouldReturnStatusWithUrl()
        {
            var encryptedMSISDN = "abcdef123452452";
            var request = new HttpRequestMessage(HttpMethod.Get, requestUrl);
            var authorizeUrl = "http://www.authorize.com/authorize";
            var discoveryResponse = new DiscoveryResponse(new RestResponse(System.Net.HttpStatusCode.OK, responseJson));
            discoveryResponse.OperatorUrls.AuthorizationUrl = authorizeUrl;

            var response = _mobileConnect.StartAuthentication(request, discoveryResponse, encryptedMSISDN, null, null, new MobileConnectRequestOptions());

            Assert.IsNotNull(response);
            Assert.That(response.Url.StartsWith(authorizeUrl));
        }

        [Test]
        public void StartAuthenticationShouldUseClientIdFromDiscoveryResponse()
        {
            var encryptedMSISDN = "abcdef123452452";
            var request = new HttpRequestMessage(HttpMethod.Get, requestUrl);
            var clientId = "123clientid123";
            var discoveryResponse = new DiscoveryResponse(new RestResponse(System.Net.HttpStatusCode.OK, responseJson));
            discoveryResponse.ResponseData.response.client_id = clientId;

            var response = _mobileConnect.StartAuthentication(request, discoveryResponse, encryptedMSISDN, null, null, new MobileConnectRequestOptions());

            Assert.IsNotNull(response);
            Assert.That(response.Url.Contains("client_id=" + clientId));
        }
    }
}
