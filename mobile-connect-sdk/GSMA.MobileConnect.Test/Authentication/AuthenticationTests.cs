using GSMA.MobileConnect.Authentication;
using GSMA.MobileConnect.Claims;
using GSMA.MobileConnect.Exceptions;
using GSMA.MobileConnect.Utils;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace GSMA.MobileConnect.Test.Authentication
{
    [TestFixture]
    public class AuthenticationTests
    {
        private const string REDIRECT_URL = "http://localhost:8080/";
        private const string AUTHORIZE_URL = "http://localhost:8080/authorize";
        private const string TOKEN_URL = "http://localhost:8080/token";

        private Dictionary<string, RestResponse> _responses = new Dictionary<string, RestResponse>()
        {
            { "token", new RestResponse(System.Net.HttpStatusCode.OK, "{\"access_token\":\"966ad150-16c5-11e6-944f-43079d13e2f3\",\"token_type\":\"Bearer\",\"expires_in\":3600,\"id_token\":\"eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJub25jZSI6Ijc3YzE2M2VmZDkzYzQ4ZDFhNWY2NzdmNGNmNTUzOGE4Iiwic3ViIjoiY2M3OGEwMmNjM2ViNjBjOWVjNTJiYjljZDNhMTg5MTAiLCJhbXIiOlsiU0lNX1BJTiJdLCJhdXRoX3RpbWUiOjE0NjI4OTQ4NTcsImFjciI6IjIiLCJhenAiOiI2Njc0MmE4NS0yMjgyLTQ3NDctODgxZC1lZDViN2JkNzRkMmQiLCJpYXQiOjE0NjI4OTQ4NTYsImV4cCI6MTQ2Mjg5ODQ1NiwiYXVkIjpbIjY2NzQyYTg1LTIyODItNDc0Ny04ODFkLWVkNWI3YmQ3NGQyZCJdLCJpc3MiOiJodHRwOi8vb3BlcmF0b3JfYS5zYW5kYm94Mi5tb2JpbGVjb25uZWN0LmlvL29pZGMvYWNjZXNzdG9rZW4ifQ.lwXhpEp2WUTi0brKBosM8Uygnrdq6FnLqkZ0Bm53gXA\"}") },
            { "invalid-code", new RestResponse(System.Net.HttpStatusCode.BadRequest, "{\"error\":\"invalid_grant\",\"error_description\":\"Authorization code doesn't exist or is invalid for the client\"}") },
        };

        private MobileConnect.Discovery.SupportedVersions _defaultVersions = new MobileConnect.Discovery.SupportedVersions(new Dictionary<string, string> { ["openid"] = "mc_v1.2" });
        private IAuthentication _authentication;
        private MockRestClient _restClient;
        private MobileConnectConfig _config;

        [SetUp]
        public void Setup()
        {
            _restClient = new MockRestClient();
            _authentication = new MobileConnect.Authentication.Authentication(this._restClient);
            _config = new MobileConnectConfig() { ClientId = "1234567890", ClientSecret = "1234567890", DiscoveryUrl = "http://localhost:8080/v2/discovery/" };
        }

        [Test]
        public void StartAuthenticationReturnsUrlWhenArgumentsValid()
        {
            var result = _authentication.StartAuthentication(_config.ClientId, AUTHORIZE_URL, REDIRECT_URL, "state", "nonce", null, null, null);

            Assert.IsNotNull(result);
            Assert.IsNotEmpty(result.Url);
            Assert.That(result.Url.Contains(AUTHORIZE_URL));
        }

        [Test]
        public void StartAuthenticationWith1_1VersionShouldStripAuthnArgumentFromScope()
        {
            var initialScope = "openid mc_authn";
            var expectedScope = "openid";
            var versions = new MobileConnect.Discovery.SupportedVersions(new Dictionary<string, string> { ["openid"] = "mc_v1.1" });

            var result = _authentication.StartAuthentication(_config.ClientId, AUTHORIZE_URL, REDIRECT_URL, "state", "nonce", null, versions, new AuthenticationOptions { Scope = initialScope });
            var actualScope = HttpUtils.ExtractQueryValue(result.Url, "scope");

            Assert.AreEqual(expectedScope, actualScope);
        }

        [Test]
        public void StartAuthenticationWith1_2VersionShouldLeaveAuthnArgumentInScope()
        {
            var initialScope = "openid mc_authn";
            var expectedScope = "openid mc_authn";
            var versions = new MobileConnect.Discovery.SupportedVersions(new Dictionary<string, string> { ["openid"] = "mc_v1.2" });

            var result = _authentication.StartAuthentication(_config.ClientId, AUTHORIZE_URL, REDIRECT_URL, "state", "nonce", null, versions, new AuthenticationOptions { Scope = initialScope });
            var actualScope = HttpUtils.ExtractQueryValue(result.Url, "scope");

            Assert.AreEqual(expectedScope, actualScope);
        }

        [Test]
        public void StartAuthenticationWithout1_2VersionShouldAddAuthnArgumentToScope()
        {
            var initialScope = "openid";
            var expectedScope = "openid mc_authn";
            var versions = new MobileConnect.Discovery.SupportedVersions(new Dictionary<string, string> { ["openid"] = "mc_v1.2" });

            var result = _authentication.StartAuthentication(_config.ClientId, AUTHORIZE_URL, REDIRECT_URL, "state", "nonce", null, versions, new AuthenticationOptions { Scope = initialScope });
            var actualScope = HttpUtils.ExtractQueryValue(result.Url, "scope");

            Assert.AreEqual(expectedScope, actualScope);
        }

        [Test]
        public void StartAuthenticationWithMc_AuthzScopeShouldAddAuthorizationArguments()
        {
            var options = new AuthenticationOptions
            {
                Scope = "openid mc_authz",
                ClientName = "test",
                Context = "context",
                BindingMessage = "binding",
            };

            var result = _authentication.StartAuthentication(_config.ClientId, AUTHORIZE_URL, REDIRECT_URL, "state", "nonce", null, _defaultVersions, options);
            var query = HttpUtils.ParseQueryString(new Uri(result.Url).Query);

            Assert.AreEqual(options.Context, query["context"]);
            Assert.AreEqual(options.ClientName, query["client_name"]);
            Assert.AreEqual(options.BindingMessage, query["binding_message"]);
        }

        [Test]
        public void StartAuthenticationWithContextShouldUseAuthorizationScope()
        {
            var initialScope = "openid";
            var expectedScope = "openid mc_authz";
            var options = new AuthenticationOptions { Scope = initialScope, ClientName = "clientName", Context = "context" };

            var result = _authentication.StartAuthentication(_config.ClientId, AUTHORIZE_URL, REDIRECT_URL, "state", "nonce", null, _defaultVersions, options);
            var actualScope = HttpUtils.ExtractQueryValue(result.Url, "scope");

            Assert.AreEqual(expectedScope, actualScope);
        }

        [Test]
        public void StartAuthenticationWithMobileConnectProductScopeShouldUseAuthorization()
        {
            var initialScope = "openid mc_authn mc_identity_phone";
            var options = new AuthenticationOptions { Scope = initialScope };

            Assert.Throws<MobileConnectInvalidArgumentException>(() => _authentication.StartAuthentication(_config.ClientId, AUTHORIZE_URL, REDIRECT_URL, "state", "nonce", null, _defaultVersions, options));
        }

        [Test]
        public void StartAuthenticationWithClaimsShouldEncodeAndIncludeClaims()
        {
            var claims = new ClaimsParameter();
            claims.IdToken.AddRequired("test1");
            claims.UserInfo.AddWithValue("test2", false, "testvalue");
            var options = new AuthenticationOptions { Claims = claims };
            var expectedClaims = JsonConvert.SerializeObject(claims, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

            var result = _authentication.StartAuthentication(_config.ClientId, AUTHORIZE_URL, REDIRECT_URL, "state", "nonce", null, _defaultVersions, options);
            var actualClaims = HttpUtils.ExtractQueryValue(result.Url, "claims");

            Assert.IsNotEmpty(actualClaims);
            Assert.AreEqual(expectedClaims, actualClaims);
        }

        [Test]
        public void StartAuthenticationWithClaimsShouldEncodeAndIncludeClaimsJson()
        {
            var claims = "{\"user_info\":{\"test1\":{\"value\":\"test\"}}}";
            var options = new AuthenticationOptions { ClaimsJson = claims };

            var result = _authentication.StartAuthentication(_config.ClientId, AUTHORIZE_URL, REDIRECT_URL, "state", "nonce", null, _defaultVersions, options);
            var actualClaims = HttpUtils.ExtractQueryValue(result.Url, "claims");

            Assert.IsNotEmpty(actualClaims);
            Assert.AreEqual(claims, actualClaims);
        }

        [Test]
        public void RequestTokenShouldHandleTokenResponse()
        {
            var response = _responses["token"];
            _restClient.NextExpectedResponse = response;

            var result = _authentication.RequestToken(_config.ClientId, _config.ClientSecret, TOKEN_URL, REDIRECT_URL, "code");

            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.ResponseCode);
            Assert.IsNotNull(result.ResponseData);
            Assert.IsNotEmpty(result.ResponseData.AccessToken);
        }

        [Test]
        public void RequestTokenShouldHandleInvalidCodeResponse()
        {
            var response = _responses["invalid-code"];
            _restClient.NextExpectedResponse = response;

            var result = _authentication.RequestToken(_config.ClientId, _config.ClientSecret, TOKEN_URL, REDIRECT_URL, "code");

            Assert.IsNotNull(result);
            Assert.AreEqual(400, result.ResponseCode);
            Assert.IsNotNull(result.ErrorResponse);
            Assert.IsNotNull(result.ErrorResponse.ErrorDescription);
        }

        [Test]
        public void RequestTokenShouldHandleHttpRequestException()
        {
            var response = _responses["token"];
            _restClient.NextException = new System.Net.Http.HttpRequestException("this is the message");

            Assert.ThrowsAsync<MobileConnectEndpointHttpException>(() => _authentication.RequestTokenAsync(_config.ClientId, _config.ClientSecret, TOKEN_URL, REDIRECT_URL, "code"));
        }

        [Test]
        public void RequestTokenShouldHandleWebException()
        {
            var response = _responses["token"];
            _restClient.NextException = new System.Net.WebException("this is the message");

            Assert.ThrowsAsync<MobileConnectEndpointHttpException>(() => _authentication.RequestTokenAsync(_config.ClientId, _config.ClientSecret, TOKEN_URL, REDIRECT_URL, "code"));
        }

        #region Argument Validation

        [Test]
        public void StartAuthenticationShouldThrowWhenClientIdIsNull()
        {
            Assert.Throws<MobileConnectInvalidArgumentException>(() => _authentication.StartAuthentication(null, AUTHORIZE_URL, REDIRECT_URL, "state", "nonce", null, null, null));
        }

        [Test]
        public void StartAuthenticationShouldThrowWhenAuthorizeUrlIsNull()
        {
            Assert.Throws<MobileConnectInvalidArgumentException>(() => _authentication.StartAuthentication(_config.ClientId, null, REDIRECT_URL, "state", "nonce", null, null, null));
        }

        [Test]
        public void StartAuthenticationShouldThrowWhenRedirectUrlIsNull()
        {
            Assert.Throws<MobileConnectInvalidArgumentException>(() => _authentication.StartAuthentication(_config.ClientId, AUTHORIZE_URL, null, "state", "nonce", null, null, null));
        }

        [Test]
        public void StartAuthenticationShouldThrowWhenStateIsNull()
        {
            Assert.Throws<MobileConnectInvalidArgumentException>(() => _authentication.StartAuthentication(_config.ClientId, AUTHORIZE_URL, REDIRECT_URL, null, "nonce", null, null, null));
        }

        [Test]
        public void StartAuthenticationShouldThrowWhenNonceIsNull()
        {
            Assert.Throws<MobileConnectInvalidArgumentException>(() => _authentication.StartAuthentication(_config.ClientId, AUTHORIZE_URL, REDIRECT_URL, "state", null, null, null, null));
        }

        [Test]
        public void StartAuthenticationShouldThrowWhenClientNameIsNullAndShouldUseAuthorization()
        {
            var options = new AuthenticationOptions { Context = "context", BindingMessage = "bind", ClientName = null };
            Assert.Throws<MobileConnectInvalidArgumentException>(() => _authentication.StartAuthentication(_config.ClientId, AUTHORIZE_URL, REDIRECT_URL, "state", null, null, null, options));
        }

        [Test]
        public void StartAuthenticationShouldThrowWhenContextIsNullAndShouldUseAuthorization()
        {
            var options = new AuthenticationOptions { Context = null, BindingMessage = "bind", ClientName = "client" };
            Assert.Throws<MobileConnectInvalidArgumentException>(() => _authentication.StartAuthentication(_config.ClientId, AUTHORIZE_URL, REDIRECT_URL, "state", null, null, null, options));
        }

        [Test]
        public void RequestTokenShouldThrowWhenClientIdIsNull()
        {
            Assert.ThrowsAsync<MobileConnectInvalidArgumentException>(() => _authentication.RequestTokenAsync(null, _config.ClientSecret, TOKEN_URL, REDIRECT_URL, "code"));
        }

        [Test]
        public void RequestTokenShouldThrowWhenClientSecretIsNull()
        {
            Assert.ThrowsAsync<MobileConnectInvalidArgumentException>(() => _authentication.RequestTokenAsync(_config.ClientId, null, TOKEN_URL, REDIRECT_URL, "code"));
        }

        [Test]
        public void RequestTokenShouldThrowWhenTokenUrlIsNull()
        {
            Assert.ThrowsAsync<MobileConnectInvalidArgumentException>(() => _authentication.RequestTokenAsync(_config.ClientId, _config.ClientSecret, null, REDIRECT_URL, "code"));
        }

        [Test]
        public void RequestTokenShouldThrowWhenRedirectUrlIsNull()
        {
            Assert.ThrowsAsync<MobileConnectInvalidArgumentException>(() => _authentication.RequestTokenAsync(_config.ClientId, _config.ClientSecret, TOKEN_URL, null, "code"));
        }

        [Test]
        public void RequestTokenShouldThrowWhenCodeIsNull()
        {
            Assert.ThrowsAsync<MobileConnectInvalidArgumentException>(() => _authentication.RequestTokenAsync(_config.ClientId, _config.ClientSecret, TOKEN_URL, REDIRECT_URL, null));
        }

        #endregion
    }
}
