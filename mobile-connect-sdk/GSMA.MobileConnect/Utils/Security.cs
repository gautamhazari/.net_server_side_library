using PCLCrypto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSMA.MobileConnect.Utils
{
    /// <summary>
    /// Utility functions for security
    /// </summary>
    public static class Security
    {
        /// <summary>
        /// Generate cryptographically random string with length number of bytes
        /// </summary>
        /// <param name="length">Number of bytes to generate</param>
        /// <returns>Random Base64Url encoded string</returns>
        public static string GenerateRandomString(int length)
        {
            byte[] buffer = new byte[length];
            NetFxCrypto.RandomNumberGenerator.GetBytes(buffer);

            return StringUtils.EncodeAsBase64Url(buffer);
        }

        /// <summary>
        /// Generates cryptographically random Base64Url encoded 32 byte string
        /// </summary>
        /// <returns>Cryptographically random Base64Url encoded 32 byte string</returns>
        public static string GenerateSecureNonce()
        {
            return GenerateRandomString(32);
        }
    }
}
