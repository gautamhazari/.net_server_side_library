using System;
using GSMA.MobileConnect.Cache;
using GSMA.MobileConnect.Web;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using GSMA.MobileConnect.Constants;
using GSMA.MobileConnect.ServerSide.Web.Objects;
using GSMA.MobileConnect.ServerSide.Web.Utils;
using Newtonsoft.Json;
using System.Net.Http;
using System.Runtime.InteropServices;
using GSMA.MobileConnect.Discovery;
using GSMA.MobileConnect.Utils;

namespace GSMA.MobileConnect.ServerSide.Web.Controllers
{
    [RoutePrefix("server_side_api")]
    public class MobileConnectController : ApiController
    {
        private static ReadAndParseFiles readAndParseFiles = new ReadAndParseFiles();
        private static MobileConnectWebInterface _mobileConnect;
        private static string _apiVersion;
        private static bool _includeRequestIp;
        private static string _clientName;
        private static MobileConnectConfig _mobileConnectConfig;
        private static OperatorParameters _operatorParams;

    private static HttpRequestMessage _requestMessage = new HttpRequestMessage();
        private static SessionCache _sessionCache;
        private static DiscoveryCache _discoveryCache;
        IDiscoveryService discovery;

        public MobileConnectController(MobileConnectWebInterface mobileConnect)
        {
            _mobileConnect = mobileConnect;
        }

        public MobileConnectController()
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
        [Route("start_discovery")]
        public async Task<IHttpActionResult> StartDiscovery(string msisdn = "", string mcc = "", string mnc = "", string sourceIp = "")
        {
            _mobileConnect = new MobileConnectWebInterface(_mobileConnectConfig, _sessionCache, _discoveryCache);
            GetParameters();

            var discoveryResponse = GetDiscoveryCache(msisdn, mcc, mnc, sourceIp);
            MobileConnectStatus status;

            if (discoveryResponse == null)
            {
                status = await AttemptDiscovery(msisdn, mcc, mnc, sourceIp, Request);
                discoveryResponse = status.DiscoveryResponse;

                if (discoveryResponse == null || discoveryResponse.ResponseCode != Utils.Constants.Response_OK)
                {
                    if (status.Url != null)
                    {
                        return GetHttpMsgWithRedirect(status.Url);
                    }
                    else
                    {
                        return await StartDiscovery(msisdn, mcc, mnc, null);
                    }
                }
            }
            
            SetDiscoveryCache(msisdn, mcc, mnc, sourceIp, discoveryResponse);

            string url = StartAuthentication(discoveryResponse, discoveryResponse.ResponseData.subscriber_id, Request,
                msisdn, mcc, mnc, sourceIp);

            if (url == null)
            {
                return await StartDiscovery(null, null, null, null);
            }

            return GetHttpMsgWithRedirect(url);
        }

        private async Task<MobileConnectStatus> AttemptDiscovery(string msisdn, string mcc, string mnc, string sourceIp,
            HttpRequestMessage request)
        {
            var requestOptions = new MobileConnectRequestOptions { ClientIP = sourceIp };
            var discoveryOptions = requestOptions?.DiscoveryOptions ?? new DiscoveryOptions();
            discoveryOptions.MSISDN = msisdn;
            discoveryOptions.IdentifiedMCC = mcc;
            discoveryOptions.IdentifiedMNC = mnc;

            var status = await _mobileConnect.AttemptDiscoveryAsync(request, msisdn, mcc, mnc, true, _includeRequestIp,
                requestOptions);
            
            if (HandleErrorMsg(status))
            {
                status = await _mobileConnect.AttemptDiscoveryAsync(
                    request, null, null, null, false, false, requestOptions);
            }

            return status;
        }

        private async void SetDiscoveryCache(string msisdn, string mcc, string mnc, string sourceIp,
            DiscoveryResponse discoveryResponse)
        {
            await _discoveryCache.Add(StringUtils.FormatKey(msisdn, mcc, mnc, sourceIp), discoveryResponse);
        }

        private DiscoveryResponse GetDiscoveryCache(string msisdn, string mcc, string mnc, string sourceIp)
        {
            string key = StringUtils.FormatKey(msisdn, mcc, mnc, sourceIp);
            return _discoveryCache.Get(key);
        }

