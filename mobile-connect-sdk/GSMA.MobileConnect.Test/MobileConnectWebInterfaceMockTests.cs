using GSMA.MobileConnect.Cache;
using GSMA.MobileConnect.Claims;
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
    // These tests use a mock rest client so the methods that require authorisation can be tested, we can't test these directly on a true endpoint because we can't complete authorisation
    // without a javascript enabled browser implementation
    [TestFixture]
    public class MobileConnectWebInterfaceMockTests
    {
        private static RestResponse _unauthorizedResponse = new RestResponse(System.Net.HttpStatusCode.Unauthorized, "")
        {
            Headers = new List<BasicKeyValuePair> { new BasicKeyValuePair("WWW-Authenticate", "Bearer error=\"invalid_request\", error_description=\"No Access Token\"") }
        };

        private Dictionary<string, RestResponse> _responses = new Dictionary<string, RestResponse>()
        {
            ["operator-selection"] = new RestResponse(System.Net.HttpStatusCode.Accepted, "{\"links\":[{\"rel\":\"operatorSelection\",\"href\":\"http://discovery.sandbox2.mobileconnect.io/v2/discovery/users/operator-selection?session_id=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJyZWRpcmVjdFVybCI6Imh0dHA6Ly9sb2NhbGhvc3Q6ODAwMS8iLCJhcHBsaWNhdGlvbiI6eyJleHRlcm5hbF9pZCI6IjExMzgiLCJuYW1lIjoiY3NoYXJwLXNkayIsImtleXMiOnsic2FuZGJveCI6eyJrZXkiOiI2Njc0MmE4NS0yMjgyLTQ3NDctODgxZC1lZDViN2JkNzRkMmQiLCJzZWNyZXQiOiJmMTUxOTlmNC1iNjU4LTRlNTgtOGJiMy1lNDA5OTg4NzMzOTIifX0sInJlZGlyZWN0X3VyaSI6Imh0dHBzOi8vbG9jYWxob3N0OjgwMDEvIiwiZGV2ZWxvcGVyIjp7InBvcnRhbF91c2VyX2lkIjoiMTEzOCIsIm5hbWUiOiJOaWNob2xhcyBEb25vaG9lIiwiZW1haWwiOiJuaWNob2xhcy5kb25vaG9lQGJqc3MuY29tIiwicHJvZmlsZSI6Imh0dHBzOi8vZGV2ZWxvcGVyLm1vYmlsZWNvbm5lY3QuaW8vYXBpL3YxL3VzZXI_ZW1haWw9bmljaG9sYXMuZG9ub2hvZSU0MGJqc3MuY29tIiwidXBkYXRlZCI6IjIwMTYtMDQtMjBUMDk6MzQ6MThaIiwibXNpc2RucyI6WyI5NDE0ZTI1MmMzYjE1ZWUzMGIyN2NmYmQxNjkzN2UwNWJlMGQ1NWYwZGZjZGQ0MjM2OTg3NTU1MjQ3ZjU0YzUyIiwiZjYwZjFkZDU1YzUxMjE3ZTAwMTc4YWE3ZGIxM2Q5Njc4OGUxZmM0MzRkMGU2ZGZiZmI2NjVlYjU5NzU3MGIwZiJdLCJtc2lzZG5TaG9ydCI6WyI3NTc1IiwiMzMzMyJdLCJzbXNBdXRoIjp0cnVlLCJtY2MiOiI5MDEiLCJtbmMiOiIwMSIsImNvbnNlbnQiOmZhbHNlfX0sInVzZXIiOnsibmFtZSI6IjY2NzQyYTg1LTIyODItNDc0Ny04ODFkLWVkNWI3YmQ3NGQyZCIsInBhc3MiOiJmMTUxOTlmNC1iNjU4LTRlNTgtOGJiMy1lNDA5OTg4NzMzOTIifSwiaWF0IjoxNDYxMTY5MzA5fQ.2Lp0Xt9JXVZxNbnNq_RH-5KJPQ06qw6ttR4ZK3fwcQU\"}]}"),
            ["authentication"] = new RestResponse(System.Net.HttpStatusCode.OK, "{\"ttl\":1466082848000,\"response\":{\"client_id\":\"x-ZWRhNjU3OWI3MGIwYTRh\",\"client_secret\":\"x-NjQzZTBhZWM0YmQ4ZDQ5\",\"serving_operator\":\"demo_unitedkingdom\",\"country\":\"UnitedKingdom\",\"currency\":\"GBP\",\"apis\":{\"operatorid\":{\"link\":[{\"rel\":\"authorization\",\"href\":\"https://reference.mobileconnect.io/mobileconnect/index.php/auth\"},{\"rel\":\"token\",\"href\":\"https://reference.mobileconnect.io/mobileconnect/index.php/token\"},{\"rel\":\"userinfo\",\"href\":\"https://reference.mobileconnect.io/mobileconnect/index.php/userinfo\"},{\"rel\":\"jwks\",\"href\":\"https://reference.mobileconnect.io/mobileconnect/cert.jwk\"},{\"rel\":\"applicationShortName\",\"href\":\"test1\"},{\"rel\":\"openid-configuration\",\"href\":\"https://reference.mobileconnect.io/mobileconnect/discovery.php/openid-configuration\"}]}}},\"subscriber_id\":\"6c483ef529a86e5aa808f9cfdcb78ac3ec9f24aba27ea1a003476b0693751d89c3feacd3d2ff00c0e1e1cb683ff7de9ea87bdd775d4e79b7da5a4fbec509d918c1f804fdaf1fcaa9d1aae572bd19a12de7de2d695d004a3b2828be9b79e5f13a5c70a35adebedef138ab11440f8573fff53e59c8348caaf458716dbb53b4162d27737f290a8a759a4eab409af27685b3667659ce1f5b2194ab68953c0381126fc941eb0043c17647021d1e47a07cfde2e5e18c9e29ca01af1a8d2b3558d9853ffeed1cd9c8545e0d4c609db4ca318c02d10cddaf83bab927f81c4ca8bbb04da4dba273a4f76d3962e5a31a59f806067393823ae6702850726281352849209fe4\"}"),
            ["error"] = new RestResponse(System.Net.HttpStatusCode.OK, "{\"error\":\"Not_Found_Entity\",\"description\":\"Operator Not Found\"}"),
            ["provider-metadata"] = new RestResponse(System.Net.HttpStatusCode.OK, "{\"version\":\"3.0\",\"issuer\":\"https://reference.mobileconnect.io/mobileconnect\",\"authorization_endpoint\":\"https://reference.mobileconnect.io/mobileconnect/index.php/auth\",\"token_endpoint\":\"https://reference.mobileconnect.io/mobileconnect/index.php/token\",\"userinfo_endpoint\":\"https://reference.mobileconnect.io/mobileconnect/index.php/userinfo\",\"check_session_iframe\":\"https://reference.mobileconnect.io/mobileconnect/opframe.php\",\"end_session_endpoint\":\"https://reference.mobileconnect.io/mobileconnect/index.php/endsession\",\"jwks_uri\":\"https://reference.mobileconnect.io/mobileconnect/op.jwk\",\"scopes_supported\":[\"openid\",\"mc_authn\",\"mc_authz\",\"profile\",\"email\",\"address\"],\"response_types_supported\":[\"code\",\"code token\",\"code id_token\",\"token\",\"token id_token\",\"code token id_token\",\"id_token\"],\"grant_types_supported\":[\"authorization_code\"],\"acr_values_supported\":[\"2\",\"3\"],\"subject_types_supported\":[\"public\",\"pairwise\"],\"userinfo_signing_alg_values_supported\":[\"HS256\",\"HS384\",\"HS512\",\"RS256\",\"RS384\",\"RS512\"],\"userinfo_encryption_alg_values_supported\":[\"RSA1_5\",\"RSA-OAEP\"],\"userinfo_encryption_enc_values_supported\":[\"A128CBC-HS256\",\"A256CBC-HS512\",\"A128GCM\",\"A256GCM\"],\"id_token_signing_alg_values_supported\":[\"HS256\",\"HS384\",\"HS512\",\"RS256\",\"RS384\",\"RS512\"],\"id_token_encryption_alg_values_supported\":[\"RSA1_5\",\"RSA-OAEP\"],\"id_token_encryption_enc_values_supported\":[\"A128CBC-HS256\",\"A256CBC-HS512\",\"A128GCM\",\"A256GCM\"],\"request_object_signing_alg_values_supported\":[\"HS256\",\"HS384\",\"HS512\",\"RS256\",\"RS384\",\"RS512\"],\"request_object_encryption_alg_values_supported\":[\"RSA1_5\",\"RSA-OAEP\"],\"request_object_encryption_enc_values_supported\":[\"A128CBC-HS256\",\"A256CBC-HS512\",\"A128GCM\",\"A256GCM\"],\"token_endpoint_auth_methods_supported\":[\"client_secret_post\",\"client_secret_basic\",\"client_secret_jwt\",\"private_key_jwt\"],\"token_endpoint_auth_signing_alg_values_supported\":[\"HS256\",\"HS384\",\"HS512\",\"RS256\",\"RS384\",\"RS512\"],\"display_values_supported\":[\"page\"],\"claim_types_supported\":[\"normal\"],\"claims_supported\":[\"name\",\"given_name\",\"family_name\",\"middle_name\",\"nickname\",\"preferred_username\",\"profile\",\"picture\",\"website\",\"email\",\"email_verified\",\"gender\",\"birthdate\",\"zoneinfo\",\"locale\",\"phone_number\",\"phone_number_verified\",\"address\",\"updated_at\"],\"service_documentation\":\"https://reference.mobileconnect.io/mobileconnect/index.php/servicedocs\",\"claims_locales_supported\":[\"en-US\"],\"ui_locales_supported\":[\"en-US\"],\"require_request_uri_registration\":false,\"op_policy_uri\":\"https://reference.mobileconnect.io/mobileconnect/index.php/op_policy\",\"op_tos_uri\":\"https://reference.mobileconnect.io/mobileconnect/index.php/op_tos\",\"claims_parameter_supported\":true,\"request_parameter_supported\":true,\"request_uri_parameter_supported\":true,\"mobile_connect_version_supported\":[{\"openid\":\"mc_v1.1\"},{\"openid mc_authn\":\"mc_v1.2\"},{\"openid mc_authz\":\"mc_v1.2\"}],\"login_hint_methods_supported\":[\"MSISDN\",\"ENCR_MSISDN\",\"PCR\"]} "),
            ["user-info"] = new RestResponse(System.Net.HttpStatusCode.OK, "{\"sub\":\"411421B0-38D6-6568-A53A-DF99691B7EB6\",\"email\":\"test2@example.com\",\"email_verified\":true}"),
            ["unauthorized"] = _unauthorizedResponse,
        };

        private MobileConnect.Discovery.DiscoveryResponse _discoveryResponse;
        private string _validSdkSession = "zxcvbnm";
        private string _invalidSdkSession = "mnbvcxz";

        private MobileConnectConfig _config;
        private MockRestClient _restClient;
        private IDiscoveryCache _cache;
        private MobileConnect.Discovery.IDiscovery _discovery;
        private MobileConnect.Authentication.IAuthentication _authentication;
        private MobileConnect.Identity.IIdentityService _identity;
        private MobileConnectWebInterface _mobileConnect;

        private HttpRequestMessage _request = new HttpRequestMessage(HttpMethod.Get, "http://discovery.mobileconnect.io");

        [SetUp]
        public void Setup()
        {
            _restClient = new MockRestClient();
            _cache = new ConcurrentDiscoveryCache();
            _discovery = new GSMA.MobileConnect.Discovery.Discovery(_cache, _restClient);
            _authentication = new GSMA.MobileConnect.Authentication.Authentication(_restClient);
            _identity = new GSMA.MobileConnect.Identity.IdentityService(_restClient);

            _discoveryResponse = new MobileConnect.Discovery.DiscoveryResponse(_responses["authentication"]);
            _cache.Add(_validSdkSession, _discoveryResponse);

            _config = new MobileConnectConfig
            {
                ClientId = "zxcvbnm",
                ClientSecret = "asdfghjkl",
                DiscoveryUrl = "qwertyuiop",
                RedirectUrl = "http://qwertyuiop",
            };

            _mobileConnect = new MobileConnectWebInterface(_discovery, _authentication, _identity, _config);
        }

        private MobileConnect.Discovery.DiscoveryResponse CompleteDiscovery()
        {
            _restClient.QueueResponse(_responses["authentication"]);
            _restClient.QueueResponse(_responses["provider-metadata"]);
            return _discovery.CompleteSelectedOperatorDiscovery(_config, _config.RedirectUrl, "111", "11");
        }

        [Test]
        public void StartAuthenticationShouldUseAuthnWhenAuthzOptionsNotSet()
        {
            var discoveryResponse = CompleteDiscovery();

            var result = _mobileConnect.StartAuthorization(_request, discoveryResponse, "1111222233334444", "state", "nonce", new MobileConnectRequestOptions());
            var scope = HttpUtils.ExtractQueryValue(result.Url, "scope");

            Assert.AreEqual(MobileConnectResponseType.Authorization, result.ResponseType);
            Assert.That(() => scope.Contains("mc_authn"));
            Assert.That(() => !scope.Contains("mc_authz"));
        }

        [Test]
        public void StartAuthenticationShouldUseAuthzWhenContextSet()
        {
            var discoveryResponse = CompleteDiscovery();

            var result = _mobileConnect.StartAuthorization(_request, discoveryResponse, "1111222233334444", "state", "nonce", new MobileConnectRequestOptions { Context = "context" });
            var scope = HttpUtils.ExtractQueryValue(result.Url, "scope");

            Assert.AreEqual(MobileConnectResponseType.Authorization, result.ResponseType);
            Assert.That(() => scope.Contains("mc_authz"));
            Assert.That(() => !scope.Contains("mc_authn"));
        }

        [Test]
        public void StartAuthenticationShouldUseAuthzWhenAuthzScope()
        {
            var discoveryResponse = CompleteDiscovery();

            var result = _mobileConnect.StartAuthorization(_request, discoveryResponse, "1111222233334444", "state", "nonce", new MobileConnectRequestOptions { Scope = "mc_authz", Context = "context", BindingMessage = "message" });
            var scope = HttpUtils.ExtractQueryValue(result.Url, "scope");

            Assert.AreEqual(MobileConnectResponseType.Authorization, result.ResponseType);
            Assert.That(() => scope.Contains("mc_authz"));
            Assert.That(() => !scope.Contains("mc_authn"));
        }

        [Test]
        public void StartAuthenticationShouldUseAuthzWhenMCProductScope()
        {
            var discoveryResponse = CompleteDiscovery();

            var result = _mobileConnect.StartAuthorization(_request, discoveryResponse, "1111222233334444", "state", "nonce", new MobileConnectRequestOptions { Scope = "mc_identity_phone", Context = "context", BindingMessage = "message" });
            var scope = HttpUtils.ExtractQueryValue(result.Url, "scope");

            Assert.AreEqual(MobileConnectResponseType.Authorization, result.ResponseType);
            Assert.That(() => scope.Contains("mc_authz"));
            Assert.That(() => scope.Contains("mc_identity_phone"));
            Assert.That(() => !scope.Contains("mc_authn"));
        }

        [Test]
        public void StartAuthenticationShouldSetClientNameWhenAuthz()
        {
            var discoveryResponse = CompleteDiscovery();
            var expected = "test1";

            var result = _mobileConnect.StartAuthorization(_request, discoveryResponse, "1111222233334444", "state", "nonce", new MobileConnectRequestOptions { Scope = "mc_identity_phone", Context = "context", BindingMessage = "message" });
            var clientName = HttpUtils.ExtractQueryValue(result.Url, "client_name");

            Assert.AreEqual(expected, clientName);
        }

        [Test]
        public async Task RequestUserInfoReturnsUserInfo()
        {
            _restClient.NextExpectedResponse = _responses["user-info"];
            var claims = new ClaimsParameter();
            claims.UserInfo.AddRequired("test");
            claims.IdToken.AddWithValue("testvalue", false, "this value");

            var result = await _mobileConnect.RequestUserInfoAsync(_request, _discoveryResponse, "zaqwsxcderfvbgtyhnmjukilop", claims, new MobileConnectRequestOptions());

            Assert.IsNotNull(result.UserInfoResponse);
            Assert.AreEqual(MobileConnectResponseType.UserInfo, result.ResponseType);
        }

        [Test]
        public async Task RequestUserInfoReturnsErrorWhenNoUserInfoUrl()
        {
            var claims = new ClaimsParameter();
            claims.UserInfo.AddRequired("test");
            claims.IdToken.AddWithValue("testvalue", false, "this value");
            _discoveryResponse.OperatorUrls.UserInfoUrl = null;

            var result = await _mobileConnect.RequestUserInfoAsync(_request, _discoveryResponse, "zaqwsxcderfvbgtyhnmjukilop", claims, new MobileConnectRequestOptions());

            Assert.IsNull(result.UserInfoResponse);
            Assert.IsNotNull(result.ErrorCode);
            Assert.IsNotNull(result.ErrorMessage);
            Assert.AreEqual(MobileConnectResponseType.Error, result.ResponseType);
        }

        [Test]
        public async Task RequestUserInfoShouldUseSdkSessionCache()
        {
            _restClient.NextExpectedResponse = _responses["user-info"];
            var claims = new ClaimsParameter();
            claims.UserInfo.AddRequired("test");
            claims.IdToken.AddWithValue("testvalue", false, "this value");

            var result = await _mobileConnect.RequestUserInfoAsync(_request, _validSdkSession, "zaqwsxcderfvbgtyhnmjukilop", claims, new MobileConnectRequestOptions());

            Assert.IsNotNull(result.UserInfoResponse);
            Assert.AreEqual(MobileConnectResponseType.UserInfo, result.ResponseType);
        }

        [Test]
        public async Task RequestTokenShouldReturnErrorForInvalidSession()
        {
            var result = await _mobileConnect.RequestTokenAsync(_request, _invalidSdkSession, new Uri("http://localhost"), "state", "nonce");

            Assert.AreEqual(MobileConnectResponseType.Error, result.ResponseType);
            Assert.AreEqual("sdksession_not_found", result.ErrorCode);
        }

        [Test]
        public async Task RequestTokenShouldReturnErrorForCacheDisabled()
        {
            _config.CacheResponsesWithSessionId = false;
            _mobileConnect = new MobileConnectWebInterface(_discovery, _authentication, _identity, _config);

            var result = await _mobileConnect.RequestTokenAsync(_request, _invalidSdkSession, new Uri("http://localhost"), "state", "nonce");

            Assert.AreEqual(MobileConnectResponseType.Error, result.ResponseType);
            Assert.AreEqual("cache_disabled", result.ErrorCode);
        }

        
    }
}
