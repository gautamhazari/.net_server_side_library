using GSMA.MobileConnect.Authentication;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSMA.MobileConnect.Test.Authentication
{
    [TestFixture]
    public class RequestTokenResponseDataTests
    {
        [Test]
        public void ResponseDataShouldDeserialize()
        {
            var response = "{\"time_received\":\"2016-01-01T01:01:00\",\"access_token\":\"-pM0e0SjymNH9QMekbamDFDYiydNGO4X3YeK1Df_3Zo\",\"token_type\":\"Bearer\",\"expires_in\":3600,\"refresh_token\":null,\"id_token\":\"eyJhbGciOiJSUzI1NiIsImtpZCI6IlBIUE9QLTAwIn0.eyJpc3MiOiJodHRwczpcL1wvcmVmZXJlbmNlLm1vYmlsZWNvbm5lY3QuaW9cL21vYmlsZWNvbm5lY3QiLCJzdWIiOiI0MTE0MjFCMC0zOEQ2LTY1NjgtQTUzQS1ERjk5NjkxQjdFQjYiLCJhdWQiOlsieC1aV1JoTmpVM09XSTNNR0l3WVRSaCJdLCJleHAiOjE0Njg1NzUzODgsImlhdCI6MTQ2ODU3NTA4OCwibm9uY2UiOiJmMWIyMDcyMWM0ZjM0YWYyOGZhMWI0ZGU5NDUzM2ZjZSIsImF0X2hhc2giOiJIQnFaTnlndUN3eWhuLXplNUt3alRnIiwiYXV0aF90aW1lIjoxNDY4NTc1MDg3LCJhY3IiOiIyIiwiYW1yIjpbIlNJTV9QSU4iXSwiYXpwIjoieC1aV1JoTmpVM09XSTNNR0l3WVRSaCJ9.lF2e4yh42-n4MxoOXGd6RzFjfmqrw_d_ilP9UGkabctJMx54SRH3Xyl44cy-UNGCghX7aEq0IcBTDjAo_fF9SKOfLnnEVHP-rJ1Z4hTbbbhdu-Tp_gYAo1YAkkfRg-p9np_amM058-irnbdfb5T10rhJjtp7bs6AklNJ6XhuFgk\"}";

            var actual = JsonConvert.DeserializeObject<RequestTokenResponseData>(response);

            Assert.AreEqual("-pM0e0SjymNH9QMekbamDFDYiydNGO4X3YeK1Df_3Zo", actual.AccessToken);
            Assert.AreEqual("Bearer", actual.TokenType);
            Assert.AreEqual(3600, actual.ExpiresIn);
            Assert.AreEqual("eyJhbGciOiJSUzI1NiIsImtpZCI6IlBIUE9QLTAwIn0.eyJpc3MiOiJodHRwczpcL1wvcmVmZXJlbmNlLm1vYmlsZWNvbm5lY3QuaW9cL21vYmlsZWNvbm5lY3QiLCJzdWIiOiI0MTE0MjFCMC0zOEQ2LTY1NjgtQTUzQS1ERjk5NjkxQjdFQjYiLCJhdWQiOlsieC1aV1JoTmpVM09XSTNNR0l3WVRSaCJdLCJleHAiOjE0Njg1NzUzODgsImlhdCI6MTQ2ODU3NTA4OCwibm9uY2UiOiJmMWIyMDcyMWM0ZjM0YWYyOGZhMWI0ZGU5NDUzM2ZjZSIsImF0X2hhc2giOiJIQnFaTnlndUN3eWhuLXplNUt3alRnIiwiYXV0aF90aW1lIjoxNDY4NTc1MDg3LCJhY3IiOiIyIiwiYW1yIjpbIlNJTV9QSU4iXSwiYXpwIjoieC1aV1JoTmpVM09XSTNNR0l3WVRSaCJ9.lF2e4yh42-n4MxoOXGd6RzFjfmqrw_d_ilP9UGkabctJMx54SRH3Xyl44cy-UNGCghX7aEq0IcBTDjAo_fF9SKOfLnnEVHP-rJ1Z4hTbbbhdu-Tp_gYAo1YAkkfRg-p9np_amM058-irnbdfb5T10rhJjtp7bs6AklNJ6XhuFgk", 
                actual.IdToken);
            Assert.AreEqual(new DateTime(2016, 1, 1, 1, 1, 0), actual.TimeReceived);
            Assert.AreEqual(new DateTime(2016, 1, 1, 2, 1, 0), actual.Expiry);
            Assert.IsNull(actual.RefreshToken);
        }
    }
}
