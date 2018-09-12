using NUnit.Framework;

namespace GSMA.MobileConnect.Test
{
    [SetUpFixture]
    public class TestFixtureSetup
    {
        [OneTimeSetUp]
        public void Setup()
        {
            TestConfig.LoadConfig();
        }
    }
}
