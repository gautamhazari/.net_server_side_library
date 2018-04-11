using System.Threading.Tasks;
using System.Collections.Concurrent;
using Newtonsoft.Json;
using GSMA.MobileConnect.Discovery;

namespace GSMA.MobileConnect.Cache
{
    /// <summary>
    /// Concrete implementation of <see cref="ICache"/> using a ConcurrentDictionary as the internal caching mechanism
    /// </summary>
    public class ConcurrentCache : BaseCache
    {
        private readonly ConcurrentDictionary<string, string> _internalCache =
            new ConcurrentDictionary<string, string>();

        private static JsonSerializerSettings _serializerSettings =
            new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };

        private long? _maxCacheSize;

        private long CacheSize => new BinaryFormatter.BinaryConverter().Serialize(_internalCache).Length;

        public ConcurrentCache() { }

        public ConcurrentCache(long maxCacheSize)
        {
            _maxCacheSize = maxCacheSize;
        }

        /// <inheritdoc/>
        public override bool IsEmpty
        {
            get { return _internalCache.IsEmpty; }
        }

        /// <inheritdoc/>
        protected override Task InternalAdd<T>(string key, T value)
        {
            var jsonValue = JsonConvert.SerializeObject(value, _serializerSettings);
            var valueSize = new BinaryFormatter.BinaryConverter().Serialize(jsonValue).Length;

            if (_maxCacheSize != null && CacheSize + valueSize >= _maxCacheSize)
            {
                CleanCacheAsync();
            }

            if (_maxCacheSize == null || CacheSize + valueSize < _maxCacheSize)
            {
                _internalCache[key] = jsonValue;
            }

            return _completedTask;
        }

        /// <inheritdoc/>
        protected override Task<T> InternalGet<T>(string key)
        {
            string json;
            if (!_internalCache.TryGetValue(key, out json))
            {
                return Task.FromResult<T>(default(T));
            }

            T cached;
            try
            {
                cached = JsonConvert.DeserializeObject<T>(json);
            }
            catch (JsonSerializationException)
            {
                cached = default(T);
            }
             
            return Task.FromResult(cached);
        }

        /// <inheritdoc/>
        public override Task Clear()
        {
            _internalCache.Clear();
            return _completedTask;
        }

        /// <inheritdoc/>
        public override Task Remove(string mcc, string mnc)
        {
            if (string.IsNullOrEmpty(mcc) || string.IsNullOrEmpty(mnc))
            {
                return _completedTask;
            }

            return Remove(ConcatKey(mcc, mnc));
        }

        /// <inheritdoc/>
        public override Task Remove(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                return _completedTask;
            }

            string value;
            _internalCache.TryRemove(key, out value);
            return _completedTask;
        }

        private async Task CleanCacheAsync()
        {
            foreach (var record in _internalCache)
            {
                if ((await Get<DiscoveryResponse>(record.Key)).HasExpired)
                {
                    await Remove(record.Key).ConfigureAwait(false);
                }
            }
        }
    }
}
