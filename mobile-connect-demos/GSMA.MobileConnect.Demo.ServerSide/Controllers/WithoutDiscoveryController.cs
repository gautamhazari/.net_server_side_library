using GSMA.MobileConnect.Cache;
using System.Threading.Tasks;
using System.Web.Http;
using GSMA.MobileConnect.Constants;
using System.Net.Http;
using GSMA.MobileConnect.Discovery;
using Scope = GSMA.MobileConnect.Constants.Scope;

namespace GSMA.MobileConnect.ServerSide.Web.Controllers
{
    [RoutePrefix("server_side_api")]
    public class WithoutDiscoveryController : Controller
    {
        public WithoutDiscoveryController(MobileConnectWebInterface mobileConnect)
        {
            MobileConnect = mobileConnect;
        }

        public WithoutDiscoveryController()
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
        [Route("start_discovery_manually")]
        public async Task<IHttpActionResult> StartAuthenticationWithoutDiscovery(string msisdn = "")
        {
            MobileConnect = new MobileConnectWebInterface(MobileConnectConfig, SessionCache, DiscoveryCache);
            GetParameters();

            DiscoveryResponse discoveryResponse = null;
            MobileConnectStatus status;

           
            discoveryResponse = await MobileConnect.GenerateDiscoveryManually(OperatorParams.clientID, OperatorParams.clientSecret, OperatorParams.clientName, OperatorParams.operatorUrls);

            string url = CallStartAuth(discoveryResponse, msisdn, Request);

            return GetHttpMsgWithRedirect(url);
        }
        
        private string CallStartAuth(
            DiscoveryResponse discoveryResponse,
            string msisdn,
            HttpRequestMessage request)
        {
            if (OperatorParams.scope.Contains(Scope.AUTHZ))
            {
                return StartAuthorize(discoveryResponse, msisdn, request);
            }
            return StartAuthentication(discoveryResponse, msisdn, request);
        }

        private string StartAuthentication(
            DiscoveryResponse discoveryResponse,
            string msisdn,
            HttpRequestMessage request)
        {
            return StartAuth(discoveryResponse, msisdn, request);
        }

        private string StartAuthorize(
            DiscoveryResponse discoveryResponse,
            string msisdn,
            HttpRequestMessage request)
        {
            return StartAuth(discoveryResponse, msisdn, request);
        }

        private string StartAuth(
            DiscoveryResponse discoveryResponse,
            string msisdn, 
            HttpRequestMessage request)
        {
            string scope = OperatorParams.scope;

            string loginHint = null;
            if (!string.IsNullOrEmpty(msisdn))
            {
                loginHint = $"{Parameters.MSISDN}:{msisdn}";
            }

            var options = new MobileConnectRequestOptions
            {
                Scope = scope,
                Context = ApiVersion.Equals(Utils.Constants.VERSION2_0) || ApiVersion.Equals(Utils.Constants.VERSION2_3) || ApiVersion.Equals(Utils.Constants.VERSION3_0) ? Utils.Constants.ContextBindingMsg : null,
                BindingMessage = ApiVersion.Equals(Utils.Constants.VERSION2_0) || ApiVersion.Equals(Utils.Constants.VERSION2_3) || ApiVersion.Equals(Utils.Constants.VERSION3_0) ? Utils.Constants.ContextBindingMsg : null,
                ClientName = OperatorParams.clientName,
                AcrValues = OperatorParams.acrValues,
                LoginHint = loginHint
            };

            var status =
                MobileConnect.StartAuthentication(request, discoveryResponse, null, null, null, options, ApiVersion);

            if (HandleErrorMsg(status))
            {
                return null;
            }

            SetSessionCache(status, discoveryResponse, status.Nonce);
            
            return status.Url;
        }

        private void GetParameters()
        {
            OperatorParams = ReadAndParseFiles.ReadFile(Utils.Constants.WithoutDiscoveryFilePath);
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

        private async void SetSessionCache(MobileConnectStatus status, DiscoveryResponse discoveryResponse, string nonce)
        {
            await SessionCache.Add(status.State, new SessionData(discoveryResponse, nonce));
        }
    }
}