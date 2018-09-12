using System;

namespace GSMA.MobileConnect.Cache
{
    /// <summary>
    /// Interface for cacheable objects
    /// </summary>
    public interface ICacheable
    {
        /// <summary>
        /// Returns true if object came from cache
        /// </summary>
        bool Cached { get; set; }

        /// <summary>
        /// Returns true if the object has expired and should be removed from the cache
        /// </summary>
        bool HasExpired { get; }

        /// <summary>
        /// Time when the object was initially cached
        /// </summary>
        DateTime? TimeCachedUtc { get; set; }

        /// <summary>
        /// Mark the object as expired, this method should only cause HasExpired to move from false to true, not true to false
        /// </summary>
        /// <param name="isExpired">True if should mark object as expired</param>
        void MarkExpired(bool isExpired);
    }
}
