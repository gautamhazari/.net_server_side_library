using System.Threading.Tasks;
using GSMA.MobileConnect.Cache;
using GSMA.MobileConnect.ServerSide.Web.Objects;

namespace GSMA.MobileConnect.ServerSide.Web.Utils
{
    public class ResponseChecker
    {
        private static OperatorParameters _operatorParams;
        private static ReadAndParseFiles readAndParseFiles = new ReadAndParseFiles();
        private ConcurrentCache cache;

        public ResponseChecker()
        {
            _operatorParams = readAndParseFiles.ReadFile(Constants.ConfigFilePath);
            cache = new ConcurrentCache(_operatorParams.maxDiscoveryCacheSize);
        }

        public async Task SaveData(string state, CachedParameters cachedParameters)
        {
            await cache.Add(state, cachedParameters);
        }

        public async Task<CachedParameters> getData(string state)
        {
            var cachedParameters = cache.Get<CachedParameters>(state);
            return await cachedParameters;
        }

        public async Task<CachedParameters> RemoveData(string state)
        {
            return await cache.Remove<CachedParameters>(state);
        }
    }
}