        [HttpGet]
        [Route("headless_authentication")]
        public async Task<IHttpActionResult> RequestHeadlessAuthentication(
            string sdksession = null,
            string subscriberId = null,
            string scope = null)
        {
            var options = new MobileConnectRequestOptions
            {
                Scope = scope,
                Context = "headless",
                BindingMessage = "demo headless",
                AutoRetrieveIdentityHeadless = true,
            };

            var response = await _mobileConnect.RequestHeadlessAuthenticationAsync(
                Request, sdksession, subscriberId, null, null, options);

            return CreateResponse(response);
        }

        [HttpGet]
        [Route("")]
        public async Task<IHttpActionResult> HandleRedirect(
            string sdksession = null, 
            string mcc_mnc = null, 
            string code = null,
            string expectedState = null, 
            string expectedNonce = null)
        {
            // Accept valid results and results indicating validation 
            // was skipped due to missing support on the provider
            var requestOptions = new MobileConnectRequestOptions
            {
                AcceptedValidationResults = Authentication.TokenValidationResult.Valid |
                    Authentication.TokenValidationResult.IdTokenValidationSkipped
            };

            var response = await _mobileConnect.HandleUrlRedirectAsync(
                Request, Request.RequestUri, sdksession, expectedState, expectedNonce, requestOptions);

            return CreateResponse(response);
        }

        [HttpGet]
        [Route("discovery_callback")]
        public async Task<IHttpActionResult> MCC_MNC_DiscoveryCallback(string mcc_mnc, string subscriber_id = "")
        {
            var requestOptions = new MobileConnectRequestOptions
            {
                Context = _apiVersion.Equals(Utils.Constants.Version2) ? Utils.Constants.ContextBindingMsg : null,
                BindingMessage = _apiVersion.Equals(Utils.Constants.Version2) ? Utils.Constants.ContextBindingMsg : null,
                ClientName = _operatorParams.clientName
            };

            var mcc_mncArray = mcc_mnc.Split(new char[] { '_' });
            var mcc = mcc_mncArray[0];
            var mnc = mcc_mncArray[1];

            var status = await _mobileConnect.AttemptDiscoveryAsync(
                _requestMessage, null, mcc, mnc, true, _includeRequestIp, requestOptions);

            if (status.DiscoveryResponse != null)
            {
                SetDiscoveryCache(null, mcc, mnc, null, status.DiscoveryResponse);

                var url = StartAuthentication(status.DiscoveryResponse, subscriber_id, _requestMessage, null, mcc, mnc,
                    null);
                return GetHttpMsgWithRedirect(url);


            }
            else
            {
                return GetHttpMsgWithRedirect(status.Url, status.ErrorMessage);
            }
        }


