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
        private MobileConnectWebInterface _mobileConnect;

        public MobileConnectController(MobileConnectWebInterface mobileConnect)
        {
            this._mobileConnect = mobileConnect;
        }

        [HttpGet]
        [Route("start_discovery")]
        public async Task<IHttpActionResult> StartDiscovery(string msisdn="", string mcc="", string mnc="")
        {
            var response = await _mobileConnect.AttemptDiscoveryAsync(Request, msisdn, mcc, mnc, true, new MobileConnectRequestOptions());
            return CreateResponse(response);
        }

        [HttpGet]
        [Route("start_authentication")]
        public async Task<IHttpActionResult> StartAuthentication(string sdksession = null, string subscriberId = null, string scope = null)
        {
            var options = new MobileConnectRequestOptions
            {
                Scope = scope,
                Context = "demo",
                BindingMessage = "demo auth",
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
            var response = await _mobileConnect.HandleUrlRedirectAsync(Request, Request.RequestUri, sdksession, expectedState, expectedNonce, new MobileConnectRequestOptions());
            
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
