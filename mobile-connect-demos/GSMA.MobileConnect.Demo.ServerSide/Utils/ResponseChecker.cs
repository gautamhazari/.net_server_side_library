using System.Threading.Tasks;
using GSMA.MobileConnect.Cache;
using GSMA.MobileConnect.ServerSide.Web.Objects;

namespace GSMA.MobileConnect.ServerSide.Web.Utils
{
    public class ResponseChecker
    {
        ConcurrentCache cache = new ConcurrentCache();

        public async Task SaveData(string state, CachedParameters cachedParameters)
        {
            await cache.Add(state, cachedParameters);
        }

        public async Task<CachedParameters> getData(string state)
        {
            var cachedParameters = cache.Get<CachedParameters>(state);
            await cache.Remove<CachedParameters>(state);
            return await cachedParameters;
        }

        public async Task<CachedParameters> RemoveData(string state)
        {
            return await cache.Remove<CachedParameters>(state);
        }
    }
}