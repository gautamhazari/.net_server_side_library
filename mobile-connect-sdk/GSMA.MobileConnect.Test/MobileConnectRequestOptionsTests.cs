using NUnit.Framework;

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
            var scope = "scope value";
            var acr = "acr value";
            var maxAge = 1200;
            var claimsJson = "claims json";
            var claims = new MobileConnect.Claims.ClaimsParameter();

            var actual = new MobileConnectRequestOptions
            {
                Display = display,
                Prompt = prompt,
                UiLocales = uiLocales,
                ClaimsLocales = claimsLocales,
                IdTokenHint = idTokenHint,
                LoginHint = loginHint,
                Dtbs = dtbs,
                Scope = scope,
                AcrValues = acr,
                MaxAge = maxAge,
                ClaimsJson = claimsJson,
                Claims = claims,
            };

            Assert.AreEqual(display, actual.Display);
            Assert.AreEqual(prompt, actual.Prompt);
            Assert.AreEqual(uiLocales, actual.UiLocales);
            Assert.AreEqual(claimsLocales, actual.ClaimsLocales);
            Assert.AreEqual(idTokenHint, actual.IdTokenHint);
            Assert.AreEqual(loginHint, actual.LoginHint);
            Assert.AreEqual(dtbs, actual.Dtbs);
            Assert.AreEqual(scope, actual.Scope);
            Assert.AreEqual(acr, actual.AcrValues);
            Assert.AreEqual(maxAge, actual.MaxAge);
            Assert.AreEqual(claimsJson, actual.ClaimsJson);
            Assert.AreEqual(claims, actual.Claims);
        }
    }
}
