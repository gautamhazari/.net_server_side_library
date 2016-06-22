using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSMA.MobileConnect.Test
{
    [TestFixture]
    public class MobileConnectRequestOptionsTests
    {
        [Test]
        public void ShouldFillDiscoveryOptions()
        {
            var isUsingMobileData = true;
            var localClientIp = "111.11.11.11";
            var clientIp = "222.22.22.22";
            var expected = new MobileConnect.Discovery.DiscoveryOptions()
            {
                IsUsingMobileData = true,
                LocalClientIP = localClientIp,
                ClientIP = clientIp,
            };

            var actual = new MobileConnectRequestOptions
            {
                IsUsingMobileData = isUsingMobileData,
                LocalClientIP = localClientIp,
                ClientIP = clientIp,
            };

            Assert.AreEqual(isUsingMobileData, actual.IsUsingMobileData);
            Assert.AreEqual(localClientIp, actual.LocalClientIP);
            Assert.AreEqual(clientIp, actual.ClientIP);
        }

        [Test]
        public void ShouldFillAuthenticationOptions()
        {
            var display = "display type";
            var prompt = "prompt";
            var uiLocales = "ui locales";
            var claimsLocales = "claims locales";
            var idTokenHint = "id token";
            var loginHint = "login hint";
            var dtbs = "data to be sent";
            var expected = new MobileConnect.Authentication.AuthenticationOptions
            {
                Display = display,
                Prompt = prompt,
                UiLocales = uiLocales,
                ClaimsLocales = claimsLocales,
                IdTokenHint = idTokenHint,
                LoginHint = loginHint,
                Dtbs = dtbs,
            };

            var actual = new MobileConnectRequestOptions
            {
                Display = display,
                Prompt = prompt,
                UiLocales = uiLocales,
                ClaimsLocales = claimsLocales,
                IdTokenHint = idTokenHint,
                LoginHint = loginHint,
                Dtbs = dtbs,
            };

            Assert.AreEqual(display, actual.Display);
            Assert.AreEqual(prompt, actual.Prompt);
            Assert.AreEqual(uiLocales, actual.UiLocales);
            Assert.AreEqual(claimsLocales, actual.ClaimsLocales);
            Assert.AreEqual(idTokenHint, actual.IdTokenHint);
            Assert.AreEqual(loginHint, actual.LoginHint);
            Assert.AreEqual(dtbs, actual.Dtbs);
        }
    }
}
