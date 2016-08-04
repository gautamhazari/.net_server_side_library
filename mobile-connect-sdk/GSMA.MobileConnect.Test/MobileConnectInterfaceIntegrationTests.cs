using GSMA.MobileConnect.Authentication;
using GSMA.MobileConnect.Cache;
using GSMA.MobileConnect.Discovery;
using GSMA.MobileConnect.Exceptions;
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
    public class MobileConnectInterfaceIntegrationTests
    {
        //private const string validEncryptedMSISDN = "33bf6c6172098e9521dee0cb86df822354745a2fd25a74caab18461d7477787a203d144e386f1458707a383acba9f248bf07b245c26f54386039f8943ef19578ad94a4307b633e5e4343cc63510199541d4bb3f2c1dd0a843ce80e825f48f9465476a0c11ff277261cdb1b98495855e3e781611f72aa32ff4dc6078b6d15de233304b17d335f299552a2c3d8e208429d0eb9a3b0ffe131717b393205b45d8ce6f6a43cb30331ebd02291f5ee7ca245630d54fcc29cfe907ba1eb237faadbf8ceb2f9aa936173ab48e8aa05d6f35d71e4164d5a94d8476d616fe3972d43fa97f70d7109456e36fd7f5809a980e98e86ead1643c93f80b2e92f8f599b29bb132a4";
        private string responseJson = "{\"subscriber_id\": \"8e2932cc2e9a40a7b987cffd3b0977a3cfb7a03cf82cfe656c38e20476d556c7b2de5660fce23cbd64cd945515a5913143fee4ea31315118382d9a19678b8d7ce367909d9224a02cef4f108c7862c3e6b3903b64b8c7824ad97d8249ffc2c83bfb0ef4a9776cc2b8a3e11f2f4487108bc3bb92239dc6fff19a815b455fe88b31807754ae6b9dafd389555ffdf2ee25aeb0b91bc26b71b72f2201b6bfeb0a88e608df2ffb9a7047ce701cc03013d06a31469ceb2a1248441b904ab2ff92bea13bc97ec9d8f25ce042e212fa53cbdc32eed1cd0bdf3a1e988f6d05f0826136c3e1b92849cec0757df0cfac5fca956eec20327c1c7e070ce8d608b948e0a686d5e8\", \"response\": {\"client_secret\": \"YzdhMmE3OTUtMWFmMy00OGFjLWFhYmUtZWNhZmYyNDNhNGExOm9wZXJhdG9yLWI=\", \"country\": \"US\", \"client_id\": \"MzFlZjkxZGItOWU2NS00ZTFmLTkwMzctNTQzNjdkMDBkMzczOm9wZXJhdG9yLWI=\", \"serving_operator\": \"Example Operator B\", \"applicationShortName\": \"csharp-sdk\", \"apis\": {\"operatorid\": {\"link\": [{\"href\": \"http://operator-b.integration2.sandbox.mobileconnect.io/oidc/authorize\", \"rel\": \"authorization\"}, {\"href\": \"http://operator-b.integration2.sandbox.mobileconnect.io/oidc/accesstoken\", \"rel\": \"token\"}, {\"href\": \"http://operator-b.integration2.sandbox.mobileconnect.io/oidc/userinfo\", \"rel\": \"userinfo\"}, {\"href\": \"openid profile email\", \"rel\": \"scope\"}, {\"href\": \"http://operator-b.integration2.sandbox.mobileconnect.io/.well-known/openid-configuration\", \"rel\": \"openid-configuration\"}, {\"href\": \"http://operator-b.integration2.sandbox.mobileconnect.io/oidc/operator-b/jwks.json\", \"rel\": \"jwks\"}]}}, \"currency\": \"USD\"}, \"ttl\": 1470390046}";
        private string jwksJson = "{keys:[{kty:\"RSA\",use:\"sig\",n:\"ALyIC8vj1tqEIvAvpDMQfgosw13LpBS9Z2lsMmuaLDNJjN_FKIb-HVR2qtMj7AYC0-wYJhGxJpTXJTVRRDz-zLN7uredNxuhVj76vmU1tfvEN0Xq2INYoWeJ3d9fZtkBgKl7Enfkgz858DLAfZuJzDycOzuZXR5r29zXMDstT5F5\",e:\"AQAB\",kid:\"PHPOP-00\"}]}";

        private Uri validOperatorSelectionCallback = new Uri("http://localhost:8001/?mcc_mnc=901_01&subscriber_id=33bf6c6172098e9521dee0cb86df822354745a2fd25a74caab18461d7477787a203d144e386f1458707a383acba9f248bf07b245c26f54386039f8943ef19578ad94a4307b633e5e4343cc63510199541d4bb3f2c1dd0a843ce80e825f48f9465476a0c11ff277261cdb1b98495855e3e781611f72aa32ff4dc6078b6d15de233304b17d335f299552a2c3d8e208429d0eb9a3b0ffe131717b393205b45d8ce6f6a43cb30331ebd02291f5ee7ca245630d54fcc29cfe907ba1eb237faadbf8ceb2f9aa936173ab48e8aa05d6f35d71e4164d5a94d8476d616fe3972d43fa97f70d7109456e36fd7f5809a980e98e86ead1643c93f80b2e92f8f599b29bb132a4");
        private Uri noMCCOperatorSelectionCallback = new Uri("http://localhost:8001/?subscriber_id=33bf6c6172098e9521dee0cb86df822354745a2fd25a74caab18461d7477787a203d144e386f1458707a383acba9f248bf07b245c26f54386039f8943ef19578ad94a4307b633e5e4343cc63510199541d4bb3f2c1dd0a843ce80e825f48f9465476a0c11ff277261cdb1b98495855e3e781611f72aa32ff4dc6078b6d15de233304b17d335f299552a2c3d8e208429d0eb9a3b0ffe131717b393205b45d8ce6f6a43cb30331ebd02291f5ee7ca245630d54fcc29cfe907ba1eb237faadbf8ceb2f9aa936173ab48e8aa05d6f35d71e4164d5a94d8476d616fe3972d43fa97f70d7109456e36fd7f5809a980e98e86ead1643c93f80b2e92f8f599b29bb132a4");
        private Uri noQueryOperatorSelectionCallback = new Uri("http://localhost:8001/");

        private TestConfigurationData _testConfig;
        private RestClient _restClient;
        private ICache _cache;
        private IDiscoveryService _discovery;
        private IAuthenticationService _authentication;
        private IIdentityService _identity;
        private IJWKeysetService _jwks;
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
            _cache = new ConcurrentCache();
            _discovery = new GSMA.MobileConnect.Discovery.DiscoveryService(_cache, _restClient);
            _authentication = new GSMA.MobileConnect.Authentication.AuthenticationService(_restClient);
            _identity = new GSMA.MobileConnect.Identity.IdentityService(_restClient);
            _jwks = new GSMA.MobileConnect.Authentication.JWKeysetService(_restClient, _cache);

            _config = new MobileConnectConfig()
            {
                DiscoveryUrl = _testConfig.DiscoveryUrl,
                ClientId = _testConfig.ClientId,
                ClientSecret = _testConfig.ClientSecret,
                RedirectUrl = _testConfig.RedirectUrl,
            };

            _mobileConnect = new MobileConnectInterface(_discovery, _authentication, _identity, _jwks, _config);
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

            Assert.AreEqual(MobileConnectResponseType.StartAuthentication, response.ResponseType);
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

            Assert.AreEqual(MobileConnectResponseType.StartAuthentication, response.ResponseType);
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

            Assert.AreEqual(MobileConnectResponseType.StartAuthentication, response.ResponseType);
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

            Assert.AreEqual(MobileConnectResponseType.StartAuthentication, response.ResponseType);
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

            var response = _mobileConnect.StartAuthentication(discoveryResponse, encryptedMSISDN, state, nonce, new MobileConnectRequestOptions());

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

            var response = _mobileConnect.StartAuthentication(discoveryResponse, encryptedMSISDN, state, nonce, new MobileConnectRequestOptions());

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
        public void StartAuthenticationShouldHandleInvalidArgumentException()
        {
            var discoveryResponse = new DiscoveryResponse(new RestResponse(System.Net.HttpStatusCode.OK, responseJson));
            discoveryResponse.OperatorUrls.AuthorizationUrl = null;
            var response = _mobileConnect.StartAuthentication(discoveryResponse, _testConfig.ValidSubscriberId, "state", "nonce", new MobileConnectRequestOptions());

            Assert.IsNotNull(response);
            Assert.AreEqual(MobileConnectResponseType.Error, response.ResponseType);
            Assert.IsInstanceOf<MobileConnectInvalidArgumentException>(response.Exception);
        }

        [Test]
        public async Task RequestTokenAsyncShouldHandleInvalidArgumentException()
        {
            var discoveryResponse = new DiscoveryResponse(new RestResponse(System.Net.HttpStatusCode.OK, responseJson));
            discoveryResponse.OperatorUrls.RequestTokenUrl = null;
            var uri = new Uri("http://localhost?state=state&nonce=nonce");
            var response = await _mobileConnect.RequestTokenAsync(discoveryResponse, uri, "state", "nonce");

            Assert.IsNotNull(response);
            Assert.AreEqual(MobileConnectResponseType.Error, response.ResponseType);
            Assert.IsInstanceOf<MobileConnectInvalidArgumentException>(response.Exception);
        }

        [Test]
        public async Task RequestTokenAsyncShouldHandleHttpException()
        {
            var mockClient = SetupForMockRest();

            var discoveryResponse = new DiscoveryResponse(new RestResponse(System.Net.HttpStatusCode.OK, responseJson));
            var uri = new Uri("http://localhost?code=code&state=state&nonce=nonce");
            mockClient.QueueParallelResponses(Tuple.Create<string, object>(discoveryResponse.OperatorUrls.JWKSUrl, new RestResponse(System.Net.HttpStatusCode.OK, jwksJson)), 
                Tuple.Create<string, object>(discoveryResponse.OperatorUrls.RequestTokenUrl, new HttpRequestException()));
            var response = await _mobileConnect.RequestTokenAsync(discoveryResponse, uri, "state", "nonce");

            Assert.IsNotNull(response);
            Assert.AreEqual(MobileConnectResponseType.Error, response.ResponseType);
            Assert.IsInstanceOf<MobileConnectEndpointHttpException>(response.Exception, response.Exception.StackTrace);
        }

        [Test]
        public void RequestTokenShouldHandleInvalidArgumentException()
        {
            var discoveryResponse = new DiscoveryResponse(new RestResponse(System.Net.HttpStatusCode.OK, responseJson));
            discoveryResponse.OperatorUrls.RequestTokenUrl = null;
            var uri = new Uri("http://localhost?state=state&nonce=nonce");
            var response = _mobileConnect.RequestToken(discoveryResponse, uri, "state", "nonce");

            Assert.IsNotNull(response);
            Assert.AreEqual(MobileConnectResponseType.Error, response.ResponseType);
            Assert.IsInstanceOf<MobileConnectInvalidArgumentException>(response.Exception);
        }

        [Test]
        public void RequestTokenShouldHandleHttpException()
        {
            var mockClient = SetupForMockRest();

            var discoveryResponse = new DiscoveryResponse(new RestResponse(System.Net.HttpStatusCode.OK, responseJson));
            var uri = new Uri("http://localhost?code=code&state=state&nonce=nonce");
            mockClient.QueueParallelResponses(Tuple.Create<string, object>(discoveryResponse.OperatorUrls.JWKSUrl, new RestResponse(System.Net.HttpStatusCode.OK, jwksJson)),
                Tuple.Create<string, object>(discoveryResponse.OperatorUrls.RequestTokenUrl, new HttpRequestException()));
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
