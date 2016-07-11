using GSMA.MobileConnect.Claims;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSMA.MobileConnect.Test.Claims
{
    [TestFixture]
    public class ClaimsParameterTests
    {
        [Test]
        public void UserInfoShouldSet()
        {
            var claims = new ClaimsDictionary
            {
                ["test"] = ClaimsValue.Required(),
                ["test2"] = ClaimsValue.WithValue(false, "1000"),
            };
            var parameter = new ClaimsParameter();
            parameter.UserInfo = claims;

            Assert.AreEqual(claims, parameter.UserInfo);
        }

        [Test]
        public void IdTokenShouldSet()
        {
            var claims = new ClaimsDictionary
            {
                ["test"] = ClaimsValue.Required(),
                ["test2"] = ClaimsValue.WithValue(false, "1000"),
            };
            var parameter = new ClaimsParameter();
            parameter.IdToken = claims;

            Assert.AreEqual(claims, parameter.IdToken);
        }
    }
}
