using GSMA.MobileConnect.Identity;
using GSMA.MobileConnect.Utils;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSMA.MobileConnect.Test.Identity
{
    [TestFixture]
    public class UserInfoDataTests
    {
        [Test]
        public void UserInfoDataShouldSerializeAndDeserialize()
        {
            string responseJson = "{\"sub\":\"aaaaaaa-bbbb-aaaaa-bbbbbbb\",\"name\":\"David Andrew Smith\",\"family_name\":\"Smith\",\"given_name\":\"David\",\"middle_name\":\"Andrew\",\"nickname\":\"Dave\",\"preferred_username\":\"testname\",\"profile\":\"http://profile.com/profile\",\"picture\":\"http://picture.com/picture\",\"website\":\"http://website.com/\",\"gender\":\"Male\",\"birthdate\":\"1990-11-04\",\"zoneinfo\":\"Europe/London\",\"locale\":\"en-GB\",\"updated_at\":1472136214,\"email\":\"test@test.com\",\"email_verified\":true,\"address\":{\"formatted\":\"123 Fake Street Formatted\",\"street_address\":\"123 Fake Street\",\"locality\":\"Manchester\",\"region\":\"Greater Manchester\",\"postal_code\":\"M1 1AB\",\"country\":\"England\"},\"phone_number\":\"+447700900250\",\"phone_number_verified\":true}";
            var userInfoData = JsonConvert.DeserializeObject<UserInfoData>(responseJson);

            var actual = JsonConvert.SerializeObject(userInfoData, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore });

            Assert.AreEqual(responseJson, actual);
        }

        [Test]
        public void UserInfoDataShouldSerializeAndDeserializeNullDates()
        {
            string responseJson = "{\"birthdate\":null,\"updated_at\":null}";
            var userInfoData = JsonConvert.DeserializeObject<UserInfoData>(responseJson);
            var actual = JsonConvert.SerializeObject(userInfoData, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore });

            Assert.IsNull(userInfoData.Birthdate);
            Assert.IsNull(userInfoData.UpdatedAt);
            Assert.AreEqual("{}", actual);
        }

        [Test]
        public void UserInfoDataShouldSerializeAndDeserializeBirthdateWithWithheldYear()
        {
            string responseJson = "{\"birthdate\":\"0000-06-19\"}";
            var userInfoData = JsonConvert.DeserializeObject<UserInfoData>(responseJson);
            var actual = JsonConvert.SerializeObject(userInfoData, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore });

            Assert.AreEqual(new DateTime(9999, 6, 19), userInfoData.Birthdate);
            Assert.AreEqual(responseJson, actual);
        }
    }
}
