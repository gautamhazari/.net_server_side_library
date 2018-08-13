using GSMA.MobileConnect.Discovery;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Collections.Generic;

namespace GSMA.MobileConnect.Test.Discovery
{
    [TestFixture]
    public class SupportedVersionsTests
    {
        [Test]
        public void GetSupportedVersionShouldReturnVersionForScope()
        {
            var versions = new SupportedVersions(new Dictionary<string, string> { ["openid"] = "1.2", ["openid mc_authn"] = "2.0" });
            var expected = "2.0";

            var actual = versions.GetSupportedVersion("openid mc_authn");

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetSupportedVersionShouldReturnVersionForOpenidIfScopeNotFound()
        {
            var versions = new SupportedVersions(new Dictionary<string, string> { ["openid"] = "1.2", ["openid mc_authn"] = "2.0" });
            var expected = "1.2";

            var actual = versions.GetSupportedVersion("openid mc_authz");

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetSupportedVersionShouldReturnVersionFromDefaultVersionsIfOpenidScopeNotFound()
        {
            var versions = new SupportedVersions(null);
            var expected = "mc_v1.2";

            var actual = versions.GetSupportedVersion("openid mc_authz");

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetSupportedVersionShouldReturnNullIfScopeNotRecognised()
        {
            var versions = new SupportedVersions(null);

            var actual = versions.GetSupportedVersion("testest");

            Assert.IsNull(actual);
        }

        [Test]
        public void IsVersionSupportedShouldReturnFalseIfVersionNull()
        {
            var versions = new SupportedVersions(null);
            string version = null;

            var actual = versions.IsVersionSupported(version);

            Assert.IsFalse(actual);
        }

        [Test]
        public void IsVersionSupportedShouldReturnFalseIfVersionEmpty()
        {
            var versions = new SupportedVersions(null);
            string version = "";

            var actual = versions.IsVersionSupported(version);

            Assert.IsFalse(actual);
        }

        [Test]
        public void IsVersionSupportedShouldReturnTrueIfMaxVersionSupported()
        {
            var versions = new SupportedVersions(null);
            string version = "mc_v1.1";

            var actual = versions.IsVersionSupported(version);

            Assert.IsTrue(actual);
        }

        [Test]
        public void IsVersionSupportedShouldReturnTrueIfLowerThanMaxVersionSupported()
        {
            var versions = new SupportedVersions(new Dictionary<string, string> { ["openid"] = "mc_v1.2" });
            string version = "mc_v1.1";

            var actual = versions.IsVersionSupported(version);

            Assert.IsTrue(actual);
        }

        [Test]
        public void IsVersionSupportedShouldReturnFalseIfHigherThanMaxVersionSupported()
        {
            var versions = new SupportedVersions(new Dictionary<string, string> { ["openid"] = "mc_v1.2" });
            string version = "mc_v1.3";

            var actual = versions.IsVersionSupported(version);

            Assert.IsFalse(actual);
        }

        [TestCase("{}")]
        [TestCase("{\"mobile_connect_version_supported\":undefined}")]
        [TestCase("{\"mobile_connect_version_supported\":[]}")]
        [TestCase("{\"mobile_connect_version_supported\":[{\"test\":\"mc_v1.2\"}]}")]
        [TestCase("{\"mobile_connect_version_supported\":[{\"test\":\"mc_v1.2\"},{\"test\":\"mc_v1.1\"}]}")]
        public void CustomSerializationCanSerializeBackAndForth(string objectAsJson)
        {
            var asObject = JsonConvert.DeserializeObject<ProviderMetadata>(objectAsJson);
            var backToJson = JsonConvert.SerializeObject(asObject);
            var backToObject = JsonConvert.DeserializeObject<ProviderMetadata>(backToJson);

            Assert.AreEqual(
                asObject.MobileConnectVersionSupported.IsVersionSupported("1.0"),
                backToObject.MobileConnectVersionSupported.IsVersionSupported("1.0")
            );
        }
    }
}
