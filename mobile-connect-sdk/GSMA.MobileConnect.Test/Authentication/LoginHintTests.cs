using GSMA.MobileConnect.Authentication;
using GSMA.MobileConnect.Constants;
using GSMA.MobileConnect.Discovery;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSMA.MobileConnect.Test.Authentication
{
    [TestFixture]
    public class LoginHintTests
    {
        [Test]
        public void IsSupportedMSISDNShouldReturnTrueIfMSISDNIncluded()
        {
            var metadata = GetMetadataWithSupportedLoginHint(LoginHintPrefixes.MSISDN);

            var actual = LoginHint.IsSupportedForMSISDN(metadata);

            Assert.IsTrue(actual);
        }

        [Test]
        public void IsSupportedMSISDNShouldReturnFalseIfMSISDNNotIncluded()
        {
            var metadata = GetMetadataWithSupportedLoginHint(LoginHintPrefixes.PCR);

            var actual = LoginHint.IsSupportedForMSISDN(metadata);

            Assert.IsFalse(actual);
        }

        [Test]
        public void IsSupportedEncryptedMSISDNShouldReturnTrueIfEncryptedMSISDNIncluded()
        {
            var metadata = GetMetadataWithSupportedLoginHint(LoginHintPrefixes.EncryptedMSISDN);

            var actual = LoginHint.IsSupportedForEncryptedMSISDN(metadata);

            Assert.IsTrue(actual);
        }

        [Test]
        public void IsSupportedEncryptedMSISDNShouldReturnFalseIfEncryptedMSISDNNotIncluded()
        {
            var metadata = GetMetadataWithSupportedLoginHint(LoginHintPrefixes.PCR);

            var actual = LoginHint.IsSupportedForEncryptedMSISDN(metadata);

            Assert.IsFalse(actual);
        }

        [Test]
        public void IsSupportedPCRShouldReturnTrueIfPCRIncluded()
        {
            var metadata = GetMetadataWithSupportedLoginHint(LoginHintPrefixes.PCR);

            var actual = LoginHint.IsSupportedForPCR(metadata);

            Assert.IsTrue(actual);
        }

        [Test]
        public void IsSupportedPCRShouldReturnFalseIfPCRNotIncluded()
        {
            var metadata = GetMetadataWithSupportedLoginHint(LoginHintPrefixes.MSISDN);

            var actual = LoginHint.IsSupportedForPCR(metadata);

            Assert.IsFalse(actual);
        }

        [Test]
        public void IsSupportedMSISDNShouldReturnTrueIfMissingMetadata()
        {
            var actual = LoginHint.IsSupportedForMSISDN(null);

            Assert.IsTrue(actual);
        }

        [Test]
        public void IsSupportedEncryptedMSISDNShouldReturnTrueIfMissingMetadata()
        {
            var actual = LoginHint.IsSupportedForEncryptedMSISDN(null);

            Assert.IsTrue(actual);
        }

        [Test]
        public void IsSupportedPCRShouldReturnFalseIfMissingMetadata()
        {
            var actual = LoginHint.IsSupportedForPCR(null);

            Assert.IsFalse(actual);
        }

        [Test]
        public void IsSupportedPCRShouldReturnTrueIfSupportedVersionIs1_2()
        {
            var metadata = new ProviderMetadata
            {
                MobileConnectVersionSupported = new SupportedVersions(new Dictionary<string, string> { ["openid"] = "mc_v1.2" }),
                LoginHintMethodsSupported = null,
            };

            var actual = LoginHint.IsSupportedForMSISDN(metadata);

            Assert.IsTrue(actual);
        }

        [Test]
        public void IsSupportedForShouldReturnFalseIfUnrecognisedPrefixAndMissingMetadata()
        {
            var actual = LoginHint.IsSupportedFor(null, "testprefix");

            Assert.IsFalse(actual);
        }

        [Test]
        public void IsSupportedForShouldBeCaseInsensitive()
        {
            var metadata = GetMetadataWithSupportedLoginHint("MSISDN");

            var actual = LoginHint.IsSupportedFor(metadata, "MsIsDn");

            Assert.IsTrue(actual);
        }

        [Test]
        public void GenerateForMSISDNShouldGenerateCorrectFormat()
        {
            var actual = LoginHint.GenerateForMSISDN("+447700900250");

            Assert.AreEqual("MSISDN:447700900250", actual);
        }

        [Test]
        public void GenerateForEncryptedMSISDNShouldGenerateCorrectFormat()
        {
            var actual = LoginHint.GenerateForEncryptedMSISDN("zmalqpwoeirutyfhdjskaslxzmxncbv");

            Assert.AreEqual("ENCR_MSISDN:zmalqpwoeirutyfhdjskaslxzmxncbv", actual);
        }

        [Test]
        public void GenerateForPCRShouldGenerateCorrectFormat()
        {
            var actual = LoginHint.GenerateForPCR("zmalqpwoeirutyfhdjskaslxzmxncbv");

            Assert.AreEqual("PCR:zmalqpwoeirutyfhdjskaslxzmxncbv", actual);
        }

        [Test]
        public void GenerateForShouldReturnNullWhenValueNull()
        {
            Assert.IsNull(LoginHint.GenerateFor("PCR", null));
        }

        [Test]
        public void GenerateForShouldReturnNullWhenValueEmpty()
        {
            Assert.IsNull(LoginHint.GenerateFor("PCR", null));
        }

        [Test]
        public void GenerateForShouldReturnNullWhenPrefixNull()
        {
            Assert.IsNull(LoginHint.GenerateFor(null, "testvalue"));
        }

        [Test]
        public void GenerateForShouldReturnNullWhenPrefixEmpty()
        {
            Assert.IsNull(LoginHint.GenerateFor("", "testvalue"));
        }

        private ProviderMetadata GetMetadataWithSupportedLoginHint(string supported)
        {
            return new ProviderMetadata { LoginHintMethodsSupported = new List<string> { supported } };
        }
    }
}
