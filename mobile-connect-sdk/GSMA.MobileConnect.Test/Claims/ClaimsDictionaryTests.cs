using GSMA.MobileConnect.Claims;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSMA.MobileConnect.Test.Claims
{
    [TestFixture]
    public class ClaimsDictionaryTests
    {
        [Test]
        public void ClaimsDictionaryShouldSerialize()
        {
            var claims = new ClaimsDictionary();
            claims.Add("test");
            claims.AddRequired("test2");
            claims.AddWithValue("test3", false, "1634");
            var expected = "{\"test\":null,\"test2\":{\"essential\":true},\"test3\":{\"value\":\"1634\"}}";

            var serialized = JsonConvert.SerializeObject(claims);

            Assert.AreEqual(expected, serialized);
        }

        [Test]
        public void ClaimsDictionaryShouldDeserialize()
        {
            var serialized = "{\"test\":null,\"test2\":{\"essential\":true},\"test3\":{\"value\":\"1634\"}}";

            var actual = JsonConvert.DeserializeObject<ClaimsDictionary>(serialized);

            Assert.AreEqual(3, actual.Count);
            Assert.AreEqual(null, actual["test"]);
            Assert.IsNotNull(actual["test2"]);
            Assert.IsNotNull(actual["test3"]);
        }

        [Test]
        public void RemoveShouldRemoveClaimsValue()
        {
            var claims = new ClaimsDictionary();
            claims.Add("test");
            claims.AddWithValue("test2", true, "1234567");

            claims.Remove("test2");

            Assert.AreEqual(1, claims.Count);
            Assert.IsNull(claims["test2"]);
        }
    }
}
