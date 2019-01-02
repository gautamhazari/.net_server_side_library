using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GSMA.MobileConnect.Exceptions;

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
        /// Inspect a String for content, throws NullPointerException if is null or empty.
        /// </summary>
        /// <param name="keys">keys to convert</param>
        /// <returns>string that contains all keys.</returns>
        public static bool requireNonEmpty(string name, string value, params string[] values)
        {
            if (!string.IsNullOrEmpty(value) & !IsNullOrEmpty(values))
            {
                throw new MobileConnectInvalidArgumentException(name);
            }
            Validate.RejectNullOrEmpty(name, "name");
            if (string.IsNullOrEmpty(value) & !IsNullOrEmpty(values))
            {
                foreach (var val in values)
                {
                    Validate.RejectNullOrEmpty(val, name);
                }
            }

            return !string.IsNullOrEmpty(value) || !IsNullOrEmpty(values);
        }

        /// <summary>
        /// Inspect a String for content, throws NullPointerException if is null or empty.
        /// </summary>
        /// <param name="keys">keys to convert</param>
        /// <returns>string that contains all keys.</returns>
        public static bool IsNullOrEmpty(params string[] values)
        {
            bool isEmpty = true;
            foreach (var value in values)
            {
                if (!string.IsNullOrEmpty(value))
                {
                    isEmpty = false;
                }
            }

            return isEmpty;
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

        /// <summary>
        /// Convert init string to list by spaces
        /// </summary>
        /// <param name="initString"></param>
        /// <returns></returns>
        public static List<string> ConvertToListBySpace(string initString)
        {
            if (String.IsNullOrEmpty(initString))
            {
                return new List<string>();
            }

            return initString.Split(' ').ToList();
        }
    }
}
