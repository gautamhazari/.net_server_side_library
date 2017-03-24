using System;
namespace GSMA.MobileConnect.Exceptions
{
    /// <summary>
    /// Exception raised when a JWK contains incomplete or invalid information so is unable to complete JWT validation
    /// </summary>
    public class MobileConnectInvalidJWKException : Exception
    {
        /// <inheritdoc/>
        public MobileConnectInvalidJWKException() { }

        /// <inheritdoc/>
        public MobileConnectInvalidJWKException(string message) : base(message) { }

        /// <inheritdoc/>
        public MobileConnectInvalidJWKException(string message, Exception innerException) : base(message, innerException) { }
    }
}
