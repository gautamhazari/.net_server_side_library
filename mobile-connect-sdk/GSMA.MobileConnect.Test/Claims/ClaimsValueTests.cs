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
    public class ClaimsValueTests
    {
        [Test]
        public void RequiredClaimsValueShouldSerializeToJson()
        {
            var claims = ClaimsValue.Required();
            var expected = "{\"essential\":true}";

            var serialized = JsonConvert.SerializeObject(claims);

            Assert.AreEqual(expected, serialized);
        }

        [Test]
        public void RequiredClaimsValueWithValueShouldSerializeToJson()
        {
            var claims = ClaimsValue.WithValue(true, "1263746");
            var expected = "{\"essential\":true,\"value\":\"1263746\"}";

            var serialized = JsonConvert.SerializeObject(claims);

            Assert.AreEqual(expected, serialized);
        }

        [Test]
        public void NotRequiredClaimsValueWithValueShouldSerializeToJson()
        {
            var claims = ClaimsValue.WithValue(false, "1263746");
            var expected = "{\"value\":\"1263746\"}";

            var serialized = JsonConvert.SerializeObject(claims);

            Assert.AreEqual(expected, serialized);
        }

        [Test]
        public void RequiredClaimsValueWithValuesShouldSerializeToJson()
        {
            var claims = ClaimsValue.WithValues(true, "1263746", "23456712");
            var expected = "{\"essential\":true,\"values\":[\"1263746\",\"23456712\"]}";

            var serialized = JsonConvert.SerializeObject(claims);

            Assert.AreEqual(expected, serialized);
        }

        [Test]
        public void NotRequiredClaimsValueWithValuesShouldSerializeToJson()
        {
            var claims = ClaimsValue.WithValues(false, "1263746", "23456712");
            var expected = "{\"values\":[\"1263746\",\"23456712\"]}";

            var serialized = JsonConvert.SerializeObject(claims);

            Assert.AreEqual(expected, serialized);
        }

        [Test]
        public void RequiredClaimsValueShouldDeserializeToJson()
        {
            var serialized = "{\"essential\":true}";

            var actual = JsonConvert.DeserializeObject<ClaimsValue>(serialized);

            Assert.AreEqual(true, actual.Essential);
            Assert.IsNull(actual.Value);
            Assert.IsNull(actual.Values);
        }

        [Test]
        public void RequiredClaimsValueWithValueShouldDeserializeToJson()
        {
            var serialized = "{\"essential\":true,\"value\":\"1263746\"}";
            var expectedValue = "1263746";

            var actual = JsonConvert.DeserializeObject<ClaimsValue>(serialized);

            Assert.AreEqual(true, actual.Essential);
            Assert.AreEqual(expectedValue, actual.Value);
            Assert.IsNull(actual.Values);
        }

        [Test]
        public void NotRequiredClaimsValueShouldDeserializeToJson()
        {
            var serialized = "{\"value\":\"1263746\"}";
            var expectedValue = "1263746";

            var actual = JsonConvert.DeserializeObject<ClaimsValue>(serialized);

            Assert.AreEqual(false, actual.Essential);
            Assert.AreEqual(expectedValue, actual.Value);
            Assert.IsNull(actual.Values);
        }

        [Test]
        public void RequiredClaimsValueWithValuesShouldDeserializeToJson()
        {
            var serialized = "{\"essential\":true,\"values\":[\"1263746\",\"23456712\"]}";
            var expectedValues = new object[] { "1263746", "23456712" };

            var actual = JsonConvert.DeserializeObject<ClaimsValue>(serialized);

            Assert.AreEqual(true, actual.Essential);
            Assert.IsNull(actual.Value);
            Assert.AreEqual(expectedValues, actual.Values);
        }

        [Test]
        public void NotRequiredClaimsValueWithValuesShouldDeserializeToJson()
        {
            var serialized = "{\"values\":[\"1263746\",\"23456712\"]}";
            var expectedValues = new object[] { "1263746", "23456712" };

            var actual = JsonConvert.DeserializeObject<ClaimsValue>(serialized);

            Assert.AreEqual(false, actual.Essential);
            Assert.IsNull(actual.Value);
            Assert.AreEqual(expectedValues, actual.Values);
        }
    }
}
