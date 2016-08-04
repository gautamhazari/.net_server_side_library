using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GSMA.MobileConnect.Discovery;
using GSMA.MobileConnect.Constants;
using GSMA.MobileConnect.Exceptions;

namespace GSMA.MobileConnect.Cache
{
    /// <summary>
    /// Base class for Discovery Caches that implements basic cache control mechanisms and type casting reducing the amount of implementation needed in each derived cache class
    /// </summary>
    public abstract class BaseCache : ICache
    {
        /// <summary>
        /// Convenience field to return when a non-async Task returning method needs to return early
        /// </summary>
        protected static readonly Task _completedTask = Task.FromResult(Type.Missing);

        /// <summary>
        /// Values configured for the minimum and maximum configurable cache expiry times
        /// </summary>
        protected readonly Dictionary<Type, Tuple<TimeSpan?, TimeSpan?>> _cacheExpiryLimits = new Dictionary<Type, Tuple<TimeSpan?, TimeSpan?>>()
        {
            [typeof(ProviderMetadata)] = Tuple.Create<TimeSpan?, TimeSpan?>(TimeSpan.FromSeconds(60), TimeSpan.FromHours(24))
        };

        /// <summary>
        /// Values configured for cache expiry times of types
        /// </summary>
        protected readonly Dictionary<Type, TimeSpan> _cacheExpiryTimes = new Dictionary<Type, TimeSpan>()
        {
            [typeof(ProviderMetadata)] = TimeSpan.FromSeconds(DefaultOptions.PROVIDER_METADATA_TTL_SECONDS),
        };

        /// <inheritdoc/>
        public abstract bool IsEmpty { get; }

        /// <inheritdoc/>
        public async Task Add(string mcc, string mnc, DiscoveryResponse value)
        {
            if (string.IsNullOrEmpty(mcc) || string.IsNullOrEmpty(mnc))
            {
                return;
            }

            await Add(ConcatKey(mcc, mnc), value).ConfigureAwait(false);
        }

        /// <inheritdoc/>
        public async Task Add<T>(string key, T value) where T : ICacheable
        {
            if (string.IsNullOrEmpty(key))
            {
                return;
            }

            value.TimeCachedUtc = DateTime.UtcNow;
            await InternalAdd<T>(key, value).ConfigureAwait(false);
        }

        /// <summary>
        /// Add value to internal cache with given key
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        protected abstract Task InternalAdd<T>(string key, T value) where T : ICacheable;

        /// <inheritdoc/>
        public abstract Task Clear();

        /// <inheritdoc/>
        public async Task<DiscoveryResponse> Get(string mcc, string mnc)
        {
            if (string.IsNullOrEmpty(mcc) || string.IsNullOrEmpty(mnc))
            {
                return null;
            }

            var key = ConcatKey(mcc, mnc);
            var response = await Get<DiscoveryResponse>(key);
            if (response != null && response.HasExpired)
            {
                response = null;
                await Remove(key).ConfigureAwait(false);
            }

            return response;
        }

        /// <inheritdoc/>
        public async Task<T> Get<T>(string key, bool removeIfExpired = true) where T : ICacheable
        {
            if (string.IsNullOrEmpty(key))
            {
                return default(T);
            }

            var response = await InternalGet<T>(key);

            if(response == null)
            {
                return response;
            }

            response.Cached = true;
            response.MarkExpired(CheckIsExpired(response));
            if (removeIfExpired && response != null && response.HasExpired)
            {
                response = default(T);
                await Remove(key).ConfigureAwait(false);
            }

            return response;
        }

        /// <summary>
        /// Checks if a object has been cached past the defined caching time or if internally the object has been marked as expired
        /// </summary>
        /// <param name="value">Object to check for expiry</param>
        /// <returns>True if the object has expired</returns>
        protected bool CheckIsExpired(ICacheable value)
        {
            bool isExpired = false;
            TimeSpan timeToExpire;
            if (_cacheExpiryTimes.TryGetValue(value.GetType(), out timeToExpire))
            {
                isExpired = value.TimeCachedUtc.HasValue && value.TimeCachedUtc.Value.Add(timeToExpire) < DateTime.UtcNow;
            }

            return isExpired || value.HasExpired;
        }

        /// <summary>
        /// Get value from internal cache with given key
        /// </summary>
        /// <typeparam name="T">Type to be returned from cache</typeparam>
        /// <param name="key">Cache key to return</param>
        /// <returns></returns>
        protected abstract Task<T> InternalGet<T>(string key) where T : ICacheable;

        /// <inheritdoc/>
        public abstract Task Remove(string key);

        /// <inheritdoc/>
        public abstract Task Remove(string mcc, string mnc);

        /// <summary>
        /// Concatenates MCC and MNC into a single key
        /// </summary>
        /// <param name="mcc">Mobile Country Code</param>
        /// <param name="mnc">Mobile Network Code</param>
        /// <returns>Concatenated key</returns>
        protected string ConcatKey(string mcc, string mnc)
        {
            return string.Format("{0}_{1}", mcc, mnc);
        }

        /// <inheritdoc/>
        public void SetCacheExpiryTime<T>(TimeSpan cacheTime) where T : ICacheable
        {
            var type = typeof(T);
            Tuple<TimeSpan?, TimeSpan?> limits;
            if(!_cacheExpiryLimits.TryGetValue(type, out limits))
            {
                _cacheExpiryTimes[typeof(T)] = cacheTime;
                return;
            }

            if ((limits.Item1.HasValue && limits.Item1.Value.CompareTo(cacheTime) > 0) || 
                (limits.Item2.HasValue && limits.Item2.Value.CompareTo(cacheTime) < 0))
            {
                throw new MobileConnectCacheExpiryLimitException(type, limits.Item1, limits.Item2);
            }
        }
    }
}
