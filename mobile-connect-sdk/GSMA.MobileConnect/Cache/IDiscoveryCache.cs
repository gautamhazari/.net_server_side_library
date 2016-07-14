using GSMA.MobileConnect.Discovery;
using System;
using System.Threading.Tasks;

namespace GSMA.MobileConnect.Cache
{
    /// <summary>
    /// Interface for the cache used during the discovery process, cache is mainly used to cache DiscoveryResponse objects but can also be used to cache any data used during the Discovery process
    /// </summary>
    public interface IDiscoveryCache
    {
        /// <summary>
        /// Returns true if cache is empty
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
        /// <typeparam name="T">Type of value to be added to the cache</typeparam>
        Task Add<T>(string key, T value) where T : ICacheable;

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
        /// <param name="removeIfExpired">
        /// If value should be removed if it is retrieved and found to be expired, should be set to false if a fallback value is required for if the next call for the required resource fails.
        /// </param>
        /// <typeparam name="T">Type of value to be returned by cache</typeparam>
        /// <returns>The cached value if preset, null otherwise</returns>
        Task<T> Get<T>(string key, bool removeIfExpired = true) where T : ICacheable;

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

        /// <summary>
        /// Set length of time before cached values of the specified type are marked as expired.
        /// </summary>
        /// <typeparam name="T">Type of cached value</typeparam>
        /// <param name="cacheTime">Length of time before expiry</param>
        void SetCacheExpiryTime<T>(TimeSpan cacheTime) where T : ICacheable;
    }
}
