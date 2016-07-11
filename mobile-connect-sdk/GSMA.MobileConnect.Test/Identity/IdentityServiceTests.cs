using GSMA.MobileConnect.Claims;
using GSMA.MobileConnect.Exceptions;
using GSMA.MobileConnect.Identity;
using GSMA.MobileConnect.Utils;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSMA.MobileConnect.Test.Identity
{
    [TestFixture]
    public class IdentityServiceTests
    {
        private static RestResponse _unauthorizedResponse = new RestResponse(System.Net.HttpStatusCode.Unauthorized, "")
        {
            Headers = new List<BasicKeyValuePair> { new BasicKeyValuePair("WWW-Authenticate", "Bearer error=\"invalid_request\", error_description=\"No Access Token\"") }
        };

        private Dictionary<string, RestResponse> _responses = new Dictionary<string, RestResponse>()
        {
            { "user-info", new RestResponse(System.Net.HttpStatusCode.OK, "{\"sub\":\"411421B0-38D6-6568-A53A-DF99691B7EB6\",\"email\":\"test2@example.com\",\"email_verified\":true}") },
            { "unauthorized", _unauthorizedResponse },
        };

        private MockRestClient _restClient;
        private IIdentityService _identityService;

        [SetUp]
        public void Setup()
        {
            _restClient = new MockRestClient();
            _identityService = new IdentityService(_restClient);
        }

        [Test]
        public void RequestUserInfoShouldHandleUserInfoResponse()
        {
            var response = _responses["user-info"];
            _restClient.NextExpectedResponse = response;

            var result = _identityService.RequestUserInfo("user info url", "zmalqpxnskwocbdjeivbfhru", "").Result;

            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.ResponseCode);
            Assert.IsNotNull(result.ResponseJson);
        }

        [Test]
        public void RequestUserInfoShouldHandleUnauthorizedResponse()
        {
            var response = _responses["unauthorized"];
            _restClient.NextExpectedResponse = response;

            var result = _identityService.RequestUserInfo("user info url", "zmalqpxnskwocbdjeivbfhru", "").Result;

            Assert.IsNotNull(result);
            Assert.AreEqual(401, result.ResponseCode);
            Assert.IsNull(result.ResponseJson);
            Assert.IsNotNull(result.ErrorResponse);
            Assert.IsNotEmpty(result.ErrorResponse.Error);
            Assert.IsNotEmpty(result.ErrorResponse.ErrorDescription);
        }

        [Test]
        public void RequestUserInfoShouldHandleHttpRequestException()
        {
            _restClient.NextException = new System.Net.Http.HttpRequestException("This is the message");

            Assert.ThrowsAsync<MobileConnectEndpointHttpException>(() => _identityService.RequestUserInfo("user info url", "zmalqpxnskwocbdjeivbfhru", ""));
        }

        [Test]
        public void RequestUserInfoShouldHandleWebRequestException()
        {
            _restClient.NextException = new System.Net.WebException("This is the message");

            Assert.ThrowsAsync<MobileConnectEndpointHttpException>(() => _identityService.RequestUserInfo("user info url", "zmalqpxnskwocbdjeivbfhru", ""));
        }

        [Test]
        public void RequestUserInfoShouldAcceptClaimsParameter()
        {
            _restClient.NextExpectedResponse = _responses["user-info"];
            var claims = new ClaimsParameter();
            claims.UserInfo.AddRequired("test");
            claims.IdToken.AddWithValue("testvalue", false, "this value");

            var result = _identityService.RequestUserInfo("user info url", "zmalqpxnskwocbdjeivbfhru", claims).Result;

            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.ResponseCode);
            Assert.IsNotNull(result.ResponseJson);
        }

        #region Argument Validation

        [Test]
        public void RequestUserInfoShouldThrowWhenUserInfoUrlNull()
        {
            Assert.ThrowsAsync<MobileConnectInvalidArgumentException>(() => _identityService.RequestUserInfo(null, "zmalqpxnskwocndjeivbfhru", ""));
        }

        [Test]
        public void RequestUserInfoShouldThrowWhenAccessTokenNull()
        {
            Assert.ThrowsAsync<MobileConnectInvalidArgumentException>(() => _identityService.RequestUserInfo("user info url", null, ""));
        }

        #endregion
    }
}
