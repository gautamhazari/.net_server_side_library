using System.IO;
using GSMA.MobileConnect.Cache;
using GSMA.MobileConnect.Demo.Config;
using GSMA.MobileConnect.Discovery;
using GSMA.MobileConnect.Utils;
using GSMA.MobileConnect.Web;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;

namespace GSMA.MobileConnect.Demo.Web.Controllers
{
    [RoutePrefix("api/mobileconnect")]
    public class MobileConnectController : ApiController
    {
        private static MobileConnectWebInterface _mobileConnect;
        private static string _apiVersion;
        private static RestClient _restClient;
        private static ICache _cache;
        private static MobileConnectConfig _mobileConnectConfig;
        private static OperatorUrls _operatorUrLs;

        public MobileConnectController(MobileConnectWebInterface mobileConnect)
        {
            _mobileConnect = mobileConnect;
        }
        
        public MobileConnectController()
        {
            var cache = new ConcurrentCache();
            if (_mobileConnect==null)
                _mobileConnect =  new MobileConnectWebInterface(DemoConfiguration.Config, cache);
        }

        [HttpGet]
        [Route("get_parameters")]
        public void GetParameters(string clientID = "", string clientSecret = "", string discoveryURL = "", string redirectURL = "",
            string xRedirect = "", string scope = "", string apiVersion = "")
        {
            _apiVersion = apiVersion;
            _cache = new ConcurrentCache();
            _restClient = new RestClient();
            _mobileConnectConfig = new MobileConnectConfig()
            {
                ClientId = clientID,
                ClientSecret = clientSecret,
                DiscoveryUrl = discoveryURL,
                RedirectUrl = redirectURL,
                XRedirect = xRedirect
            };
            _mobileConnect = new MobileConnectWebInterface(_mobileConnectConfig, _cache, _restClient);
        }

        [HttpGet]
        [Route("endpoints")]
        public void Endpoints(string authURL = "", string tokenURL = "", string userInfoURl = "", string metadata = "", string discoveryURL = "", string redirectURL = "")
        {
            _operatorUrLs = new OperatorUrls()
            {
                AuthorizationUrl = authURL,
                UserInfoUrl = userInfoURl,
                RequestTokenUrl = tokenURL,
                ProviderMetadataUrl = metadata,
            };
            _cache = new ConcurrentCache();
            _restClient = new RestClient();

            MobileConnectConfig mobileConnectConfig = new MobileConnectConfig()
            {
                DiscoveryUrl = discoveryURL,
                RedirectUrl = redirectURL
            };

            _mobileConnect = new MobileConnectWebInterface(mobileConnectConfig, _cache, _restClient);
        }

        [HttpGet]
        [Route("start_discovery")]
        public async Task<IHttpActionResult> StartDiscovery(string msisdn = "", string sourceIp = "")
        {
            var requestOptions = new MobileConnectRequestOptions { ClientIP = sourceIp };
            var status = await _mobileConnect.AttemptDiscoveryAsync(Request, msisdn, null, null, true, requestOptions);
            return CreateResponse(status);
        }

        [HttpGet]
        [Route("start_manual_discovery")]
        public async Task<IHttpActionResult> StartManualDiscoveryWithMetadata(string subId = "", string clientId = "", string clientName = "", string clientSecret = "")
        {
            var discoveryResponse = await _mobileConnect.GenerateDiscoveryManually(clientId, clientSecret, subId, clientName, _operatorUrLs);
            var discoverystatus = await _mobileConnect.GenerateStatusFromDiscoveryResponse(discoveryResponse);
            return CreateResponse(discoverystatus);
        }

        [HttpGet]
        [Route("start_manual_discovery_no_metadata")]
        public async Task<IHttpActionResult> StartManualDiscoveryWithoutMetadata(string subId = "", string clientId = "", string clientSecret = "" )
        {
            var operatorUrlsWd = new OperatorUrls
            {
                AuthorizationUrl = _operatorUrLs.AuthorizationUrl,
                RequestTokenUrl = _operatorUrLs.RequestTokenUrl,
                UserInfoUrl = _operatorUrLs.UserInfoUrl
            };
            
            var discoveryResponse = await _mobileConnect.GenerateDiscoveryManually(clientId, clientSecret, subId, "demoapp", operatorUrlsWd);
            var discoverystatus = await _mobileConnect.GenerateStatusFromDiscoveryResponse(discoveryResponse);
            return CreateResponse(discoverystatus);
        }

