using GSMA.MobileConnect.Identity;
using GSMA.MobileConnect.Utils;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSMA.MobileConnect.Test.Identity
{
    [TestFixture]
    public class UserInfoResponseTests
    {
        [Test]
        public void ConstructorShouldSetResponseJson()
        {
            string responseJson = "{\"sub\":\"411421B0-38D6-6568-A53A-DF99691B7EB6\",\"email\":\"test2@example.com\",\"email_verified\":true}";
            var response = new RestResponse(System.Net.HttpStatusCode.Accepted, responseJson);

            var actual = new UserInfoResponse(response);

            Assert.AreEqual(responseJson, actual.ResponseJson);
        }

        [Test]
        public void ConstructorShouldSetResponseWithDecodedJWTPayload()
        {
            string responseJWT = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiI0MTE0MjFCMC0zOEQ2LTY1NjgtQTUzQS1ERjk5NjkxQjdFQjYiLCJlbWFpbCI6InRlc3QyQGV4YW1wbGUuY29tIiwiZW1haWxfdmVyaWZpZWQiOnRydWV9.AcpILNH2Uvok99MQWwxP6X7x3OwtVmTOw0t9Hq00gmQ";
            var response = new RestResponse(System.Net.HttpStatusCode.Accepted, responseJWT);

            var actual = new UserInfoResponse(response);
            JObject json = JObject.Parse(actual.ResponseJson);

            Assert.IsNotNull(actual.ResponseJson);
            Assert.AreEqual("411421B0-38D6-6568-A53A-DF99691B7EB6", (string)json["sub"]);
            Assert.AreEqual("test2@example.com", (string)json["email"]);
            Assert.AreEqual(true, (bool)json["email_verified"]);
        }
    }
}
