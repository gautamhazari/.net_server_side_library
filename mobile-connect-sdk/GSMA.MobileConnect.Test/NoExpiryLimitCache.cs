using GSMA.MobileConnect.Cache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSMA.MobileConnect.Test
{
    public class NoExpiryLimitCache : ConcurrentDiscoveryCache
    {
        public NoExpiryLimitCache()
        {
            // Remove cache expiry limits so cache expiry times of any amount can be set for testing purposes
            this._cacheExpiryLimits.Clear();
        }

        public void SetCacheExpiryLimit<T>(TimeSpan? lower, TimeSpan? upper)
        {
            _cacheExpiryLimits[typeof(T)] = Tuple.Create(lower, upper);
        }
    }
}
