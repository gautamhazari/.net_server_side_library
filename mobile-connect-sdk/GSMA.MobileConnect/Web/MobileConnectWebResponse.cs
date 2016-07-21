using GSMA.MobileConnect.Authentication;

namespace GSMA.MobileConnect.Web
{
    /// <summary>
    /// Lightweight object to be serialized and returned through a web api
    /// </summary>
    public class MobileConnectWebResponse
    {
        /// <summary>
        /// "success" or "failure", if "success" the next step should be attempted
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// Action to take for next step
        /// </summary>
        public string Action { get; set; }
        /// <summary>
        /// Application short name returned by discovery service, this identifies the application requesting authorization
        /// </summary>
        public string ApplicationShortName { get; set; }
        /// <summary>
        /// If next step requires visiting a url it will be returned with this property
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// If caching is enabled this will be required in the steps following discovery
        /// </summary>
        public string SdkSession { get; set; }
        /// <summary>
        /// State value used during Authorization, should be passed when handling the next redirect
        /// </summary>
        public string State { get; set; }
        /// <summary>
        /// Nonce value used during Authorization, should be passed when handling the next redirect
        /// </summary>
        public string Nonce { get; set; }
        /// <summary>
        /// Encrypted MSISDN value returned from a successful Discovery call
        /// </summary>
        public string SubscriberId { get; set; }
        /// <summary>
        /// Token data returned from a successful RequestToken call
        /// </summary>
        public RequestTokenResponseData Token { get; set; }
        /// <summary>
        /// Identity data returned from successful RequestUserInfo or RequestIdentityInfo call
        /// </summary>
        public Newtonsoft.Json.Linq.JRaw Identity { get; set; }

        /// <summary>
        /// Error code if available
        /// </summary>
        public string Error { get; set; }
        /// <summary>
        /// Error user friendly description if available
        /// </summary>
        public string Description { get; set; }
    }
}
