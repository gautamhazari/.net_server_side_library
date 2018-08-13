using GSMA.MobileConnect.Utils;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSMA.MobileConnect.Test.Utils
{
    [TestFixture]
    public class StringUtilsTests
    {
        [Test]
        public void EncodeAsBase64UrlShouldEncodeString()
        {
            var input = "{ \"url\": \"http://developer.mobileconnect.io/?test=12345\" }";

            var actual = StringUtils.EncodeAsBase64Url(input);

            Assert.AreEqual("eyAidXJsIjogImh0dHA6Ly9kZXZlbG9wZXIubW9iaWxlY29ubmVjdC5pby8_dGVzdD0xMjM0NSIgfQ", actual);
        }

        [Test]
        public void EncodeAsBase64ShouldEncodeString()
        {
            var input = "{ \"url\": \"http://developer.mobileconnect.io/?test=12345\" }";

            var actual = StringUtils.EncodeAsBase64(input);

            Assert.AreEqual("eyAidXJsIjogImh0dHA6Ly9kZXZlbG9wZXIubW9iaWxlY29ubmVjdC5pby8/dGVzdD0xMjM0NSIgfQ==", actual);
        }

        [Test]
        public void DecodeFromBase64ShouldDecodeString()
        {
            var input = "eyAidXJsIjogImh0dHA6Ly9kZXZlbG9wZXIubW9iaWxlY29ubmVjdC5pby8/dGVzdD0xMjM0NSIgfQ==";
            var expected = Encoding.UTF8.GetBytes("{ \"url\": \"http://developer.mobileconnect.io/?test=12345\" }");

            var actual = StringUtils.DecodeFromBase64(input);

            Assert.AreEqual(expected, actual);
        }
    }
}
