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
    public class UnixTimestampTests
    {
        [Test]
        public void ToUTCDateTimeShouldConvertTimestampFromString()
        {
            var timestamp = "1470330420";
            var actual = UnixTimestamp.ToUTCDateTime(timestamp);

            Assert.AreEqual(new DateTime(2016, 8, 4, 17, 7, 0, DateTimeKind.Utc), actual);
        }

        [Test]
        public void ToUTCDateTimeShouldConvertTimestampFromInt()
        {
            var timestamp = 1470330420;
            var actual = UnixTimestamp.ToUTCDateTime(timestamp);

            Assert.AreEqual(new DateTime(2016, 8, 4, 17, 7, 0, DateTimeKind.Utc), actual);
        }
    }
}
