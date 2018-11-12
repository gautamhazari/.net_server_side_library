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
using System.Json;

namespace GSMA.MobileConnect.ServerSide.Web.Controllers
{
    [RoutePrefix("server_side_api")]
    public class Controller : ApiController
    {
        protected static ReadAndParseFiles readAndParseFiles = new ReadAndParseFiles();
        protected static MobileConnectWebInterface _mobileConnect;
        protected static string _apiVersion;
        protected static bool _includeRequestIp;
        protected static MobileConnectConfig _mobileConnectConfig;
        protected static OperatorParameters _operatorParams;

        protected static HttpRequestMessage _requestMessage = new HttpRequestMessage();
        protected static SessionCache _sessionCache;
        protected static DiscoveryCache _discoveryCache;
        protected static string[] _identityScopes = {Scope.IDENTITYPHONE, Scope.IDENTITYSIGNUP,
            Scope.IDENTITYNATIONALID, Scope.IDENTITYSIGNUPPLUS, Scope.KYCHASHED, Scope.KYCPLAIN};
        protected static string[] _userInfoScopes = {Scope.PROFILE, Scope.EMAIL, Scope.ADDRESS,
            Scope.PHONE, Scope.OFFLINEACCESS};
        IDiscoveryService discovery;

        protected Controller(MobileConnectWebInterface mobileConnect)
        {
            _mobileConnect = mobileConnect;
        }

        protected Controller()
        {
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
                Request, Request.RequestUri, sdksession, expectedState, expectedNonce, requestOptions, _apiVersion);

            return CreateResponse(response);
        }

        protected IHttpActionResult GetHttpMsgWithRedirect(string url, string errMsg = null)
        {
            if (string.IsNullOrEmpty(url))
            {
                return CreateResponse(MobileConnectStatus.Error(ErrorCodes.InvalidArgument, errMsg, new Exception()));
            }

            var authResponse = Request.CreateResponse(HttpStatusCode.Redirect);
            authResponse.Headers.Location = new Uri(url);

            return new ResponseMessageResult(authResponse);
        }

        protected bool HandleErrorMsg(MobileConnectStatus status)
        {
            return !string.IsNullOrEmpty(status.ErrorMessage);
        }

        protected async Task<MobileConnectStatus> RequestUserInfo(DiscoveryResponse discoveryResponse, string accessToken = null)
        {
            return await _mobileConnect.RequestUserInfoAsync(Request, discoveryResponse, accessToken, new MobileConnectRequestOptions());
        }

        protected async Task<MobileConnectStatus> RequestPremiumInfo(DiscoveryResponse discoveryResponse, string accessToken = null)
        {
            return await _mobileConnect.RequestPremiumInfoAsync(Request, discoveryResponse, accessToken, new MobileConnectRequestOptions());
        }

        protected IHttpActionResult CreateResponse(MobileConnectStatus status)
        {
            HttpResponseMessage response;
            if (!string.IsNullOrEmpty(status.ErrorCode))
            {
                response = Request.CreateResponse(HttpStatusCode.Found, ResponseConverter.Convert(status));
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.OK, ResponseConverter.Convert(status));
            }
            if (status.SetCookie != null)
            {
                foreach (var cookie in status.SetCookie)
                {
                    response.Headers.Add("Set-Cookie", cookie);
                }
            }

            return new ResponseMessageResult(response);
        }

        protected IHttpActionResult CreateIdentityResponse(MobileConnectStatus authnStatus, MobileConnectStatus identityUserInfoStatustatus = null)
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

        protected string СreateNewHttpResponseMessage(HttpResponseMessage authnResponse, HttpResponseMessage identityUserInfoStatustatus = null)
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

    }
}