using System;
using GSMA.MobileConnect.Cache;
using GSMA.MobileConnect.Web;
using System.Dynamic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using GSMA.MobileConnect.Constants;
using GSMA.MobileConnect.ServerSide.Web.Objects;
using GSMA.MobileConnect.ServerSide.Web.Utils;
using Newtonsoft.Json;
using System.Net.Http;
using GSMA.MobileConnect.Discovery;
using GSMA.MobileConnect.Utils;
using Scope = GSMA.MobileConnect.Constants.Scope;
using GSMA.MobileConnect.Constants;

namespace GSMA.MobileConnect.ServerSide.Web.Controllers
{
    [RoutePrefix("server_side_api")]
    public class WithoutDiscoveryController : Controller
    {
     

        public WithoutDiscoveryController(MobileConnectWebInterface mobileConnect)
        {
            _mobileConnect = mobileConnect;
        }

        public WithoutDiscoveryController()
        {
            GetParameters();
            if (_mobileConnect == null)
            {
                _sessionCache = new SessionCache();
                _discoveryCache = new DiscoveryCache(_operatorParams.maxDiscoveryCacheSize);
                _mobileConnect = new MobileConnectWebInterface(_mobileConnectConfig, _sessionCache, _discoveryCache);
            }
        }

        [HttpGet]
        [Route("start_discovery_manually")]
        public async Task<IHttpActionResult> StartAuthenticationWithoutDiscovery(string msisdn = "")
        {
            _mobileConnect = new MobileConnectWebInterface(_mobileConnectConfig, _sessionCache, _discoveryCache);
            GetParameters();

            DiscoveryResponse discoveryResponse = null;
            MobileConnectStatus status;

           
            discoveryResponse = await _mobileConnect.GenerateDiscoveryManually(_operatorParams.clientID, _operatorParams.clientSecret, _operatorParams.clientName, _operatorParams.operatorUrls);

            String url = CallStartAuth(discoveryResponse, msisdn, Request);

            return GetHttpMsgWithRedirect(url);
        }
        
        private IHttpActionResult GetHttpMsgWithRedirect(string url, string errMsg = null)
        {
            if (string.IsNullOrEmpty(url))
            {
                return CreateResponse(MobileConnectStatus.Error(ErrorCodes.InvalidArgument, errMsg, new Exception()));
            }

            var authResponse = Request.CreateResponse(HttpStatusCode.Redirect);
            authResponse.Headers.Location = new Uri(url);

            return new ResponseMessageResult(authResponse);
        }

       

        private String CallStartAuth(
            DiscoveryResponse discoveryResponse,
            string msisdn,
            HttpRequestMessage request)
        {
            if (_operatorParams.scope.Contains(Scope.AUTHZ))
            {
                return StartAuthorize(discoveryResponse, msisdn, request);
            }
            return StartAuthentication(discoveryResponse, msisdn, request);
        }

        private String StartAuthentication(
            DiscoveryResponse discoveryResponse,
            string msisdn,
            HttpRequestMessage request)
        {
            return StartAuth(discoveryResponse, msisdn, request);
        }

        private String StartAuthorize(
            DiscoveryResponse discoveryResponse,
            string msisdn,
            HttpRequestMessage request)
        {
            return StartAuth(discoveryResponse, msisdn, request);
        }

        private String StartAuth(
            DiscoveryResponse discoveryResponse,
            string msisdn, 
            HttpRequestMessage request)
        {
            string scope = _operatorParams.scope;

            string loginHint = null;
            if (!string.IsNullOrEmpty(msisdn))
            {
                loginHint = "MSISDN:"+msisdn;
            }

            var options = new MobileConnectRequestOptions
            {
                Scope = scope,
                Context = _apiVersion.Equals(Utils.Constants.VERSION2_0) ? Utils.Constants.ContextBindingMsg : null,
                BindingMessage = _apiVersion.Equals(Utils.Constants.VERSION2_0) ? Utils.Constants.ContextBindingMsg : null,
                ClientName = _operatorParams.clientName,
                AcrValues = _operatorParams.acrValues,
                LoginHint = loginHint
            };

            var status =
                _mobileConnect.StartAuthentication(request, discoveryResponse, null, null, null, options);

            if (HandleErrorMsg(status))
            {
                return null;
            }

            SetSessionCache(status, discoveryResponse, status.Nonce);
            
            return status.Url;
        }



        private bool HandleErrorMsg(MobileConnectStatus status)
        {
            return !string.IsNullOrEmpty(status.ErrorMessage);
        }

        private async Task<MobileConnectStatus> RequestPremiumInfo(DiscoveryResponse discoveryResponse, string accessToken = null)
        {
            return await _mobileConnect.RequestPremiumInfoAsync(Request, discoveryResponse,accessToken, new MobileConnectRequestOptions());
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

        private IHttpActionResult CreateIdentityResponse(MobileConnectStatus authnStatus, MobileConnectStatus identityUserInfoStatustatus = null)
        {
            var authnResponse = Request.CreateResponse(HttpStatusCode.OK, ResponseConverter.Convert(authnStatus));

            if (identityUserInfoStatustatus != null)
            {
                var response = Request.CreateResponse(HttpStatusCode.OK, ResponseConverter.Convert(identityUserInfoStatustatus));
                authnResponse.Content = new StringContent(СreateNewHttpResponseMessage(authnResponse, response));

                if (identityUserInfoStatustatus.SetCookie != null)
                {
                    foreach (var cookie in identityUserInfoStatustatus.SetCookie)
                    {
                        authnResponse.Headers.Add("Set-Cookie", cookie);
                    }
                }
            }

            else
            {
                authnResponse.Content = new StringContent(СreateNewHttpResponseMessage(authnResponse));
            }
            return new ResponseMessageResult(authnResponse);
        }

        private string СreateNewHttpResponseMessage(HttpResponseMessage authnResponse, HttpResponseMessage identityUserInfoStatustatus = null)
        {

            dynamic convertAuthnResponseToJson = JsonConvert.DeserializeObject(
                    authnResponse.Content.ReadAsStringAsync().Result);

            if (identityUserInfoStatustatus != null)
            {
                dynamic convertResponseToJson =
                    JsonConvert.DeserializeObject(identityUserInfoStatustatus.Content.ReadAsStringAsync().Result);
                convertAuthnResponseToJson.identity = convertResponseToJson.identity;
            }

            return JsonConvert.SerializeObject(convertAuthnResponseToJson);
        }

        private void GetParameters()
        {
            _operatorParams = readAndParseFiles.ReadFile(Utils.Constants.WithoutDiscoveryFilePath);
            _apiVersion = _operatorParams.apiVersion;
            _includeRequestIp = _operatorParams.includeRequestIP.Equals("True");

            _mobileConnectConfig = new MobileConnectConfig()
            {
                ClientId = _operatorParams.clientID,
                ClientSecret = _operatorParams.clientSecret,
                DiscoveryUrl = _operatorParams.discoveryURL,
                RedirectUrl = _operatorParams.redirectURL,
                XRedirect = _operatorParams.xRedirect.Equals("True") ? "APP" : "False"
            };
        }

        private async void SetSessionCache(MobileConnectStatus status, DiscoveryResponse discoveryResponse, String nonce)
        {
            await _sessionCache.Add(status.State, new SessionData(discoveryResponse, nonce));
        }

    }
}