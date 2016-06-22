using GSMA.MobileConnect.Cache;
using GSMA.MobileConnect.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSMA.MobileConnect.Discovery
{
    /// <summary>
    /// Interface for Mobile Connect Discovery requests
    /// </summary>
    /// <seealso cref="Discovery"/>
    /// <seealso cref="DiscoveryOptions"/>
    /// <seealso cref="DiscoveryResponse"/>
    public interface IDiscovery
    {
        /// <summary>
        /// Discovery response cache
        /// </summary>
        IDiscoveryCache Cache { get; }

        /// <summary>
        /// Synchronous wrapper for <see cref="IDiscovery.StartAutomatedOperatorDiscoveryAsync(string, string, string, string, DiscoveryOptions, IEnumerable{BasicKeyValuePair})"/>
        /// </summary>
        /// <param name="clientId">The registered application clientId (Required)</param>
        /// <param name="clientSecret">the registered application client secret (Required)</param>
        /// <param name="discoveryUrl">The URL of the discovery endpoint (Required)</param>
        /// <param name="redirectUrl">The URL of the operator selection functionality redirects to. (Required)</param>
        /// <param name="options">Optional parameters</param>
        /// <param name="currentCookies">List of the current cookies sent by the browser if applicable</param>
        DiscoveryResponse StartAutomatedOperatorDiscovery(string clientId, string clientSecret, string discoveryUrl, string redirectUrl, DiscoveryOptions options, IEnumerable<BasicKeyValuePair> currentCookies);

        /// <summary>
        /// Synchronous wrapper for <see cref="IDiscovery.StartAutomatedOperatorDiscoveryAsync(IPreferences, string, DiscoveryOptions, IEnumerable{BasicKeyValuePair})"/>
        /// </summary>
        /// <param name="preferences">Instance of IPreferences that provides clientId, clientSecret and discoveryUrl (Required)</param>
        /// <param name="redirectUrl">The URL of the operator selection functionality redirects to. (Required)</param>
        /// <param name="options">Optional parameters</param>
        /// <param name="currentCookies">List of the current cookies sent by the browser if applicable</param>
        DiscoveryResponse StartAutomatedOperatorDiscovery(IPreferences preferences, string redirectUrl, DiscoveryOptions options, IEnumerable<BasicKeyValuePair> currentCookies);

        /// <summary>
        /// Allows an application to conduct discovery based on the predetermined operator/network identified operator semantics.
        /// If the operator cannot be identified the function will return the 'operator selection' form of the response.
        /// The application can then determine how to proceed i.e. open the operator selection page separately or otherwise handle this.
        /// </summary>
        /// <remarks>
        /// The operator selection functionality will display a series of pages that enables the user to identify an operator, 
        /// the results are passed back to the current application as parameters on the redirect URL.
        /// <para>Valid discovery responses can be cached and this method can return cached data</para>
        /// </remarks>
        /// <param name="clientId">The registered application clientId (Required)</param>
        /// <param name="clientSecret">the registered application client secret (Required)</param>
        /// <param name="discoveryUrl">The URL of the discovery endpoint (Required)</param>
        /// <param name="redirectUrl">The URL of the operator selection functionality redirects to. (Required)</param>
        /// <param name="options">Optional parameters</param>
        /// <param name="currentCookies">List of the current cookies sent by the browser if applicable</param>
        Task<DiscoveryResponse> StartAutomatedOperatorDiscoveryAsync(string clientId, string clientSecret, string discoveryUrl, string redirectUrl, DiscoveryOptions options, IEnumerable<BasicKeyValuePair> currentCookies);

        /// <summary>
        /// Convenience version of <see cref="IDiscovery.StartAutomatedOperatorDiscoveryAsync(string, string, string, string, DiscoveryOptions, IEnumerable{BasicKeyValuePair})"/>
        /// where the clientId, clientSecret and discoveryUrl are provided by the IPreferences implementation
        /// </summary>
        /// <param name="preferences">Instance of IPreferences that provides clientId, clientSecret and discoveryUrl (Required)</param>
        /// <param name="redirectUrl">The URL of the operator selection functionality redirects to. (Required)</param>
        /// <param name="options">Optional parameters</param>
        /// <param name="currentCookies">List of the current cookies sent by the browser if applicable</param>
        Task<DiscoveryResponse> StartAutomatedOperatorDiscoveryAsync(IPreferences preferences, string redirectUrl, DiscoveryOptions options, IEnumerable<BasicKeyValuePair> currentCookies);

        /// <summary>
        /// Synchronous wrapper for <see cref="IDiscovery.GetOperatorSelectionURLAsync(string, string, string, string)"/>
        /// </summary>
        /// <param name="clientId">The registered application client id. (Required)</param>
        /// <param name="clientSecret">The registered application client secret. (Required)</param>
        /// <param name="discoveryUrl">The URL of the discovery end point. (Required)</param>
        /// <param name="redirectUrl">The URL the operator selection functionality redirects to. (Required)</param>
        DiscoveryResponse GetOperatorSelectionURL(string clientId, string clientSecret, string discoveryUrl, string redirectUrl);

        /// <summary>
        /// Synchronous wrapper for <see cref="IDiscovery.GetOperatorSelectionURLAsync(IPreferences, string)"/>
        /// </summary>
        /// <param name="preferences">Instance of IPreferences that provides clientId, clientSecret and discoveryUrl (Required)</param>
        /// <param name="redirectUrl">The URL the operator selection functionality redirects to. (Required)</param>
        DiscoveryResponse GetOperatorSelectionURL(IPreferences preferences, string redirectUrl);

        /// <summary>
        /// Allows an application to get the URL for the operator selection UI of the discovery service. This will not reference the discovery result cache.
        /// The returned URL will contain a session id created by the discovery server. The URL must be used as-is.
        /// </summary>
        /// <param name="clientId">The registered application client id. (Required)</param>
        /// <param name="clientSecret">The registered application client secret. (Required)</param>
        /// <param name="discoveryUrl">The URL of the discovery end point. (Required)</param>
        /// <param name="redirectUrl">The URL the operator selection functionality redirects to. (Required)</param>
        Task<DiscoveryResponse> GetOperatorSelectionURLAsync(string clientId, string clientSecret, string discoveryUrl, string redirectUrl);

        /// <summary>
        /// Convenience wrapper for <see cref="IDiscovery.GetOperatorSelectionURLAsync(string, string, string, string)"/>
        /// where the clientId, clientSecret and discoveryUrl are provided by the IPreferences implementation
        /// </summary>
        /// <param name="preferences">Instance of IPreferences that provides clientId, clientSecret and discoveryUrl (Required)</param>
        /// <param name="redirectUrl">The URL the operator selection functionality redirects to. (Required)</param>
        Task<DiscoveryResponse> GetOperatorSelectionURLAsync(IPreferences preferences, string redirectUrl);

        /// <summary>
        /// Allows an application to obtain parameters which have been passed within a discovery redirect URL
        /// </summary>
        /// <remarks>
        /// <para>The function will parse the redirect URL and parse out the components expected for discovery i.e.</para>
        /// <para>- selectedMCC</para>
        /// <para>- selectedMNC</para>
        /// <para>- encryptedMSISDN</para>
        /// </remarks>
        /// <param name="redirectedUrl">The URL the operator selection functionality redirected to (Required)</param>
        ParsedDiscoveryRedirect ParseDiscoveryRedirect(Uri redirectedUrl);

        /// <summary>
        /// Synchronous wrapper for <see cref="IDiscovery.CompleteSelectedOperatorDiscoveryAsync(string, string, string, string, string, string)"/>
        /// </summary>
        /// <param name="clientId">The registered application clientId (Required)</param>
        /// <param name="clientSecret">the registered application client secret (Required)</param>
        /// <param name="discoveryUrl">The URL of the discovery endpoint (Required)</param>
        /// <param name="redirectUrl">The registered application redirect url (Required)</param>
        /// <param name="selectedMCC">The Mobile Country Code of the selected operator. (Required)</param>
        /// <param name="selectedMNC">The Mobile Network Code of the selected operator. (Required)</param>
        DiscoveryResponse CompleteSelectedOperatorDiscovery(string clientId, string clientSecret, string discoveryUrl, string redirectUrl, string selectedMCC, string selectedMNC);

        /// <summary>
        /// Synchronous wrapper for <see cref="IDiscovery.CompleteSelectedOperatorDiscoveryAsync(IPreferences, string, string, string)"/>
        /// </summary>
        /// <param name="preferences">Instance of IPreferences that provides clientId, clientSecret and discoveryUrl (Required)</param>
        /// <param name="redirectUrl">The registered application redirect url (Required)</param>
        /// <param name="selectedMCC">The Mobile Country Code of the selected operator. (Required)</param>
        /// <param name="selectedMNC">The Mobile Network Code of the selected operator. (Required)</param>
        DiscoveryResponse CompleteSelectedOperatorDiscovery(IPreferences preferences, string redirectUrl, string selectedMCC, string selectedMNC);

        /// <summary>
        /// Allows an application to use the selected operator MCC and MNC to obtain the discovery response.
        /// In the case there is already a discovery result in the cache and the Selected-MCC/Selected-MNC in the 
        /// new request are the same as relates to the discovery result for the cached result, the cached result will 
        /// be returned.
        /// </summary>
        /// <remarks>
        /// If the operator cannot be identified by the discovery service the function will return the 'operator selection' 
        /// form of the response.
        /// </remarks>
        /// <param name="clientId">The registered application clientId (Required)</param>
        /// <param name="clientSecret">the registered application client secret (Required)</param>
        /// <param name="discoveryUrl">The URL of the discovery endpoint (Required)</param>
        /// <param name="redirectUrl">The registered application redirect url (Required)</param>
        /// <param name="selectedMCC">The Mobile Country Code of the selected operator. (Required)</param>
        /// <param name="selectedMNC">The Mobile Network Code of the selected operator. (Required)</param>
        Task<DiscoveryResponse> CompleteSelectedOperatorDiscoveryAsync(string clientId, string clientSecret, string discoveryUrl, string redirectUrl, string selectedMCC, string selectedMNC);

        /// <summary>
        /// Convenience version of <see cref="IDiscovery.CompleteSelectedOperatorDiscoveryAsync(string, string, string, string, string, string)"/>
        /// where the clientId, clientSecret and discoveryUrl are provided by the IPreferences implementation
        /// </summary>
        /// <param name="preferences">Instance of IPreferences that provides clientId, clientSecret and discoveryUrl (Required)</param>
        /// <param name="redirectUrl">The registered application redirect url (Required)</param>
        /// <param name="selectedMCC">The Mobile Country Code of the selected operator. (Required)</param>
        /// <param name="selectedMNC">The Mobile Network Code of the selected operator. (Required)</param>
        Task<DiscoveryResponse> CompleteSelectedOperatorDiscoveryAsync(IPreferences preferences, string redirectUrl, string selectedMCC, string selectedMNC);

        /// <summary>
        /// Helper function to extract operator selection URL from the discovery reponse
        /// </summary>
        /// <param name="result">The discovery response to parse (Required)</param>
        /// <returns>The operator selection URL or null if not found</returns>
        string ExtractOperatorSelectionURL(DiscoveryResponse result);

        /// <summary>
        /// Helper function which retrieves a discovery response (if available) from the discovery cache which corresponds with the operator details
        /// </summary>
        /// <param name="mcc">The Mobile Country Code (Required)</param>
        /// <param name="mnc">The Mobile Network Code (Required)</param>
        /// <returns>A cached entry if found, otherwise null</returns>
        Task<DiscoveryResponse> GetCachedDiscoveryResultAsync(string mcc, string mnc);

        /// <summary>
        /// Helper function which clears any result from the discovery cache which corresponds with the provided parameters
        /// </summary>
        /// <param name="mcc">The mobile country code of the cached object (optional)</param>
        /// <param name="mnc">The mobile network code of the cached object (optional)</param>
        /// <remarks>If either mcc or mnc are null or empty the cache will be cleared</remarks>
        Task ClearDiscoveryCacheAsync(string mcc = null, string mnc = null);
    }
}
