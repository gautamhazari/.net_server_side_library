using GSMA.MobileConnect.Authentication;
using GSMA.MobileConnect.Cache;
using GSMA.MobileConnect.Discovery;
using GSMA.MobileConnect.Exceptions;
using GSMA.MobileConnect.Identity;
using GSMA.MobileConnect.Utils;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GSMA.MobileConnect.Test
{
    [TestFixture]
    [Category("Integration")]
    public class MobileConnectInterfaceTests
    {
        //private const string validEncryptedMSISDN = "33bf6c6172098e9521dee0cb86df822354745a2fd25a74caab18461d7477787a203d144e386f1458707a383acba9f248bf07b245c26f54386039f8943ef19578ad94a4307b633e5e4343cc63510199541d4bb3f2c1dd0a843ce80e825f48f9465476a0c11ff277261cdb1b98495855e3e781611f72aa32ff4dc6078b6d15de233304b17d335f299552a2c3d8e208429d0eb9a3b0ffe131717b393205b45d8ce6f6a43cb30331ebd02291f5ee7ca245630d54fcc29cfe907ba1eb237faadbf8ceb2f9aa936173ab48e8aa05d6f35d71e4164d5a94d8476d616fe3972d43fa97f70d7109456e36fd7f5809a980e98e86ead1643c93f80b2e92f8f599b29bb132a4";
        private string responseJson = "{\"ttl\":1461169322705,\"subscriber_id\":\"e06a09de399ae6c6798c2126e531775ddf3cfe00367af1842534be709fef25e199157c49cc44adf661d286a29afa09c017747fb4383db22b2eaf33db5f878b3ea261c8f342b234e998757e83de23f4a637ce2390453d5d578c76cd65aae99332ee7fbdbd4a140c99babc4e700eae6aa44d3e17ac050771c1fd784fef0214bf770cd0854ea6f4cff87b3ea1e4b25dccd1d340f00eb66c0f041f90596f5236c1017b2541606fff5165320fc4b3381ebfe1fdb848ab04fbedc550bc575ca385b44695a0a9917a368552ee9f8e2178553318a17c32284197631f74f293f30fe6c04f7a77115ec0d2e8ab2a522db88c60263ec1b690ca22540b916e8a9d2c3d820ec1\",\"response\":{\"serving_operator\":\"Example Operator A\",\"country\":\"US\",\"currency\":\"USD\",\"apis\":{\"operatorid\":{\"link\":[{\"href\":\"http://operator_a.sandbox2.mobileconnect.io/oidc/authorize\",\"rel\":\"authorization\"},{\"href\":\"http://operator_a.sandbox2.mobileconnect.io/oidc/accesstoken\",\"rel\":\"token\"},{\"href\":\"http://operator_a.sandbox2.mobileconnect.io/oidc/userinfo\",\"rel\":\"userinfo\"},{\"href\":\"openid profile email\",\"rel\":\"scope\"}]}},\"client_id\":\"66742a85-2282-4747-881d-ed5b7bd74d2d\",\"client_secret\":\"f15199f4-b658-4e58-8bb3-e40998873392\",\"subscriber_id\":\"e06a09de399ae6c6798c2126e531775ddf3cfe00367af1842534be709fef25e199157c49cc44adf661d286a29afa09c017747fb4383db22b2eaf33db5f878b3ea261c8f342b234e998757e83de23f4a637ce2390453d5d578c76cd65aae99332ee7fbdbd4a140c99babc4e700eae6aa44d3e17ac050771c1fd784fef0214bf770cd0854ea6f4cff87b3ea1e4b25dccd1d340f00eb66c0f041f90596f5236c1017b2541606fff5165320fc4b3381ebfe1fdb848ab04fbedc550bc575ca385b44695a0a9917a368552ee9f8e2178553318a17c32284197631f74f293f30fe6c04f7a77115ec0d2e8ab2a522db88c60263ec1b690ca22540b916e8a9d2c3d820ec1\"}}";

        private Uri validOperatorSelectionCallback = new Uri("http://localhost:8001/?mcc_mnc=901_01&subscriber_id=33bf6c6172098e9521dee0cb86df822354745a2fd25a74caab18461d7477787a203d144e386f1458707a383acba9f248bf07b245c26f54386039f8943ef19578ad94a4307b633e5e4343cc63510199541d4bb3f2c1dd0a843ce80e825f48f9465476a0c11ff277261cdb1b98495855e3e781611f72aa32ff4dc6078b6d15de233304b17d335f299552a2c3d8e208429d0eb9a3b0ffe131717b393205b45d8ce6f6a43cb30331ebd02291f5ee7ca245630d54fcc29cfe907ba1eb237faadbf8ceb2f9aa936173ab48e8aa05d6f35d71e4164d5a94d8476d616fe3972d43fa97f70d7109456e36fd7f5809a980e98e86ead1643c93f80b2e92f8f599b29bb132a4");
        private Uri noMCCOperatorSelectionCallback = new Uri("http://localhost:8001/?subscriber_id=33bf6c6172098e9521dee0cb86df822354745a2fd25a74caab18461d7477787a203d144e386f1458707a383acba9f248bf07b245c26f54386039f8943ef19578ad94a4307b633e5e4343cc63510199541d4bb3f2c1dd0a843ce80e825f48f9465476a0c11ff277261cdb1b98495855e3e781611f72aa32ff4dc6078b6d15de233304b17d335f299552a2c3d8e208429d0eb9a3b0ffe131717b393205b45d8ce6f6a43cb30331ebd02291f5ee7ca245630d54fcc29cfe907ba1eb237faadbf8ceb2f9aa936173ab48e8aa05d6f35d71e4164d5a94d8476d616fe3972d43fa97f70d7109456e36fd7f5809a980e98e86ead1643c93f80b2e92f8f599b29bb132a4");
        private Uri noQueryOperatorSelectionCallback = new Uri("http://localhost:8001/");

        private TestConfigurationData _testConfig;
        private RestClient _restClient;
        private IDiscoveryCache _cache;
        private IDiscovery _discovery;
        private IAuthentication _authentication;
        private IIdentityService _identity;
        private MobileConnectConfig _config;
        private MobileConnectInterface _mobileConnect;

        [SetUp]
        public void Setup()
        {
            _testConfig = TestConfig.GetConfig(TestConfig.DEFAULT_TEST_CONFIG);
            Setup(new RestClient(TimeSpan.FromSeconds(20)));
        }

        public void Setup(RestClient client)
        {
            _restClient = client;
            _cache = new ConcurrentDiscoveryCache();
            _discovery = new GSMA.MobileConnect.Discovery.Discovery(_cache, _restClient);
            _authentication = new GSMA.MobileConnect.Authentication.Authentication(_restClient);
            _identity = new GSMA.MobileConnect.Identity.IdentityService(_restClient);

            _config = new MobileConnectConfig()
            {
                DiscoveryUrl = _testConfig.DiscoveryUrl,
                ClientId = _testConfig.ClientId,
                ClientSecret = _testConfig.ClientSecret,
                RedirectUrl = _testConfig.RedirectUrl,
            };

            _mobileConnect = new MobileConnectInterface(_discovery, _authentication, _identity, _config);
        }

        public MockRestClient SetupForMockRest()
        {
            var client = new MockRestClient();
            Setup(client);
            return client;
        }

        [Test]
        public async Task AttemptDiscoveryShouldSucceedWithTestMSISDN()
        {
            var requestOptions = new MobileConnectRequestOptions();
            var response = await _mobileConnect.AttemptDiscoveryAsync(_testConfig.ValidMSISDN, null, null, requestOptions);

            Assert.AreEqual(MobileConnectResponseType.StartAuthorization, response.ResponseType);
            Assert.IsNotNull(response.DiscoveryResponse);
        }

        [Test]
        public async Task AttemptDiscoveryShouldFailWithNonExistentMSISDN()
        {
            var requestOptions = new MobileConnectRequestOptions();
            var response = await _mobileConnect.AttemptDiscoveryAsync(_testConfig.InvalidMSISDN, null, null, requestOptions);

            Assert.AreEqual(MobileConnectResponseType.Error, response.ResponseType);
            Assert.IsNotNull(response.DiscoveryResponse);
        }

        [Test]
        public async Task AttemptDiscoveryShouldSucceedWithTestMCCMNC()
        {
            var requestOptions = new MobileConnectRequestOptions();
            var response = await _mobileConnect.AttemptDiscoveryAsync(null, _testConfig.ValidMCC, _testConfig.ValidMNC, requestOptions);

            Assert.AreEqual(MobileConnectResponseType.StartAuthorization, response.ResponseType);
            Assert.IsNotNull(response.DiscoveryResponse);
        }

        [Test]
        public async Task AttemptDiscoveryShouldFailWithNonExistentMCCMNC()
        {
            var requestOptions = new MobileConnectRequestOptions();
            var response = await _mobileConnect.AttemptDiscoveryAsync(null, _testConfig.InvalidMCC, _testConfig.InvalidMNC, requestOptions);

            Assert.AreEqual(MobileConnectResponseType.Error, response.ResponseType);
            Assert.IsNotNull(response.DiscoveryResponse);
        }

        [Test]
        public async Task AttemptDiscoveryShouldFailWithInvalidFormatMCCMNC()
        {
            var requestOptions = new MobileConnectRequestOptions();
            var response = await _mobileConnect.AttemptDiscoveryAsync(null, "99999", "99", requestOptions);

            Assert.AreEqual(MobileConnectResponseType.Error, response.ResponseType);
            Assert.IsNotNull(response.DiscoveryResponse);
        }

        [Test]
        public async Task AttemptDiscoveryShouldResolveToOperatorSelectionWithNoArguments()
        {
            var requestOptions = new MobileConnectRequestOptions();
            var response = await _mobileConnect.AttemptDiscoveryAsync(null, null, null, requestOptions);

            Assert.AreEqual(MobileConnectResponseType.OperatorSelection, response.ResponseType);
            Assert.IsNotEmpty(response.Url);
        }

        [Test]
        public async Task AttemptDiscoveryAterOperatorSelectionShouldSucceedWithValidCallback()
        {
            var response = await _mobileConnect.AttemptDiscoveryAfterOperatorSelectionAsync(validOperatorSelectionCallback);

            Assert.AreEqual(MobileConnectResponseType.StartAuthorization, response.ResponseType);
            Assert.IsNotNull(response.DiscoveryResponse);
        }

        [Test]
        public async Task AttemptDiscoveryAfterOperatorSelectionWithNoMCCShouldIndicateStartDiscovery()
        {
            var response = await _mobileConnect.AttemptDiscoveryAfterOperatorSelectionAsync(noMCCOperatorSelectionCallback);

            Assert.AreEqual(MobileConnectResponseType.StartDiscovery, response.ResponseType);
        }

        [Test]
        public async Task AttemptDiscoveryAfterOperatorSelectionWithQueryShouldIndicateStartDiscovery()
        {
            var response = await _mobileConnect.AttemptDiscoveryAfterOperatorSelectionAsync(noQueryOperatorSelectionCallback);

            Assert.AreEqual(MobileConnectResponseType.StartDiscovery, response.ResponseType);
        }

        [Test]
        public async Task HandleRedirectWithMCCShouldSucceedWithStartAuthorizationResponse()
        {
            var response = await _mobileConnect.HandleUrlRedirectAsync(validOperatorSelectionCallback);

            Assert.AreEqual(MobileConnectResponseType.StartAuthorization, response.ResponseType);
        }

        [Test]
        public void StartAuthorizationShouldReturnStatusWithUrl()
        {
            var state = "state123";
            var nonce = "nonce123";
            var authorizeUrl = "http://www.authorize.com/authorize";
            var encryptedMSISDN = "abcdef123452452";
            var discoveryResponse = new DiscoveryResponse(new RestResponse(System.Net.HttpStatusCode.OK, responseJson));
            discoveryResponse.OperatorUrls.AuthorizationUrl = authorizeUrl;

            var response = _mobileConnect.StartAuthorization(discoveryResponse, encryptedMSISDN, state, nonce, new MobileConnectRequestOptions());

            Assert.IsNotNull(response);
            Assert.That(response.Url.StartsWith(authorizeUrl));
        }

        [Test]
        public void StartAuthorizationShouldUseClientIdFromDiscoveryResponse()
        {
            var state = "state123";
            var nonce = "nonce123";
            var encryptedMSISDN = "abcdef123452452";
            var clientId = "123clientid123";
            var discoveryResponse = new DiscoveryResponse(new RestResponse(System.Net.HttpStatusCode.OK, responseJson));
            discoveryResponse.ResponseData.response.client_id = clientId;

            var response = _mobileConnect.StartAuthorization(discoveryResponse, encryptedMSISDN, state, nonce, new MobileConnectRequestOptions());

            Assert.IsNotNull(response);
            Assert.That(response.Url.Contains("client_id=" + clientId));
        }

        #region Exception Handling

        [Test]
        public async Task AttemptDiscoveryAsyncShouldHandleInvalidArgumentExceptions()
        {
            _config.ClientId = "";

            var response = await _mobileConnect.AttemptDiscoveryAsync(null, null, null, new MobileConnectRequestOptions());

            Assert.IsNotNull(response);
            Assert.AreEqual(MobileConnectResponseType.Error, response.ResponseType);
            Assert.IsInstanceOf<MobileConnectInvalidArgumentException>(response.Exception);
        }

        [Test]
        public async Task AttemptDiscoveryAsyncShouldHandleHttpException()
        {
            var mockClient = SetupForMockRest();
            mockClient.NextException = new HttpRequestException();

            var response = await _mobileConnect.AttemptDiscoveryAsync(null, null, null, new MobileConnectRequestOptions());

            Assert.IsNotNull(response);
            Assert.AreEqual(MobileConnectResponseType.Error, response.ResponseType);
            Assert.IsInstanceOf<MobileConnectEndpointHttpException>(response.Exception);
        }

        [Test]
        public void AttemptDiscoveryShouldHandleInvalidArgumentException()
        {
            _config.ClientId = "";

            var response = _mobileConnect.AttemptDiscovery(null, null, null, new MobileConnectRequestOptions());

            Assert.IsNotNull(response);
            Assert.AreEqual(MobileConnectResponseType.Error, response.ResponseType);
            Assert.IsInstanceOf<MobileConnectInvalidArgumentException>(response.Exception);
        }

        [Test]
        public void AttemptDiscoveryShouldHandleHttpException()
        {
            var mockClient = SetupForMockRest();
            mockClient.NextException = new HttpRequestException();

            var response = _mobileConnect.AttemptDiscovery(null, null, null, new MobileConnectRequestOptions());

            Assert.IsNotNull(response);
            Assert.AreEqual(MobileConnectResponseType.Error, response.ResponseType);
            Assert.IsInstanceOf<MobileConnectEndpointHttpException>(response.Exception);
        }

        [Test]
        public async Task AttemptDiscoveryAfterOperatorSelectionAsyncShouldHandleInvalidArgumentException()
        {
            _config.ClientId = "";

            var response = await _mobileConnect.AttemptDiscoveryAfterOperatorSelectionAsync(validOperatorSelectionCallback);

            Assert.IsNotNull(response);
            Assert.AreEqual(MobileConnectResponseType.Error, response.ResponseType);
            Assert.IsInstanceOf<MobileConnectInvalidArgumentException>(response.Exception);
        }

        [Test]
        public async Task AttemptDiscoveryAfterOperatorSelectionAsyncShouldHandleHttpException()
        {
            var mockClient = SetupForMockRest();
            mockClient.NextException = new HttpRequestException();

            var response = await _mobileConnect.AttemptDiscoveryAfterOperatorSelectionAsync(validOperatorSelectionCallback);

            Assert.IsNotNull(response);
            Assert.AreEqual(MobileConnectResponseType.Error, response.ResponseType);
            Assert.IsInstanceOf<MobileConnectEndpointHttpException>(response.Exception);
        }

        [Test]
        public void AttemptDiscoveryAfterOperatorSelectionShouldHandleInvalidArgumentException()
        {
            _config.ClientId = "";

            var response = _mobileConnect.AttemptDiscoveryAfterOperatorSelection(validOperatorSelectionCallback);

            Assert.IsNotNull(response);
            Assert.AreEqual(MobileConnectResponseType.Error, response.ResponseType);
            Assert.IsInstanceOf<MobileConnectInvalidArgumentException>(response.Exception);
        }

        [Test]
        public void AttemptDiscoveryAfterOperatorSelectionShouldHandleHttpException()
        {
            var mockClient = SetupForMockRest();
            mockClient.NextException = new HttpRequestException();

            var response = _mobileConnect.AttemptDiscoveryAfterOperatorSelection(validOperatorSelectionCallback);

            Assert.IsNotNull(response);
            Assert.AreEqual(MobileConnectResponseType.Error, response.ResponseType);
            Assert.IsInstanceOf<MobileConnectEndpointHttpException>(response.Exception);
        }

        [Test]
        public void StartAuthorizationShouldHandleInvalidArgumentException()
        {
            var response = _mobileConnect.StartAuthorization(null, _testConfig.ValidSubscriberId, "state", "nonce", new MobileConnectRequestOptions());

            Assert.IsNotNull(response);
            Assert.AreEqual(MobileConnectResponseType.Error, response.ResponseType);
            Assert.IsInstanceOf<MobileConnectInvalidArgumentException>(response.Exception);
        }

        [Test]
        public async Task RequestTokenAsyncShouldHandleInvalidArgumentException()
        {
            var uri = new Uri("http://localhost?state=state&nonce=nonce");
            var response = await _mobileConnect.RequestTokenAsync(null, uri, "state", "nonce");

            Assert.IsNotNull(response);
            Assert.AreEqual(MobileConnectResponseType.Error, response.ResponseType);
            Assert.IsInstanceOf<MobileConnectInvalidArgumentException>(response.Exception);
        }

        [Test]
        public async Task RequestTokenAsyncShouldHandleHttpException()
        {
            var mockClient = SetupForMockRest();
            mockClient.NextException = new HttpRequestException();

            var discoveryResponse = new DiscoveryResponse(new RestResponse(System.Net.HttpStatusCode.OK, responseJson));
            var uri = new Uri("http://localhost?code=code&state=state&nonce=nonce");
            var response = await _mobileConnect.RequestTokenAsync(discoveryResponse, uri, "state", "nonce");

            Assert.IsNotNull(response);
            Assert.AreEqual(MobileConnectResponseType.Error, response.ResponseType);
            Assert.IsInstanceOf<MobileConnectEndpointHttpException>(response.Exception);
        }

        [Test]
        public void RequestTokenShouldHandleInvalidArgumentException()
        {
            var uri = new Uri("http://localhost?state=state&nonce=nonce");
            var response = _mobileConnect.RequestToken(null, uri, "state", "nonce");

            Assert.IsNotNull(response);
            Assert.AreEqual(MobileConnectResponseType.Error, response.ResponseType);
            Assert.IsInstanceOf<MobileConnectInvalidArgumentException>(response.Exception);
        }

        [Test]
        public void RequestTokenShouldHandleHttpException()
        {
            var mockClient = SetupForMockRest();
            mockClient.NextException = new HttpRequestException();

            var discoveryResponse = new DiscoveryResponse(new RestResponse(System.Net.HttpStatusCode.OK, responseJson));
            var uri = new Uri("http://localhost?code=code&state=state&nonce=nonce");
            var response = _mobileConnect.RequestToken(discoveryResponse, uri, "state", "nonce");

            Assert.IsNotNull(response);
            Assert.AreEqual(MobileConnectResponseType.Error, response.ResponseType);
            Assert.IsInstanceOf<MobileConnectEndpointHttpException>(response.Exception);
        }

        [Test]
        public void HandleUrlRedirectShouldHandleErrorRedirect()
        {
            var errorCode = "invalid";
            var errorDescription = "invalid thing happened";
            var uri = new Uri(string.Format("http://localhost?error={0}&error_description={1}", errorCode, errorDescription));

            var response = _mobileConnect.HandleUrlRedirect(uri);

            Assert.AreEqual(MobileConnectResponseType.Error, response.ResponseType);
            Assert.AreEqual(errorCode, response.ErrorCode);
            Assert.AreEqual(errorDescription, response.ErrorMessage);
        }

        #endregion
    }
}
