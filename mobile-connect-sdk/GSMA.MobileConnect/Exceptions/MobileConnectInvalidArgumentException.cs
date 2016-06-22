using GSMA.MobileConnect.Authentication;
using GSMA.MobileConnect.Discovery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSMA.MobileConnect.Exceptions
{
    /// <summary>
    /// Exception raised when invalid arguments are passed to <see cref="IAuthentication"/> or <see cref="IDiscovery"/> methods
    /// </summary>
    public class MobileConnectInvalidArgumentException : Exception
    {
        /// <summary>
        /// The invalid argument
        /// </summary>
        public string Argument { get; set; }

        /// <inheritdoc/>
        public MobileConnectInvalidArgumentException() { }
        /// <inheritdoc/>
        public MobileConnectInvalidArgumentException(string message) : base(message) { }
        /// <inheritdoc/>
        public MobileConnectInvalidArgumentException(string message, Exception inner) : base(message, inner) { }
        /// <summary>
        /// Creates a new exception with a composite message describing the invalid argument and calling method
        /// </summary>
        /// <param name="argument">Argument that is invalid</param>
        /// <param name="caller">Method with invalid argument</param>
        public MobileConnectInvalidArgumentException(string argument, string caller) : base(string.Format("Argument {0} is invalid at method {1}.", argument, caller))
        {
            this.Argument = argument;
        }
    }
}
