using GSMA.MobileConnect.Exceptions;
using GSMA.MobileConnect.Utils;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Collections.Generic;

namespace GSMA.MobileConnect.Test.Discovery
{
    [TestFixture]
    public class DiscoveryResponseTests
    {
        [Test]
        public void CachedDiscoveryResponseShouldClearSubscriberId()
        {
            var responseJson = "{\"ttl\":1461169322705,\"subscriber_id\":\"e06a09de399ae6c6798c2126e531775ddf3cfe00367af1842534be709fef25e199157c49cc44adf661d286a29afa09c017747fb4383db22b2eaf33db5f878b3ea261c8f342b234e998757e83de23f4a637ce2390453d5d578c76cd65aae99332ee7fbdbd4a140c99babc4e700eae6aa44d3e17ac050771c1fd784fef0214bf770cd0854ea6f4cff87b3ea1e4b25dccd1d340f00eb66c0f041f90596f5236c1017b2541606fff5165320fc4b3381ebfe1fdb848ab04fbedc550bc575ca385b44695a0a9917a368552ee9f8e2178553318a17c32284197631f74f293f30fe6c04f7a77115ec0d2e8ab2a522db88c60263ec1b690ca22540b916e8a9d2c3d820ec1\",\"response\":{\"serving_operator\":\"Example Operator A\",\"country\":\"US\",\"currency\":\"USD\",\"apis\":{\"operatorid\":{\"link\":[{\"href\":\"http://operator_a.sandbox2.mobileconnect.io/oidc/authorize\",\"rel\":\"authorization\"},{\"href\":\"http://operator_a.sandbox2.mobileconnect.io/oidc/accesstoken\",\"rel\":\"token\"},{\"href\":\"http://operator_a.sandbox2.mobileconnect.io/oidc/userinfo\",\"rel\":\"userinfo\"},{\"href\":\"openid profile email\",\"rel\":\"scope\"}]}},\"client_id\":\"66742a85-2282-4747-881d-ed5b7bd74d2d\",\"client_secret\":\"f15199f4-b658-4e58-8bb3-e40998873392\",\"subscriber_id\":\"e06a09de399ae6c6798c2126e531775ddf3cfe00367af1842534be709fef25e199157c49cc44adf661d286a29afa09c017747fb4383db22b2eaf33db5f878b3ea261c8f342b234e998757e83de23f4a637ce2390453d5d578c76cd65aae99332ee7fbdbd4a140c99babc4e700eae6aa44d3e17ac050771c1fd784fef0214bf770cd0854ea6f4cff87b3ea1e4b25dccd1d340f00eb66c0f041f90596f5236c1017b2541606fff5165320fc4b3381ebfe1fdb848ab04fbedc550bc575ca385b44695a0a9917a368552ee9f8e2178553318a17c32284197631f74f293f30fe6c04f7a77115ec0d2e8ab2a522db88c60263ec1b690ca22540b916e8a9d2c3d820ec1\"}}";
            var restResponse = new RestResponse(System.Net.HttpStatusCode.OK, responseJson);
            var initialDiscoveryResponse = new MobileConnect.Discovery.DiscoveryResponse(restResponse);
            Assert.IsNotNull(initialDiscoveryResponse.ResponseData.subscriber_id);

            initialDiscoveryResponse.Cached = true;
            Assert.IsNull(initialDiscoveryResponse.ResponseData.subscriber_id);
        }

        [Test]
        public void OperatorURLsShouldBeOverriddenByProviderMetadataOnSet()
        {
            var responseJson = "{\"ttl\":1461169322705,\"subscriber_id\":\"e06a09de399ae6c6798c2126e531775ddf3cfe00367af1842534be709fef25e199157c49cc44adf661d286a29afa09c017747fb4383db22b2eaf33db5f878b3ea261c8f342b234e998757e83de23f4a637ce2390453d5d578c76cd65aae99332ee7fbdbd4a140c99babc4e700eae6aa44d3e17ac050771c1fd784fef0214bf770cd0854ea6f4cff87b3ea1e4b25dccd1d340f00eb66c0f041f90596f5236c1017b2541606fff5165320fc4b3381ebfe1fdb848ab04fbedc550bc575ca385b44695a0a9917a368552ee9f8e2178553318a17c32284197631f74f293f30fe6c04f7a77115ec0d2e8ab2a522db88c60263ec1b690ca22540b916e8a9d2c3d820ec1\",\"response\":{\"serving_operator\":\"Example Operator A\",\"country\":\"US\",\"currency\":\"USD\",\"apis\":{\"operatorid\":{\"link\":[{\"href\":\"http://operator_a.sandbox2.mobileconnect.io/oidc/authorize\",\"rel\":\"authorization\"},{\"href\":\"http://operator_a.sandbox2.mobileconnect.io/oidc/accesstoken\",\"rel\":\"token\"},{\"href\":\"http://operator_a.sandbox2.mobileconnect.io/oidc/userinfo\",\"rel\":\"userinfo\"},{\"href\":\"openid profile email\",\"rel\":\"scope\"}]}},\"client_id\":\"66742a85-2282-4747-881d-ed5b7bd74d2d\",\"client_secret\":\"f15199f4-b658-4e58-8bb3-e40998873392\",\"subscriber_id\":\"e06a09de399ae6c6798c2126e531775ddf3cfe00367af1842534be709fef25e199157c49cc44adf661d286a29afa09c017747fb4383db22b2eaf33db5f878b3ea261c8f342b234e998757e83de23f4a637ce2390453d5d578c76cd65aae99332ee7fbdbd4a140c99babc4e700eae6aa44d3e17ac050771c1fd784fef0214bf770cd0854ea6f4cff87b3ea1e4b25dccd1d340f00eb66c0f041f90596f5236c1017b2541606fff5165320fc4b3381ebfe1fdb848ab04fbedc550bc575ca385b44695a0a9917a368552ee9f8e2178553318a17c32284197631f74f293f30fe6c04f7a77115ec0d2e8ab2a522db88c60263ec1b690ca22540b916e8a9d2c3d820ec1\"}}";
            var restResponse = new RestResponse(System.Net.HttpStatusCode.OK, responseJson);
            var authzEndpoint = "test authz";
            var tokenEndpoint = "test token";
            var userInfoEndpoint = "test userinfo";
            var jwksEndpoint = "test jwks";
            var providerMetadata = new MobileConnect.Discovery.ProviderMetadata
            {
                AuthorizationEndpoint = authzEndpoint,
                UserInfoEndpoint = userInfoEndpoint,
                TokenEndpoint = tokenEndpoint,
                JwksUri = jwksEndpoint,
            };

            var discoveryResponse = new MobileConnect.Discovery.DiscoveryResponse(restResponse);
            discoveryResponse.ProviderMetadata = providerMetadata;

            Assert.AreEqual(authzEndpoint, discoveryResponse.OperatorUrls.AuthorizationUrl);
            Assert.AreEqual(tokenEndpoint, discoveryResponse.OperatorUrls.RequestTokenUrl);
            Assert.AreEqual(userInfoEndpoint, discoveryResponse.OperatorUrls.UserInfoUrl);
            Assert.AreEqual(jwksEndpoint, discoveryResponse.OperatorUrls.JWKSUrl);
        }

