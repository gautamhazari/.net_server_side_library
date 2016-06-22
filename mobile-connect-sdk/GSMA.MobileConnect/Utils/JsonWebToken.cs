using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSMA.MobileConnect.Utils
{
    /// <summary>
    /// Static helper class for interacting with JSON Web Tokens
    /// </summary>
    public static class JsonWebToken
    {
        /// <summary>
        /// Decodes the payload of a JSON Web Token to a standard JSON string
        /// </summary>
        /// <param name="token">JSON Web Token to decode the payload content</param>
        /// <returns>JSON string decoded from payload</returns>
        public static string DecodePayload(string token)
        {
            var split = token.Split('.');
            var base64 = split[1].Replace('-', '+').Replace('_', '/');
            var padding = 4 - (base64.Length % 4);
            var base64Padded = padding < 4 ? base64.PadRight(base64.Length + padding, '=') : base64;

            var decoded = Convert.FromBase64String(base64Padded);
            var decodedString = Encoding.UTF8.GetString(decoded, 0, decoded.Length);

            return decodedString;
        }
    }
}
