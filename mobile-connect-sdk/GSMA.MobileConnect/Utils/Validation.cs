using GSMA.MobileConnect.Exceptions;
using Newtonsoft.Json.Linq;
using System.Runtime.CompilerServices;

namespace GSMA.MobileConnect.Utils
{
    internal static class Validation
    {
        /// <summary>
        /// Throws an ArgumentNullException if the passed parameter is null
        /// </summary>
        /// <param name="obj">Parameter to check for null</param>
        /// <param name="name">Name of the parameter for the exception message</param>
        /// <param name="caller">Calling method</param>
        /// <exception cref="MobileConnectInvalidArgumentException">If obj is null</exception>
        internal static void RejectNull(object obj, string name, [CallerMemberName]string caller = null)
        {
            if(obj == null)
            {
                throw new MobileConnectInvalidArgumentException(name, caller);
            }
        }

        /// <summary>
        /// Throws an ArgumentException if the passed parameter is empty or ArgumentNullException if null
        /// </summary>
        /// <param name="input">Parameter to check for null or empty</param>
        /// <param name="name">Name of the parameter for the exception message</param>
        /// /// <param name="caller">Calling method</param>
        /// <exception cref="MobileConnectInvalidArgumentException">If input is null or empty</exception>
        internal static void RejectNullOrEmpty(string input, string name, [CallerMemberName]string caller = null)
        {
            RejectNull(input, name, caller);

            if(input == string.Empty)
            {
                throw new MobileConnectInvalidArgumentException(name, caller);
            }
        }

        /// <summary>
        /// Validates that the nonce contained within a JSON Web Token payload is the expected nonce
        /// </summary>
        /// <param name="token">JSON Web Token that the nonce value will be extracted from</param>
        /// <param name="expectedNonce">Expected nonce value</param>
        /// <returns>True if the nonce value found is the same as the expected value</returns>
        internal static bool IsExpectedNonce(string token, string expectedNonce)
        {
            var decodedPayload = JsonWebToken.DecodePart(token, JWTPart.Payload);
            JObject parsed = JObject.Parse(decodedPayload);

            return expectedNonce == (string)parsed["nonce"];
        }
    }
}