        [Test]
        public void OperatorURLsShouldBeOverriddenByProviderMetadataOnDeserialize()
        {
            var responseJson = "{\"ttl\":1461169322705,\"subscriber_id\":\"e06a09de399ae6c6798c2126e531775ddf3cfe00367af1842534be709fef25e199157c49cc44adf661d286a29afa09c017747fb4383db22b2eaf33db5f878b3ea261c8f342b234e998757e83de23f4a637ce2390453d5d578c76cd65aae99332ee7fbdbd4a140c99babc4e700eae6aa44d3e17ac050771c1fd784fef0214bf770cd0854ea6f4cff87b3ea1e4b25dccd1d340f00eb66c0f041f90596f5236c1017b2541606fff5165320fc4b3381ebfe1fdb848ab04fbedc550bc575ca385b44695a0a9917a368552ee9f8e2178553318a17c32284197631f74f293f30fe6c04f7a77115ec0d2e8ab2a522db88c60263ec1b690ca22540b916e8a9d2c3d820ec1\",\"response\":{\"serving_operator\":\"Example Operator A\",\"country\":\"US\",\"currency\":\"USD\",\"apis\":{\"operatorid\":{\"link\":[{\"href\":\"http://operator_a.sandbox2.mobileconnect.io/oidc/authorize\",\"rel\":\"authorization\"},{\"href\":\"http://operator_a.sandbox2.mobileconnect.io/oidc/accesstoken\",\"rel\":\"token\"},{\"href\":\"http://operator_a.sandbox2.mobileconnect.io/oidc/userinfo\",\"rel\":\"userinfo\"},{\"href\":\"openid profile email\",\"rel\":\"scope\"}]}},\"client_id\":\"66742a85-2282-4747-881d-ed5b7bd74d2d\",\"client_secret\":\"f15199f4-b658-4e58-8bb3-e40998873392\",\"subscriber_id\":\"e06a09de399ae6c6798c2126e531775ddf3cfe00367af1842534be709fef25e199157c49cc44adf661d286a29afa09c017747fb4383db22b2eaf33db5f878b3ea261c8f342b234e998757e83de23f4a637ce2390453d5d578c76cd65aae99332ee7fbdbd4a140c99babc4e700eae6aa44d3e17ac050771c1fd784fef0214bf770cd0854ea6f4cff87b3ea1e4b25dccd1d340f00eb66c0f041f90596f5236c1017b2541606fff5165320fc4b3381ebfe1fdb848ab04fbedc550bc575ca385b44695a0a9917a368552ee9f8e2178553318a17c32284197631f74f293f30fe6c04f7a77115ec0d2e8ab2a522db88c60263ec1b690ca22540b916e8a9d2c3d820ec1\"}}";
            var restResponse = new RestResponse(System.Net.HttpStatusCode.OK, responseJson);
            var authzEndpoint = "test authz";
            var tokenEndpoint = "test token";
            var userInfoEndpoint = "test userinfo";
            var jwksEndpoint = "test jwks";
            var providerMetadata = new MobileConnect.Discovery.ProviderMetadata
            {
                AuthorizationEndpoint = authzEndpoint,
                UserInfoEndpoint = userInfoEndpoint,
                TokenEndpoint = tokenEndpoint,
                JwksUri = jwksEndpoint,
            };

            var discoveryResponse = new MobileConnect.Discovery.DiscoveryResponse(restResponse);
            discoveryResponse.ProviderMetadata = providerMetadata;

            var serialized = JsonConvert.SerializeObject(discoveryResponse);
            var actual = JsonConvert.DeserializeObject<MobileConnect.Discovery.DiscoveryResponse>(serialized);

            Assert.AreEqual(authzEndpoint, actual.OperatorUrls.AuthorizationUrl);
            Assert.AreEqual(tokenEndpoint, actual.OperatorUrls.RequestTokenUrl);
            Assert.AreEqual(userInfoEndpoint, actual.OperatorUrls.UserInfoUrl);
            Assert.AreEqual(jwksEndpoint, actual.OperatorUrls.JWKSUrl);
        }

