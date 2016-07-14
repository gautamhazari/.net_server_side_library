namespace GSMA.MobileConnect.Discovery
{
    /// <summary>
    /// Interface for specifying required options in the discovery process
    /// </summary>
    /// <seealso cref="MobileConnectConfig"/>
    public interface IPreferences
    {
        /// <summary>
        /// The application client Id
        /// </summary>
        string ClientId { get; }

        /// <summary>
        /// The application client secret
        /// </summary>
        string ClientSecret { get; }

        /// <summary>
        /// The URL of the discovery service endpoint
        /// </summary>
        string DiscoveryUrl { get; }
    }
}
