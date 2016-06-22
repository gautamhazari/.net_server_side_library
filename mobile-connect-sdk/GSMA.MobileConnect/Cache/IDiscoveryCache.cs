using GSMA.MobileConnect.Discovery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSMA.MobileConnect.Cache
{
    /// <summary>
    /// Interface for the discovery response cache
    /// </summary>
    public interface IDiscoveryCache
    {
        /// <summary>
        /// Is the cache empty?
        /// </summary>
        bool IsEmpty { get; }

        /// <summary>
        /// Add a value to the cache with the specified mcc and mnc
        /// </summary>
        /// <param name="mcc">Mobile Country Code (Required)</param>
        /// <param name="mnc">Mobile Network Code (Required)</param>
        /// <param name="value">Value (Required)</param>
        Task Add(string mcc, string mnc, DiscoveryResponse value);

        /// <summary>
        /// Add a value with the specified key
        /// </summary>
        /// <param name="key">Key (Required)</param>
        /// <param name="value">Value (Required)</param>
        Task Add(string key, DiscoveryResponse value);

        /// <summary>
        /// Return a cached value based on the mcc and mnc
        /// </summary>
        /// <param name="mcc">Mobile Country Code (Required)</param>
        /// <param name="mnc">Mobile Network Code (Required)</param>
        /// <returns>The cached value if present, null otherwise</returns>
        Task<DiscoveryResponse> Get(string mcc, string mnc);

        /// <summary>
        /// Return a cached value based on the key
        /// </summary>
        /// <param name="key">Key (Required)</param>
        /// <returns>The cached value if preset, null otherwise</returns>
        Task<DiscoveryResponse> Get(string key);

        /// <summary>
        /// Remove an entry from the cache that matches the mcc and mnc
        /// </summary>
        /// <param name="mcc">Mobile Country Code (Required)</param>
        /// <param name="mnc">Mobile Network Code (Required)</param>
        Task Remove(string mcc, string mnc);

        /// <summary>
        /// Remove an entry from the cache that matches the key
        /// </summary>
        /// <param name="key">Key (Required)</param>
        Task Remove(string key);

        /// <summary>
        /// Remove all key value pairs from the cache
        /// </summary>
        Task Clear();
    }
}