        [Test]
        public void ApplicationShortNameShouldBePopulatedIfAvailable()
        {
            var responseJson = "{\"ttl\":1471596217,\"response\":{\"serving_operator\":\"Example Operator B\",\"client_id\":\"MzFlZjkxZGItOWU2NS00ZTFmLTkwMzctNTQzNjdkMDBkMzczOm9wZXJhdG9yLWI=\",\"apis\":{\"operatorid\":{\"link\":[{\"rel\":\"authorization\",\"href\":\"https://operator-b.integration.sandbox.mobileconnect.io/oidc/authorize\"},{\"rel\":\"token\",\"href\":\"https://operator-b.integration.sandbox.mobileconnect.io/oidc/accesstoken\"},{\"rel\":\"userinfo\",\"href\":\"https://operator-b.integration.sandbox.mobileconnect.io/oidc/userinfo\"},{\"rel\":\"premiuminfo\",\"href\":\"https://operator-b.integration.sandbox.mobileconnect.io/oidc/premiuminfo\"},{\"rel\":\"scope\",\"href\":\"openid profile email\"},{\"rel\":\"openid-configuration\",\"href\":\"https://operator-b.integration.sandbox.mobileconnect.io/.well-known/openid-configuration\"},{\"rel\":\"jwks\",\"href\":\"https://operator-b.integration.sandbox.mobileconnect.io/oidc/operator-b/jwks.json\"}]}},\"applicationShortName\":\"csharp-sdk\",\"client_secret\":\"YzdhMmE3OTUtMWFmMy00OGFjLWFhYmUtZWNhZmYyNDNhNGExOm9wZXJhdG9yLWI=\",\"country\":\"US\",\"currency\":\"USD\"},\"subscriber_id\":\"bd559362369e88b14b94918461a507b78e69110fb716776f67ce613e8ef2443f2c731571a4c9f4150cc7b96e34aea3d6bd2240d52c8d022ba02ea83eaa1d6961693d2b6e93ece8c3da05f4fb449776a93036a1d8cc966478a84d243a79d813fcee0c1010e5c96d70aa3e132684b200a21dff4dd2ff70e51128b67301b739a53884feffe43f795cee0ce37cbddf8b97b34f6b9c85592f457733328247b05fd143b6e27390f2b46e2207879ec4e1d11acdb4599c6fc3bf3df8b1bc0619c4620f9e3aa66d93f0a053be79342e4416513c2a29940aed2d986fe88560992c4ee8efdbc0996e3fe48a01c357b077f99856f714bfd8c10edd6ac81a339523e394103ec2\"}";
            var restResponse = new RestResponse(System.Net.HttpStatusCode.OK, responseJson);
            var discoveryResponse = new MobileConnect.Discovery.DiscoveryResponse(restResponse);
            Assert.IsNotNull(discoveryResponse.ApplicationShortName);
        }

        [Test]
        public void ApplicationShortNamePopulationShouldHandleNonExistentShortName()
        {
            var responseJson = "{\"ttl\":1461169322705,\"subscriber_id\":\"e06a09de399ae6c6798c2126e531775ddf3cfe00367af1842534be709fef25e199157c49cc44adf661d286a29afa09c017747fb4383db22b2eaf33db5f878b3ea261c8f342b234e998757e83de23f4a637ce2390453d5d578c76cd65aae99332ee7fbdbd4a140c99babc4e700eae6aa44d3e17ac050771c1fd784fef0214bf770cd0854ea6f4cff87b3ea1e4b25dccd1d340f00eb66c0f041f90596f5236c1017b2541606fff5165320fc4b3381ebfe1fdb848ab04fbedc550bc575ca385b44695a0a9917a368552ee9f8e2178553318a17c32284197631f74f293f30fe6c04f7a77115ec0d2e8ab2a522db88c60263ec1b690ca22540b916e8a9d2c3d820ec1\",\"response\":{\"serving_operator\":\"Example Operator A\",\"country\":\"US\",\"currency\":\"USD\",\"apis\":{\"operatorid\":{\"link\":[{\"href\":\"http://operator_a.sandbox2.mobileconnect.io/oidc/authorize\",\"rel\":\"authorization\"},{\"href\":\"http://operator_a.sandbox2.mobileconnect.io/oidc/accesstoken\",\"rel\":\"token\"},{\"href\":\"http://operator_a.sandbox2.mobileconnect.io/oidc/userinfo\",\"rel\":\"userinfo\"},{\"href\":\"openid profile email\",\"rel\":\"scope\"}]}},\"client_id\":\"66742a85-2282-4747-881d-ed5b7bd74d2d\",\"client_secret\":\"f15199f4-b658-4e58-8bb3-e40998873392\",\"subscriber_id\":\"e06a09de399ae6c6798c2126e531775ddf3cfe00367af1842534be709fef25e199157c49cc44adf661d286a29afa09c017747fb4383db22b2eaf33db5f878b3ea261c8f342b234e998757e83de23f4a637ce2390453d5d578c76cd65aae99332ee7fbdbd4a140c99babc4e700eae6aa44d3e17ac050771c1fd784fef0214bf770cd0854ea6f4cff87b3ea1e4b25dccd1d340f00eb66c0f041f90596f5236c1017b2541606fff5165320fc4b3381ebfe1fdb848ab04fbedc550bc575ca385b44695a0a9917a368552ee9f8e2178553318a17c32284197631f74f293f30fe6c04f7a77115ec0d2e8ab2a522db88c60263ec1b690ca22540b916e8a9d2c3d820ec1\"}}";
            var restResponse = new RestResponse(System.Net.HttpStatusCode.OK, responseJson);
            var discoveryResponse = new MobileConnect.Discovery.DiscoveryResponse(restResponse);
            Assert.IsNull(discoveryResponse.ApplicationShortName);
        }

