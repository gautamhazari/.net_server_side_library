using GSMA.MobileConnect.Web;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using System;
using GSMA.MobileConnect.Discovery;
using GSMA.MobileConnect.Cache;
using GSMA.MobileConnect;
using GSMA.MobileConnect.Utils;

namespace GSMA.MobileConnect.Demo.Web.Controllers
{

    public class MobileConnectController : ApiController
    {

        [HttpGet]
        [ActionName("start_manual_discovery")]
        public async Task<IHttpActionResult> StartManualDiscoveryWithMetadata(string subId = "", string clientId = "", string clientName = "", string clientSecret = "")
        {
            var operatorUrls = Config.setOperatorUrlsR2();

            var mobileConnectRequestOptions = new MobileConnectRequestOptions()
            {
                Scope = "",
                Context = "demo",
                BindingMessage = "demo auth",
            };

            MobileConnectConfig mobileConnectConfig = new MobileConnectConfig
            {
                ClientId = clientId,
                ClientSecret = clientSecret,
                RedirectUrl = Config.redirectUrl
            };

            MobileConnectWebInterface mobileConnectWebInterface = new MobileConnectWebInterface(mobileConnectConfig, new ConcurrentCache());
            var discoveryResponse = await mobileConnectWebInterface.GenerateDiscoveryManually(clientId, clientSecret, subId, clientName, operatorUrls);
            var status = mobileConnectWebInterface.StartAuthentication(Request, discoveryResponse, subId, null, null, mobileConnectRequestOptions);
            Config.response = discoveryResponse;
            return CreateResponse(status);
        }

        [HttpGet]
        [ActionName("start_manual_discovery_no_metadata")]
        public async Task<IHttpActionResult> StartManualDiscoveryWithoutMetadata(string subId = "", string clientId = "", string clientName = "", string clientSecret = "")
        {
            var operatorUrls = Config.setOperatorUrlsR1();

            var mobileConnectRequestOptions = new MobileConnectRequestOptions()
            {
                Scope = ""
            };

            MobileConnectConfig mobileConnectConfig = new MobileConnectConfig
            {
                ClientId = "",
                ClientSecret = "",
                RedirectUrl = Config.redirectUrl
            };

            MobileConnectWebInterface mobileConnectWebInterface = new MobileConnectWebInterface(mobileConnectConfig, new ConcurrentCache());

            var discoveryResponse = await mobileConnectWebInterface.GenerateDiscoveryManually(clientId, clientSecret, subId, "anyName", operatorUrls);
            var status = mobileConnectWebInterface.StartAuthentication(Request, discoveryResponse, subId, null, null, mobileConnectRequestOptions);
            Config.response = discoveryResponse;
            return CreateResponse(status);
        }

        [HttpGet]
        [ActionName("redirect")]
        public async Task<IHttpActionResult> HandleRedirect(string sdksession = null, string mcc_mnc = null, string code = null, string expectedState = null, string expectedNonce = null)
        {
            // Accept valid results and results indicating validation was skipped due to missing support on the provider
            var requestOptions = new MobileConnectRequestOptions { AcceptedValidationResults = Authentication.TokenValidationResult.Valid | Authentication.TokenValidationResult.IdTokenValidationSkipped };
            MobileConnectConfig mobileConnectConfig = new MobileConnectConfig
            {
                ClientId = "",
                ClientSecret = "",
                RedirectUrl = Config.redirectUrl
            };
            MobileConnectWebInterface mobileConnectWebInterface = new MobileConnectWebInterface(mobileConnectConfig, new ConcurrentCache());
            var response = await mobileConnectWebInterface.HandleUrlRedirectAsync(Request, Request.RequestUri, Config.response, expectedState, expectedNonce, requestOptions);

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
