using GSMA.MobileConnect.Authentication;
using GSMA.MobileConnect.Cache;
using GSMA.MobileConnect.Discovery;
using GSMA.MobileConnect.Identity;
using GSMA.MobileConnect.Utils;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace GSMA.MobileConnect.Test
{
    [TestFixture]
    [Category("EndToEnd")]
    public class EndToEndTests
    {
        private List<BasicKeyValuePair> _basicRequestHeaders = new List<BasicKeyValuePair>()
        {
            new BasicKeyValuePair("Accept", "image/gif, image/jpeg, image/pjpeg, application/x-ms-application, application/xaml+xml, application/x-ms-xbap, */*"),
        };

        //[TestCase("SandboxV1")]
        [TestCase("SandboxV2")]
        //[TestCase("SandboxR2")]
        public async Task MobileConnectInterfaceShouldWorkEndToEnd(string configKey)
        {
            RestClient restClient = new RestClient();
            ICache cache = null;
            IDiscoveryService discovery = new GSMA.MobileConnect.Discovery.DiscoveryService(cache, restClient);
            IAuthenticationService authentication = new GSMA.MobileConnect.Authentication.AuthenticationService(restClient);
            IIdentityService identity = new GSMA.MobileConnect.Identity.IdentityService(restClient);
            IJWKeysetService jwks = new GSMA.MobileConnect.Authentication.JWKeysetService(restClient, cache);

            var testConfig = TestConfig.GetConfig(configKey);
            MobileConnectConfig config = new MobileConnectConfig()
            {
                DiscoveryUrl = testConfig.DiscoveryUrl,
                ClientId = testConfig.ClientId,
                ClientSecret = testConfig.ClientSecret,
                RedirectUrl = testConfig.RedirectUrl
            };

            MobileConnectRequestOptions blankOptions = new MobileConnectRequestOptions();
            MobileConnectInterface mobileConnect = new MobileConnectInterface(discovery, authentication, identity, jwks, config);

            //Attempt discovery
            var status = await mobileConnect.AttemptDiscoveryAsync(testConfig.ValidMSISDN, null, null, blankOptions);

            Assert.AreEqual(MobileConnectResponseType.StartAuthentication, status.ResponseType);

            var discoveryResponse = status.DiscoveryResponse;
            var encryptedMsisdn = status.DiscoveryResponse.ResponseData.subscriber_id;
            var state = "zmxncbvalskdjfhgqpwoeiruty";
            var nonce = "qpwoeirutyalskdjfhgzmxncbv";

            //Start Authorization
            status = mobileConnect.StartAuthentication(discoveryResponse, encryptedMsisdn, state, nonce, blankOptions);

            Assert.AreEqual(MobileConnectResponseType.Authentication, status.ResponseType);

            //Inconclusive at this point because the sandbox no longer allows us to follow redirects easily
            Assert.Inconclusive("Can't follow redirects in sandbox");

            //Authorization
            var redirectedUrl = await FollowRedirects(status.Url, _basicRequestHeaders, testConfig.RedirectUrl);

            Assert.That(() => redirectedUrl.AbsoluteUri.StartsWith(testConfig.RedirectUrl));
            Assert.AreEqual(state, HttpUtils.ExtractQueryValue(redirectedUrl.Query, "state"));

            //Handle auth redirect and request token
            status = await mobileConnect.HandleUrlRedirectAsync(redirectedUrl, discoveryResponse, state, nonce);

            Assert.AreEqual(MobileConnectResponseType.Complete, status.ResponseType);
            Assert.IsNotEmpty(status.TokenResponse.ResponseData.AccessToken);
        }

        //[TestCase("SandboxV1")]
        [TestCase("SandboxV2")]
        //[TestCase("SandboxR2")]
        public async Task MobileConnectInterfaceShouldRejectIncorrectState(string configKey)
        {
            RestClient restClient = new RestClient();
            ICache cache = null;
            IDiscoveryService discovery = new GSMA.MobileConnect.Discovery.DiscoveryService(cache, restClient);
            IAuthenticationService authentication = new GSMA.MobileConnect.Authentication.AuthenticationService(restClient);
            IIdentityService identity = new GSMA.MobileConnect.Identity.IdentityService(restClient);
            IJWKeysetService jwks = new GSMA.MobileConnect.Authentication.JWKeysetService(restClient, cache);

            var testConfig = TestConfig.GetConfig(configKey);
            MobileConnectConfig config = new MobileConnectConfig()
            {
                DiscoveryUrl = testConfig.DiscoveryUrl,
                ClientId = testConfig.ClientId,
                ClientSecret = testConfig.ClientSecret,
                RedirectUrl = testConfig.RedirectUrl
            };

            MobileConnectRequestOptions blankOptions = new MobileConnectRequestOptions();
            MobileConnectInterface mobileConnect = new MobileConnectInterface(discovery, authentication, identity, jwks, config);

            //Attempt discovery
            var status = await mobileConnect.AttemptDiscoveryAsync(testConfig.ValidMSISDN, null, null, blankOptions);

            Assert.AreEqual(MobileConnectResponseType.StartAuthentication, status.ResponseType);

            var discoveryResponse = status.DiscoveryResponse;
            var encryptedMsisdn = status.DiscoveryResponse.ResponseData.subscriber_id;
            var state = "zmxncbvalskdjfhgqpwoeiruty";
            var nonce = "qpwoeirutyalskdjfhgzmxncbv";

            //Start Authorization
            status = mobileConnect.StartAuthentication(discoveryResponse, encryptedMsisdn, state, nonce, blankOptions);

            Assert.AreEqual(MobileConnectResponseType.Authentication, status.ResponseType);

            //Inconclusive at this point because the sandbox no longer allows us to follow redirects easily
            Assert.Inconclusive("Can't follow redirects in sandbox");

            //Authorization
            var redirectedUrl = await FollowRedirects(status.Url, _basicRequestHeaders, testConfig.RedirectUrl);

            Assert.That(() => redirectedUrl.AbsoluteUri.StartsWith(testConfig.RedirectUrl));
            Assert.AreEqual(state, HttpUtils.ExtractQueryValue(redirectedUrl.Query, "state"));

            //Handle auth redirect and request token
            status = await mobileConnect.HandleUrlRedirectAsync(redirectedUrl, discoveryResponse, "incorrectstate", nonce);

            Assert.AreEqual(MobileConnectResponseType.Error, status.ResponseType);
            Assert.AreEqual("invalid_state", status.ErrorCode);
            Assert.IsNotEmpty(status.ErrorMessage);
        }

        //[TestCase("SandboxV1")]
        [TestCase("SandboxV2")]
        //[TestCase("SandboxR2")]
        public async Task MobileConnectInterfaceShouldRejectIncorrectNonce(string configKey)
        {
            RestClient restClient = new RestClient();
            ICache cache = null;
            IDiscoveryService discovery = new GSMA.MobileConnect.Discovery.DiscoveryService(cache, restClient);
            IAuthenticationService authentication = new GSMA.MobileConnect.Authentication.AuthenticationService(restClient);
            IIdentityService identity = new GSMA.MobileConnect.Identity.IdentityService(restClient);
            IJWKeysetService jwks = new GSMA.MobileConnect.Authentication.JWKeysetService(restClient, cache);

            var testConfig = TestConfig.GetConfig(configKey);
            MobileConnectConfig config = new MobileConnectConfig()
            {
                DiscoveryUrl = testConfig.DiscoveryUrl,
                ClientId = testConfig.ClientId,
                ClientSecret = testConfig.ClientSecret,
                RedirectUrl = testConfig.RedirectUrl
            };

            MobileConnectRequestOptions blankOptions = new MobileConnectRequestOptions();
            MobileConnectInterface mobileConnect = new MobileConnectInterface(discovery, authentication, identity, jwks, config);

            //Attempt discovery
            var status = await mobileConnect.AttemptDiscoveryAsync(testConfig.ValidMSISDN, null, null, blankOptions);

            Assert.AreEqual(MobileConnectResponseType.StartAuthentication, status.ResponseType);

            var discoveryResponse = status.DiscoveryResponse;
            var encryptedMsisdn = status.DiscoveryResponse.ResponseData.subscriber_id;
            var state = "zmxncbvalskdjfhgqpwoeiruty";
            var nonce = "qpwoeirutyalskdjfhgzmxncbv";

            //Start Authorization
            status = mobileConnect.StartAuthentication(discoveryResponse, encryptedMsisdn, state, nonce, blankOptions);

            Assert.AreEqual(MobileConnectResponseType.Authentication, status.ResponseType);

            //Inconclusive at this point because the sandbox no longer allows us to follow redirects easily
            Assert.Inconclusive("Can't follow redirects in sandbox");

            //Authorization
            var redirectedUrl = await FollowRedirects(status.Url, _basicRequestHeaders, testConfig.RedirectUrl);

            Assert.That(() => redirectedUrl.AbsoluteUri.StartsWith(testConfig.RedirectUrl));
            Assert.AreEqual(state, HttpUtils.ExtractQueryValue(redirectedUrl.Query, "state"));

            //Handle auth redirect and request token
            status = await mobileConnect.HandleUrlRedirectAsync(redirectedUrl, discoveryResponse, state, "incorrectnonce");

            Assert.AreEqual(MobileConnectResponseType.Error, status.ResponseType);
            Assert.AreEqual("invalid_nonce", status.ErrorCode);
            Assert.IsNotEmpty(status.ErrorMessage);
        }

        //[TestCase("SandboxV1")]
        [TestCase("SandboxV2")]
        //[TestCase("SandboxR2")]
        public async Task MobileConnectWebInterfaceShouldWorkEndToEnd(string configKey)
        {
            RestClient restClient = new RestClient();
            ICache cache = null;
            IDiscoveryService discovery = new GSMA.MobileConnect.Discovery.DiscoveryService(cache, restClient);
            IAuthenticationService authentication = new GSMA.MobileConnect.Authentication.AuthenticationService(restClient);
            IIdentityService identity = new GSMA.MobileConnect.Identity.IdentityService(restClient);
            IJWKeysetService jwks = new GSMA.MobileConnect.Authentication.JWKeysetService(restClient, cache);

            var testConfig = TestConfig.GetConfig(configKey);
            MobileConnectConfig config = new MobileConnectConfig()
            {
                DiscoveryUrl = testConfig.DiscoveryUrl,
                ClientId = testConfig.ClientId,
                ClientSecret = testConfig.ClientSecret,
                RedirectUrl = testConfig.RedirectUrl
            };

            MobileConnectRequestOptions blankOptions = new MobileConnectRequestOptions();
            MobileConnectWebInterface mobileConnect = new MobileConnectWebInterface(discovery, authentication, identity, jwks, config);

            //Attempt discovery
            var request = new HttpRequestMessage();
            var status = await mobileConnect.AttemptDiscoveryAsync(request, testConfig.ValidMSISDN, null, null, true, blankOptions);

            Assert.AreEqual(MobileConnectResponseType.StartAuthentication, status.ResponseType);

            var discoveryResponse = status.DiscoveryResponse;
            var encryptedMsisdn = status.DiscoveryResponse.ResponseData.subscriber_id;
            var state = "zmxncbvalskdjfhgqpwoeiruty";
            var nonce = "qpwoeirutyalskdjfhgzmxncbv";

            //Start Authorization
            request = new HttpRequestMessage();
            status = mobileConnect.StartAuthentication(request, discoveryResponse, encryptedMsisdn, state, nonce, blankOptions);

            Assert.AreEqual(MobileConnectResponseType.Authentication, status.ResponseType);

            //Inconclusive at this point because the sandbox no longer allows us to follow redirects easily
            Assert.Inconclusive("Can't follow redirects in sandbox");

            //Authorization
            request = new HttpRequestMessage();
            var redirectedUrl = await FollowRedirects(status.Url, _basicRequestHeaders, testConfig.RedirectUrl);

            Assert.That(() => redirectedUrl.AbsoluteUri.StartsWith(testConfig.RedirectUrl));
            Assert.AreEqual(state, HttpUtils.ExtractQueryValue(redirectedUrl.Query, "state"));

            //Handle auth redirect and request token
            request = new HttpRequestMessage();
            status = await mobileConnect.HandleUrlRedirectAsync(request, redirectedUrl, discoveryResponse, state, nonce);

            Assert.AreEqual(MobileConnectResponseType.Complete, status.ResponseType);
            Assert.IsNotEmpty(status.TokenResponse.ResponseData.AccessToken);
        }

        //[TestCase("SandboxV1")]
        [TestCase("SandboxV2")]
        //[TestCase("SandboxR2")]
        public async Task MobileConnectWebInterfaceShouldWorkEndToEndWithCache(string configKey)
        {
            RestClient restClient = new RestClient();
            ICache cache = new ConcurrentCache();
            IDiscoveryService discovery = new GSMA.MobileConnect.Discovery.DiscoveryService(cache, restClient);
            IAuthenticationService authentication = new GSMA.MobileConnect.Authentication.AuthenticationService(restClient);
            IIdentityService identity = new GSMA.MobileConnect.Identity.IdentityService(restClient);
            IJWKeysetService jwks = new GSMA.MobileConnect.Authentication.JWKeysetService(restClient, cache);

            var testConfig = TestConfig.GetConfig(configKey);
            MobileConnectConfig config = new MobileConnectConfig()
            {
                DiscoveryUrl = testConfig.DiscoveryUrl,
                ClientId = testConfig.ClientId,
                ClientSecret = testConfig.ClientSecret,
                RedirectUrl = testConfig.RedirectUrl
            };

            MobileConnectRequestOptions blankOptions = new MobileConnectRequestOptions();
            MobileConnectWebInterface mobileConnect = new MobileConnectWebInterface(discovery, authentication, identity, jwks, config);

            //Attempt discovery
            var request = new HttpRequestMessage();
            var status = await mobileConnect.AttemptDiscoveryAsync(request, testConfig.ValidMSISDN, null, null, true, blankOptions);

            Assert.AreEqual(MobileConnectResponseType.StartAuthentication, status.ResponseType);

            var session = status.SDKSession;
            var encryptedMsisdn = status.DiscoveryResponse.ResponseData.subscriber_id;
            var state = "zmxncbvalskdjfhgqpwoeiruty";
            var nonce = "qpwoeirutyalskdjfhgzmxncbv";

            //Start Authorization
            request = new HttpRequestMessage();
            status = await mobileConnect.StartAuthentication(request, session, encryptedMsisdn, state, nonce, blankOptions);

            Assert.AreEqual(MobileConnectResponseType.Authentication, status.ResponseType);

            //Inconclusive at this point because the sandbox no longer allows us to follow redirects easily
            Assert.Inconclusive("Can't follow redirects in sandbox");

            //Authorization
            request = new HttpRequestMessage();
            var redirectedUrl = await FollowRedirects(status.Url, _basicRequestHeaders, testConfig.RedirectUrl);

            Assert.That(() => redirectedUrl.AbsoluteUri.StartsWith(testConfig.RedirectUrl));
            Assert.AreEqual(state, HttpUtils.ExtractQueryValue(redirectedUrl.Query, "state"));

            //Handle auth redirect and request token
            request = new HttpRequestMessage();
            status = await mobileConnect.HandleUrlRedirectAsync(request, redirectedUrl, session, state, nonce);

            Assert.AreEqual(MobileConnectResponseType.Complete, status.ResponseType);
            Assert.IsNotEmpty(status.TokenResponse.ResponseData.AccessToken);
        }

        private async Task<Uri> FollowRedirects(string targetUrl, List<BasicKeyValuePair> headers, string expectedUrl)
        {
            var handler = new HttpClientHandler { AllowAutoRedirect = false };
            using (HttpClient client = new HttpClient(handler, true))
            {
                foreach (var header in headers)
                {
                    client.DefaultRequestHeaders.Add(header.Key, header.Value);
                }

                HttpResponseMessage response = null;
                var nextUrl = new Uri(targetUrl);
                var numRedirects = 0;

                do
                {
                    try
                    {
                        if (numRedirects > 10)
                        {
                            throw new HttpRequestException("Stuck in redirect loop");
                        }

                        if (response != null)
                        {
                            nextUrl = RetrieveLocation(response);
                            numRedirects++;
                        }

                        response = await client.GetAsync(nextUrl);
                    }
                    catch (HttpRequestException)
                    {
                        //If the final redirect is a non-working url then it may cause a request exception, if we verify it is the redirect url then just return it.
                        //Otherwise it was a request failure at some other point in the redirect chain
                        if (nextUrl.AbsoluteUri.StartsWith(expectedUrl))
                        {
                            return nextUrl;
                        }
                        throw;
                    }
                } while (((int)response.StatusCode).ToString().StartsWith("3"));

                return response.RequestMessage.RequestUri;
            }
        }

        private Uri RetrieveLocation(HttpResponseMessage message)
        {
            var uri = message.Headers.Location;

            if(!uri.IsAbsoluteUri && uri.OriginalString.StartsWith("/"))
            {
                var requestUri = message.RequestMessage.RequestUri;
                var absolute = string.Format("{0}://{1}{2}", requestUri.Scheme, requestUri.Authority, uri.OriginalString);
                uri = new Uri(absolute);
            }

            return uri;
        }
    }
}
