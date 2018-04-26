using System;
using GSMA.MobileConnect.Cache;
using GSMA.MobileConnect.Discovery;

namespace GSMA.MobileConnect.ServerSide.Web.Objects
{
    public class CachedParameters : ICacheable
    {
        public string nonce { get; set; }
        public string sdkSession { get; set; }
        public string accessToken { get; set; }
        public bool Cached { get; set; }
        public bool HasExpired { get; private set; }
        public DiscoveryOptions discoveryOptions { get; set; }

        public DateTime? TimeCachedUtc { get; set; }

        public void MarkExpired(bool isExpired)
        {
            HasExpired = HasExpired || isExpired;
        }
    }
}