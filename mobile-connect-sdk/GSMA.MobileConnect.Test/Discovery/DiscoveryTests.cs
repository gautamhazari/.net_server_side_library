using GSMA.MobileConnect.Cache;
using GSMA.MobileConnect.Discovery;
using GSMA.MobileConnect.Exceptions;
using GSMA.MobileConnect.Utils;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSMA.MobileConnect.Test.Discovery
{
    [TestFixture]
    public class DiscoveryTests
    {
        private const string REDIRECT_URL = "http://localhost:8080/";
        private Dictionary<string, RestResponse> _responses = new Dictionary<string, RestResponse>()
        {
            { "operator-selection", new RestResponse(System.Net.HttpStatusCode.Accepted, "{\"links\":[{\"rel\":\"operatorSelection\",\"href\":\"http://discovery.sandbox2.mobileconnect.io/v2/discovery/users/operator-selection?session_id=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJyZWRpcmVjdFVybCI6Imh0dHA6Ly9sb2NhbGhvc3Q6ODAwMS8iLCJhcHBsaWNhdGlvbiI6eyJleHRlcm5hbF9pZCI6IjExMzgiLCJuYW1lIjoiY3NoYXJwLXNkayIsImtleXMiOnsic2FuZGJveCI6eyJrZXkiOiI2Njc0MmE4NS0yMjgyLTQ3NDctODgxZC1lZDViN2JkNzRkMmQiLCJzZWNyZXQiOiJmMTUxOTlmNC1iNjU4LTRlNTgtOGJiMy1lNDA5OTg4NzMzOTIifX0sInJlZGlyZWN0X3VyaSI6Imh0dHBzOi8vbG9jYWxob3N0OjgwMDEvIiwiZGV2ZWxvcGVyIjp7InBvcnRhbF91c2VyX2lkIjoiMTEzOCIsIm5hbWUiOiJOaWNob2xhcyBEb25vaG9lIiwiZW1haWwiOiJuaWNob2xhcy5kb25vaG9lQGJqc3MuY29tIiwicHJvZmlsZSI6Imh0dHBzOi8vZGV2ZWxvcGVyLm1vYmlsZWNvbm5lY3QuaW8vYXBpL3YxL3VzZXI_ZW1haWw9bmljaG9sYXMuZG9ub2hvZSU0MGJqc3MuY29tIiwidXBkYXRlZCI6IjIwMTYtMDQtMjBUMDk6MzQ6MThaIiwibXNpc2RucyI6WyI5NDE0ZTI1MmMzYjE1ZWUzMGIyN2NmYmQxNjkzN2UwNWJlMGQ1NWYwZGZjZGQ0MjM2OTg3NTU1MjQ3ZjU0YzUyIiwiZjYwZjFkZDU1YzUxMjE3ZTAwMTc4YWE3ZGIxM2Q5Njc4OGUxZmM0MzRkMGU2ZGZiZmI2NjVlYjU5NzU3MGIwZiJdLCJtc2lzZG5TaG9ydCI6WyI3NTc1IiwiMzMzMyJdLCJzbXNBdXRoIjp0cnVlLCJtY2MiOiI5MDEiLCJtbmMiOiIwMSIsImNvbnNlbnQiOmZhbHNlfX0sInVzZXIiOnsibmFtZSI6IjY2NzQyYTg1LTIyODItNDc0Ny04ODFkLWVkNWI3YmQ3NGQyZCIsInBhc3MiOiJmMTUxOTlmNC1iNjU4LTRlNTgtOGJiMy1lNDA5OTg4NzMzOTIifSwiaWF0IjoxNDYxMTY5MzA5fQ.2Lp0Xt9JXVZxNbnNq_RH-5KJPQ06qw6ttR4ZK3fwcQU\"}]}") },
            { "authentication", new RestResponse(System.Net.HttpStatusCode.OK, "{\"ttl\":1461169322705,\"subscriber_id\":\"e06a09de399ae6c6798c2126e531775ddf3cfe00367af1842534be709fef25e199157c49cc44adf661d286a29afa09c017747fb4383db22b2eaf33db5f878b3ea261c8f342b234e998757e83de23f4a637ce2390453d5d578c76cd65aae99332ee7fbdbd4a140c99babc4e700eae6aa44d3e17ac050771c1fd784fef0214bf770cd0854ea6f4cff87b3ea1e4b25dccd1d340f00eb66c0f041f90596f5236c1017b2541606fff5165320fc4b3381ebfe1fdb848ab04fbedc550bc575ca385b44695a0a9917a368552ee9f8e2178553318a17c32284197631f74f293f30fe6c04f7a77115ec0d2e8ab2a522db88c60263ec1b690ca22540b916e8a9d2c3d820ec1\",\"response\":{\"serving_operator\":\"Example Operator A\",\"country\":\"US\",\"currency\":\"USD\",\"apis\":{\"operatorid\":{\"link\":[{\"href\":\"http://operator_a.sandbox2.mobileconnect.io/oidc/authorize\",\"rel\":\"authorization\"},{\"href\":\"http://operator_a.sandbox2.mobileconnect.io/oidc/accesstoken\",\"rel\":\"token\"},{\"href\":\"http://operator_a.sandbox2.mobileconnect.io/oidc/userinfo\",\"rel\":\"userinfo\"},{\"href\":\"openid profile email\",\"rel\":\"scope\"}]}},\"client_id\":\"66742a85-2282-4747-881d-ed5b7bd74d2d\",\"client_secret\":\"f15199f4-b658-4e58-8bb3-e40998873392\",\"subscriber_id\":\"e06a09de399ae6c6798c2126e531775ddf3cfe00367af1842534be709fef25e199157c49cc44adf661d286a29afa09c017747fb4383db22b2eaf33db5f878b3ea261c8f342b234e998757e83de23f4a637ce2390453d5d578c76cd65aae99332ee7fbdbd4a140c99babc4e700eae6aa44d3e17ac050771c1fd784fef0214bf770cd0854ea6f4cff87b3ea1e4b25dccd1d340f00eb66c0f041f90596f5236c1017b2541606fff5165320fc4b3381ebfe1fdb848ab04fbedc550bc575ca385b44695a0a9917a368552ee9f8e2178553318a17c32284197631f74f293f30fe6c04f7a77115ec0d2e8ab2a522db88c60263ec1b690ca22540b916e8a9d2c3d820ec1\"}}") },
            { "error", new RestResponse(System.Net.HttpStatusCode.OK, "{\"error\":\"Not_Found_Entity\",\"description\":\"Operator Not Found\"}") }
        };

        private IDiscovery _discovery;
        private IDiscoveryCache _cache;
        private MockRestClient _restClient;
        private MobileConnectConfig _config;

        [SetUp]
        public void Setup()
        {
            Setup(null);
        }

        private void Setup(IDiscoveryCache cache)
        {
            _restClient = new MockRestClient();
            _cache = cache;
            _discovery = new MobileConnect.Discovery.Discovery(cache, this._restClient);
            _config = new MobileConnectConfig() { ClientId = "1234567890", ClientSecret = "1234567890", DiscoveryUrl = "http://localhost:8080/v2/discovery/" };
        }

        private void SetupWithCache()
        {
            Setup(new ConcurrentDiscoveryCache());
        }

        [Test]
        public void AutomatedOperatorDiscoveryShouldHandleOperatorSelectionResponse()
        {
            var response = _responses["operator-selection"];
            var options = new DiscoveryOptions();
            _restClient.NextExpectedResponse = response;

            var result = _discovery.StartAutomatedOperatorDiscovery(_config, REDIRECT_URL, options, null);

            Assert.IsNotNull(result);
            Assert.AreEqual(202, result.ResponseCode);
            Assert.IsNotNull(result.ResponseData);
            Assert.IsNotNull(result.ResponseData.links);
            Assert.IsFalse(result.Cached);
        }

        [Test]
        public void AutomatedOperatorDiscoveryShouldHandleAuthenticationResponse()
        {
            var response = _responses["authentication"];
            var options = new DiscoveryOptions();
            _restClient.NextExpectedResponse = response;

            var result = _discovery.StartAutomatedOperatorDiscovery(_config, REDIRECT_URL, options, null);

            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.ResponseCode);
            Assert.IsNotNull(result.ResponseData);
            Assert.IsNotNull(result.ResponseData.response);
            Assert.IsNotNull(result.ResponseData.ttl);
            Assert.IsFalse(result.Cached);
        }

        [Test]
        public void AutomatedOperatorDiscoveryShouldHandleErrorResponse()
        {
            var response = _responses["error"];
            var options = new DiscoveryOptions();
            _restClient.NextExpectedResponse = response;

            var result = _discovery.StartAutomatedOperatorDiscovery(_config, REDIRECT_URL, options, null);

            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.ResponseCode);
            Assert.IsNotNull(result.ResponseData);
            Assert.IsNotNull(result.ErrorResponse);
            Assert.IsFalse(result.Cached);
        }

        [Test]
        public void AutomatedOperatorDiscoveryShouldHandleHttpRequestException()
        {
            var options = new DiscoveryOptions();
            _restClient.NextException = new System.Net.Http.HttpRequestException("This is the message");

            Assert.ThrowsAsync<MobileConnectEndpointHttpException>(() => _discovery.StartAutomatedOperatorDiscoveryAsync(_config, REDIRECT_URL, options, null));
        }

        [Test]
        public void AutomatedOperatorDiscoveryShouldHandleWebException()
        {
            var options = new DiscoveryOptions();
            _restClient.NextException = new System.Net.WebException("This is the message");

            Assert.ThrowsAsync<MobileConnectEndpointHttpException>(() => _discovery.StartAutomatedOperatorDiscoveryAsync(_config, REDIRECT_URL, options, null));
        }

        [Test]
        public void GetOperatorSelectionURLShouldHandleOperatorSelectionResponse()
        {
            var response = _responses["operator-selection"];
            _restClient.NextExpectedResponse = response;

            var result = _discovery.GetOperatorSelectionURL(_config, REDIRECT_URL);

            Assert.IsNotNull(result);
            Assert.AreEqual(202, result.ResponseCode);
            Assert.IsNotNull(result.ResponseData);
            Assert.IsNotNull(result.ResponseData.links);
            Assert.IsFalse(result.Cached);
        }

        [Test]
        public void GetOperatorSelectionURLShouldHandleHttpRequestException()
        {
            _restClient.NextException = new System.Net.Http.HttpRequestException("This is the message");

            Assert.ThrowsAsync<MobileConnectEndpointHttpException>(() => _discovery.GetOperatorSelectionURLAsync(_config, REDIRECT_URL));
        }

        [Test]
        public void GetOperatorSelectionURLShouldHandleWebException()
        {
            _restClient.NextException = new System.Net.WebException("This is the message");

            Assert.ThrowsAsync<MobileConnectEndpointHttpException>(() => _discovery.GetOperatorSelectionURLAsync(_config, REDIRECT_URL));
        }

        [Test]
        public void CompleteSelectedOperatorDiscoveryShouldHandleOperatorSelectionResponse()
        {
            var response = _responses["operator-selection"];
            _restClient.NextExpectedResponse = response;

            var result = _discovery.CompleteSelectedOperatorDiscovery(_config, REDIRECT_URL, "901", "01");

            Assert.IsNotNull(result);
            Assert.AreEqual(202, result.ResponseCode);
            Assert.IsNotNull(result.ResponseData);
            Assert.IsNotNull(result.ResponseData.links);
            Assert.IsFalse(result.Cached);
        }

        [Test]
        public void CompleteSelectedOperatorDiscoveryShouldHandleAuthenticationResponse()
        {
            var response = _responses["authentication"];
            _restClient.NextExpectedResponse = response;

            var result = _discovery.CompleteSelectedOperatorDiscovery(_config, REDIRECT_URL, "901", "01");

            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.ResponseCode);
            Assert.IsNotNull(result.ResponseData);
            Assert.IsNotNull(result.ResponseData.response);
            Assert.IsNotNull(result.ResponseData.ttl);
            Assert.IsFalse(result.Cached);
        }

        [Test]
        public void CompleteSelectedOperatorDiscoveryShouldHandleErrorResponse()
        {
            var response = _responses["error"];
            _restClient.NextExpectedResponse = response;

            var result = _discovery.CompleteSelectedOperatorDiscovery(_config, REDIRECT_URL, "901", "01");

            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.ResponseCode);
            Assert.IsNotNull(result.ResponseData);
            Assert.IsNotNull(result.ErrorResponse);
            Assert.IsFalse(result.Cached);
        }

        [Test]
        public void CompleteSelectedOperatorDiscoveryShouldUseCachedResponsesIfCacheSupplied()
        {
            SetupWithCache();
            var response = _responses["authentication"];
            var options = new DiscoveryOptions();
            _restClient.NextExpectedResponse = response;
            var initialResult = _discovery.CompleteSelectedOperatorDiscovery(_config, REDIRECT_URL, "901", "01");
            _restClient.NextException = new System.Net.WebException("this should not be hit as the process should pull the cached value");

            var cachedResult = _discovery.CompleteSelectedOperatorDiscovery(_config, REDIRECT_URL, "901", "01");

            Assert.IsNotNull(cachedResult);
            Assert.IsTrue(cachedResult.Cached);
            Assert.AreEqual(initialResult.ResponseData.links, cachedResult.ResponseData.links);
        }

        [Test]
        public void CompleteSelectedSelectedOperatorDiscoveryShouldHandleHttpRequestException()
        {
            _restClient.NextException = new System.Net.Http.HttpRequestException("This is the message");

            Assert.ThrowsAsync<MobileConnectEndpointHttpException>(() => _discovery.CompleteSelectedOperatorDiscoveryAsync(_config, REDIRECT_URL, "901", "01"));
        }

        [Test]
        public void CompleteSelectedSelectedOperatorDiscoveryShouldHandleWebException()
        {
            _restClient.NextException = new System.Net.WebException("This is the message");

            Assert.ThrowsAsync<MobileConnectEndpointHttpException>(() => _discovery.CompleteSelectedOperatorDiscoveryAsync(_config, REDIRECT_URL, "901", "01"));
        }

        [Test]
        public void GetCachedDiscoveryResultShouldReturnCachedResult()
        {
            SetupWithCache();
            var response = _responses["authentication"];
            var options = new DiscoveryOptions();
            _restClient.NextExpectedResponse = response;
            var initialResult = _discovery.CompleteSelectedOperatorDiscovery(_config, REDIRECT_URL, "901", "01");

            var cachedResult = _discovery.GetCachedDiscoveryResultAsync("901", "01").Result;

            Assert.IsNotNull(cachedResult);
            Assert.IsTrue(cachedResult.Cached);
            Assert.AreEqual(initialResult.ResponseData.links, cachedResult.ResponseData.links);
        }

        [Test]
        public void ClearDiscoveryCacheShouldEmptyCacheWithEmptyArguments()
        {
            SetupWithCache();
            var response = _responses["authentication"];
            var options = new DiscoveryOptions();

            for (int i = 0; i < 5; i++)
            {
                _restClient.NextExpectedResponse = response;
                var result = _discovery.CompleteSelectedOperatorDiscovery(_config, REDIRECT_URL, "90" + i, "01");
            }

            _discovery.ClearDiscoveryCacheAsync(null, null);

            Assert.IsTrue(_cache.IsEmpty);
        }

        [Test]
        public void ClearDiscoveryCacheShouldClearSingleEntryIfSuppliedValidMCCMNC()
        {
            SetupWithCache();
            var response = _responses["authentication"];
            var options = new DiscoveryOptions();

            for (int i = 0; i < 5; i++)
            {
                _restClient.NextExpectedResponse = response;
                var result = _discovery.CompleteSelectedOperatorDiscovery(_config, REDIRECT_URL, "90" + i, "01");
            }

            _discovery.ClearDiscoveryCacheAsync("903", "01");
            var otherCachedResult = _discovery.GetCachedDiscoveryResultAsync("902", "01").Result;

            Assert.IsFalse(_cache.IsEmpty);
            Assert.IsNotNull(otherCachedResult);
        }

        #region Argument Validation

        [Test]
        public void AutomatedOperatorDiscoveryShouldThrowWhenPreferencesNull()
        {
            Assert.Throws<MobileConnectInvalidArgumentException>(() => _discovery.StartAutomatedOperatorDiscovery(null, REDIRECT_URL, new DiscoveryOptions(), null));
        }

        [Test]
        public void AutomatedOperatorDiscoveryShouldThrowWhenClientIdNull()
        {
            Assert.ThrowsAsync<MobileConnectInvalidArgumentException>(() => _discovery.StartAutomatedOperatorDiscoveryAsync(null, "secret", "discoveryUrl", "redirecturl", new DiscoveryOptions(), null));
        }

        [Test]
        public void AutomatedOperatorDiscoveryShouldThrowWhenClientSecretNull()
        {
            Assert.ThrowsAsync<MobileConnectInvalidArgumentException>(() => _discovery.StartAutomatedOperatorDiscoveryAsync("id", null, "discoveryUrl", "redirecturl", new DiscoveryOptions(), null));
        }

        [Test]
        public void AutomatedOperatorDiscoveryShouldThrowWhenDiscoveryUrlNull()
        {
            Assert.ThrowsAsync<MobileConnectInvalidArgumentException>(() => _discovery.StartAutomatedOperatorDiscoveryAsync("id", "secret", null, "redirecturl", new DiscoveryOptions(), null));
        }

        [Test]
        public void AutomatedOperatorDiscoveryShouldThrowWhenRedirectUrlNull()
        {
            Assert.ThrowsAsync<MobileConnectInvalidArgumentException>(() => _discovery.StartAutomatedOperatorDiscoveryAsync("id", "secret", "discoveryUrl", null, new DiscoveryOptions(), null));
        }

        [Test]
        public void GetOperatorSelectionUrlShouldThrowWhenPreferencesNull()
        {
            Assert.Throws<MobileConnectInvalidArgumentException>(() => _discovery.GetOperatorSelectionURL(null, REDIRECT_URL));
        }

        [Test]
        public void GetOperatorSelectionUrlShouldThrowWhenClientIdNull()
        {
            Assert.ThrowsAsync<MobileConnectInvalidArgumentException>(() => _discovery.GetOperatorSelectionURLAsync(null, "secret", "discoveryUrl", "redirecturl"));
        }

        [Test]
        public void GetOperatorSelectionUrlShouldThrowWhenClientSecretNull()
        {
            Assert.ThrowsAsync<MobileConnectInvalidArgumentException>(() => _discovery.GetOperatorSelectionURLAsync("id", null, "discoveryUrl", "redirecturl"));
        }

        [Test]
        public void GetOperatorSelectionUrlShouldThrowWhenDiscoveryUrlNull()
        {
            Assert.ThrowsAsync<MobileConnectInvalidArgumentException>(() => _discovery.GetOperatorSelectionURLAsync("id", "secret", null, "redirecturl"));
        }

        [Test]
        public void GetOperatorSelectionUrlShouldThrowWhenRedirectUrlNull()
        {
            Assert.ThrowsAsync<MobileConnectInvalidArgumentException>(() => _discovery.GetOperatorSelectionURLAsync("id", "secret", "discoveryUrl", null));
        }

        [Test]
        public void CompleteSelectedOperatorDiscoveryShouldThrowWhenPreferencesNull()
        {
            Assert.Throws<MobileConnectInvalidArgumentException>(() => _discovery.CompleteSelectedOperatorDiscovery(null, REDIRECT_URL, "901", "01"));
        }

        [Test]
        public void CompleteSelectedOperatorDiscoveryShouldThrowWhenClientIdNull()
        {
            Assert.ThrowsAsync<MobileConnectInvalidArgumentException>(() => _discovery.CompleteSelectedOperatorDiscoveryAsync(null, "secret", "discoveryUrl", "redirecturl", "selectedMcc", "selectedMnc"));
        }

        [Test]
        public void CompleteSelectedOperatorDiscoveryShouldThrowWhenClientSecretNull()
        {
            Assert.ThrowsAsync<MobileConnectInvalidArgumentException>(() => _discovery.CompleteSelectedOperatorDiscoveryAsync("id", null, "discoveryUrl", "redirecturl", "selectedMcc", "selectedMnc"));
        }

        [Test]
        public void CompleteSelectedOperatorDiscoveryThrowWhenDiscoveryUrlNull()
        {
            Assert.ThrowsAsync<MobileConnectInvalidArgumentException>(() => _discovery.CompleteSelectedOperatorDiscoveryAsync("id", "secret", null, "redirecturl", "selectedMcc", "selectedMnc"));
        }

        [Test]
        public void CompleteSelectedOperatorDiscoveryShouldThrowWhenRedirectUrlNull()
        {
            Assert.ThrowsAsync<MobileConnectInvalidArgumentException>(() => _discovery.CompleteSelectedOperatorDiscoveryAsync("id", "secret", "discoveryUrl", null, "selectedMcc", "selectedMnc"));
        }

        [Test]
        public void CompleteSelectedOperatorDiscoveryShouldThrowWhenSelectedMCCNull()
        {
            Assert.ThrowsAsync<MobileConnectInvalidArgumentException>(() => _discovery.CompleteSelectedOperatorDiscoveryAsync("id", "secret", "discoveryUrl", "redirectUrl", null, "selectedMnc"));
        }

        [Test]
        public void CompleteSelectedOperatorDiscoveryShouldThrowWhenSelectedMNCNull()
        {
            Assert.ThrowsAsync<MobileConnectInvalidArgumentException>(() => _discovery.CompleteSelectedOperatorDiscoveryAsync("id", "secret", "discoveryUrl", "redirectUrl", "selectedMcc", null));
        }

        #endregion
    }
}
