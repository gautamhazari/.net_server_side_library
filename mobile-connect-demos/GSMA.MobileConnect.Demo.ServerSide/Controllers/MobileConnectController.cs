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
using System.Linq;
using GSMA.MobileConnect.Discovery;

namespace GSMA.MobileConnect.ServerSide.Web.Controllers
{
    [RoutePrefix("server_side_api")]
    public class MobileConnectController : ApiController
    {
        private static ReadAndParseFiles readAndParseFiles = new ReadAndParseFiles();
        private static MobileConnectWebInterface _mobileConnect;
        private static string _apiVersion;
        private static bool _includeRequestIP;
        private static MobileConnectConfig _mobileConnectConfig;
        private static OperatorParameters _operatorParams;
        private static CachedParameters CachedParameters = new CachedParameters();
        private static ResponseChecker responseChecker = new ResponseChecker();
        private static HttpRequestMessage _requestMessage = new HttpRequestMessage();
        private ConcurrentCache cache;
        private ConcurrentCache discoveryCache;
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
                cache = new ConcurrentCache();
                discoveryCache = new ConcurrentCache(_operatorParams.maxDiscoveryCacheSize);
                _mobileConnect = new MobileConnectWebInterface(_mobileConnectConfig, cache, discoveryCache);
            }
        }

        [HttpGet]
        [Route("start_discovery")]
        public async Task<IHttpActionResult> StartDiscovery(string msisdn = "", string mcc = "", string mnc = "")
        {
            string sourceIp = Request.Headers.Any(h => h.Key.Equals("X-Source-IP")) ?
                Request.Headers.GetValues("X-Source-IP").ToList().FirstOrDefault() :
                string.Empty;

            var requestOptions = new MobileConnectRequestOptions { ClientIP = sourceIp };
            var discoveryOptions = requestOptions?.DiscoveryOptions ?? new DiscoveryOptions();
            discoveryOptions.MSISDN = msisdn;
            discoveryOptions.IdentifiedMCC = mcc;
            discoveryOptions.IdentifiedMNC = mnc;

            var status = await _mobileConnect.AttemptDiscoveryAsync(
                Request, msisdn, mcc, mnc, false, _includeRequestIP, requestOptions);

            _requestMessage = Request;

            if (HandleErrorMsg(status) == true)
            {
                status = await _mobileConnect.AttemptDiscoveryAsync(
                    Request, null, null, null, false, false, requestOptions);
            }

            if (status.DiscoveryResponse != null && 
                status.DiscoveryResponse.ResponseCode == Utils.Constants.Response_OK)
            {
                CachedParameters.sdkSession = status.SDKSession;
                CachedParameters.discoveryOptions = discoveryOptions;
                var authResponse = await StartAuthentication(
                    Request, status.SDKSession, status.DiscoveryResponse.ResponseData.subscriber_id);

                return authResponse;
            }
            else
            {
                return GetHttpMsgWithRedirect(status, status.ErrorCode);
            }
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
        public async Task<IHttpActionResult> DiscoveryCallback(
            string state = null, 
            string error = null, 
            string description = null)
        {
            if (!string.IsNullOrEmpty(error))
            {
                if (!string.IsNullOrEmpty(state))
                {
                    return await StartDiscovery();
                }

                return CreateResponse(MobileConnectStatus.Error(error, description, new Exception()));
            }

            var requestOptions = new MobileConnectRequestOptions
            {
                AcceptedValidationResults = Authentication.TokenValidationResult.Valid |
                    Authentication.TokenValidationResult.IdTokenValidationSkipped
            };

            var cachedInfo = responseChecker.getData(state);
            var authConnectStatus = await _mobileConnect.HandleUrlRedirectAsync(
                Request, 
                Request.RequestUri, 
                cachedInfo.Result.sdkSession, 
                state,
                cachedInfo.Result.nonce, 
                requestOptions);

            if (HandleErrorMsg(authConnectStatus))
            {
                RemoveSessionFromCache(discoveryCache, cachedInfo.Result.discoveryOptions);
                return CreateResponse(MobileConnectStatus.Error(
                    ErrorCodes.InvalidArgument, authConnectStatus.ErrorMessage, new Exception()));
            }

            MobileConnectStatus response = null;
            var idTokenResponseModel = 
                JsonConvert.DeserializeObject<IdTokenResponse>(authConnectStatus.TokenResponse.DecodedIdTokenPayload);

            if (idTokenResponseModel.nonce.Equals(cachedInfo.Result.nonce))
            {
                if (_operatorParams.identity.Equals("True"))
                {
                    response = await RequestUserInfo(state, authConnectStatus.TokenResponse.ResponseData.AccessToken);
                    return CreateIdentityResponse(response, authConnectStatus);
                }
                else if (_operatorParams.userInfo.Equals("True"))
                {
                    response = await RequestIdentity(state, authConnectStatus.TokenResponse.ResponseData.AccessToken);
                    return CreateIdentityResponse(response, authConnectStatus);
                }
            }
            else
            {
                response = MobileConnectStatus.Error(
                    ErrorCodes.InvalidArgument, "nonce is incorrect", new Exception());
            }

            return CreateResponse(response);
        }

        [HttpGet]
        [Route("discovery_callback")]
        public async Task<IHttpActionResult> MCC_MNC_DiscoveryCallback(string mcc_mnc, string subscriber_id = "")
        {
            var requestOptions = new MobileConnectRequestOptions { ClientIP = "" };
            var mcc_mncArray = mcc_mnc.Split(new char[] { '_' });
            var mcc = mcc_mncArray[0];
            var mnc = mcc_mncArray[1];
            var status = await _mobileConnect.AttemptDiscoveryAsync(
                _requestMessage, "", mcc, mnc, true, _includeRequestIP, requestOptions);

            if (status.DiscoveryResponse != null)
            {
                CachedParameters.sdkSession = status.SDKSession;
                var authResponse = await StartAuthentication(_requestMessage, status.SDKSession, subscriber_id);
                return authResponse;
            }
            else
            {
                return GetHttpMsgWithRedirect(status, status.ErrorMessage);
            }
        }

        private async void RemoveSessionFromCache(ConcurrentCache cache, DiscoveryOptions options)
        {
            var mcc = options.IdentifiedMCC != null ? options.IdentifiedMCC : options.SelectedMCC;
            var mnc = options.IdentifiedMNC != null ? options.IdentifiedMNC : options.SelectedMNC;
            var msisdn = options.MSISDN;
            var client_ip = options.LocalClientIP;

            if (cache == null || options == null)
            {
                return;
            }

            if (!string.IsNullOrEmpty(msisdn))
                await cache.Remove<DiscoveryResponse>(msisdn);

            else if (!(string.IsNullOrEmpty(mcc) && string.IsNullOrEmpty(mnc)))
                await cache.Remove(mcc, mnc);

            else if (!string.IsNullOrEmpty(client_ip))
                await cache.Remove<DiscoveryResponse>(client_ip);

        }


        private IHttpActionResult GetHttpMsgWithRedirect(MobileConnectStatus status, string errMsg)
        {
            if (string.IsNullOrEmpty(status.Url))
            {
                return CreateResponse(MobileConnectStatus.Error(ErrorCodes.InvalidArgument, errMsg, new Exception()));
            }

            var authResponse = Request.CreateResponse(HttpStatusCode.Redirect);
            authResponse.Headers.Location = new Uri(status.Url);

            return new ResponseMessageResult(authResponse);
        }

        private bool HandleErrorMsg(MobileConnectStatus status)
        {
            return !string.IsNullOrEmpty(status.ErrorMessage);
        }

        private async Task<MobileConnectStatus> RequestUserInfo(string state = null, string accessToken = null)
        {
            var cachedInfo = responseChecker.getData(state);
            MobileConnectStatus response = null;

            try
            {
                response = await _mobileConnect.RequestUserInfoAsync(Request, cachedInfo.Result.sdkSession,
                    accessToken ?? cachedInfo.Result.accessToken, new MobileConnectRequestOptions());
            }
            catch (Exception e)
            {
                if (cachedInfo.Result != null)
                {
                    return response;
                }

                response = MobileConnectStatus.Error(ErrorCodes.InvalidArgument, "state value is incorrect", e);
            }

            return response;
        }

        private async Task<IHttpActionResult> StartAuthentication(
            HttpRequestMessage request, 
            string sdksession = null, 
            string subscriberId = null)
        {
            string scope = _operatorParams.scope;

            var options = new MobileConnectRequestOptions
            {
                AcrValues = _operatorParams.acrValues,
                Scope = scope,
                ClientName = _operatorParams.clientName,
                Version = _apiVersion,
                Context = _apiVersion.Equals(Utils.Constants.Version2) ? Utils.Constants.ContextBindingMsg : null,
                BindingMessage = _apiVersion.Equals(Utils.Constants.Version2) ? 
                    Utils.Constants.ContextBindingMsg : null
            };

            var response = await _mobileConnect.StartAuthentication(
                request, sdksession, subscriberId, null, null, options);

            if (response.ErrorMessage != null)
            {
                return CreateResponse(
                    MobileConnectStatus.Error(ErrorCodes.InvalidArgument, response.ErrorMessage, new Exception()));
            }

            CachedParameters.nonce = response.Nonce;
            await responseChecker.SaveData(response.State, CachedParameters);
            var authResponse = Request.CreateResponse(HttpStatusCode.Redirect);
            authResponse.Headers.Location = new Uri(response.Url);

            return new ResponseMessageResult(authResponse);
        }

        private async Task<MobileConnectStatus> RequestIdentity(string state = null, string accessToken = null)
        {
            var cachedInfo = responseChecker.getData(state);
            MobileConnectStatus response = null;

            try
            {
                response = await _mobileConnect.RequestIdentityAsync(Request, cachedInfo.Result.sdkSession,
                    accessToken ?? cachedInfo.Result.accessToken, new MobileConnectRequestOptions());
            }
            catch (Exception e)
            {
                if (cachedInfo.Result != null)
                {
                    return response;
                }
                response = MobileConnectStatus.Error(ErrorCodes.InvalidArgument, "state value is incorrect", e);
            }

            return response;
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

        private IHttpActionResult CreateIdentityResponse(MobileConnectStatus status, MobileConnectStatus authnStatus)
        {
            var response = Request.CreateResponse(HttpStatusCode.OK, ResponseConverter.Convert(status));
            var authnResponse = Request.CreateResponse(HttpStatusCode.OK, ResponseConverter.Convert(authnStatus));
            authnResponse.Content = new StringContent(СreateNewHttpResponseMessage(response, authnResponse));

            if (status.SetCookie != null)
            {
                foreach (var cookie in status.SetCookie)
                {
                    authnResponse.Headers.Add("Set-Cookie", cookie);
                }
            }

            return new ResponseMessageResult(authnResponse);
        }

        private string СreateNewHttpResponseMessage(HttpResponseMessage response, HttpResponseMessage authnResponse)
        {
            dynamic convertResponseToJson = JsonConvert.DeserializeObject(response.Content.ReadAsStringAsync().Result);
            dynamic convertAuthnResponseToJson = JsonConvert.DeserializeObject(
                authnResponse.Content.ReadAsStringAsync().Result);

            dynamic responseMessage = new ExpandoObject();
            responseMessage.access_token = convertAuthnResponseToJson.token.access_token;
            responseMessage.token_type = convertAuthnResponseToJson.token.token_type;
            responseMessage.id_token = convertAuthnResponseToJson.token.id_token;
            responseMessage.identity = convertResponseToJson.identity;

            return JsonConvert.SerializeObject(responseMessage);
        }

        private void GetParameters()
        {
            _operatorParams = readAndParseFiles.ReadFile(Utils.Constants.ConfigFilePath);
            _apiVersion = _operatorParams.apiVersion;
            _includeRequestIP = _operatorParams.includeRequestIP.Equals("True");

            _mobileConnectConfig = new MobileConnectConfig()
            {
                ClientId = _operatorParams.clientID,
                ClientSecret = _operatorParams.clientSecret,
                DiscoveryUrl = _operatorParams.discoveryURL,
                RedirectUrl = _operatorParams.redirectURL,
                XRedirect = _operatorParams.xRedirect.Equals("True") ? "APP" : "False"
            };
        }
    }
}