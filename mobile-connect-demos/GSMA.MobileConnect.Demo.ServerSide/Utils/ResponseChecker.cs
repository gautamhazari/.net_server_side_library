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
           return await cache.Get<CachedParameters>(state);
        }

        public async Task<CachedParameters> RemoveData(string state)
        {
            return await cache.Remove<CachedParameters>(state);
        }
    }
}