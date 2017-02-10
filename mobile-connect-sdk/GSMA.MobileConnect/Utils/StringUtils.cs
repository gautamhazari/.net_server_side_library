using System;
using System.Text;

namespace GSMA.MobileConnect.Utils
{
    /// <summary>
    /// Hepful string utility methods
    /// </summary>
    public static class StringUtils
    {
        /// <summary>
        /// Encode an input string in Base64UrlEncoded form
        /// </summary>
        /// <param name="input">UTF8 string to encode</param>
        /// <returns>Base64Url encoded string</returns>
        public static string EncodeAsBase64Url(string input)
        {
            var bytes = Encoding.UTF8.GetBytes(input);
            return EncodeAsBase64Url(bytes);
        }

        /// <summary>
        /// Encode an input byte array in Base64UrlEncoded form
        /// </summary>
        /// <param name="input">Byte array to encode</param>
        /// <returns>Base64Url encoded string</returns>
        public static string EncodeAsBase64Url(byte[] input)
        {
            return JosePCL.Serialization.Base64Url.Encode(input);
        }

        /// <summary>
        /// Encode an input string in Base64 form
        /// </summary>
        /// <param name="input">UTF8 string to encode</param>
        /// <returns>Base64Url encoded string</returns>
        public static string EncodeAsBase64(string input)
        {
            var bytes = Encoding.UTF8.GetBytes(input);
            return EncodeAsBase64(bytes);
        }

        /// <summary>
        /// Encode an input byte array in Base64 form
        /// </summary>
        /// <param name="input">Byte array to encode</param>
        /// <returns>Base64 encoded string</returns>
        public static string EncodeAsBase64(byte[] input)
        {
            return Convert.ToBase64String(input);
        }

        /// <summary>
        /// Decode Base64 string to byte array
        /// </summary>
        /// <param name="base64Input">Base64 encoded string</param>
        /// <returns>Decoded byte array</returns>
        public static byte[] DecodeFromBase64(string base64Input)
        {
            return Convert.FromBase64String(base64Input);
        }

        /// <summary>
        /// Decode Base64Url encoded string to byte array
        /// </summary>
        /// <param name="base64UrlInput">Base64Url encoded string</param>
        /// <returns>Decoded byte array</returns>
        public static byte[] DecodeFromBase64Url(string base64UrlInput)
        {
            return JosePCL.Serialization.Base64Url.Decode(base64UrlInput);
        }
    }
}
