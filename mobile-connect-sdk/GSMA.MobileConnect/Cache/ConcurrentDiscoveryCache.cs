using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSMA.MobileConnect.Discovery;
using System.Collections.Concurrent;

namespace GSMA.MobileConnect.Cache
{
    /// <summary>
    /// Concrete implementation of <see cref="IDiscoveryCache"/> using a ConcurrentDictionary as the internal caching mechanism
    /// </summary>
    public class ConcurrentDiscoveryCache : IDiscoveryCache
    {
        private static readonly Task _completedTask = Task.FromResult(Type.Missing);
        private readonly ConcurrentDictionary<string, DiscoveryResponse> _internalCache = new ConcurrentDictionary<string, DiscoveryResponse>();

        /// <summary>
        /// Returns true if cache is empty
        /// </summary>
        public bool IsEmpty
        {
            get { return _internalCache.IsEmpty; }
        }

        /// <summary>
        /// Adds the DiscoveryResponse to the cache with the supplied MCC and MNC values
        /// </summary>
        /// <remarks>Value will not be cached if MCC or MNC are null or empty</remarks>
        /// <param name="mcc">Mobile Country Code</param>
        /// <param name="mnc">Mobile Network Code</param>
        /// <param name="value">Value to be cached</param>
        public Task Add(string mcc, string mnc, DiscoveryResponse value)
        {
            if(string.IsNullOrEmpty(mcc) || string.IsNullOrEmpty(mnc))
            {
                return _completedTask;
            }

            return Add(ConcatKey(mcc, mnc), value);
        }

        /// <summary>
        /// Adds the DiscoveryResponse to the cache with the supplied key value
        /// </summary>
        /// <param name="key">Key</param>
        /// <param name="value">Value to be cached</param>
        public Task Add(string key, DiscoveryResponse value)
        {
            if(string.IsNullOrEmpty(key))
            {
                return _completedTask;
            }

            _internalCache[key] = value;
            return _completedTask;
        }

        /// <summary>
        /// Clears the cache
        /// </summary>
        public Task Clear()
        {
            _internalCache.Clear();
            return _completedTask;
        }

        /// <summary>
        /// Retrieves a copy of the cached response if found and has not expired
        /// </summary>
        /// <param name="mcc">Mobile Country Code</param>
        /// <param name="mnc">Mobile Network Code</param>
        /// <returns>A copy of the cached value or null if no cached value or cached value has expired</returns>
        public Task<DiscoveryResponse> Get(string mcc, string mnc)
        {
            if (string.IsNullOrEmpty(mcc) || string.IsNullOrEmpty(mnc))
            {
                return Task.FromResult<DiscoveryResponse>(null);
            }

            return Get(ConcatKey(mcc, mnc));
        }

        /// <summary>
        /// Retrieves a copy of the cached response if found and has not expired
        /// </summary>
        /// <param name="key">Key</param>
        /// <returns>A copy of the cached value or null if no cached value found or cached value has expired</returns>
        public Task<DiscoveryResponse> Get(string key)
        {
            if(string.IsNullOrEmpty(key))
            {
                return Task.FromResult<DiscoveryResponse>(null);
            }

            DiscoveryResponse value;
            _internalCache.TryGetValue(key, out value);

            if (value != null && value.HasExpired)
            {
                value = null;
                Remove(key);
            }

            return Task.FromResult(value != null ? new DiscoveryResponse(value) : null);
        }

        /// <summary>
        /// Removes a value from the cache if it exists
        /// </summary>
        /// <param name="mcc">Mobile Country Code</param>
        /// <param name="mnc">Mobile Network Code</param>
        public Task Remove(string mcc, string mnc)
        {
            if (string.IsNullOrEmpty(mcc) || string.IsNullOrEmpty(mnc))
            {
                return _completedTask;
            }

            return Remove(ConcatKey(mcc, mnc));
        }

        /// <summary>
        /// Removes a value from the cache if it exists
        /// </summary>
        /// <param name="key">Key</param>
        public Task Remove(string key)
        {
            if(string.IsNullOrEmpty(key))
            {
                return _completedTask;
            }

            DiscoveryResponse value;
            _internalCache.TryRemove(key, out value);
            return _completedTask;
        }

        private string ConcatKey(string mcc, string mnc)
        {
            return string.Format("{0}_{1}", mcc, mnc);
        }
    }
}
