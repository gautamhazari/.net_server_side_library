using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSMA.MobileConnect.Discovery;

namespace GSMA.MobileConnect.Cache
{
    public class SessionCache : ConcurrentCache
    {
        public SessionCache()
        {
        }

        public SessionData Get(string key)
        {
            var sessiondata = this.Get<SessionData>(key).Result;
            if (sessiondata == null)
            {
                return null;
            }
            this.Remove(key);
            return sessiondata;
        }
    }
}