        [Test]
        public void IsMobileConnectServiceSupportedShouldReturnTrueIfAllScopesAreSupported()
        {
            var responseJson = "{\"ttl\":1461169322705,\"subscriber_id\":\"e06a09de399ae6c6798c2126e531775ddf3cfe00367af1842534be709fef25e199157c49cc44adf661d286a29afa09c017747fb4383db22b2eaf33db5f878b3ea261c8f342b234e998757e83de23f4a637ce2390453d5d578c76cd65aae99332ee7fbdbd4a140c99babc4e700eae6aa44d3e17ac050771c1fd784fef0214bf770cd0854ea6f4cff87b3ea1e4b25dccd1d340f00eb66c0f041f90596f5236c1017b2541606fff5165320fc4b3381ebfe1fdb848ab04fbedc550bc575ca385b44695a0a9917a368552ee9f8e2178553318a17c32284197631f74f293f30fe6c04f7a77115ec0d2e8ab2a522db88c60263ec1b690ca22540b916e8a9d2c3d820ec1\",\"response\":{\"serving_operator\":\"Example Operator A\",\"country\":\"US\",\"currency\":\"USD\",\"apis\":{\"operatorid\":{\"link\":[{\"href\":\"http://operator_a.sandbox2.mobileconnect.io/oidc/authorize\",\"rel\":\"authorization\"},{\"href\":\"http://operator_a.sandbox2.mobileconnect.io/oidc/accesstoken\",\"rel\":\"token\"},{\"href\":\"http://operator_a.sandbox2.mobileconnect.io/oidc/userinfo\",\"rel\":\"userinfo\"},{\"href\":\"openid profile email\",\"rel\":\"scope\"}]}},\"client_id\":\"66742a85-2282-4747-881d-ed5b7bd74d2d\",\"client_secret\":\"f15199f4-b658-4e58-8bb3-e40998873392\",\"subscriber_id\":\"e06a09de399ae6c6798c2126e531775ddf3cfe00367af1842534be709fef25e199157c49cc44adf661d286a29afa09c017747fb4383db22b2eaf33db5f878b3ea261c8f342b234e998757e83de23f4a637ce2390453d5d578c76cd65aae99332ee7fbdbd4a140c99babc4e700eae6aa44d3e17ac050771c1fd784fef0214bf770cd0854ea6f4cff87b3ea1e4b25dccd1d340f00eb66c0f041f90596f5236c1017b2541606fff5165320fc4b3381ebfe1fdb848ab04fbedc550bc575ca385b44695a0a9917a368552ee9f8e2178553318a17c32284197631f74f293f30fe6c04f7a77115ec0d2e8ab2a522db88c60263ec1b690ca22540b916e8a9d2c3d820ec1\"}}";
            var restResponse = new RestResponse(System.Net.HttpStatusCode.OK, responseJson);
            var discoveryResponse = new MobileConnect.Discovery.DiscoveryResponse(restResponse);
            var providerMetadata = new MobileConnect.Discovery.ProviderMetadata { ScopesSupported = new List<string> { "openid", "mc_authn", "mc_authz", "profile", "email" } };
            discoveryResponse.ProviderMetadata = providerMetadata;
            var scopesToTest = "openid mc_authz email";

            var actual = discoveryResponse.IsMobileConnectServiceSupported(scopesToTest);

            Assert.IsTrue(actual);
        }

