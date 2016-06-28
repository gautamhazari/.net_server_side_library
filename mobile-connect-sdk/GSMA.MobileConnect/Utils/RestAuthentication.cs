using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSMA.MobileConnect.Utils
{
    /// <summary>
    /// Helper class for holding authentication values for calling rest endpoints using <see cref="RestClient"/>
    /// </summary>
    public class RestAuthentication
    {
        /// <summary>
        /// The scheme of authentication e.g. Basic
        /// </summary>
        public string Scheme { get; set; }
        /// <summary>
        /// The authentication parameter such as a token or encoded value
        /// </summary>
        public string Parameter { get; set; }

        /// <summary>
        /// Create a new instance of the RestAuthentication class with the specified scheme and parameter
        /// </summary>
        /// <param name="scheme">The scheme to be used</param>
        /// <param name="parameter">The authentication parameter value</param>
        public RestAuthentication(string scheme, string parameter)
        {
            Scheme = scheme;
            Parameter = parameter;
        }

        /// <summary>
        /// Creates a new instance of the RestAuthentication class for Basic authentication
        /// </summary>
        /// <param name="key">Key/User value</param>
        /// <param name="secret">Secret/Password value</param>
        /// <returns>A new instance of RestAuthentication configured for Basic auth</returns>
        public static RestAuthentication Basic(string key, string secret)
        {
            return new RestAuthentication("Basic", BasicAuthentication.Encode(key, secret));
        }

        /// <summary>
        /// Creates a new instance of the RestAuthentication class for Bearer authentication
        /// </summary>
        /// <param name="token">Bearer token</param>
        /// <returns>A new instance of RestAuthentication configured for Bearer auth</returns>
        public static RestAuthentication Bearer(string token)
        {
            return new RestAuthentication("Bearer", token);
        }
    }
}
