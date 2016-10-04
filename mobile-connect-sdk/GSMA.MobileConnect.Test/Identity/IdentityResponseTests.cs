using GSMA.MobileConnect.Identity;
using GSMA.MobileConnect.Utils;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace GSMA.MobileConnect.Test.Identity
{
    [TestFixture]
    public class IdentityResponseTests
    {
        [Test]
        public void ConstructorShouldSetResponseJson()
        {
            string responseJson = "{\"sub\":\"411421B0-38D6-6568-A53A-DF99691B7EB6\",\"email\":\"test2@example.com\",\"email_verified\":true}";
            var response = new RestResponse(System.Net.HttpStatusCode.Accepted, responseJson);

            var actual = new IdentityResponse(response, IdentityService.InfoType.UserInfo);

            Assert.AreEqual(responseJson, actual.ResponseJson);
        }

        [Test]
        public void ConstructorShouldSetResponseWithDecodedJWTPayload()
        {
            string responseJWT = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiI0MTE0MjFCMC0zOEQ2LTY1NjgtQTUzQS1ERjk5NjkxQjdFQjYiLCJlbWFpbCI6InRlc3QyQGV4YW1wbGUuY29tIiwiZW1haWxfdmVyaWZpZWQiOnRydWV9.AcpILNH2Uvok99MQWwxP6X7x3OwtVmTOw0t9Hq00gmQ";
            var response = new RestResponse(System.Net.HttpStatusCode.Accepted, responseJWT);

            var actual = new IdentityResponse(response, IdentityService.InfoType.UserInfo);
            JObject json = JObject.Parse(actual.ResponseJson);

            Assert.IsNotNull(actual.ResponseJson);
            Assert.AreEqual("411421B0-38D6-6568-A53A-DF99691B7EB6", (string)json["sub"]);
            Assert.AreEqual("test2@example.com", (string)json["email"]);
            Assert.AreEqual(true, (bool)json["email_verified"]);
        }

        [Test]
        public void ConstructorShouldSetResponseWithNullContent()
        {
            var response = new RestResponse(System.Net.HttpStatusCode.Accepted, null);

            var actual = new IdentityResponse(response, IdentityService.InfoType.UserInfo);

            Assert.IsNull(actual.ResponseJson);
        }

        [Test]
        public void ConstructorShouldSetErrorForInvalidFormatResponseDataForUserInfo()
        {
            string responseJson = "<html>not valid</html>";
            var response = new RestResponse(System.Net.HttpStatusCode.Accepted, responseJson);

            var actual = new IdentityResponse(response, IdentityService.InfoType.UserInfo);

            Assert.IsNotNull(actual.ErrorResponse);
            Assert.AreEqual("invalid_format", actual.ErrorResponse.Error);
            Assert.AreEqual("{\"error\":\"invalid_format\",\"error_description\":\"Received UserInfo response that is not JSON or JWT format\"}", actual.ResponseJson);
        }

        [Test]
        public void ConstructorShouldSetErrorForInvalidFormatResponseDataForPremiumInfo()
        {
            string responseJson = "<html>not valid</html>";
            var response = new RestResponse(System.Net.HttpStatusCode.Accepted, responseJson);

            var actual = new IdentityResponse(response, IdentityService.InfoType.PremiumInfo);

            Assert.IsNotNull(actual.ErrorResponse);
            Assert.AreEqual("invalid_format", actual.ErrorResponse.Error);
            Assert.AreEqual("{\"error\":\"invalid_format\",\"error_description\":\"Received PremiumInfo response that is not JSON or JWT format\"}", actual.ResponseJson);
        }

        [Test]
        public void ConstructorShouldSetErrorForAuthenticationError()
        {
            var response = new RestResponse(System.Net.HttpStatusCode.Unauthorized, "");
            response.Headers = new List<BasicKeyValuePair> { new BasicKeyValuePair("WWW-Authenticate", "Bearer error = \"invalid_request\", error_description = \"No Access Token\"") };

            var actual = new IdentityResponse(response, IdentityService.InfoType.UserInfo);

            Assert.IsNotNull(actual.ErrorResponse);
            Assert.AreEqual("invalid_request", actual.ErrorResponse.Error);
            Assert.AreEqual("No Access Token", actual.ErrorResponse.ErrorDescription);
        }

        [Test]
        public void ResponseDataAsShouldDeserializeToUserInfoData()
        {
            string responseJson = "{\"sub\":\"411421B0-38D6-6568-A53A-DF99691B7EB6\",\"email\":\"test2@example.com\",\"email_verified\":true,\"phone_number\":\"+447700200200\",\"phone_number_verified\":true,\"birthdate\":\"1990-04-11\",\"updated_at\":\"1460779506\",\"address\":{\"formatted\":\"123 Fake Street \r\n Manchester\",\"postal_code\":\"M1 1AB\"}}";
            var response = new RestResponse(System.Net.HttpStatusCode.Accepted, responseJson);

            var userInfoResponse = new IdentityResponse(response, IdentityService.InfoType.UserInfo);
            var actual = userInfoResponse.ResponseDataAs<UserInfoData>();

            Assert.IsNotNull(actual);
            Assert.AreEqual("411421B0-38D6-6568-A53A-DF99691B7EB6", actual.Sub);
            Assert.AreEqual("test2@example.com", actual.Email);
            Assert.AreEqual(true, actual.EmailVerified);
            Assert.AreEqual("+447700200200", actual.PhoneNumber);
            Assert.AreEqual(true, actual.PhoneNumberVerified);
            Assert.IsNotNull(actual.Address);
            Assert.AreEqual("123 Fake Street \r\n Manchester", actual.Address.Formatted);
            Assert.AreEqual("M1 1AB", actual.Address.PostalCode);
            Assert.AreEqual("1990-04-11", actual.Birthdate);
            Assert.AreEqual(new DateTime(2016, 4, 16, 4, 5, 6), actual.UpdatedAt);
        }

        [Test]
        public void ResponseDataAsShouldReuseConvertedResponse()
        {
            string responseJson = "{\"sub\":\"411421B0-38D6-6568-A53A-DF99691B7EB6\",\"email\":\"test2@example.com\",\"email_verified\":true,\"phone_number\":\"+447700200200\",\"phone_number_verified\":true,\"birthdate\":\"1990-04-11\",\"updated_at\":\"1460779506\",\"address\":{\"formatted\":\"123 Fake Street \r\n Manchester\",\"postal_code\":\"M1 1AB\"}}";
            var response = new RestResponse(System.Net.HttpStatusCode.Accepted, responseJson);

            var userInfoResponse = new IdentityResponse(response, IdentityService.InfoType.UserInfo);
            var first = userInfoResponse.ResponseDataAs<UserInfoData>();
            var second = userInfoResponse.ResponseDataAs<UserInfoData>();

            Assert.AreSame(first, second);
        }

        [Test]
        public void ResponseDataAsShouldReturnDefaultIfResponseJsonNull()
        {
            var response = new RestResponse(System.Net.HttpStatusCode.Accepted, null);

            var userInfoResponse = new IdentityResponse(response, IdentityService.InfoType.UserInfo);
            var actual = userInfoResponse.ResponseDataAs<UserInfoData>();

            Assert.IsNull(actual);
        }
    }
}
