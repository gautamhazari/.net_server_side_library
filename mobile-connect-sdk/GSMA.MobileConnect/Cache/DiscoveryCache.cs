using GSMA.MobileConnect.Discovery;

namespace GSMA.MobileConnect.Cache
{
    public class DiscoveryCache : ConcurrentCache
    {
        public DiscoveryCache() {}

        public DiscoveryCache(long cacheSize)
        {
            _maxCacheSize = cacheSize;
        }

        public DiscoveryResponse Get(string key)
        {
            DiscoveryResponse discoveryResp = null;
            discoveryResp = this.Get<DiscoveryResponse>(key).Result;
            if (discoveryResp == null)
            {
                return null;
            }

            if (discoveryResp.HasExpired)
            {
                this.Remove(key);
                return null;
            }
            
            return discoveryResp;
        }
    }
}
