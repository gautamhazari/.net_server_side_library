using GSMA.MobileConnect.Identity;
using Newtonsoft.Json;
using NUnit.Framework;

namespace GSMA.MobileConnect.Test.Identity
{
    [TestFixture]
    public class IdentityDataTests
    {
        [Test]
        public void IdentityDataShouldSerializeAndDeserialize()
        {
            string responseJson = "{\"sub\":\"411421B0-38D6-6568-A53A-DF99691B7EB6\",\"phone_number_alternate\":\"447700100100\",\"title\":\"Mr\",\"given_name\":\"David\",\"family_name\":\"Smith\",\"middle_name\":\"Andrew\",\"street_address\":\"123 Fake Street\",\"city\":\"Manchester\",\"state\":\"Greater Manchester\",\"postal_code\":\"M1 1AB\",\"country\":\"England\",\"email\":\"test@test.com\",\"phone_number\":\"447700200200\",\"birthdate\":\"1990-11-04\",\"national_identifier\":\"XXXXXXXXXX\"}";
            var userInfoData = JsonConvert.DeserializeObject<IdentityData>(responseJson);

            var actual = JsonConvert.SerializeObject(userInfoData, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore });

            Assert.AreEqual(responseJson, actual);
        }
    }
}
