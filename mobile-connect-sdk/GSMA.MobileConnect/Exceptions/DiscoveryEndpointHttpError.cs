using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSMA.MobileConnect.Exceptions
{
    /// <summary>
    /// Exception raised when calls to the discovery endpoint encounter a http exception such as unreachable host
    /// </summary>
    public class DiscoveryEndpointHttpException : Exception
    {
        /// <inheritdoc/>
        public DiscoveryEndpointHttpException() { }
        /// <inheritdoc/>
        public DiscoveryEndpointHttpException(string message) : base(message) { }
        /// <inheritdoc/>
        public DiscoveryEndpointHttpException(string message, Exception inner) : base(message, inner) { }
    }
}