        [HttpGet]
        [Route("discovery_callback")]
        public async Task<IHttpActionResult> DiscoveryCallback(
          string state = null,
          string error = null,
          string error_description = null,
          string description = null)
        {
            if (!string.IsNullOrEmpty(error))
            {
                return CreateResponse(MobileConnectStatus.Error(error, error_description != null ? error_description : description, new Exception()));
            }

            var options = new MobileConnectRequestOptions
            {
                AcceptedValidationResults = Authentication.TokenValidationResult.Valid |
                    Authentication.TokenValidationResult.IdTokenValidationSkipped,
                Context = _apiVersion.Equals(Utils.Constants.Version2) ? Utils.Constants.ContextBindingMsg : null,
                BindingMessage = _apiVersion.Equals(Utils.Constants.Version2) ? Utils.Constants.ContextBindingMsg : null,
                ClientName = _operatorParams.clientName
            };
          
            Uri requestUri = Request.RequestUri;

            SessionData sessionData = _sessionCache.Get(state);

            MobileConnectStatus status = await _mobileConnect.HandleUrlRedirectAsync(Request, requestUri, sessionData.DiscoveryResponse,
                state, sessionData.Nonce, options);


            var idTokenResponseModel =
                JsonConvert.DeserializeObject<IdTokenResponse>(status.TokenResponse.DecodedIdTokenPayload);


            MobileConnectStatus response = null;
            if (idTokenResponseModel.nonce.Equals(sessionData.Nonce))
            {
                if (!string.IsNullOrEmpty(sessionData.DiscoveryResponse.OperatorUrls.UserInfoUrl))
                {
                    response = await RequestUserInfo(sessionData.DiscoveryResponse, status.TokenResponse.ResponseData.AccessToken);
                    return CreateIdentityResponse(status, response);
                }
                
                if (!string.IsNullOrEmpty(sessionData.DiscoveryResponse.OperatorUrls.PremiumInfoUrl))
                {
                    response = await RequestIdentity(sessionData.DiscoveryResponse, status.TokenResponse.ResponseData.AccessToken);
                    return CreateIdentityResponse(status, response);
                }
            }
            else
            {
                response = MobileConnectStatus.Error(
                    ErrorCodes.InvalidArgument, "nonce is incorrect", new Exception());
                return CreateResponse(response);
            }
            return CreateIdentityResponse(status);
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

        private bool HandleErrorMsg(MobileConnectStatus status)
        {
            return !string.IsNullOrEmpty(status.ErrorMessage);
        }

        private async Task<MobileConnectStatus> RequestUserInfo(DiscoveryResponse discoveryResponse, string accessToken = null)
        {
            return await _mobileConnect.RequestUserInfoAsync(Request, discoveryResponse, accessToken, new MobileConnectRequestOptions());
        }

        private String StartAuthentication(
            DiscoveryResponse discoveryResponse, 
            string subscriberId,
            HttpRequestMessage request,
            string msisdn,
            string mcc,
            string mnc,
            string sourceIp)
        {
            string scope = _operatorParams.scope;

            var options = new MobileConnectRequestOptions
            {
                Scope = scope,
                Context = _apiVersion.Equals(Utils.Constants.Version2) ? Utils.Constants.ContextBindingMsg : null,
                BindingMessage = _apiVersion.Equals(Utils.Constants.Version2) ? Utils.Constants.ContextBindingMsg : null,
                ClientName = _operatorParams.clientName
            };

            var status =
                _mobileConnect.StartAuthentication(request, discoveryResponse, subscriberId, null, null, options);

            if (HandleErrorMsg(status))
            {
                return null;
            }

            SetSessionCache(status, msisdn, mcc, mnc, sourceIp);
            return status.Url;
        }

        private async Task<MobileConnectStatus> RequestIdentity(DiscoveryResponse discoveryResponse, string accessToken = null)
        {
            return await _mobileConnect.RequestIdentityAsync(Request, discoveryResponse,accessToken, new MobileConnectRequestOptions());
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

            dynamic responseMessage = new ExpandoObject();
            responseMessage.access_token = convertAuthnResponseToJson.token.access_token;
            responseMessage.token_type = convertAuthnResponseToJson.token.token_type;
            responseMessage.id_token = convertAuthnResponseToJson.token.id_token;

            if (identityUserInfoStatustatus != null)
            {
                dynamic convertResponseToJson =
                    JsonConvert.DeserializeObject(identityUserInfoStatustatus.Content.ReadAsStringAsync().Result);
                responseMessage.identity = convertResponseToJson.identity;
            }

            return JsonConvert.SerializeObject(responseMessage);
        }

        private void GetParameters()
        {
            _operatorParams = readAndParseFiles.ReadFile(Utils.Constants.ConfigFilePath);
            _apiVersion = _operatorParams.apiVersion;
            _includeRequestIp = _operatorParams.includeRequestIP.Equals("True");
            _clientName = _operatorParams.clientName;
            _mobileConnectConfig = new MobileConnectConfig()
            {
                ClientId = _operatorParams.clientID,
                ClientSecret = _operatorParams.clientSecret,
                ClientName = _operatorParams.clientName,
                DiscoveryUrl = _operatorParams.discoveryURL,
                RedirectUrl = _operatorParams.redirectURL,
                XRedirect = _operatorParams.xRedirect.Equals("True") ? "APP" : "False"
            };
        }

        private async void SetSessionCache(MobileConnectStatus status, string msisdn, string mcc, string mnc, string sourceIp)
        {
            await _sessionCache.Add(status.State,
                new SessionData(_discoveryCache.Get(StringUtils.FormatKey(msisdn, mcc, mnc, sourceIp)), status.Nonce));
        }
    }
}