        [HttpGet]
        [Route("start_authentication"), Route("start_authorization")]
        public async Task<IHttpActionResult> StartAuthentication(string sdksession = null, string subscriberId = null, string scope = null)
        {
            if (scope == null && _operatorUrLs.ProviderMetadataUrl == null)
                _apiVersion = Config.Constants.Version1;
            else if (scope==null)
                _apiVersion = Config.Constants.Version2;

            var options = new MobileConnectRequestOptions
            {
                Scope = scope,
                Context = _apiVersion.Equals(Config.Constants.Version2) ? Config.Constants.ContextBindingMsg : null,
                BindingMessage = _apiVersion.Equals(Config.Constants.Version2) ? Config.Constants.ContextBindingMsg : null
            };

            var response = await _mobileConnect.StartAuthentication(Request, sdksession, subscriberId, null, null, options);
            return CreateResponse(response);
        }

        [HttpGet]
        [Route("headless_authentication")]
        public async Task<IHttpActionResult> RequestHeadlessAuthentication(string sdksession = null, string subscriberId = null, string scope = null)
        {
            var options = new MobileConnectRequestOptions
            {
                Scope = scope,
                Context = "headless",
                BindingMessage = "demo headless",
                AutoRetrieveIdentityHeadless = true,
            };

            var response = await _mobileConnect.RequestHeadlessAuthenticationAsync(Request, sdksession, subscriberId, null, null, options);
            return CreateResponse(response);
        }

        [HttpGet]
        [Route("user_info")]
        public async Task<IHttpActionResult> RequestUserInfo(string sdksession = null, string accessToken = null)
        {
            var response = await _mobileConnect.RequestUserInfoAsync(Request, sdksession, accessToken, new MobileConnectRequestOptions());
            return CreateResponse(response);
        }

        [HttpGet]
        [Route("identity")]
        public async Task<IHttpActionResult> RequestIdentity(string sdksession = null, string accessToken = null)
        {
            var response = await _mobileConnect.RequestIdentityAsync(Request, sdksession, accessToken, new MobileConnectRequestOptions());
            return CreateResponse(response);
        }

        [HttpGet]
        [Route("refresh_token")]
        public async Task<IHttpActionResult> RefreshToken(string sdksession = null, string refreshToken = null)
        {
            var response = await _mobileConnect.RefreshTokenAsync(Request, refreshToken, sdksession);
            return CreateResponse(response);
        }

        [HttpGet]
        [Route("revoke_token")]
        public async Task<IHttpActionResult> RevokeToken(string sdksession = null, string accessToken = null)
        {
            var response = await _mobileConnect.RevokeTokenAsync(Request, accessToken, "access_token", sdksession);
            return CreateResponse(response);
        }

        [HttpGet]
        [Route("")]
        public async Task<IHttpActionResult> HandleRedirect(string sdksession=null, string mcc_mnc=null, string code=null, string expectedState=null, string expectedNonce=null)
        {
            // Accept valid results and results indicating validation was skipped due to missing support on the provider
            var requestOptions = new MobileConnectRequestOptions { AcceptedValidationResults = Authentication.TokenValidationResult.Valid | Authentication.TokenValidationResult.IdTokenValidationSkipped };
            var response = await _mobileConnect.HandleUrlRedirectAsync(Request, Request.RequestUri, sdksession, expectedState, expectedNonce, requestOptions);
            
            return CreateResponse(response);
        }

        private IHttpActionResult CreateResponse(MobileConnectStatus status)
        {
            var response = Request.CreateResponse(HttpStatusCode.OK, ResponseConverter.Convert(status));

            if (status.SetCookie != null)
            {
                foreach (var cookie in status.SetCookie)
                {
                    response.Headers.Add("Set-Cookie", cookie);
                }
            }

            return new ResponseMessageResult(response);
        }
    }
}