        [Test]
        public void IsMobileConnectServiceSupportedShouldReturnFalseIfNotAllScopesAreSupported()
        {
            var responseJson = "{\"ttl\":1461169322705,\"subscriber_id\":\"e06a09de399ae6c6798c2126e531775ddf3cfe00367af1842534be709fef25e199157c49cc44adf661d286a29afa09c017747fb4383db22b2eaf33db5f878b3ea261c8f342b234e998757e83de23f4a637ce2390453d5d578c76cd65aae99332ee7fbdbd4a140c99babc4e700eae6aa44d3e17ac050771c1fd784fef0214bf770cd0854ea6f4cff87b3ea1e4b25dccd1d340f00eb66c0f041f90596f5236c1017b2541606fff5165320fc4b3381ebfe1fdb848ab04fbedc550bc575ca385b44695a0a9917a368552ee9f8e2178553318a17c32284197631f74f293f30fe6c04f7a77115ec0d2e8ab2a522db88c60263ec1b690ca22540b916e8a9d2c3d820ec1\",\"response\":{\"serving_operator\":\"Example Operator A\",\"country\":\"US\",\"currency\":\"USD\",\"apis\":{\"operatorid\":{\"link\":[{\"href\":\"http://operator_a.sandbox2.mobileconnect.io/oidc/authorize\",\"rel\":\"authorization\"},{\"href\":\"http://operator_a.sandbox2.mobileconnect.io/oidc/accesstoken\",\"rel\":\"token\"},{\"href\":\"http://operator_a.sandbox2.mobileconnect.io/oidc/userinfo\",\"rel\":\"userinfo\"},{\"href\":\"openid profile email\",\"rel\":\"scope\"}]}},\"client_id\":\"66742a85-2282-4747-881d-ed5b7bd74d2d\",\"client_secret\":\"f15199f4-b658-4e58-8bb3-e40998873392\",\"subscriber_id\":\"e06a09de399ae6c6798c2126e531775ddf3cfe00367af1842534be709fef25e199157c49cc44adf661d286a29afa09c017747fb4383db22b2eaf33db5f878b3ea261c8f342b234e998757e83de23f4a637ce2390453d5d578c76cd65aae99332ee7fbdbd4a140c99babc4e700eae6aa44d3e17ac050771c1fd784fef0214bf770cd0854ea6f4cff87b3ea1e4b25dccd1d340f00eb66c0f041f90596f5236c1017b2541606fff5165320fc4b3381ebfe1fdb848ab04fbedc550bc575ca385b44695a0a9917a368552ee9f8e2178553318a17c32284197631f74f293f30fe6c04f7a77115ec0d2e8ab2a522db88c60263ec1b690ca22540b916e8a9d2c3d820ec1\"}}";
            var restResponse = new RestResponse(System.Net.HttpStatusCode.OK, responseJson);
            var discoveryResponse = new MobileConnect.Discovery.DiscoveryResponse(restResponse);
            var providerMetadata = new MobileConnect.Discovery.ProviderMetadata { ScopesSupported = new List<string> { "openid", "mc_authn", "mc_authz", "profile", "email" } };
            discoveryResponse.ProviderMetadata = providerMetadata;
            var scopesToTest = "openid mc_authz email notsupported";

            var actual = discoveryResponse.IsMobileConnectServiceSupported(scopesToTest);

            Assert.IsFalse(actual);
        }

        [Test]
        public void IsMobileConnectServiceSupportedShouldHandleSingleScope()
        {
            var responseJson = "{\"ttl\":1461169322705,\"subscriber_id\":\"e06a09de399ae6c6798c2126e531775ddf3cfe00367af1842534be709fef25e199157c49cc44adf661d286a29afa09c017747fb4383db22b2eaf33db5f878b3ea261c8f342b234e998757e83de23f4a637ce2390453d5d578c76cd65aae99332ee7fbdbd4a140c99babc4e700eae6aa44d3e17ac050771c1fd784fef0214bf770cd0854ea6f4cff87b3ea1e4b25dccd1d340f00eb66c0f041f90596f5236c1017b2541606fff5165320fc4b3381ebfe1fdb848ab04fbedc550bc575ca385b44695a0a9917a368552ee9f8e2178553318a17c32284197631f74f293f30fe6c04f7a77115ec0d2e8ab2a522db88c60263ec1b690ca22540b916e8a9d2c3d820ec1\",\"response\":{\"serving_operator\":\"Example Operator A\",\"country\":\"US\",\"currency\":\"USD\",\"apis\":{\"operatorid\":{\"link\":[{\"href\":\"http://operator_a.sandbox2.mobileconnect.io/oidc/authorize\",\"rel\":\"authorization\"},{\"href\":\"http://operator_a.sandbox2.mobileconnect.io/oidc/accesstoken\",\"rel\":\"token\"},{\"href\":\"http://operator_a.sandbox2.mobileconnect.io/oidc/userinfo\",\"rel\":\"userinfo\"},{\"href\":\"openid profile email\",\"rel\":\"scope\"}]}},\"client_id\":\"66742a85-2282-4747-881d-ed5b7bd74d2d\",\"client_secret\":\"f15199f4-b658-4e58-8bb3-e40998873392\",\"subscriber_id\":\"e06a09de399ae6c6798c2126e531775ddf3cfe00367af1842534be709fef25e199157c49cc44adf661d286a29afa09c017747fb4383db22b2eaf33db5f878b3ea261c8f342b234e998757e83de23f4a637ce2390453d5d578c76cd65aae99332ee7fbdbd4a140c99babc4e700eae6aa44d3e17ac050771c1fd784fef0214bf770cd0854ea6f4cff87b3ea1e4b25dccd1d340f00eb66c0f041f90596f5236c1017b2541606fff5165320fc4b3381ebfe1fdb848ab04fbedc550bc575ca385b44695a0a9917a368552ee9f8e2178553318a17c32284197631f74f293f30fe6c04f7a77115ec0d2e8ab2a522db88c60263ec1b690ca22540b916e8a9d2c3d820ec1\"}}";
            var restResponse = new RestResponse(System.Net.HttpStatusCode.OK, responseJson);
            var discoveryResponse = new MobileConnect.Discovery.DiscoveryResponse(restResponse);
            var providerMetadata = new MobileConnect.Discovery.ProviderMetadata { ScopesSupported = new List<string> { "openid", "mc_authn", "mc_authz", "profile", "email" } };
            discoveryResponse.ProviderMetadata = providerMetadata;
            var scopesToTest = "openid";

            var actual = discoveryResponse.IsMobileConnectServiceSupported(scopesToTest);

            Assert.IsTrue(actual);
        }

