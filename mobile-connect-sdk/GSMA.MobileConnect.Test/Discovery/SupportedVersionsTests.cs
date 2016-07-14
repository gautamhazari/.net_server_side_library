using GSMA.MobileConnect.Discovery;
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
            var versions = new SupportedVersions(new Dictionary<string, string> { ["openid"] = "1", ["test"] = "2" });
            var expected = "2";

            var actual = versions.GetSupportedVersion("test");

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetSupportedVersionShouldReturnVersionForOpenidIfScopeNotFound()
        {
            var versions = new SupportedVersions(new Dictionary<string, string> { ["openid"] = "1", ["test2"] = "2" });
            var expected = "1";

            var actual = versions.GetSupportedVersion("test");

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
    }
}
