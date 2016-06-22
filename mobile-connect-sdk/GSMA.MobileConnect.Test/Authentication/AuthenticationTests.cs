using GSMA.MobileConnect.Authentication;
using GSMA.MobileConnect.Exceptions;
using GSMA.MobileConnect.Utils;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var result = _authentication.StartAuthentication(_config.ClientId, AUTHORIZE_URL, REDIRECT_URL, "state", "nonce", "scope", 3600, null, null, null);

            Assert.IsNotNull(result);
            Assert.IsNotEmpty(result.Url);
            Assert.That(result.Url.Contains(AUTHORIZE_URL));
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
            Assert.Throws<MobileConnectInvalidArgumentException>(() => _authentication.StartAuthentication(null, AUTHORIZE_URL, REDIRECT_URL, "state", "nonce", "scope", null, null, null, null));
        }

        [Test]
        public void StartAuthenticationShouldThrowWhenAuthorizeUrlIsNull()
        {
            Assert.Throws<MobileConnectInvalidArgumentException>(() => _authentication.StartAuthentication(_config.ClientId, null, REDIRECT_URL, "state", "nonce", "scope", null, null, null, null));
        }

        [Test]
        public void StartAuthenticationShouldThrowWhenRedirectUrlIsNull()
        {
            Assert.Throws<MobileConnectInvalidArgumentException>(() => _authentication.StartAuthentication(_config.ClientId, AUTHORIZE_URL, null, "state", "nonce", "scope", null, null, null, null));
        }

        [Test]
        public void StartAuthenticationShouldThrowWhenStateIsNull()
        {
            Assert.Throws<MobileConnectInvalidArgumentException>(() => _authentication.StartAuthentication(_config.ClientId, AUTHORIZE_URL, REDIRECT_URL, null, "nonce", "scope", null, null, null, null));
        }

        [Test]
        public void StartAuthenticationShouldThrowWhenNonceIsNull()
        {
            Assert.Throws<MobileConnectInvalidArgumentException>(() => _authentication.StartAuthentication(_config.ClientId, AUTHORIZE_URL, REDIRECT_URL, "state", null, "scope", null, null, null, null));
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
