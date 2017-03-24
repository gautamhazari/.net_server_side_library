using GSMA.MobileConnect.Cache;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GSMA.MobileConnect.Authentication
{
    /// <summary>
    /// JWKS retrieved from the JWKS endpoint
    /// </summary>
    public class JWKeyset : ICacheable
    {
        /// <inheritdoc/>
        public bool Cached { get; set; }

        /// <inheritdoc/>
        [JsonIgnore]
        public bool HasExpired { get; private set; }

        /// <inheritdoc/>
        public DateTime? TimeCachedUtc { get; set; }

        /// <summary>
        /// All available keys
        /// </summary>
        public List<JWKey> Keys { get; set; }

        /// <summary>
        /// Return all keys matching the predicate
        /// </summary>
        /// <param name="predicate">A function to test each key for eligibility</param>
        /// <returns>Ienumerable containing matching elements</returns>
        public IEnumerable<JWKey> GetMatching(Func<JWKey, bool> predicate)
        {
            if(predicate == null || Keys == null || Keys.Count == 0)
            {
                return Keys;
            }

            return Keys.Where(predicate);
        }

        /// <inheritdoc/>
        public void MarkExpired(bool isExpired)
        {
            HasExpired = HasExpired || isExpired;
        }
    }
}
