using GSMA.MobileConnect.Discovery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSMA.MobileConnect
{
    /// <summary>
    /// Configuration properties for the MobileConnectInterface, reused across all requests for a single <see cref="MobileConnectInterface"/> or <see cref="MobileConnectWebInterface"/>
    /// </summary>
    /// <seealso cref="IPreferences"/>
    public class MobileConnectConfig : IPreferences
    {
        #region Required

        /// <inheritdoc/>
        public string ClientId { get; set; }

        /// <inheritdoc/>
        public string ClientSecret { get; set; }

        /// <inheritdoc/>
        public string DiscoveryUrl { get; set; }

        /// <summary>
        /// The redirect url specified for the mobileconnect application
        /// </summary>
        public string RedirectUrl { get; set; }

        #endregion

        #region Authorization

        /// <inheritdoc cref="Authentication.AuthenticationOptions.AcrValues"/>
        public string AuthorizationAcrValues { get; set; }

        /// <inheritdoc cref="Authentication.AuthenticationOptions.MaxAge"/>
        public int AuthorizationMaxAge { get; set; }

        #endregion

        #region Web

        /// <summary>
        /// When set to true <see cref="MobileConnectWebInterface"/> will use the configured discovery cache to cache discovery responses against
        /// a session id. This allows the session id to be passed to following calls in the mobile connect process instead of requiring the discovery response to be passed.
        /// (DEFAULTS to true)
        /// </summary>
        /// <remarks>
        /// For this method to be reliable in multi server deployments a cross server cache implementation must be configured
        /// </remarks>
        public bool CacheResponsesWithSessionId { get; set; } = true;

        #endregion
    }
}
