using GSMA.MobileConnect.Cache;
using GSMA.MobileConnect.Claims;
using GSMA.MobileConnect.Utils;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net.Http;
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
            ["authentication"] = new RestResponse(System.Net.HttpStatusCode.OK, "{\"ttl\":1471596217,\"response\":{\"serving_operator\":\"Example Operator B\",\"client_id\":\"MzFlZjkxZGItOWU2NS00ZTFmLTkwMzctNTQzNjdkMDBkMzczOm9wZXJhdG9yLWI=\",\"apis\":{\"operatorid\":{\"link\":[{\"rel\":\"authorization\",\"href\":\"https://operator-b.integration.sandbox.mobileconnect.io/oidc/authorize\"},{\"rel\":\"token\",\"href\":\"https://operator-b.integration.sandbox.mobileconnect.io/oidc/accesstoken\"},{\"rel\":\"userinfo\",\"href\":\"https://operator-b.integration.sandbox.mobileconnect.io/oidc/userinfo\"},{\"rel\":\"premiuminfo\",\"href\":\"https://operator-b.integration.sandbox.mobileconnect.io/oidc/premiuminfo\"},{\"rel\":\"scope\",\"href\":\"openid profile email\"},{\"rel\":\"openid-configuration\",\"href\":\"https://operator-b.integration.sandbox.mobileconnect.io/.well-known/openid-configuration\"},{\"rel\":\"jwks\",\"href\":\"https://operator-b.integration.sandbox.mobileconnect.io/oidc/operator-b/jwks.json\"}]}},\"client_name\":\"csharp-sdk\",\"client_secret\":\"YzdhMmE3OTUtMWFmMy00OGFjLWFhYmUtZWNhZmYyNDNhNGExOm9wZXJhdG9yLWI=\",\"country\":\"US\",\"currency\":\"USD\"},\"subscriber_id\":\"bd559362369e88b14b94918461a507b78e69110fb716776f67ce613e8ef2443f2c731571a4c9f4150cc7b96e34aea3d6bd2240d52c8d022ba02ea83eaa1d6961693d2b6e93ece8c3da05f4fb449776a93036a1d8cc966478a84d243a79d813fcee0c1010e5c96d70aa3e132684b200a21dff4dd2ff70e51128b67301b739a53884feffe43f795cee0ce37cbddf8b97b34f6b9c85592f457733328247b05fd143b6e27390f2b46e2207879ec4e1d11acdb4599c6fc3bf3df8b1bc0619c4620f9e3aa66d93f0a053be79342e4416513c2a29940aed2d986fe88560992c4ee8efdbc0996e3fe48a01c357b077f99856f714bfd8c10edd6ac81a339523e394103ec2\"}"),
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
        private ICache _cache;
        private MobileConnect.Discovery.IDiscoveryService _discovery;
        private MobileConnect.Authentication.IAuthenticationService _authentication;
        private MobileConnect.Identity.IIdentityService _identity;
        private MobileConnect.Authentication.IJWKeysetService _jwks;
        private MobileConnectWebInterface _mobileConnect;

        private HttpRequestMessage _request = new HttpRequestMessage(HttpMethod.Get, "http://discovery.mobileconnect.io");

        [SetUp]
        public void Setup()
        {
            _restClient = new MockRestClient();
            _cache = new ConcurrentCache();
            _discovery = new GSMA.MobileConnect.Discovery.DiscoveryService(_cache, _restClient);
            _authentication = new GSMA.MobileConnect.Authentication.AuthenticationService(_restClient);
            _identity = new GSMA.MobileConnect.Identity.IdentityService(_restClient);
            _jwks = new GSMA.MobileConnect.Authentication.JWKeysetService(_restClient, _cache);

            _discoveryResponse = new MobileConnect.Discovery.DiscoveryResponse(_responses["authentication"]);
            _cache.Add(_validSdkSession, _discoveryResponse);

            _config = new MobileConnectConfig
            {
                ClientId = "zxcvbnm",
                ClientSecret = "asdfghjkl",
                DiscoveryUrl = "qwertyuiop",
                RedirectUrl = "http://qwertyuiop",
            };

            _mobileConnect = new MobileConnectWebInterface(_discovery, _authentication, _identity, _jwks, _config);
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

            var result = _mobileConnect.StartAuthentication(_request, discoveryResponse, "1111222233334444", "state", "nonce", new MobileConnectRequestOptions());
            var scope = HttpUtils.ExtractQueryValue(result.Url, "scope");

            Assert.AreEqual(MobileConnectResponseType.Authentication, result.ResponseType);
            Assert.That(() => scope.Contains("mc_authn"));
            Assert.That(() => !scope.Contains("mc_authz"));
        }

        [Test]
        public void StartAuthenticationShouldUseAuthzWhenContextSet()
        {
            var discoveryResponse = CompleteDiscovery();

            var result = _mobileConnect.StartAuthentication(_request, discoveryResponse, "1111222233334444", "state", "nonce", new MobileConnectRequestOptions { Context = "context" });
            var scope = HttpUtils.ExtractQueryValue(result.Url, "scope");

            Assert.AreEqual(MobileConnectResponseType.Authentication, result.ResponseType);
            Assert.That(() => scope.Contains("mc_authz"));
            Assert.That(() => !scope.Contains("mc_authn"));
        }

        [Test]
        public void StartAuthenticationShouldUseAuthzWhenAuthzScope()
        {
            var discoveryResponse = CompleteDiscovery();

            var result = _mobileConnect.StartAuthentication(_request, discoveryResponse, "1111222233334444", "state", "nonce", new MobileConnectRequestOptions { Scope = "mc_authz", Context = "context", BindingMessage = "message" });
            var scope = HttpUtils.ExtractQueryValue(result.Url, "scope");

            Assert.AreEqual(MobileConnectResponseType.Authentication, result.ResponseType);
            Assert.That(() => scope.Contains("mc_authz"));
            Assert.That(() => !scope.Contains("mc_authn"));
        }

        [Test]
        public void StartAuthenticationShouldUseAuthzWhenMCProductScope()
        {
            var discoveryResponse = CompleteDiscovery();

            var result = _mobileConnect.StartAuthentication(_request, discoveryResponse, "1111222233334444", "state", "nonce", new MobileConnectRequestOptions { Scope = "mc_identity_phone", Context = "context", BindingMessage = "message" });
            var scope = HttpUtils.ExtractQueryValue(result.Url, "scope");

            Assert.AreEqual(MobileConnectResponseType.Authentication, result.ResponseType);
            Assert.That(() => scope.Contains("mc_authz"));
            Assert.That(() => scope.Contains("mc_identity_phone"));
            Assert.That(() => !scope.Contains("mc_authn"));
        }

        [Test]
        public void StartAuthenticationShouldSetClientNameWhenAuthz()
        {
            var discoveryResponse = CompleteDiscovery();
            var expected = "csharp-sdk";

            var result = _mobileConnect.StartAuthentication(_request, discoveryResponse, "1111222233334444", "state", "nonce", new MobileConnectRequestOptions { Scope = "mc_identity_phone", Context = "context", BindingMessage = "message" });
            var clientName = HttpUtils.ExtractQueryValue(result.Url, "client_name");

            Assert.AreEqual(expected, clientName);
        }

        [Test]
        public async Task RequestUserInfoReturnsUserInfo()
        {
            _restClient.NextExpectedResponse = _responses["user-info"];

            var result = await _mobileConnect.RequestUserInfoAsync(_request, _discoveryResponse, "zaqwsxcderfvbgtyhnmjukilop", new MobileConnectRequestOptions());

            Assert.IsNotNull(result.IdentityResponse);
            Assert.AreEqual(MobileConnectResponseType.UserInfo, result.ResponseType);
        }

        [Test]
        public async Task RequestUserInfoReturnsErrorWhenNoUserInfoUrl()
        {
            var claims = new ClaimsParameter();
            _discoveryResponse.OperatorUrls.UserInfoUrl = null;

            var result = await _mobileConnect.RequestUserInfoAsync(_request, _discoveryResponse, "zaqwsxcderfvbgtyhnmjukilop", new MobileConnectRequestOptions());

            Assert.IsNull(result.IdentityResponse);
            Assert.IsNotNull(result.ErrorCode);
            Assert.IsNotNull(result.ErrorMessage);
            Assert.AreEqual(MobileConnectResponseType.Error, result.ResponseType);
        }

        [Test]
        public async Task RequestUserInfoShouldUseSdkSessionCache()
        {
            _restClient.NextExpectedResponse = _responses["user-info"];

            var result = await _mobileConnect.RequestUserInfoAsync(_request, _validSdkSession, "zaqwsxcderfvbgtyhnmjukilop", new MobileConnectRequestOptions());

            Assert.IsNotNull(result.IdentityResponse);
            Assert.AreEqual(MobileConnectResponseType.UserInfo, result.ResponseType);
        }

        [Test]
        public async Task RequestTokenShouldReturnErrorForInvalidSession()
        {
            var result = await _mobileConnect.RequestTokenAsync(_request, _invalidSdkSession, new Uri("http://localhost"), "state", "nonce", new MobileConnectRequestOptions());

            Assert.AreEqual(MobileConnectResponseType.Error, result.ResponseType);
            Assert.AreEqual(Constants.ErrorCodes.InvalidSdkSession, result.ErrorCode);
        }

        [Test]
        public async Task RequestTokenShouldReturnErrorForCacheDisabled()
        {
            _config.CacheResponsesWithSessionId = false;
            _mobileConnect = new MobileConnectWebInterface(_discovery, _authentication, _identity, _jwks, _config);

            var result = await _mobileConnect.RequestTokenAsync(_request, _invalidSdkSession, new Uri("http://localhost"), "state", "nonce", new MobileConnectRequestOptions());

            Assert.AreEqual(MobileConnectResponseType.Error, result.ResponseType);
            Assert.AreEqual("cache_disabled", result.ErrorCode);
        }

        
    }
}
