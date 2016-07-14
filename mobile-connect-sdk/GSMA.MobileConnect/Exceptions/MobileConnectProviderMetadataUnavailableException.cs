using System;

namespace GSMA.MobileConnect.Exceptions
{
    /// <summary>
    /// Exception raised when provider metadata or required properties of provider metadata are unavailable
    /// </summary>
    public class MobileConnectProviderMetadataUnavailableException : Exception
    {
        /// <inheritdoc/>
        public MobileConnectProviderMetadataUnavailableException()
        {
        }

        /// <summary>
        /// Creates an instance of the MobileConnectProviderMetadataUnavailableException class with a message regarding the required property that is unavailable
        /// </summary>
        /// <param name="requiredProperty">Property that was required on provider metadata</param>
        public MobileConnectProviderMetadataUnavailableException(string requiredProperty) : base($"{requiredProperty} not available on provider metadata")
        {
        }

        /// <inheritdoc/>
        public MobileConnectProviderMetadataUnavailableException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