        [Test]
        public void IsMobileConnectServiceSupportedShouldHandleEmptyScope()
        {
            var responseJson = "{\"ttl\":1461169322705,\"subscriber_id\":\"e06a09de399ae6c6798c2126e531775ddf3cfe00367af1842534be709fef25e199157c49cc44adf661d286a29afa09c017747fb4383db22b2eaf33db5f878b3ea261c8f342b234e998757e83de23f4a637ce2390453d5d578c76cd65aae99332ee7fbdbd4a140c99babc4e700eae6aa44d3e17ac050771c1fd784fef0214bf770cd0854ea6f4cff87b3ea1e4b25dccd1d340f00eb66c0f041f90596f5236c1017b2541606fff5165320fc4b3381ebfe1fdb848ab04fbedc550bc575ca385b44695a0a9917a368552ee9f8e2178553318a17c32284197631f74f293f30fe6c04f7a77115ec0d2e8ab2a522db88c60263ec1b690ca22540b916e8a9d2c3d820ec1\",\"response\":{\"serving_operator\":\"Example Operator A\",\"country\":\"US\",\"currency\":\"USD\",\"apis\":{\"operatorid\":{\"link\":[{\"href\":\"http://operator_a.sandbox2.mobileconnect.io/oidc/authorize\",\"rel\":\"authorization\"},{\"href\":\"http://operator_a.sandbox2.mobileconnect.io/oidc/accesstoken\",\"rel\":\"token\"},{\"href\":\"http://operator_a.sandbox2.mobileconnect.io/oidc/userinfo\",\"rel\":\"userinfo\"},{\"href\":\"openid profile email\",\"rel\":\"scope\"}]}},\"client_id\":\"66742a85-2282-4747-881d-ed5b7bd74d2d\",\"client_secret\":\"f15199f4-b658-4e58-8bb3-e40998873392\",\"subscriber_id\":\"e06a09de399ae6c6798c2126e531775ddf3cfe00367af1842534be709fef25e199157c49cc44adf661d286a29afa09c017747fb4383db22b2eaf33db5f878b3ea261c8f342b234e998757e83de23f4a637ce2390453d5d578c76cd65aae99332ee7fbdbd4a140c99babc4e700eae6aa44d3e17ac050771c1fd784fef0214bf770cd0854ea6f4cff87b3ea1e4b25dccd1d340f00eb66c0f041f90596f5236c1017b2541606fff5165320fc4b3381ebfe1fdb848ab04fbedc550bc575ca385b44695a0a9917a368552ee9f8e2178553318a17c32284197631f74f293f30fe6c04f7a77115ec0d2e8ab2a522db88c60263ec1b690ca22540b916e8a9d2c3d820ec1\"}}";
            var restResponse = new RestResponse(System.Net.HttpStatusCode.OK, responseJson);
            var discoveryResponse = new MobileConnect.Discovery.DiscoveryResponse(restResponse);
            var providerMetadata = new MobileConnect.Discovery.ProviderMetadata { ScopesSupported = new List<string> { "openid", "mc_authn", "mc_authz", "profile", "email" } };
            discoveryResponse.ProviderMetadata = providerMetadata;
            var scopesToTest = "";

            var actual = discoveryResponse.IsMobileConnectServiceSupported(scopesToTest);

            Assert.IsTrue(actual);
        }

        [Test]
        public void IsMobileConnectServiceSupportedShouldIgnoreCase()
        {
            var responseJson = "{\"ttl\":1461169322705,\"subscriber_id\":\"e06a09de399ae6c6798c2126e531775ddf3cfe00367af1842534be709fef25e199157c49cc44adf661d286a29afa09c017747fb4383db22b2eaf33db5f878b3ea261c8f342b234e998757e83de23f4a637ce2390453d5d578c76cd65aae99332ee7fbdbd4a140c99babc4e700eae6aa44d3e17ac050771c1fd784fef0214bf770cd0854ea6f4cff87b3ea1e4b25dccd1d340f00eb66c0f041f90596f5236c1017b2541606fff5165320fc4b3381ebfe1fdb848ab04fbedc550bc575ca385b44695a0a9917a368552ee9f8e2178553318a17c32284197631f74f293f30fe6c04f7a77115ec0d2e8ab2a522db88c60263ec1b690ca22540b916e8a9d2c3d820ec1\",\"response\":{\"serving_operator\":\"Example Operator A\",\"country\":\"US\",\"currency\":\"USD\",\"apis\":{\"operatorid\":{\"link\":[{\"href\":\"http://operator_a.sandbox2.mobileconnect.io/oidc/authorize\",\"rel\":\"authorization\"},{\"href\":\"http://operator_a.sandbox2.mobileconnect.io/oidc/accesstoken\",\"rel\":\"token\"},{\"href\":\"http://operator_a.sandbox2.mobileconnect.io/oidc/userinfo\",\"rel\":\"userinfo\"},{\"href\":\"openid profile email\",\"rel\":\"scope\"}]}},\"client_id\":\"66742a85-2282-4747-881d-ed5b7bd74d2d\",\"client_secret\":\"f15199f4-b658-4e58-8bb3-e40998873392\",\"subscriber_id\":\"e06a09de399ae6c6798c2126e531775ddf3cfe00367af1842534be709fef25e199157c49cc44adf661d286a29afa09c017747fb4383db22b2eaf33db5f878b3ea261c8f342b234e998757e83de23f4a637ce2390453d5d578c76cd65aae99332ee7fbdbd4a140c99babc4e700eae6aa44d3e17ac050771c1fd784fef0214bf770cd0854ea6f4cff87b3ea1e4b25dccd1d340f00eb66c0f041f90596f5236c1017b2541606fff5165320fc4b3381ebfe1fdb848ab04fbedc550bc575ca385b44695a0a9917a368552ee9f8e2178553318a17c32284197631f74f293f30fe6c04f7a77115ec0d2e8ab2a522db88c60263ec1b690ca22540b916e8a9d2c3d820ec1\"}}";
            var restResponse = new RestResponse(System.Net.HttpStatusCode.OK, responseJson);
            var discoveryResponse = new MobileConnect.Discovery.DiscoveryResponse(restResponse);
            var providerMetadata = new MobileConnect.Discovery.ProviderMetadata { ScopesSupported = new List<string> { "openid", "mc_authn", "mc_authz", "profile", "email" } };
            discoveryResponse.ProviderMetadata = providerMetadata;
            var scopesToTest = "OPENID mC_AUthz eMaIl";

            var actual = discoveryResponse.IsMobileConnectServiceSupported(scopesToTest);

            Assert.IsTrue(actual);
        }

