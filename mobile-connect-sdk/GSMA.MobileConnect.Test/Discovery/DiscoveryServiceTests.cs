using GSMA.MobileConnect.Cache;
using GSMA.MobileConnect.Discovery;
using GSMA.MobileConnect.Exceptions;
using GSMA.MobileConnect.Utils;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GSMA.MobileConnect.Test.Discovery
{
    [TestFixture]
    public class DiscoveryServiceTests
    {
        private const string REDIRECT_URL = "http://localhost:8080/";
        private Dictionary<string, RestResponse> _responses = new Dictionary<string, RestResponse>()
        {
            { "operator-selection", new RestResponse(System.Net.HttpStatusCode.Accepted, "{\"links\":[{\"rel\":\"operatorSelection\",\"href\":\"http://discovery.sandbox2.mobileconnect.io/v2/discovery/users/operator-selection?session_id=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJyZWRpcmVjdFVybCI6Imh0dHA6Ly9sb2NhbGhvc3Q6ODAwMS8iLCJhcHBsaWNhdGlvbiI6eyJleHRlcm5hbF9pZCI6IjExMzgiLCJuYW1lIjoiY3NoYXJwLXNkayIsImtleXMiOnsic2FuZGJveCI6eyJrZXkiOiI2Njc0MmE4NS0yMjgyLTQ3NDctODgxZC1lZDViN2JkNzRkMmQiLCJzZWNyZXQiOiJmMTUxOTlmNC1iNjU4LTRlNTgtOGJiMy1lNDA5OTg4NzMzOTIifX0sInJlZGlyZWN0X3VyaSI6Imh0dHBzOi8vbG9jYWxob3N0OjgwMDEvIiwiZGV2ZWxvcGVyIjp7InBvcnRhbF91c2VyX2lkIjoiMTEzOCIsIm5hbWUiOiJOaWNob2xhcyBEb25vaG9lIiwiZW1haWwiOiJuaWNob2xhcy5kb25vaG9lQGJqc3MuY29tIiwicHJvZmlsZSI6Imh0dHBzOi8vZGV2ZWxvcGVyLm1vYmlsZWNvbm5lY3QuaW8vYXBpL3YxL3VzZXI_ZW1haWw9bmljaG9sYXMuZG9ub2hvZSU0MGJqc3MuY29tIiwidXBkYXRlZCI6IjIwMTYtMDQtMjBUMDk6MzQ6MThaIiwibXNpc2RucyI6WyI5NDE0ZTI1MmMzYjE1ZWUzMGIyN2NmYmQxNjkzN2UwNWJlMGQ1NWYwZGZjZGQ0MjM2OTg3NTU1MjQ3ZjU0YzUyIiwiZjYwZjFkZDU1YzUxMjE3ZTAwMTc4YWE3ZGIxM2Q5Njc4OGUxZmM0MzRkMGU2ZGZiZmI2NjVlYjU5NzU3MGIwZiJdLCJtc2lzZG5TaG9ydCI6WyI3NTc1IiwiMzMzMyJdLCJzbXNBdXRoIjp0cnVlLCJtY2MiOiI5MDEiLCJtbmMiOiIwMSIsImNvbnNlbnQiOmZhbHNlfX0sInVzZXIiOnsibmFtZSI6IjY2NzQyYTg1LTIyODItNDc0Ny04ODFkLWVkNWI3YmQ3NGQyZCIsInBhc3MiOiJmMTUxOTlmNC1iNjU4LTRlNTgtOGJiMy1lNDA5OTg4NzMzOTIifSwiaWF0IjoxNDYxMTY5MzA5fQ.2Lp0Xt9JXVZxNbnNq_RH-5KJPQ06qw6ttR4ZK3fwcQU\"}]}") },
            { "authentication", new RestResponse(System.Net.HttpStatusCode.OK, "{\"ttl\":1466082848000,\"response\":{\"client_id\":\"x-ZWRhNjU3OWI3MGIwYTRh\",\"client_secret\":\"x-NjQzZTBhZWM0YmQ4ZDQ5\",\"serving_operator\":\"demo_unitedkingdom\",\"country\":\"UnitedKingdom\",\"currency\":\"GBP\",\"apis\":{\"operatorid\":{\"link\":[{\"rel\":\"authorization\",\"href\":\"https://reference.mobileconnect.io/mobileconnect/index.php/auth\"},{\"rel\":\"token\",\"href\":\"https://reference.mobileconnect.io/mobileconnect/index.php/token\"},{\"rel\":\"userinfo\",\"href\":\"https://reference.mobileconnect.io/mobileconnect/index.php/userinfo\"},{\"rel\":\"jwks\",\"href\":\"https://reference.mobileconnect.io/mobileconnect/cert.jwk\"},{\"rel\":\"applicationShortName\",\"href\":\"test1\"},{\"rel\":\"openid-configuration\",\"href\":\"https://reference.mobileconnect.io/mobileconnect/discovery.php/openid-configuration\"}]}}},\"subscriber_id\":\"6c483ef529a86e5aa808f9cfdcb78ac3ec9f24aba27ea1a003476b0693751d89c3feacd3d2ff00c0e1e1cb683ff7de9ea87bdd775d4e79b7da5a4fbec509d918c1f804fdaf1fcaa9d1aae572bd19a12de7de2d695d004a3b2828be9b79e5f13a5c70a35adebedef138ab11440f8573fff53e59c8348caaf458716dbb53b4162d27737f290a8a759a4eab409af27685b3667659ce1f5b2194ab68953c0381126fc941eb0043c17647021d1e47a07cfde2e5e18c9e29ca01af1a8d2b3558d9853ffeed1cd9c8545e0d4c609db4ca318c02d10cddaf83bab927f81c4ca8bbb04da4dba273a4f76d3962e5a31a59f806067393823ae6702850726281352849209fe4\"}") },
            { "error", new RestResponse(System.Net.HttpStatusCode.OK, "{\"error\":\"Not_Found_Entity\",\"description\":\"Operator Not Found\"}") },
            { "provider-metadata", new RestResponse(System.Net.HttpStatusCode.OK, "{\"version\":\"3.0\",\"issuer\":\"https://reference.mobileconnect.io/mobileconnect\",\"authorization_endpoint\":\"https://reference.mobileconnect.io/mobileconnect/index.php/auth\",\"token_endpoint\":\"https://reference.mobileconnect.io/mobileconnect/index.php/token\",\"userinfo_endpoint\":\"https://reference.mobileconnect.io/mobileconnect/index.php/userinfo\",\"check_session_iframe\":\"https://reference.mobileconnect.io/mobileconnect/opframe.php\",\"end_session_endpoint\":\"https://reference.mobileconnect.io/mobileconnect/index.php/endsession\",\"jwks_uri\":\"https://reference.mobileconnect.io/mobileconnect/op.jwk\",\"scopes_supported\":[\"openid\",\"mc_authn\",\"mc_authz\",\"profile\",\"email\",\"address\"],\"response_types_supported\":[\"code\",\"code token\",\"code id_token\",\"token\",\"token id_token\",\"code token id_token\",\"id_token\"],\"grant_types_supported\":[\"authorization_code\"],\"acr_values_supported\":[\"2\",\"3\"],\"subject_types_supported\":[\"public\",\"pairwise\"],\"userinfo_signing_alg_values_supported\":[\"HS256\",\"HS384\",\"HS512\",\"RS256\",\"RS384\",\"RS512\"],\"userinfo_encryption_alg_values_supported\":[\"RSA1_5\",\"RSA-OAEP\"],\"userinfo_encryption_enc_values_supported\":[\"A128CBC-HS256\",\"A256CBC-HS512\",\"A128GCM\",\"A256GCM\"],\"id_token_signing_alg_values_supported\":[\"HS256\",\"HS384\",\"HS512\",\"RS256\",\"RS384\",\"RS512\"],\"id_token_encryption_alg_values_supported\":[\"RSA1_5\",\"RSA-OAEP\"],\"id_token_encryption_enc_values_supported\":[\"A128CBC-HS256\",\"A256CBC-HS512\",\"A128GCM\",\"A256GCM\"],\"request_object_signing_alg_values_supported\":[\"HS256\",\"HS384\",\"HS512\",\"RS256\",\"RS384\",\"RS512\"],\"request_object_encryption_alg_values_supported\":[\"RSA1_5\",\"RSA-OAEP\"],\"request_object_encryption_enc_values_supported\":[\"A128CBC-HS256\",\"A256CBC-HS512\",\"A128GCM\",\"A256GCM\"],\"token_endpoint_auth_methods_supported\":[\"client_secret_post\",\"client_secret_basic\",\"client_secret_jwt\",\"private_key_jwt\"],\"token_endpoint_auth_signing_alg_values_supported\":[\"HS256\",\"HS384\",\"HS512\",\"RS256\",\"RS384\",\"RS512\"],\"display_values_supported\":[\"page\"],\"claim_types_supported\":[\"normal\"],\"claims_supported\":[\"name\",\"given_name\",\"family_name\",\"middle_name\",\"nickname\",\"preferred_username\",\"profile\",\"picture\",\"website\",\"email\",\"email_verified\",\"gender\",\"birthdate\",\"zoneinfo\",\"locale\",\"phone_number\",\"phone_number_verified\",\"address\",\"updated_at\"],\"service_documentation\":\"https://reference.mobileconnect.io/mobileconnect/index.php/servicedocs\",\"claims_locales_supported\":[\"en-US\"],\"ui_locales_supported\":[\"en-US\"],\"require_request_uri_registration\":false,\"op_policy_uri\":\"https://reference.mobileconnect.io/mobileconnect/index.php/op_policy\",\"op_tos_uri\":\"https://reference.mobileconnect.io/mobileconnect/index.php/op_tos\",\"claims_parameter_supported\":true,\"request_parameter_supported\":true,\"request_uri_parameter_supported\":true,\"mobile_connect_version_supported\":[{\"openid\":\"mc_v1.1\"},{\"openid mc_authn\":\"mc_v1.2\"},{\"openid mc_authz\":\"mc_v1.2\"}],\"login_hint_methods_supported\":[\"MSISDN\",\"ENCR_MSISDN\",\"PCR\"]} ") },
            { "invalid-metadata", new RestResponse(System.Net.HttpStatusCode.OK, "{\"test\":\"this\",\"obj\":{,}") },
        };

        private IDiscoveryService _discovery;
        private ICache _cache;
        private MockRestClient _restClient;
        private MobileConnectConfig _config;

        [SetUp]
        public void Setup()
        {
            Setup(null);
        }

        private void Setup(ICache cache)
        {
            _restClient = new MockRestClient();
            _cache = cache;
            _discovery = new MobileConnect.Discovery.DiscoveryService(cache, this._restClient);
            _config = new MobileConnectConfig() { ClientId = "1234567890", ClientSecret = "1234567890", DiscoveryUrl = "http://localhost:8080/v2/discovery/" };
        }

        private void SetupWithCache()
        {
            Setup(new ConcurrentCache());
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
            _restClient.QueueResponse(response);
            _restClient.QueueResponse(_responses["provider-metadata"]);

            var result = _discovery.StartAutomatedOperatorDiscovery(_config, REDIRECT_URL, options, null);

            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.ResponseCode);
            Assert.IsNotNull(result.ResponseData);
            Assert.IsNotNull(result.ResponseData.response);
            Assert.IsNotNull(result.ResponseData.ttl);
            Assert.IsNotNull(result.ProviderMetadata);
            Assert.IsFalse(result.Cached);
        }

        [Test]
        public void AutomatedOperatorDiscoveryShouldHandleMalformedProviderMetadata()
        {
            var response = _responses["authentication"];
            var options = new DiscoveryOptions();
            _restClient.QueueResponse(response);
            _restClient.QueueResponse(_responses["invalid-metadata"]);

            var result = _discovery.StartAutomatedOperatorDiscovery(_config, REDIRECT_URL, options, null);

            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.ResponseCode);
            Assert.IsNotNull(result.ResponseData);
            Assert.IsNotNull(result.ResponseData.response);
            Assert.IsNotNull(result.ResponseData.ttl);
            Assert.IsNotNull(result.ProviderMetadata);
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
            _restClient.QueueResponse(response);
            _restClient.QueueResponse(_responses["provider-metadata"]);

            var result = _discovery.CompleteSelectedOperatorDiscovery(_config, REDIRECT_URL, "901", "01");

            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.ResponseCode);
            Assert.IsNotNull(result.ResponseData);
            Assert.IsNotNull(result.ResponseData.response);
            Assert.IsNotNull(result.ResponseData.ttl);
            Assert.IsNotNull(result.ProviderMetadata);
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
            _restClient.QueueResponse(response);
            _restClient.QueueResponse(_responses["provider-metadata"]);
            _restClient.QueueResponse(new System.Net.WebException("this should not be hit as the process should pull the cached value"));
            var initialResult = _discovery.CompleteSelectedOperatorDiscovery(_config, REDIRECT_URL, "901", "01");

            var cachedResult = _discovery.CompleteSelectedOperatorDiscovery(_config, REDIRECT_URL, "901", "01");

            Assert.IsNotNull(cachedResult);
            Assert.IsTrue(cachedResult.Cached);
            Assert.AreEqual(initialResult.ResponseData.links, cachedResult.ResponseData.links);
            Assert.IsNotNull(cachedResult.ProviderMetadata);
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
            _restClient.QueueResponse(response);
            _restClient.QueueResponse(_responses["provider-metadata"]);
            var initialResult = _discovery.CompleteSelectedOperatorDiscovery(_config, REDIRECT_URL, "901", "01");

            var cachedResult = _discovery.GetCachedDiscoveryResultAsync("901", "01").Result;

            Assert.IsNotNull(cachedResult);
            Assert.IsTrue(cachedResult.Cached);
            Assert.AreEqual(initialResult.ResponseData.links, cachedResult.ResponseData.links);
            Assert.IsNotNull(cachedResult.ProviderMetadata);
        }

        [Test]
        public void ClearDiscoveryCacheShouldEmptyCacheWithEmptyArguments()
        {
            SetupWithCache();
            var response = _responses["authentication"];
            var options = new DiscoveryOptions();

            for (int i = 0; i < 5; i++)
            {
                _restClient.QueueResponse(response);
                _restClient.QueueResponse(_responses["provider-metadata"]);
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
                _restClient.QueueResponse(response);
                _restClient.QueueResponse(_responses["provider-metadata"]);
                var result = _discovery.CompleteSelectedOperatorDiscovery(_config, REDIRECT_URL, "90" + i, "01");
            }

            _discovery.ClearDiscoveryCacheAsync("903", "01");
            var otherCachedResult = _discovery.GetCachedDiscoveryResultAsync("902", "01").Result;

            Assert.IsFalse(_cache.IsEmpty);
            Assert.IsNotNull(otherCachedResult);
        }

        [Test]
        public void DiscoveryResponseShouldContainProviderMetadataWhenAvailable()
        {
            var response = _responses["authentication"];
            _restClient.QueueResponse(response);
            _restClient.QueueResponse(_responses["provider-metadata"]);

            var result = _discovery.CompleteSelectedOperatorDiscovery(_config, REDIRECT_URL, "901", "01");

            Assert.IsNotNull(result.ProviderMetadata);
            Assert.IsNotNull(result.ProviderMetadata.Version);
        }

        [Test]
        public async Task DiscoveryResponseShouldUseCachedProviderMetadataWhenAvailable()
        {
            SetupWithCache();
            var response = _responses["authentication"];
            var options = new DiscoveryOptions { MSISDN = "+441122334455" };

            _restClient.QueueResponse(response);
            _restClient.QueueResponse(_responses["provider-metadata"]);
            var discoveryResponse = await _discovery.StartAutomatedOperatorDiscoveryAsync(_config, REDIRECT_URL, options, null);
            _restClient.QueueResponse(response);

            var responseWithCachedMetadata = await _discovery.StartAutomatedOperatorDiscoveryAsync(_config, REDIRECT_URL, options, null);

            Assert.IsNotNull(responseWithCachedMetadata.ProviderMetadata);
        }

        [Test]
        public async Task GetProviderMetadataShouldBypassCacheIfRequested()
        {
            SetupWithCache();
            var updatedMetadata = new RestResponse(System.Net.HttpStatusCode.OK, "{\"version\":\"4.0\",\"issuer\":\"https://reference.mobileconnect.io/mobileconnect\",\"authorization_endpoint\":\"https://reference.mobileconnect.io/mobileconnect/index.php/auth\",\"token_endpoint\":\"https://reference.mobileconnect.io/mobileconnect/index.php/token\",\"userinfo_endpoint\":\"https://reference.mobileconnect.io/mobileconnect/index.php/userinfo\",\"check_session_iframe\":\"https://reference.mobileconnect.io/mobileconnect/opframe.php\",\"end_session_endpoint\":\"https://reference.mobileconnect.io/mobileconnect/index.php/endsession\",\"jwks_uri\":\"https://reference.mobileconnect.io/mobileconnect/op.jwk\",\"scopes_supported\":[\"openid\",\"mc_authn\",\"mc_authz\",\"profile\",\"email\",\"address\"],\"response_types_supported\":[\"code\",\"code token\",\"code id_token\",\"token\",\"token id_token\",\"code token id_token\",\"id_token\"],\"grant_types_supported\":[\"authorization_code\"],\"acr_values_supported\":[\"2\",\"3\"],\"subject_types_supported\":[\"public\",\"pairwise\"],\"userinfo_signing_alg_values_supported\":[\"HS256\",\"HS384\",\"HS512\",\"RS256\",\"RS384\",\"RS512\"],\"userinfo_encryption_alg_values_supported\":[\"RSA1_5\",\"RSA-OAEP\"],\"userinfo_encryption_enc_values_supported\":[\"A128CBC-HS256\",\"A256CBC-HS512\",\"A128GCM\",\"A256GCM\"],\"id_token_signing_alg_values_supported\":[\"HS256\",\"HS384\",\"HS512\",\"RS256\",\"RS384\",\"RS512\"],\"id_token_encryption_alg_values_supported\":[\"RSA1_5\",\"RSA-OAEP\"],\"id_token_encryption_enc_values_supported\":[\"A128CBC-HS256\",\"A256CBC-HS512\",\"A128GCM\",\"A256GCM\"],\"request_object_signing_alg_values_supported\":[\"HS256\",\"HS384\",\"HS512\",\"RS256\",\"RS384\",\"RS512\"],\"request_object_encryption_alg_values_supported\":[\"RSA1_5\",\"RSA-OAEP\"],\"request_object_encryption_enc_values_supported\":[\"A128CBC-HS256\",\"A256CBC-HS512\",\"A128GCM\",\"A256GCM\"],\"token_endpoint_auth_methods_supported\":[\"client_secret_post\",\"client_secret_basic\",\"client_secret_jwt\",\"private_key_jwt\"],\"token_endpoint_auth_signing_alg_values_supported\":[\"HS256\",\"HS384\",\"HS512\",\"RS256\",\"RS384\",\"RS512\"],\"display_values_supported\":[\"page\"],\"claim_types_supported\":[\"normal\"],\"claims_supported\":[\"name\",\"given_name\",\"family_name\",\"middle_name\",\"nickname\",\"preferred_username\",\"profile\",\"picture\",\"website\",\"email\",\"email_verified\",\"gender\",\"birthdate\",\"zoneinfo\",\"locale\",\"phone_number\",\"phone_number_verified\",\"address\",\"updated_at\"],\"service_documentation\":\"https://reference.mobileconnect.io/mobileconnect/index.php/servicedocs\",\"claims_locales_supported\":[\"en-US\"],\"ui_locales_supported\":[\"en-US\"],\"require_request_uri_registration\":false,\"op_policy_uri\":\"https://reference.mobileconnect.io/mobileconnect/index.php/op_policy\",\"op_tos_uri\":\"https://reference.mobileconnect.io/mobileconnect/index.php/op_tos\",\"claims_parameter_supported\":true,\"request_parameter_supported\":true,\"request_uri_parameter_supported\":true,\"mobile_connect_version_supported\":[{\"openid\":\"mc_v1.1\"},{\"openid mc_authn\":\"mc_v1.2\"},{\"openid mc_authz\":\"mc_v1.2\"}],\"login_hint_methods_supported\":[\"MSISDN\",\"ENCR_MSISDN\",\"PCR\"]} ");
            var options = new DiscoveryOptions { MSISDN = "+441122334455" };
            _restClient.QueueResponse(_responses["authentication"]);
            _restClient.QueueResponse(_responses["provider-metadata"]);
            var discoveryResponse = await _discovery.StartAutomatedOperatorDiscoveryAsync(_config, REDIRECT_URL, options, null);

            _restClient.QueueResponse(updatedMetadata);
            var nonCachedMetadata = await _discovery.GetProviderMetadata(discoveryResponse, true);

            Assert.AreEqual("4.0", nonCachedMetadata.Version);
            Assert.AreEqual(nonCachedMetadata, discoveryResponse.ProviderMetadata);
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
