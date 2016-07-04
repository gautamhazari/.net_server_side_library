using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSMA.MobileConnect.Exceptions
{
    /// <summary>
    /// Exception raised when a cache expiry time is set to a value outside of the min and max expiry time range
    /// </summary>
    public class MobileConnectCacheExpiryLimitException : Exception
    {
        /// <inheritdoc/>
        public MobileConnectCacheExpiryLimitException()
        {
        }

        /// <inheritdoc/>
        public MobileConnectCacheExpiryLimitException(string message) : base(message)
        {
        }

        /// <inheritdoc/>
        public MobileConnectCacheExpiryLimitException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Creates an instance of the class MobileConnectCacheExpiryLimitException with a message detailing the target type and the configured limits for that type
        /// </summary>
        /// <param name="targetType">Target type for cache expiry</param>
        /// <param name="lower">Lower limit for configuring the cache expiry against the target type</param>
        /// <param name="upper">Upper limit for configuring the cache expiry against the target type</param>
        public MobileConnectCacheExpiryLimitException(Type targetType, TimeSpan? lower, TimeSpan? upper) 
            : this($"Cache expiry for type {targetType.FullName} should be between {lower?.TotalSeconds ?? 0} seconds and {upper?.TotalSeconds ?? double.PositiveInfinity} seconds")
        {

        }
    }
}
