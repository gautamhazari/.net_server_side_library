using System;
using GSMA.MobileConnect.Cache;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using GSMA.MobileConnect.Constants;
using GSMA.MobileConnect.ServerSide.Web.Objects;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Formatting;
using GSMA.MobileConnect.Discovery;
using GSMA.MobileConnect.Utils;
using Newtonsoft.Json.Linq;
using Scope = GSMA.MobileConnect.Constants.Scope;


namespace GSMA.MobileConnect.ServerSide.Web.Controllers
{
    [RoutePrefix("server_side_api")]
    public class MobileConnectController : Controller
    {

        public MobileConnectController(MobileConnectWebInterface mobileConnect)
        {
            MobileConnect = mobileConnect;
        }

        public MobileConnectController()
        {
            GetParameters();
            if (MobileConnect == null)
            {
                SessionCache = new SessionCache();
                DiscoveryCache = new DiscoveryCache(OperatorParams.maxDiscoveryCacheSize);
                MobileConnect = new MobileConnectWebInterface(MobileConnectConfig, SessionCache, DiscoveryCache);
            }
        }

        [HttpGet]
        [Route("start_discovery")]
        public async Task<IHttpActionResult> StartDiscovery(string msisdn = "", string mcc = "", string mnc = "", string sourceIp = "", bool IgnoreIp = false)
        {
            MobileConnect = new MobileConnectWebInterface(MobileConnectConfig, SessionCache, DiscoveryCache);
            GetParameters();

            if (string.IsNullOrEmpty(sourceIp) & !IgnoreIp)
            {
                sourceIp = IncludeRequestIp ? Request.GetClientIp() : null;
            }

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
                        return await StartDiscovery(null, null, null, null, true);
                    }
                }
            }

            SetDiscoveryCache(msisdn, mcc, mnc, sourceIp, discoveryResponse);

            string url = CallStartAuth(discoveryResponse, discoveryResponse.ResponseData.subscriber_id, Request,
                msisdn, mcc, mnc, sourceIp);

            if (url == null)
            {
                return await StartDiscovery(null, null, null, null, true);
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

            var status = await MobileConnect.AttemptDiscoveryAsync(request, msisdn, mcc, mnc, true, IncludeRequestIp,
                requestOptions);
            
            if (HandleErrorMsg(status))
            {
                status = await MobileConnect.AttemptDiscoveryAsync(
                    request, null, null, null, false, false, requestOptions);
            }

            return status;
        }

        private HttpResponseMessage redirectToView(MobileConnectStatus status, string operationStatus)
        {
            if (status.ErrorCode != null)
            {
                return Utils.ControllerResponseConverter.GetResponseMessage(new { Status = status, Operation = operationStatus }, Utils.Constants.FailPage);
            }

            return Utils.ControllerResponseConverter.GetResponseMessage(new { Operation = operationStatus }, Utils.Constants.SuccessPage);
        }

        [HttpGet]
        [Route("discovery_callback")]
        public async Task<HttpResponseMessage> DiscoveryCallback(
          string state = null,
          string error = null,
          string error_description = null,
          string description = null)
        {
            string operationStatus;

            if (!string.IsNullOrEmpty(error))
            {
                if (OperatorParams.scope.Contains(Scope.AUTHN) || OperatorParams.scope.Equals(Scope.OPENID))
                {
                    operationStatus = Utils.Status.AUTHENTICATION;
                }
                else
                {
                    operationStatus = Utils.Status.AUTHORISATION;
                }
                return redirectToView(MobileConnectStatus.Error(error, error_description ?? description, new Exception()), operationStatus);
            }

            var options = new MobileConnectRequestOptions
            {
                AcceptedValidationResults = Authentication.TokenValidationResult.Valid |
                    Authentication.TokenValidationResult.IdTokenValidationSkipped,
                Context = ApiVersion.Equals(Utils.Constants.VERSION2_0) || ApiVersion.Equals(Utils.Constants.VERSION2_3) ? Utils.Constants.ContextBindingMsg : null,
                BindingMessage = ApiVersion.Equals(Utils.Constants.VERSION2_0) || ApiVersion.Equals(Utils.Constants.VERSION2_3) ? Utils.Constants.ContextBindingMsg : null,
                ClientName = OperatorParams.clientName,
                AcrValues = OperatorParams.acrValues
            };

            Uri requestUri = Request.RequestUri;

            SessionData sessionData = SessionCache.Get(state);

            MobileConnectStatus status = await MobileConnect.HandleUrlRedirectAsync(Request, requestUri, sessionData.DiscoveryResponse,
                state, sessionData.Nonce, options, ApiVersion);


            var idTokenResponseModel =
                JsonConvert.DeserializeObject<IdTokenResponse>(status.TokenResponse.DecodedIdTokenPayload);


            MobileConnectStatus response = null;
            if (idTokenResponseModel.nonce.Equals(sessionData.Nonce))
            {
                if (ApiVersion.Equals(Utils.Constants.VERSION1_1) &
                    !string.IsNullOrEmpty(sessionData.DiscoveryResponse.OperatorUrls.UserInfoUrl))
                {
                    for (int scopeIndex = 0; scopeIndex < UserInfoScopes.Length; scopeIndex++)
                    {
                        if (OperatorParams.scope.Contains(UserInfoScopes[scopeIndex]))
                        {
                            response = await RequestUserInfo(sessionData.DiscoveryResponse,
                                status.TokenResponse.ResponseData.AccessToken);
                        }
                    }
                }

                if ((ApiVersion.Equals(Utils.Constants.VERSION2_0) || ApiVersion.Equals(Utils.Constants.VERSION2_3)) &
                    !string.IsNullOrEmpty(sessionData.DiscoveryResponse.OperatorUrls.PremiumInfoUrl))
                {
                    for (int scopeIndex = 0; scopeIndex < IdentityScopes.Length; scopeIndex++)
                    {
                        if (OperatorParams.scope.Contains(IdentityScopes[scopeIndex]))
                        {
                            response = await RequestPremiumInfo(sessionData.DiscoveryResponse,
                                status.TokenResponse.ResponseData.AccessToken);
                        }
                    }
                }
                else
                {
                    return redirectToView(response, Utils.Status.TOKEN);
                }
            }
            else
            {
                response = MobileConnectStatus.Error(
                    ErrorCodes.InvalidArgument, "nonce is incorrect", new Exception());
                return redirectToView(response, Utils.Status.TOKEN);
            }

            // return CreateResponse(status);
            return redirectToView(response, Utils.Status.PREMIUMINFO);
        }

        private async void SetDiscoveryCache(string msisdn, string mcc, string mnc, string sourceIp,
            DiscoveryResponse discoveryResponse)
        {
            await DiscoveryCache.Add(StringUtils.FormatKey(msisdn, mcc, mnc, sourceIp), discoveryResponse);
        }

        private DiscoveryResponse GetDiscoveryCache(string msisdn, string mcc, string mnc, string sourceIp)
        {
            string key = StringUtils.FormatKey(msisdn, mcc, mnc, sourceIp);
            return DiscoveryCache.Get(key);
        }

        [HttpGet]
        [Route("discovery_callback")]
        public async Task<IHttpActionResult> MCC_MNC_DiscoveryCallback(string mcc_mnc, string subscriber_id = "")
        {
            var requestOptions = new MobileConnectRequestOptions
            {
                Context = ApiVersion.Equals(Utils.Constants.VERSION2_0) || ApiVersion.Equals(Utils.Constants.VERSION2_3) ? Utils.Constants.ContextBindingMsg : null,
                BindingMessage = ApiVersion.Equals(Utils.Constants.VERSION2_0) || ApiVersion.Equals(Utils.Constants.VERSION2_3) ? Utils.Constants.ContextBindingMsg : null,
                ClientName = OperatorParams.clientName,
                AcrValues = OperatorParams.acrValues
            };

            var mcc_mncArray = mcc_mnc.Split(new char[] { '_' });
            var mcc = mcc_mncArray[0];
            var mnc = mcc_mncArray[1];

            var status = await MobileConnect.AttemptDiscoveryAsync(
                RequestMessage, null, mcc, mnc, true, IncludeRequestIp, requestOptions);

            if (status.DiscoveryResponse != null)
            {
                SetDiscoveryCache(null, mcc, mnc, null, status.DiscoveryResponse);

                var url = CallStartAuth(status.DiscoveryResponse, subscriber_id, RequestMessage, null, mcc, mnc,
                    null);
                return GetHttpMsgWithRedirect(url);


            }
            else
            {
                return GetHttpMsgWithRedirect(status.Url, status.ErrorMessage);
            }
        }

        [HttpGet]
        [Route("sector_identifier_uri")]
        public IHttpActionResult GetSectorIdentifierUri()
        {
            var array = JArray.Parse(Utils.ReadAndParseFiles.ReadFileAsString(Utils.Constants.SectorIdentifierFilePath));
            var response = new HttpResponseMessage()
            {
                Content = new ObjectContent<JArray>(array, new JsonMediaTypeFormatter()),
                RequestMessage = Request
            };

            return new ResponseMessageResult(response);
        }

        private string CallStartAuth(
            DiscoveryResponse discoveryResponse,
            string subscriberId,
            HttpRequestMessage request,
            string msisdn,
            string mcc,
            string mnc,
            string sourceIp)
        {
            if (OperatorParams.scope.Contains(Scope.AUTHZ))
            {
                return StartAuthorize(discoveryResponse, subscriberId, request, msisdn, mcc, mnc, sourceIp);
            }
            return StartAuthentication(discoveryResponse, subscriberId, request, msisdn, mcc, mnc, sourceIp);
        }

        private string StartAuthentication(
            DiscoveryResponse discoveryResponse,
            string subscriberId,
            HttpRequestMessage request,
            string msisdn,
            string mcc,
            string mnc,
            string sourceIp)
        {
            return StartAuth(discoveryResponse, subscriberId, request, msisdn, mcc, mnc, sourceIp);
        }

        private string StartAuthorize(
            DiscoveryResponse discoveryResponse,
            string subscriberId,
            HttpRequestMessage request,
            string msisdn,
            string mcc,
            string mnc,
            string sourceIp)
        {
            return StartAuth(discoveryResponse, subscriberId, request, msisdn, mcc, mnc, sourceIp);
        }

        private string StartAuth(
            DiscoveryResponse discoveryResponse, 
            string subscriberId,
            HttpRequestMessage request,
            string msisdn,
            string mcc,
            string mnc,
            string sourceIp)
        {
            string scope = OperatorParams.scope;

            var options = new MobileConnectRequestOptions
            {
                Scope = scope,
                Context = ApiVersion.Equals(Utils.Constants.VERSION2_0) || ApiVersion.Equals(Utils.Constants.VERSION2_3) ? Utils.Constants.ContextBindingMsg : null,
                BindingMessage = ApiVersion.Equals(Utils.Constants.VERSION2_0) || ApiVersion.Equals(Utils.Constants.VERSION2_3) ? Utils.Constants.ContextBindingMsg : null,
                ClientName = OperatorParams.clientName,
                AcrValues = OperatorParams.acrValues
            };

            var status =
                MobileConnect.StartAuthentication(request, discoveryResponse, subscriberId, null, null, options, ApiVersion);

            if (HandleErrorMsg(status))
            {
                return null;
            }

            SetSessionCache(status, msisdn, mcc, mnc, sourceIp);
            return status.Url;
        }

        private void GetParameters()
        {
            OperatorParams = ReadAndParseFiles.ReadFile(Utils.Constants.OperatorDataFilePath);
            ApiVersion = OperatorParams.apiVersion;
            IncludeRequestIp = OperatorParams.includeRequestIP.Equals("True");

            MobileConnectConfig = new MobileConnectConfig()
            {
                ClientId = OperatorParams.clientID,
                ClientSecret = OperatorParams.clientSecret,
                DiscoveryUrl = OperatorParams.discoveryURL,
                RedirectUrl = OperatorParams.redirectURL,
                XRedirect = OperatorParams.xRedirect.Equals("True") ? "APP" : "False"
            };
        }

        private async void SetSessionCache(MobileConnectStatus status, string msisdn, string mcc, string mnc, string sourceIp)
        {
            await SessionCache.Add(status.State,
                new SessionData(DiscoveryCache.Get(StringUtils.FormatKey(msisdn, mcc, mnc, sourceIp)), status.Nonce));
        }
    }
}