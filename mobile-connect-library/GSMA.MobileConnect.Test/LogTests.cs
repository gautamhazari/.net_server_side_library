using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSMA.MobileConnect.Test
{
    [TestFixture]
    public class LogTests
    {
        [Test]
        public void DebugShouldNotExecuteMessageFuncIfLoggerNull()
        {
            Log.Debug(() =>
            {
                Assert.Fail();
                return "";
            });
        }

        [Test]
        public void WarningShouldNotExecuteMessageFuncIfLoggerNull()
        {
            Log.Warning(() =>
            {
                Assert.Fail();
                return "";
            });
        }

        [Test]
        public void ErrorShouldNotExecuteMessageFuncIfLoggerNull()
        {
            Log.Error(() =>
            {
                Assert.Fail();
                return "";
            });
        }

        [Test]
        public void FatalShouldNotExecuteMessageFuncIfLoggerNull()
        {
            Log.Fatal(() =>
            {
                Assert.Fail();
                return "";
            }, null);
        }
    }
}
