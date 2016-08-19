using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSMA.MobileConnect.Constants
{
    /// <summary>
    /// Error codes to be returned by MobileConnectStatus
    /// </summary>
    public static class ErrorCodes
    {
        /// <summary>
        /// An argument in the MobileConnect process was invalid or not supplied
        /// </summary>
        public const string InvalidArgument = "invalid_argument";
        /// <summary>
        /// A failure occurred when attempting to make a HTTP request
        /// </summary>
        public const string HttpFailure = "http_failure";
        /// <summary>
        /// The state supplied when requesting a token did not match the state returned by the authentication redirect
        /// </summary>
        public const string InvalidState = "invalid_state";
        /// <summary>
        /// The token response did not pass all validation checks
        /// </summary>
        public const string InvalidToken = "invalid_token";
        /// <summary>
        /// The redirected url did not contain enough information to continue the mobile connect process
        /// </summary>
        public const string InvalidRedirect = "invalid_redirect";
        /// <summary>
        /// The requested functionality is not supported by the current operator
        /// </summary>
        public const string NotSupported = "not_supported";
        /// <summary>
        /// The sdksession supplied was invalid and does not match a cached session
        /// </summary>
        public const string InvalidSdkSession = "invalid_sdksession";
        /// <summary>
        /// The cache is disabled so sdksession caching is not available
        /// </summary>
        public const string CacheDisabled = "cache_disabled";
        /// <summary>
        /// Headless authentication was cancelled via timeout or cancellation token
        /// </summary>
        public const string AuthCancelled = "auth_cancelled";
        /// <summary>
        /// An unknown error has occurred, the attached exception should include diagnosable information
        /// </summary>
        public const string Unknown = "unknown_error";
    }
}
