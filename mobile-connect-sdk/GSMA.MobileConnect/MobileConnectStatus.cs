using GSMA.MobileConnect.Authentication;
using GSMA.MobileConnect.Constants;
using GSMA.MobileConnect.Discovery;
using GSMA.MobileConnect.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSMA.MobileConnect
{
    /// <summary>
    /// Object to hold the details of a response returned from <see cref="MobileConnectInterface"/> and <see cref="MobileConnectWebInterface"/>
    /// all information required to continue the process is included
    /// </summary>
    public class MobileConnectStatus
    {
        private const string INTERNAL_ERROR_CODE = "internal error";

        /// <summary>
        /// Type of response, indicates the step in the process that should be triggered next
        /// </summary>
        public MobileConnectResponseType ResponseType { get; set; }

        /// <summary>
        /// Error code if included
        /// </summary>
        public string ErrorCode { get; set; }

        /// <summary>
        /// User friendly error description if included
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Url to navigate to in the next step if required
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// State value used for Authorization
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// Nonce value used for Authorization
        /// </summary>
        public string Nonce { get; set; }

        /// <summary>
        /// Content of the Set-Cookie header returned in the response, should be used to proxy cookies back to the user if required
        /// </summary>
        public IEnumerable<string> SetCookie { get; set; }

        /// <summary>
        /// SDK session id used to link sessions to discovery responses when <see cref="MobileConnectConfig.CacheResponsesWithSessionId"/> is set to true
        /// </summary>
        public string SDKSession { get; set; }

        /// <summary>
        /// Complete discovery response if included
        /// </summary>
        public DiscoveryResponse DiscoveryResponse { get; set; }

        /// <summary>
        /// Complete discovery response if included
        /// </summary>
        public RequestTokenResponse TokenResponse { get; set; }

        /// <summary>
        /// Exception encountered during request if included
        /// </summary>
        public Exception Exception { get; set; }

        /// <summary>
        /// Creates a Status with ResponseType error and error related properties filled.
        /// Indicates that the MobileConnect process has been aborted due to an issue encountered.
        /// </summary>
        /// <param name="error">Error code</param>
        /// <param name="message">User friendly error message</param>
        /// <param name="ex">Exception encountered (allows null)</param>
        /// <returns>MobileConnectStatus with ResponseType Error</returns>
        public static MobileConnectStatus Error(string error, string message, Exception ex)
        {
            return new MobileConnectStatus
            {
                ErrorCode = error ?? INTERNAL_ERROR_CODE,
                ErrorMessage = message,
                Exception = ex,
                ResponseType = MobileConnectResponseType.Error
            };
        }

        /// <summary>
        /// Creates a Status with ResponseType error and error related properties filled.
        /// Indicates that the MobileConnect process has been aborted due to an issue encountered.
        /// </summary>
        /// <param name="error">Error code</param>
        /// <param name="message">User friendly error message</param>
        /// <param name="ex">Exception encountered (allows null)</param>
        /// <param name="response">Discovery response if returned from <see cref="IDiscovery"/></param>
        /// <returns>MobileConnectStatus with ResponseType Error</returns>
        public static MobileConnectStatus Error(string error, string message, Exception ex, DiscoveryResponse response)
        {
            var status = Error(error, message, ex);
            status.DiscoveryResponse = response;
            return status;
        }

        /// <summary>
        /// Creates a Status with ResponseType error and error related properties filled.
        /// Indicates that the MobileConnect process has been aborted due to an issue encountered.
        /// </summary>
        /// <param name="error">Error code</param>
        /// <param name="message">User friendly error message</param>
        /// <param name="ex">Exception encountered (allows null)</param>
        /// <param name="response">RequestTokenResponse if returned from <see cref="IAuthentication"/></param>
        /// <returns>MobileConnectStatus with ResponseType Error</returns>
        public static MobileConnectStatus Error(string error, string message, Exception ex, RequestTokenResponse response)
        {
            var status = Error(error, message, ex);
            status.TokenResponse = response;
            return status;
        }

        /// <summary>
        /// Creates a Status with ResponseType OperatorSelection and url for next process step.
        /// Indicates that the next step should be navigating to the operator selection URL.
        /// </summary>
        /// <param name="url">Operator selection URL returned from <see cref="IDiscovery"/></param>
        /// <returns>MobileConnectStatus with ResponseType OperatorSelection</returns>
        public static MobileConnectStatus OperatorSelection(string url)
        {
            return new MobileConnectStatus
            {
                Url = url,
                ResponseType = MobileConnectResponseType.OperatorSelection
            };
        }

        /// <summary>
        /// Creates a Status with ResponseType StartAuthorization and the complete <see cref="DiscoveryResponse"/>.
        /// Indicates that the next step should be starting authorization.
        /// </summary>
        /// <param name="response">DiscoveryResponse returned from <see cref="IDiscovery"/></param>
        /// <returns>MobileConnectStatus with ResponseType StartAuthorization</returns>
        public static MobileConnectStatus StartAuthorization(DiscoveryResponse response)
        {
            IEnumerable<string> setCookie = response.Headers?.FirstOrDefault(x => x.Key == Headers.SET_COOKIE)?.Value?.Split(',');

            return new MobileConnectStatus
            {
                DiscoveryResponse = response,
                ResponseType = MobileConnectResponseType.StartAuthorization,
                SetCookie = setCookie
            };
        }

        /// <summary>
        /// Creates a Status with ResponseType StartDiscovery.
        /// Indicates that some required data was missing and the discovery process needs to be restarted.
        /// </summary>
        /// <returns>MobileConnectStatus with ResponseType StartDiscovery</returns>
        public static MobileConnectStatus StartDiscovery()
        {
            return new MobileConnectStatus
            {
                ResponseType = MobileConnectResponseType.StartDiscovery
            };
        }

        /// <summary>
        /// Creates a Status with ResponseType Authorization and url for next process step.
        /// Indicates that the next step should be navigating to the Authorization URL.
        /// </summary>
        /// <param name="url">Url returned from <see cref="IAuthentication"/></param>
        /// <param name="state">The unique state string generated or passed in for the authorization url</param>
        /// <param name="nonce">The unique nonce string generated or passed in for the authorization url</param>
        /// <returns>MobileConnectStatus with ResponseType Authorization</returns>
        public static MobileConnectStatus Authorization(string url, string state, string nonce)
        {
            return new MobileConnectStatus
            {
                ResponseType = MobileConnectResponseType.Authorization,
                Url = url,
                State = state,
                Nonce = nonce
            };
        }

        /// <summary>
        /// Creates a Status with ResponseType Complete and the complete <see cref="RequestTokenResponse"/>.
        /// Indicates that the MobileConnect process is complete and the user is authenticated.
        /// </summary>
        /// <param name="response">RequestTokenResponse returned from <see cref="IAuthentication"/></param>
        /// <returns>MobileConnectStatus with ResponseType Complete</returns>
        public static MobileConnectStatus Complete(RequestTokenResponse response)
        {
            return new MobileConnectStatus
            {
                ResponseType = MobileConnectResponseType.Complete,
                TokenResponse = response
            };
        }

        private MobileConnectStatus() { }
    }

    /// <summary>
    /// Enum of possible response types for <see cref="MobileConnectStatus"/>
    /// </summary>
    /// <seealso cref="MobileConnectStatus"/>
    public enum MobileConnectResponseType
    {
        /// <summary>
        /// ResponseType indicating Error was encountered
        /// </summary>
        Error,
        /// <summary>
        /// ResponseType indicating the next step should be OperatorSelection
        /// </summary>
        OperatorSelection,
        /// <summary>
        /// ResponseType indicating the next step should be to restart Discovery
        /// </summary>
        StartDiscovery,
        /// <summary>
        /// ResponseType indicating the next step should be StartAuthorization
        /// </summary>
        StartAuthorization,
        /// <summary>
        /// ResponseType indicating the next step should be Authorization
        /// </summary>
        Authorization,
        /// <summary>
        /// ResponseType indicating completion of the MobileConnectProcess
        /// </summary>
        Complete
    }
}
