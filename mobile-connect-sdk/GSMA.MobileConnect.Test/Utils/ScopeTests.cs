using GSMA.MobileConnect.Utils;
using NUnit.Framework;

namespace GSMA.MobileConnect.Test.Utils
{
    [TestFixture]
    public class ScopeTests
    {
        [Test]
        public void CoerceOpenIdScopeShouldAddDefaultScopeIfNotExists()
        {
            var scope = "profile";
            var defaultScope = "openid mc_authn";
            var expectedScope = "openid mc_authn profile";

            var actual = Scope.CoerceOpenIdScope(scope, defaultScope);

            Assert.AreEqual(expectedScope, actual);
        }

        [Test]
        public void CoerceOpenIdScopeShouldDeduplicate()
        {
            var scope = "openid mc_authn mc_authn profile";
            var defaultScope = "openid mc_authn";
            var expectedScope = "openid mc_authn profile";

            var actual = Scope.CoerceOpenIdScope(scope, defaultScope);

            Assert.AreEqual(expectedScope, actual);
        }

        [Test]
        public void CoerceOpenIdScopeShouldDeduplicateIgnoringCase()
        {
            var scope = "OPENID mc_authn mc_authn profile";
            var defaultScope = "openid mc_authn";
            var expectedScope = "openid mc_authn profile";

            var actual = Scope.CoerceOpenIdScope(scope, defaultScope);

            Assert.AreEqual(expectedScope, actual);
        }
    }
}