        [Test]
        public void IsMobileConnectServiceSupportedShouldThrowIfProviderMetadataUnavailable()
        {
            var responseJson = "{\"ttl\":1461169322705,\"subscriber_id\":\"e06a09de399ae6c6798c2126e531775ddf3cfe00367af1842534be709fef25e199157c49cc44adf661d286a29afa09c017747fb4383db22b2eaf33db5f878b3ea261c8f342b234e998757e83de23f4a637ce2390453d5d578c76cd65aae99332ee7fbdbd4a140c99babc4e700eae6aa44d3e17ac050771c1fd784fef0214bf770cd0854ea6f4cff87b3ea1e4b25dccd1d340f00eb66c0f041f90596f5236c1017b2541606fff5165320fc4b3381ebfe1fdb848ab04fbedc550bc575ca385b44695a0a9917a368552ee9f8e2178553318a17c32284197631f74f293f30fe6c04f7a77115ec0d2e8ab2a522db88c60263ec1b690ca22540b916e8a9d2c3d820ec1\",\"response\":{\"serving_operator\":\"Example Operator A\",\"country\":\"US\",\"currency\":\"USD\",\"apis\":{\"operatorid\":{\"link\":[{\"href\":\"http://operator_a.sandbox2.mobileconnect.io/oidc/authorize\",\"rel\":\"authorization\"},{\"href\":\"http://operator_a.sandbox2.mobileconnect.io/oidc/accesstoken\",\"rel\":\"token\"},{\"href\":\"http://operator_a.sandbox2.mobileconnect.io/oidc/userinfo\",\"rel\":\"userinfo\"},{\"href\":\"openid profile email\",\"rel\":\"scope\"}]}},\"client_id\":\"66742a85-2282-4747-881d-ed5b7bd74d2d\",\"client_secret\":\"f15199f4-b658-4e58-8bb3-e40998873392\",\"subscriber_id\":\"e06a09de399ae6c6798c2126e531775ddf3cfe00367af1842534be709fef25e199157c49cc44adf661d286a29afa09c017747fb4383db22b2eaf33db5f878b3ea261c8f342b234e998757e83de23f4a637ce2390453d5d578c76cd65aae99332ee7fbdbd4a140c99babc4e700eae6aa44d3e17ac050771c1fd784fef0214bf770cd0854ea6f4cff87b3ea1e4b25dccd1d340f00eb66c0f041f90596f5236c1017b2541606fff5165320fc4b3381ebfe1fdb848ab04fbedc550bc575ca385b44695a0a9917a368552ee9f8e2178553318a17c32284197631f74f293f30fe6c04f7a77115ec0d2e8ab2a522db88c60263ec1b690ca22540b916e8a9d2c3d820ec1\"}}";
            var restResponse = new RestResponse(System.Net.HttpStatusCode.OK, responseJson);
            var discoveryResponse = new MobileConnect.Discovery.DiscoveryResponse(restResponse);
            var scopesToTest = "openid mc_authz";

            Assert.Throws<MobileConnectProviderMetadataUnavailableException>(() => discoveryResponse.IsMobileConnectServiceSupported(scopesToTest));
        }

