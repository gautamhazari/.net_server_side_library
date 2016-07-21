using GSMA.MobileConnect.Constants;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace GSMA.MobileConnect.Discovery
{
    /// <summary>
    /// Parameters for the <see cref="IDiscoveryService.StartAutomatedOperatorDiscoveryAsync(string, string, string, string, DiscoveryOptions, IEnumerable{Utils.BasicKeyValuePair})"/> method.
    /// Object can be serialized to JSON to be a POST body.
    /// </summary>
    /// <seealso cref="IDiscoveryService"/>
    public class DiscoveryOptions
    {
        /// <summary>
        /// The detected or user input mobile number in E.164 number formatting
        /// </summary>
        public string MSISDN { get; set; }

        /// <summary>
        /// The URL to redirect to after succesful discovery
        /// </summary>
        [JsonProperty("Redirect_URL")]
        public string RedirectUrl { get; set; }

        /// <summary>
        /// Set to true if manual select is requested
        /// </summary>
        [JsonProperty("Manually-Select")]
        public bool IsManuallySelect { get; set; }

        /// <summary>
        /// The identified Mobile Country Code
        /// </summary>
        [JsonProperty("Identified-MCC")]
        public string IdentifiedMCC { get; set; }

        /// <summary>
        /// The identified Mobile Network Code
        /// </summary>
        [JsonProperty("Identified-MNC")]
        public string IdentifiedMNC { get; set; }

        /// <summary>
        /// The selected Mobile Country Code
        /// </summary>
        [JsonProperty("Selected-MCC")]
        public string SelectedMCC { get; set; }

        /// <summary>
        /// The selected Mobile Network Code
        /// </summary>
        [JsonProperty("Selected-MNC")]
        public string SelectedMNC { get; set; }

        /// <summary>
        /// Set to "true" if your application is able to determine that the user is accessing the service via mobile data.
        /// This tells the Discovery Service to discover using the mobile-network.
        /// </summary>
        [JsonProperty("Using-Mobile-Data")]
        public bool IsUsingMobileData { get; set; }

        /// <summary>
        /// The current local IP address of the client application i.e. the actual IP address
        /// currently allocated to the device running the application.
        /// </summary>
        /// <remarks>
        /// This can be used within header injection processes from the MNO to confirm the application is directly using 
        /// a mobile data connection from the consumption device rather than MiFi/WiFi to mobile hotspot.
        /// </remarks>
        [JsonProperty("Local-Client-IP")]
        public string LocalClientIP { get; set; }

        /// <summary>
        /// Allows a server application to indicate the 'public IP address' of the connection from a client application/mobile browser to the server.
        /// </summary>
        /// <remarks>
        /// This is used in place of the public IP address normally detected by the discovery service. Note this will usually differ 
        /// from the Local-Client-IP address, and the public IP address detected by the
        /// application server should not be used for the Local-Client-IP address.
        /// </remarks>
        [JsonIgnore]
        public string ClientIP { get; set; }

        /// <inheritdoc/>
        public DiscoveryOptions()
        {
            this.IsManuallySelect = DefaultOptions.MANUAL_SELECT;
        }
    }
}
