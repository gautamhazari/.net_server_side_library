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

        /// <summary>
        /// Convert key array into string
        /// </summary>
        /// <param name="keys">keys to convert</param>
        /// <returns>string that contains all keys.</returns>
        public static string FormatKey(params string[] keys)
        {
            StringBuilder stringBuilder = new StringBuilder();
            string appender = "_";
            foreach (var key in keys)
            {
                if (!string.IsNullOrEmpty(key))
                {
                    stringBuilder.Append(key);
                    stringBuilder.Append(appender);
                }
            }
            if (stringBuilder.Length == 0)
            {
                return null;
            }
            else return stringBuilder.ToString();
        }

        /// <summary>
        /// Set value to null if it is empty
        /// </summary>
        /// <param name="Value"> value to check.</param>
        /// <returns>value or null if it is empty.</returns>
        public static string SetValueToNullIfIsEmpty(string Value)
        {
            if (string.IsNullOrEmpty(Value))
            {
                return null;
            }

            return Value;
        }

        /// <summary>
        /// Set value to null if it is empty
        /// </summary>
        /// <param name="value">value to check.</param>
        /// <returns>value or null if it is empty.</returns>
        public static Uri SetValueToNullIfIsEmpty(Uri value)
        {
            if (value == null || value.ToString().Equals(string.Empty))
            {
                return null;
            }

            return value;
        }
    }
}