        [Test]
        public void IsMobileConnectServiceSupportedShouldThrowIfScopesSupportedUnavailable()
        {
            var responseJson = "{\"ttl\":1461169322705,\"subscriber_id\":\"e06a09de399ae6c6798c2126e531775ddf3cfe00367af1842534be709fef25e199157c49cc44adf661d286a29afa09c017747fb4383db22b2eaf33db5f878b3ea261c8f342b234e998757e83de23f4a637ce2390453d5d578c76cd65aae99332ee7fbdbd4a140c99babc4e700eae6aa44d3e17ac050771c1fd784fef0214bf770cd0854ea6f4cff87b3ea1e4b25dccd1d340f00eb66c0f041f90596f5236c1017b2541606fff5165320fc4b3381ebfe1fdb848ab04fbedc550bc575ca385b44695a0a9917a368552ee9f8e2178553318a17c32284197631f74f293f30fe6c04f7a77115ec0d2e8ab2a522db88c60263ec1b690ca22540b916e8a9d2c3d820ec1\",\"response\":{\"serving_operator\":\"Example Operator A\",\"country\":\"US\",\"currency\":\"USD\",\"apis\":{\"operatorid\":{\"link\":[{\"href\":\"http://operator_a.sandbox2.mobileconnect.io/oidc/authorize\",\"rel\":\"authorization\"},{\"href\":\"http://operator_a.sandbox2.mobileconnect.io/oidc/accesstoken\",\"rel\":\"token\"},{\"href\":\"http://operator_a.sandbox2.mobileconnect.io/oidc/userinfo\",\"rel\":\"userinfo\"},{\"href\":\"openid profile email\",\"rel\":\"scope\"}]}},\"client_id\":\"66742a85-2282-4747-881d-ed5b7bd74d2d\",\"client_secret\":\"f15199f4-b658-4e58-8bb3-e40998873392\",\"subscriber_id\":\"e06a09de399ae6c6798c2126e531775ddf3cfe00367af1842534be709fef25e199157c49cc44adf661d286a29afa09c017747fb4383db22b2eaf33db5f878b3ea261c8f342b234e998757e83de23f4a637ce2390453d5d578c76cd65aae99332ee7fbdbd4a140c99babc4e700eae6aa44d3e17ac050771c1fd784fef0214bf770cd0854ea6f4cff87b3ea1e4b25dccd1d340f00eb66c0f041f90596f5236c1017b2541606fff5165320fc4b3381ebfe1fdb848ab04fbedc550bc575ca385b44695a0a9917a368552ee9f8e2178553318a17c32284197631f74f293f30fe6c04f7a77115ec0d2e8ab2a522db88c60263ec1b690ca22540b916e8a9d2c3d820ec1\"}}";
            var restResponse = new RestResponse(System.Net.HttpStatusCode.OK, responseJson);
            var discoveryResponse = new MobileConnect.Discovery.DiscoveryResponse(restResponse);
            var providerMetadata = new MobileConnect.Discovery.ProviderMetadata { ScopesSupported = null };
            discoveryResponse.ProviderMetadata = providerMetadata;
            var scopesToTest = "openid mc_authz";

            Assert.Throws<MobileConnectProviderMetadataUnavailableException>(() => discoveryResponse.IsMobileConnectServiceSupported(scopesToTest));
        }

        [Test]
        public void IsMobileConnectServiceSupportedShouldThrowIfScopesSupportedEmpty()
        {
            var responseJson = "{\"ttl\":1461169322705,\"subscriber_id\":\"e06a09de399ae6c6798c2126e531775ddf3cfe00367af1842534be709fef25e199157c49cc44adf661d286a29afa09c017747fb4383db22b2eaf33db5f878b3ea261c8f342b234e998757e83de23f4a637ce2390453d5d578c76cd65aae99332ee7fbdbd4a140c99babc4e700eae6aa44d3e17ac050771c1fd784fef0214bf770cd0854ea6f4cff87b3ea1e4b25dccd1d340f00eb66c0f041f90596f5236c1017b2541606fff5165320fc4b3381ebfe1fdb848ab04fbedc550bc575ca385b44695a0a9917a368552ee9f8e2178553318a17c32284197631f74f293f30fe6c04f7a77115ec0d2e8ab2a522db88c60263ec1b690ca22540b916e8a9d2c3d820ec1\",\"response\":{\"serving_operator\":\"Example Operator A\",\"country\":\"US\",\"currency\":\"USD\",\"apis\":{\"operatorid\":{\"link\":[{\"href\":\"http://operator_a.sandbox2.mobileconnect.io/oidc/authorize\",\"rel\":\"authorization\"},{\"href\":\"http://operator_a.sandbox2.mobileconnect.io/oidc/accesstoken\",\"rel\":\"token\"},{\"href\":\"http://operator_a.sandbox2.mobileconnect.io/oidc/userinfo\",\"rel\":\"userinfo\"},{\"href\":\"openid profile email\",\"rel\":\"scope\"}]}},\"client_id\":\"66742a85-2282-4747-881d-ed5b7bd74d2d\",\"client_secret\":\"f15199f4-b658-4e58-8bb3-e40998873392\",\"subscriber_id\":\"e06a09de399ae6c6798c2126e531775ddf3cfe00367af1842534be709fef25e199157c49cc44adf661d286a29afa09c017747fb4383db22b2eaf33db5f878b3ea261c8f342b234e998757e83de23f4a637ce2390453d5d578c76cd65aae99332ee7fbdbd4a140c99babc4e700eae6aa44d3e17ac050771c1fd784fef0214bf770cd0854ea6f4cff87b3ea1e4b25dccd1d340f00eb66c0f041f90596f5236c1017b2541606fff5165320fc4b3381ebfe1fdb848ab04fbedc550bc575ca385b44695a0a9917a368552ee9f8e2178553318a17c32284197631f74f293f30fe6c04f7a77115ec0d2e8ab2a522db88c60263ec1b690ca22540b916e8a9d2c3d820ec1\"}}";
            var restResponse = new RestResponse(System.Net.HttpStatusCode.OK, responseJson);
            var discoveryResponse = new MobileConnect.Discovery.DiscoveryResponse(restResponse);
            var providerMetadata = new MobileConnect.Discovery.ProviderMetadata { ScopesSupported = new List<string>() };
            discoveryResponse.ProviderMetadata = providerMetadata;
            var scopesToTest = "openid mc_authz";

            Assert.Throws<MobileConnectProviderMetadataUnavailableException>(() => discoveryResponse.IsMobileConnectServiceSupported(scopesToTest));
        }
    }
}
