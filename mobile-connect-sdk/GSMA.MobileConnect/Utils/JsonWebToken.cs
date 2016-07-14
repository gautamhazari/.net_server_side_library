using System;
using System.Text;

namespace GSMA.MobileConnect.Utils
{
    /// <summary>
    /// Static helper class for interacting with JSON Web Tokens
    /// </summary>
    public static class JsonWebToken
    {
        /// <summary>
        /// Check if token is in valid JWT format
        /// </summary>
        /// <param name="token">Token to check</param>
        /// <returns>True if token contains 3 parts split by '.' the last part may be empty</returns>
        public static bool IsValidFormat(string token)
        {
            var split = token.Split(new char[] { '.' }, StringSplitOptions.None);
            return split.Length == 3;
        }

        /// <summary>
        /// Decodes the specified token part
        /// </summary>
        /// <param name="token">JSON Web Token to decode the part content</param>
        /// <param name="part">Part to decode, if signature then the part will be returned directly and no decode will be completed</param>
        /// <returns>JSON string decoded from part</returns>
        public static string DecodePart(string token, JWTPart part)
        {
            var split = token.Split(new char[] { '.' }, StringSplitOptions.None);
            var stringPart = split[(int)part];

            if(stringPart == string.Empty || part == JWTPart.Signature)
            {
                return stringPart;
            }

            var base64 = stringPart.Replace('-', '+').Replace('_', '/');
            var padding = 4 - (base64.Length % 4);
            var base64Padded = padding < 4 ? base64.PadRight(base64.Length + padding, '=') : base64;

            var decoded = Convert.FromBase64String(base64Padded);
            var decodedString = Encoding.UTF8.GetString(decoded, 0, decoded.Length);

            return decodedString;
        }
    }

    /// <summary>
    /// Enum for specifying part of a Json Web Token
    /// </summary>
    public enum JWTPart
    {
        /// <summary>
        /// First part of the JSON Web Token containing information about the Algorithm and token type
        /// </summary>
        Header = 0,
        /// <summary>
        /// Second part of the JSON Web Token containing data and required claims
        /// </summary>
        Payload = 1,
        /// <summary>
        /// Third part of the JSON Web Token used to verify the token authenticity
        /// </summary>
        Signature = 2
    }
}
