using NUnit.Framework;
using GSMA.MobileConnect.Utils;
using System;

namespace GSMA.MobileConnect.Test.Utils
{
    [TestFixture]
    public class ExtensionsTests
    {
        [Test]
        public void RemoveFromDelimitedStringRemovesValues()
        {
            var delimitedString = "test remove test remove value var";
            var expected = "test test value var";
            var toRemove = "remove";

            var actual = delimitedString.RemoveFromDelimitedString(toRemove, StringComparison.Ordinal);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void RemoveFromDelimitedRespectsSpecifiedStringComparison()
        {
            var delimitedString = "test remove test REmove value var";
            var expected = "test test value var";
            var toRemove = "reMOve";

            var actual = delimitedString.RemoveFromDelimitedString(toRemove, StringComparison.OrdinalIgnoreCase);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void RemoveFromDelimitedRespectsSpecifiedSeparator()
        {
            var delimitedString = "test:remove:test:remove:value:var";
            var expected = "test:test:value:var";
            var toRemove = "remove";

            var actual = delimitedString.RemoveFromDelimitedString(toRemove, StringComparison.Ordinal, ':');

            Assert.AreEqual(expected, actual);
        }
    }
}
