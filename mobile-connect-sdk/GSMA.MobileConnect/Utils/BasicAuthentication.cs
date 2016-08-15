using System;
using System.Text;

namespace GSMA.MobileConnect.Utils
{
    /// <summary>
    /// Helper class for basic authentication related methods
    /// </summary>
    public static class BasicAuthentication
    {
        /// <summary>
        /// Encodes the provided id and secret ready for use with basic authentication
        /// </summary>
        /// <param name="clientId">Registered application client id</param>
        /// <param name="secret">Registered application client secret</param>
        /// <returns>Base64 encoded string</returns>
        public static string Encode(string clientId, string secret)
        {
            var temp = string.Format("{0}:{1}", clientId, secret);
            byte[] authentication = Encoding.UTF8.GetBytes(temp);
            return StringUtils.EncodeAsBase64(authentication);
        }
    }
}
