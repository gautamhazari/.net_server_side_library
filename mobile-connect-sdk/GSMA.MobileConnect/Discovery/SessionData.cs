using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSMA.MobileConnect.Cache;

namespace GSMA.MobileConnect.Discovery
{
    public class SessionData : ICacheable
    {
        public string Nonce { get; set; }
        public DiscoveryResponse DiscoveryResponse { get; set; }

        public SessionData() {}

        public SessionData(DiscoveryResponse discoveryResponse, string nonce)
        {
            this.Nonce = nonce;
            this.DiscoveryResponse = discoveryResponse;
        }

        
        public bool Cached { get; set; }
        public bool HasExpired { get; set; }
        public DateTime? TimeCachedUtc { get; set; }
        public void MarkExpired(bool isExpired)
        {
             HasExpired = HasExpired || isExpired;
        }
    }
}
