using System;
using GSMA.MobileConnect.Cache;
using GSMA.MobileConnect.Web;
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

namespace GSMA.MobileConnect.ServerSide.Web.Controllers
{
    [RoutePrefix("server_side_api")]
    public class Controller : ApiController
    {
        protected static ReadAndParseFiles ReadAndParseFiles = new ReadAndParseFiles();
        protected static MobileConnectWebInterface MobileConnect;
        protected static string ApiVersion;
        protected static bool IncludeRequestIp;
        protected static MobileConnectConfig MobileConnectConfig;
        protected static OperatorParameters OperatorParams;

        protected static HttpRequestMessage RequestMessage = new HttpRequestMessage();
        protected static SessionCache SessionCache;
        protected static DiscoveryCache DiscoveryCache;
        protected static string[] IdentityScopes = {Scope.MC_IDENTITY_PHONE, Scope.MC_IDENTITY_SIGNUP,
            Scope.MC_IDENTITY_NATIONALID, Scope.MC_IDENTITY_SIGNUP_PLUS, Scope.KYC_HASHED, Scope.KYC_PLAIN};
        protected static string[] UserInfoScopes = {Scope.PROFILE, Scope.EMAIL, Scope.ADDRESS,
            Scope.PHONE, Scope.OFFLINE_ACCESS};

        protected Controller(MobileConnectWebInterface mobileConnect)
        {
            MobileConnect = mobileConnect;
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

            var response = await MobileConnect.HandleUrlRedirectAsync(
                Request, Request.RequestUri, sdksession, expectedState, expectedNonce, requestOptions, ApiVersion);

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
            return await MobileConnect.RequestUserInfoAsync(Request, discoveryResponse, accessToken, new MobileConnectRequestOptions());
        }

        protected async Task<MobileConnectStatus> RequestPremiumInfo(DiscoveryResponse discoveryResponse, string accessToken = null)
        {
            return await MobileConnect.RequestPremiumInfoAsync(Request, discoveryResponse, accessToken, new MobileConnectRequestOptions());
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

        protected string СreateNewHttpResponseMessage(HttpResponseMessage authResponse, HttpResponseMessage identityUserInfoStatus = null)
        {

            dynamic convertAuthResponseToJson = JsonConvert.DeserializeObject(
                    authResponse.Content.ReadAsStringAsync().Result);

            if (identityUserInfoStatus != null)
            {
                dynamic convertResponseToJson =
                    JsonConvert.DeserializeObject(identityUserInfoStatus.Content.ReadAsStringAsync().Result);
                convertAuthResponseToJson.identity = convertResponseToJson.identity;
            }

            return JsonConvert.SerializeObject(convertAuthResponseToJson);
        }

    }
}