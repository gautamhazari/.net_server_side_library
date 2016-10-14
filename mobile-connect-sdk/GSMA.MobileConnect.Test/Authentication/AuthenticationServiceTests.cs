using GSMA.MobileConnect.Authentication;
using GSMA.MobileConnect.Claims;
using GSMA.MobileConnect.Exceptions;
using GSMA.MobileConnect.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace GSMA.MobileConnect.Test.Authentication
{
    [TestFixture]
    public class AuthenticationServiceTests
    {
        private const string REDIRECT_URL = "http://localhost:8080/";
        private const string AUTHORIZE_URL = "http://localhost:8080/authorize";
        private const string TOKEN_URL = "http://localhost:8080/token";

        private Dictionary<string, RestResponse> _responses = new Dictionary<string, RestResponse>()
        {
            { "token", new RestResponse(System.Net.HttpStatusCode.OK, "{\"access_token\":\"966ad150-16c5-11e6-944f-43079d13e2f3\",\"token_type\":\"Bearer\",\"expires_in\":3600,\"id_token\":\"eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJub25jZSI6Ijc3YzE2M2VmZDkzYzQ4ZDFhNWY2NzdmNGNmNTUzOGE4Iiwic3ViIjoiY2M3OGEwMmNjM2ViNjBjOWVjNTJiYjljZDNhMTg5MTAiLCJhbXIiOlsiU0lNX1BJTiJdLCJhdXRoX3RpbWUiOjE0NjI4OTQ4NTcsImFjciI6IjIiLCJhenAiOiI2Njc0MmE4NS0yMjgyLTQ3NDctODgxZC1lZDViN2JkNzRkMmQiLCJpYXQiOjE0NjI4OTQ4NTYsImV4cCI6MTQ2Mjg5ODQ1NiwiYXVkIjpbIjY2NzQyYTg1LTIyODItNDc0Ny04ODFkLWVkNWI3YmQ3NGQyZCJdLCJpc3MiOiJodHRwOi8vb3BlcmF0b3JfYS5zYW5kYm94Mi5tb2JpbGVjb25uZWN0LmlvL29pZGMvYWNjZXNzdG9rZW4ifQ.lwXhpEp2WUTi0brKBosM8Uygnrdq6FnLqkZ0Bm53gXA\"}") },
            { "invalid-code", new RestResponse(System.Net.HttpStatusCode.BadRequest, "{\"error\":\"invalid_grant\",\"error_description\":\"Authorization code doesn't exist or is invalid for the client\"}") },
            { "token-revoked", new RestResponse(System.Net.HttpStatusCode.OK, "") }
        };

        private MobileConnect.Discovery.SupportedVersions _defaultVersions = new MobileConnect.Discovery.SupportedVersions(new Dictionary<string, string> { ["openid"] = "mc_v1.2" });
        private IAuthenticationService _authentication;
        private MockRestClient _restClient;
        private MobileConnectConfig _config;

        [SetUp]
        public void Setup()
        {
            _restClient = new MockRestClient();
            _authentication = new MobileConnect.Authentication.AuthenticationService(this._restClient);
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
        public void StartAuthenticationReturnsUrlWithRequestedMaxAgeArgument()
        {
            int maxage = 0;
            var result = _authentication.StartAuthentication(_config.ClientId, AUTHORIZE_URL, REDIRECT_URL, "state", "nonce", "zxcvbnmasdfghjklqwertyuiop", _defaultVersions, new AuthenticationOptions { MaxAge = maxage });

            Assert.IsNotNull(result);
            Assert.IsNotEmpty(result.Url);
            Assert.AreEqual(maxage.ToString(), HttpUtils.ExtractQueryValue(result.Url, "max_age"));
        }

        [Test]
        public void StartAuthenticationReturnsUrlWithRequestedPromptArgument()
        {
            string prompt = "login";
            var result = _authentication.StartAuthentication(_config.ClientId, AUTHORIZE_URL, REDIRECT_URL, "state", "nonce", "zxcvbnmasdfghjklqwertyuiop", _defaultVersions, new AuthenticationOptions { Prompt = prompt });

            Assert.IsNotNull(result);
            Assert.IsNotEmpty(result.Url);
            Assert.AreEqual(prompt, HttpUtils.ExtractQueryValue(result.Url, "prompt"));
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

        [Test]
        public void RefreshTokenShouldHandleTokenResponse()
        {
            var response = _responses["token"];
            _restClient.NextExpectedResponse = response;

            var result = _authentication.RefreshToken(_config.ClientId, _config.ClientSecret, TOKEN_URL, "token");

            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.ResponseCode);
            Assert.IsNotNull(result.ResponseData);
            Assert.IsNotEmpty(result.ResponseData.AccessToken);
        }

        [Test]
        public void RefreshTokenShouldHandleHttpRequestException()
        {
            var response = _responses["token"];
            _restClient.NextException = new System.Net.Http.HttpRequestException("this is the message");

            Assert.ThrowsAsync<MobileConnectEndpointHttpException>(() => _authentication.RefreshTokenAsync(_config.ClientId, _config.ClientSecret, TOKEN_URL, "token"));
        }

        [Test]
        public void RefreshTokenShouldHandleWebException()
        {
            var response = _responses["token"];
            _restClient.NextException = new System.Net.WebException("this is the message");

            Assert.ThrowsAsync<MobileConnectEndpointHttpException>(() => _authentication.RefreshTokenAsync(_config.ClientId, _config.ClientSecret, TOKEN_URL, "token"));
        }

        [Test]
        public void RevokeTokenShouldMarkSuccessIfNoError()
        {
            var response = _responses["token-revoked"];
            _restClient.NextExpectedResponse = response;

            var result = _authentication.RevokeToken(_config.ClientId, _config.ClientSecret, "http://revoke", "token", "refresh_token");

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Success);
            Assert.IsNull(result.ErrorResponse);
        }

        [Test]
        public void RevokeTokenShouldReturnErrorIfError()
        {
            var response = _responses["invalid-code"];
            _restClient.NextExpectedResponse = response;

            var result = _authentication.RevokeToken(_config.ClientId, _config.ClientSecret, "http://revoke", "token", "refresh_token");

            Assert.IsNotNull(result);
            Assert.IsFalse(result.Success);
            Assert.IsNotNull(result.ErrorResponse);
            Assert.AreEqual("invalid_grant", result.ErrorResponse.Error);
        }

        [Test]
        public void ValidateTokenResponseShouldValidateIfAccessAndIdTokenAreValid()
        {
            var jwksJson = "{\"keys\":[{\"alg\":\"RS256\",\"e\":\"AQAB\",\"n\":\"hzr2li5ABVbbQ4BvdDskl6hejaVw0tIDYO-C0GBr5lRA-AXtmCO7bh0CEC9-R6mqctkzUhVnU22Vrj-B1J0JtJoaya9VTC3DdhzI_-7kxtIc5vrHq-ss5wo8-tK7UqtKLSRf9DcyZA0H9FEABbO5Qfvh-cfK4EI_ytA5UBZgO322RVYgQ9Do0D_-jf90dcuUgoxz_JTAOpVNc0u_m9LxGnGL3GhMbxLaX3eUublD40aK0nS2k37dOYOpQHxuAS8BZxLvS6900qqaZ6z0kwZ2WFq-hhk3Imd6fweS724fzqVslY7rHpM5n7z5m7s1ArurU1dBC1Dxw1Hzn6ZeJkEaZQ\",\"kty\":\"RSA\",\"use\":\"sig\"}]}";
            var rawResponse = new RestResponse(System.Net.HttpStatusCode.Accepted, "{\"access_token\":\"966ad150-16c5-11e6-944f-43079d13e2f3\",\"token_type\":\"Bearer\",\"expires_in\":3600,\"id_token\":\"eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCJ9.eyJub25jZSI6IjEyMzQ1Njc4OTAiLCJhdWQiOiJ4LWNsaWVudGlkLXgiLCJhenAiOiJ4LWNsaWVudGlkLXgiLCJpc3MiOiJodHRwOi8vbW9iaWxlY29ubmVjdC5pbyIsImV4cCI6MjE0NzQ4MzY0NywiYXV0aF90aW1lIjoyMTQ3NDgzNjQ3LCJpYXQiOjE0NzEwMDczMjd9.U9c5iuybG4GIvrbQH5BT9AgllRbPL6SuIzL4Y3MW7VlCVIQOc_HFfkiLa0LNvqZiP-kFlADmnkzuuQxPq7IyaOILVYct20mrcOb_U_zMli4jg-t9P3BxHaq3ds9JlLBjz0oewd01ZQtWHgRnrGymfKAIojzHlde-aePuL1M26Eld5zoKQvCLcKAynZsjKsWF_6YdLk-uhlC5ofMOaOoPirPSPAxYvbj91z3o9XIgSHoU-umN7AJ6UQ4H-ulfftlRGK8hz0Yzpf2MHOy9OHg1u3ayfCaaf8g5zKGngcz0LgK9VAw2B31xJw-RHkPPh0Hz82FgBc4588oEFC1c22GGTw\"}");
            var tokenResponse = new RequestTokenResponse(rawResponse);
            var jwks = JsonConvert.DeserializeObject<JWKeyset>(jwksJson);
            string nonce = "1234567890";
            string clientId = "x-clientid-x";
            string issuer = "http://mobileconnect.io";
            int? maxAge = 36000;

            var actual = _authentication.ValidateTokenResponse(tokenResponse, clientId, issuer, nonce, maxAge, jwks);

            Assert.AreEqual(TokenValidationResult.Valid, actual);
        }

        [Test]
        public void ValidateTokenResponseShouldNotValidateIfResponseIsIncomplete()
        {
            var jwksJson = "{\"keys\":[{\"alg\":\"RS256\",\"e\":\"AQAB\",\"n\":\"hzr2li5ABVbbQ4BvdDskl6hejaVw0tIDYO-C0GBr5lRA-AXtmCO7bh0CEC9-R6mqctkzUhVnU22Vrj-B1J0JtJoaya9VTC3DdhzI_-7kxtIc5vrHq-ss5wo8-tK7UqtKLSRf9DcyZA0H9FEABbO5Qfvh-cfK4EI_ytA5UBZgO322RVYgQ9Do0D_-jf90dcuUgoxz_JTAOpVNc0u_m9LxGnGL3GhMbxLaX3eUublD40aK0nS2k37dOYOpQHxuAS8BZxLvS6900qqaZ6z0kwZ2WFq-hhk3Imd6fweS724fzqVslY7rHpM5n7z5m7s1ArurU1dBC1Dxw1Hzn6ZeJkEaZQ\",\"kty\":\"RSA\",\"use\":\"sig\"}]}";
            var rawResponse = new RestResponse(System.Net.HttpStatusCode.Accepted, "");
            var tokenResponse = new RequestTokenResponse(rawResponse);
            var jwks = JsonConvert.DeserializeObject<JWKeyset>(jwksJson);
            string nonce = "1234567890";
            string clientId = "x-clientid-x";
            string issuer = "http://mobileconnect.io";
            int? maxAge = 36000;

            var actual = _authentication.ValidateTokenResponse(tokenResponse, clientId, issuer, nonce, maxAge, jwks);

            Assert.AreEqual(TokenValidationResult.IncompleteTokenResponse, actual);
        }

        [Test]
        public void ValidateTokenResponseShouldNotValidateIfAccessTokenIsInvalid()
        {
            var jwksJson = "{\"keys\":[{\"alg\":\"RS256\",\"e\":\"AQAB\",\"n\":\"hzr2li5ABVbbQ4BvdDskl6hejaVw0tIDYO-C0GBr5lRA-AXtmCO7bh0CEC9-R6mqctkzUhVnU22Vrj-B1J0JtJoaya9VTC3DdhzI_-7kxtIc5vrHq-ss5wo8-tK7UqtKLSRf9DcyZA0H9FEABbO5Qfvh-cfK4EI_ytA5UBZgO322RVYgQ9Do0D_-jf90dcuUgoxz_JTAOpVNc0u_m9LxGnGL3GhMbxLaX3eUublD40aK0nS2k37dOYOpQHxuAS8BZxLvS6900qqaZ6z0kwZ2WFq-hhk3Imd6fweS724fzqVslY7rHpM5n7z5m7s1ArurU1dBC1Dxw1Hzn6ZeJkEaZQ\",\"kty\":\"RSA\",\"use\":\"sig\"}]}";
            var rawResponse = new RestResponse(System.Net.HttpStatusCode.Accepted, "{\"token_type\":\"Bearer\",\"expires_in\":3600,\"id_token\":\"eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCJ9.eyJub25jZSI6IjEyMzQ1Njc4OTAiLCJhdWQiOiJ4LWNsaWVudGlkLXgiLCJhenAiOiJ4LWNsaWVudGlkLXgiLCJpc3MiOiJodHRwOi8vbW9iaWxlY29ubmVjdC5pbyIsImV4cCI6MjE0NzQ4MzY0NywiYXV0aF90aW1lIjoyMTQ3NDgzNjQ3LCJpYXQiOjE0NzEwMDczMjd9.U9c5iuybG4GIvrbQH5BT9AgllRbPL6SuIzL4Y3MW7VlCVIQOc_HFfkiLa0LNvqZiP-kFlADmnkzuuQxPq7IyaOILVYct20mrcOb_U_zMli4jg-t9P3BxHaq3ds9JlLBjz0oewd01ZQtWHgRnrGymfKAIojzHlde-aePuL1M26Eld5zoKQvCLcKAynZsjKsWF_6YdLk-uhlC5ofMOaOoPirPSPAxYvbj91z3o9XIgSHoU-umN7AJ6UQ4H-ulfftlRGK8hz0Yzpf2MHOy9OHg1u3ayfCaaf8g5zKGngcz0LgK9VAw2B31xJw-RHkPPh0Hz82FgBc4588oEFC1c22GGTw\"}");
            var tokenResponse = new RequestTokenResponse(rawResponse);
            var jwks = JsonConvert.DeserializeObject<JWKeyset>(jwksJson);
            string nonce = "1234567890";
            string clientId = "x-clientid-x";
            string issuer = "http://mobileconnect.io";
            int? maxAge = 36000;

            var actual = _authentication.ValidateTokenResponse(tokenResponse, clientId, issuer, nonce, maxAge, jwks);

            Assert.AreEqual(TokenValidationResult.AccessTokenMissing, actual);
        }

        [Test]
        public void ValidateTokenResponseShouldValidateIfIdTokenIsInvalid()
        {
            var jwksJson = "{\"keys\":[{\"alg\":\"RS256\",\"e\":\"AQAB\",\"n\":\"hzr2li5ABVbbQ4BvdDskl6hejaVw0tIDYO-C0GBr5lRA-AXtmCO7bh0CEC9-R6mqctkzUhVnU22Vrj-B1J0JtJoaya9VTC3DdhzI_-7kxtIc5vrHq-ss5wo8-tK7UqtKLSRf9DcyZA0H9FEABbO5Qfvh-cfK4EI_ytA5UBZgO322RVYgQ9Do0D_-jf90dcuUgoxz_JTAOpVNc0u_m9LxGnGL3GhMbxLaX3eUublD40aK0nS2k37dOYOpQHxuAS8BZxLvS6900qqaZ6z0kwZ2WFq-hhk3Imd6fweS724fzqVslY7rHpM5n7z5m7s1ArurU1dBC1Dxw1Hzn6ZeJkEaZQ\",\"kty\":\"RSA\",\"use\":\"sig\"}]}";
            var rawResponse = new RestResponse(System.Net.HttpStatusCode.Accepted, "{\"access_token\":\"966ad150-16c5-11e6-944f-43079d13e2f3\",\"token_type\":\"Bearer\",\"expires_in\":3600,\"id_token\":\"eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCJ9.eyJub25jZSI6IjEyMzQ1Njc4OTAiLCJhdWQiOiJ4LWNsaWVudGlkLXgiLCJhenAiOiJ4LWNsaWVudGlkLXgiLCJpc3MiOiJodHRwOi8vbW9iaWxlY29ubmVjdC5pbyIsImV4cCI6MjE0NzQ4MzY0NywiYXV0aF90aW1lIjoyMTQ3NDgzNjQ3LCJpYXQiOjE0NzEwMDczMjd9.U9c5iuybG4GIvrbQH5BT9AgllRbPL6SuIzL4Y3MW7VlCVIQOc_HFfkiLa0LNvqZiP-kFlADmnkzuuQxPq7IyaOILVYct20mrcOb_U_zMli4jg-t9P3BxHaq3ds9JlLBjz0oewd01ZQtWHgRnrGymfKAIojzHlde-aePuL1M26Eld5zoKQvCLcKAynZsjKsWF_6YdLk-uhlC5ofMOaOoPirPSPAxYvbj91z3o9XIgSHoU-umN7AJ6UQ4H-ulfftlRGK8hz0Yzpf2MHOy9OHg1u3ayfCaaf8g5zKGngcz0LgK9VAw2B31xJw-RHkPPh0Hz82FgBc4588oEFC1c22GGTw\"}");
            var tokenResponse = new RequestTokenResponse(rawResponse);
            var jwks = JsonConvert.DeserializeObject<JWKeyset>(jwksJson);
            string nonce = "1234567890";
            string clientId = "x-clientid-x";
            int? maxAge = 36000;

            var actual = _authentication.ValidateTokenResponse(tokenResponse, clientId, "notissuer", nonce, maxAge, jwks);

            Assert.AreEqual(TokenValidationResult.InvalidIssuer, actual);
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

        [Test]
        public void RefreshTokenShouldThrowWhenClientIdIsNull()
        {
            Assert.ThrowsAsync<MobileConnectInvalidArgumentException>(() => _authentication.RefreshTokenAsync(null, _config.ClientSecret, TOKEN_URL, "token"));
        }

        [Test]
        public void RefreshTokenShouldThrowWhenClientSecretIsNull()
        {
            Assert.ThrowsAsync<MobileConnectInvalidArgumentException>(() => _authentication.RefreshTokenAsync(_config.ClientId, null, TOKEN_URL, "token"));
        }

        [Test]
        public void RefreshTokenShouldThrowWhenRefreshUrlIsNull()
        {
            Assert.ThrowsAsync<MobileConnectInvalidArgumentException>(() => _authentication.RefreshTokenAsync(_config.ClientId, _config.ClientSecret, null, "token"));
        }

        [Test]
        public void RefreshTokenShouldThrowWhenRefreshTokenIsNull()
        {
            Assert.ThrowsAsync<MobileConnectInvalidArgumentException>(() => _authentication.RefreshTokenAsync(_config.ClientId, _config.ClientSecret, TOKEN_URL, null));
        }

        [Test]
        public void RevokeTokenShouldThrowWhenClientIdIsNull()
        {
            Assert.ThrowsAsync<MobileConnectInvalidArgumentException>(() => _authentication.RevokeTokenAsync(null, _config.ClientSecret, "revoke url", "token", "token hint"));
        }

        [Test]
        public void RevokeTokenShouldThrowWhenClientSecretIsNull()
        {
            Assert.ThrowsAsync<MobileConnectInvalidArgumentException>(() => _authentication.RevokeTokenAsync(_config.ClientId, null, "revoke url", "token", "token hint"));
        }

        [Test]
        public void RevokeTokenShouldThrowWhenRevokeUrlIsNull()
        {
            Assert.ThrowsAsync<MobileConnectInvalidArgumentException>(() => _authentication.RevokeTokenAsync(_config.ClientId, _config.ClientSecret, null, "token", "token hint"));
        }

        [Test]
        public void RevokeTokenShouldThrowWhenTokenIsNull()
        {
            Assert.ThrowsAsync<MobileConnectInvalidArgumentException>(() => _authentication.RevokeTokenAsync(_config.ClientId, _config.ClientSecret, "revoke url", null, "token hint"));
        }

        #endregion
    }
}
