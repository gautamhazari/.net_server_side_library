using GSMA.MobileConnect.Cache;
using GSMA.MobileConnect.Discovery;
using GSMA.MobileConnect.Exceptions;
using GSMA.MobileConnect.Utils;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSMA.MobileConnect.Test.Cache
{
    [TestFixture]
    public class ConcurrentDiscoveryCacheTests
    {
        private List<RestResponse> _responses;

        [SetUp]
        public void Setup()
        {
            _responses = new List<RestResponse>()
            {
                new RestResponse(System.Net.HttpStatusCode.Accepted, "{\"links\":[{\"rel\":\"operatorSelection\",\"href\":\"http://discovery.sandbox2.mobileconnect.io/v2/discovery/users/operator-selection?session_id=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJyZWRpcmVjdFVybCI6Imh0dHA6Ly9sb2NhbGhvc3Q6ODAwMS8iLCJhcHBsaWNhdGlvbiI6eyJleHRlcm5hbF9pZCI6IjExMzgiLCJuYW1lIjoiY3NoYXJwLXNkayIsImtleXMiOnsic2FuZGJveCI6eyJrZXkiOiI2Njc0MmE4NS0yMjgyLTQ3NDctODgxZC1lZDViN2JkNzRkMmQiLCJzZWNyZXQiOiJmMTUxOTlmNC1iNjU4LTRlNTgtOGJiMy1lNDA5OTg4NzMzOTIifX0sInJlZGlyZWN0X3VyaSI6Imh0dHBzOi8vbG9jYWxob3N0OjgwMDEvIiwiZGV2ZWxvcGVyIjp7InBvcnRhbF91c2VyX2lkIjoiMTEzOCIsIm5hbWUiOiJOaWNob2xhcyBEb25vaG9lIiwiZW1haWwiOiJuaWNob2xhcy5kb25vaG9lQGJqc3MuY29tIiwicHJvZmlsZSI6Imh0dHBzOi8vZGV2ZWxvcGVyLm1vYmlsZWNvbm5lY3QuaW8vYXBpL3YxL3VzZXI_ZW1haWw9bmljaG9sYXMuZG9ub2hvZSU0MGJqc3MuY29tIiwidXBkYXRlZCI6IjIwMTYtMDQtMjBUMDk6MzQ6MThaIiwibXNpc2RucyI6WyI5NDE0ZTI1MmMzYjE1ZWUzMGIyN2NmYmQxNjkzN2UwNWJlMGQ1NWYwZGZjZGQ0MjM2OTg3NTU1MjQ3ZjU0YzUyIiwiZjYwZjFkZDU1YzUxMjE3ZTAwMTc4YWE3ZGIxM2Q5Njc4OGUxZmM0MzRkMGU2ZGZiZmI2NjVlYjU5NzU3MGIwZiJdLCJtc2lzZG5TaG9ydCI6WyI3NTc1IiwiMzMzMyJdLCJzbXNBdXRoIjp0cnVlLCJtY2MiOiI5MDEiLCJtbmMiOiIwMSIsImNvbnNlbnQiOmZhbHNlfX0sInVzZXIiOnsibmFtZSI6IjY2NzQyYTg1LTIyODItNDc0Ny04ODFkLWVkNWI3YmQ3NGQyZCIsInBhc3MiOiJmMTUxOTlmNC1iNjU4LTRlNTgtOGJiMy1lNDA5OTg4NzMzOTIifSwiaWF0IjoxNDYxMTY5MzA5fQ.2Lp0Xt9JXVZxNbnNq_RH-5KJPQ06qw6ttR4ZK3fwcQU\"}]}"),
                new RestResponse(System.Net.HttpStatusCode.OK, "{\"ttl\":1461169322705,\"subscriber_id\":\"e06a09de399ae6c6798c2126e531775ddf3cfe00367af1842534be709fef25e199157c49cc44adf661d286a29afa09c017747fb4383db22b2eaf33db5f878b3ea261c8f342b234e998757e83de23f4a637ce2390453d5d578c76cd65aae99332ee7fbdbd4a140c99babc4e700eae6aa44d3e17ac050771c1fd784fef0214bf770cd0854ea6f4cff87b3ea1e4b25dccd1d340f00eb66c0f041f90596f5236c1017b2541606fff5165320fc4b3381ebfe1fdb848ab04fbedc550bc575ca385b44695a0a9917a368552ee9f8e2178553318a17c32284197631f74f293f30fe6c04f7a77115ec0d2e8ab2a522db88c60263ec1b690ca22540b916e8a9d2c3d820ec1\",\"response\":{\"serving_operator\":\"Example Operator A\",\"country\":\"US\",\"currency\":\"USD\",\"apis\":{\"operatorid\":{\"link\":[{\"href\":\"http://operator_a.sandbox2.mobileconnect.io/oidc/authorize\",\"rel\":\"authorization\"},{\"href\":\"http://operator_a.sandbox2.mobileconnect.io/oidc/accesstoken\",\"rel\":\"token\"},{\"href\":\"http://operator_a.sandbox2.mobileconnect.io/oidc/userinfo\",\"rel\":\"userinfo\"},{\"href\":\"openid profile email\",\"rel\":\"scope\"}]}},\"client_id\":\"66742a85-2282-4747-881d-ed5b7bd74d2d\",\"client_secret\":\"f15199f4-b658-4e58-8bb3-e40998873392\",\"subscriber_id\":\"e06a09de399ae6c6798c2126e531775ddf3cfe00367af1842534be709fef25e199157c49cc44adf661d286a29afa09c017747fb4383db22b2eaf33db5f878b3ea261c8f342b234e998757e83de23f4a637ce2390453d5d578c76cd65aae99332ee7fbdbd4a140c99babc4e700eae6aa44d3e17ac050771c1fd784fef0214bf770cd0854ea6f4cff87b3ea1e4b25dccd1d340f00eb66c0f041f90596f5236c1017b2541606fff5165320fc4b3381ebfe1fdb848ab04fbedc550bc575ca385b44695a0a9917a368552ee9f8e2178553318a17c32284197631f74f293f30fe6c04f7a77115ec0d2e8ab2a522db88c60263ec1b690ca22540b916e8a9d2c3d820ec1\"}}")
            };
        }

        [Test]
        public void ConstructorShouldCreateEmptyCache()
        {
            var cache = new ConcurrentDiscoveryCache();

            Assert.IsTrue(cache.IsEmpty);
        }

        [Test]
        public async Task AddShouldStoreDiscoveryResponse()
        {
            var cache = new ConcurrentDiscoveryCache();
            var response = new DiscoveryResponse(_responses[0]);
            var mcc = "001";
            var mnc = "01";

            string json = Newtonsoft.Json.JsonConvert.SerializeObject(response, new Newtonsoft.Json.JsonSerializerSettings { NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore });
            var cached = Newtonsoft.Json.JsonConvert.DeserializeObject<DiscoveryResponse>(json);

            await cache.Add(mcc, mnc, response);
            var actual = await cache.Get(mcc, mnc);

            Assert.IsFalse(cache.IsEmpty);
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.Cached);
            Assert.AreEqual(response.ResponseData.response, actual.ResponseData.response);
        }

        [Test]
        public async Task CacheShouldGetResponseWhenMultipleStored()
        {
            var cache = new ConcurrentDiscoveryCache();
            var expected = new DiscoveryResponse(_responses[1]);
            var mcc = "001";
            var mnc = "01";

            await cache.Add(mcc, mnc, expected);
            await cache.Add("002", "02", new DiscoveryResponse(_responses[0]));
            var actual = await cache.Get(mcc, mnc);

            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.Cached);
            Assert.IsNotNull(actual.ResponseData.response.apis);
        }

        [Test]
        public async Task RemoveShouldRemoveStoredResponse()
        {
            var cache = new ConcurrentDiscoveryCache();
            var mcc = "001";
            var mnc = "01";

            await cache.Add(mcc, mnc, new DiscoveryResponse(_responses[0]));
            await cache.Remove(mcc, mnc);
            var actual = await cache.Get(mcc, mnc);

            Assert.IsNull(actual);
        }

        [Test]
        public async Task ClearShouldClearStore()
        {
            var cache = new ConcurrentDiscoveryCache();

            await cache.Add("001", "01", new DiscoveryResponse(_responses[0]));
            await cache.Add("002", "02", new DiscoveryResponse(_responses[1]));
            await cache.Clear();

            Assert.IsTrue(cache.IsEmpty);
        }

        [TestCase(null, "01")]
        [TestCase("", "01")]
        [TestCase("001", null)]
        [TestCase("001", "")]
        public async Task CacheShouldNotAddWithEmptyOrNullArguments(string mcc, string mnc)
        {
            var cache = new ConcurrentDiscoveryCache();

            await cache.Add(mcc, mnc, new DiscoveryResponse(_responses[0]));

            Assert.IsTrue(cache.IsEmpty);
        }

        [Test]
        public async Task CacheShouldNotReturnValueIfExpiredAndRemoveIfExpiredIsTrue()
        {
            var cache = new NoExpiryLimitCache();
            cache.SetCacheExpiryTime<ProviderMetadata>(TimeSpan.Zero);
            var value = new ProviderMetadata();
            var key = "test";
            await cache.Add(key, value);
            await Task.Delay(50);

            var cached = await cache.Get<ProviderMetadata>(key, true);

            Assert.IsNull(cached);
        }

        [Test]
        public async Task CacheShouldReturnValueIfExpiredAndRemoveIfExpiredIsFalse()
        {
            var cache = new NoExpiryLimitCache();
            cache.SetCacheExpiryTime<ProviderMetadata>(TimeSpan.Zero);
            var value = new ProviderMetadata();
            var key = "test";
            await cache.Add(key, value);
            await Task.Delay(50);

            var cached = await cache.Get<ProviderMetadata>(key, false);

            Assert.IsNotNull(cached);
            Assert.IsTrue(cached.HasExpired);
        }

        [Test]
        public async Task CacheShouldReturnDefaultValueIfKeyNull()
        {
            var cache = new ConcurrentDiscoveryCache();

            var cached = await cache.Get<ProviderMetadata>(null, true);

            Assert.IsNull(cached);
        }

        [Test]
        public void SetCacheExpiryTimeShouldThrowIfExpiryTimeTooShort()
        {
            var cache = new NoExpiryLimitCache();
            cache.SetCacheExpiryLimit<ProviderMetadata>(TimeSpan.FromSeconds(200), TimeSpan.FromSeconds(400));

            Assert.Throws<MobileConnectCacheExpiryLimitException>(() => cache.SetCacheExpiryTime<ProviderMetadata>(TimeSpan.FromSeconds(10)));
        }

        [Test]
        public void SetCacheExpiryTimeShouldThrowIfExpiryTimeTooLong()
        {
            var cache = new NoExpiryLimitCache();
            cache.SetCacheExpiryLimit<ProviderMetadata>(TimeSpan.FromSeconds(200), TimeSpan.FromSeconds(400));

            Assert.Throws<MobileConnectCacheExpiryLimitException>(() => cache.SetCacheExpiryTime<ProviderMetadata>(TimeSpan.FromSeconds(600)));
        }
    }
}
