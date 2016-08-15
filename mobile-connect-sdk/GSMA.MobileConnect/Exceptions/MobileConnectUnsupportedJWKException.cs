using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSMA.MobileConnect.Exceptions
{
    /// <summary>
    /// Exception raised when a token contains an unsupported algorithm in the token header
    /// </summary>
    public class MobileConnectUnsupportedJWKException : Exception
    {
        /// <inheritdoc/>
        public MobileConnectUnsupportedJWKException() { }

        /// <inheritdoc/>
        public MobileConnectUnsupportedJWKException(string message) : base(message) { }

        /// <inheritdoc/>
        public MobileConnectUnsupportedJWKException(string message, Exception innerException) : base(message, innerException) { }
    }
}
