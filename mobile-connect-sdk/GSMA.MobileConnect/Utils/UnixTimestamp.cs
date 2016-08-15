using System;

namespace GSMA.MobileConnect.Utils
{
    /// <summary>
    /// Utility methods for working with unix timestamps
    /// </summary>
    public static class UnixTimestamp
    {
        private static readonly DateTime _epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        /// <summary>
        /// Converts a unix timestamp to a UTC DateTime representation
        /// </summary>
        /// <param name="timestamp">Timestamp to convert</param>
        /// <returns>UTC DateTime</returns>
        public static DateTime ToUTCDateTime(int timestamp)
        {
            return _epoch.AddSeconds(timestamp);
        }

        /// <summary>
        /// Converts a unix timestamp to a UTC DateTime representation
        /// </summary>
        /// <param name="timestamp">Timestamp to convert</param>
        /// <exception cref="ArgumentNullException">timestamp is null</exception>
        /// <exception cref="FormatException">timestamp is not a valid number</exception>
        /// <exception cref="OverflowException">timestamp is not a valid int</exception>
        /// <returns>UTC DateTime</returns>
        public static DateTime ToUTCDateTime(string timestamp)
        {
            return ToUTCDateTime(int.Parse(timestamp, System.Globalization.NumberStyles.None));
        }
    }
}
