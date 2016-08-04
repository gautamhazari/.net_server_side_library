using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSMA.MobileConnect.Authentication
{
    /// <summary>
    /// Represents a cryptographic key that belongs to a JWKeyset
    /// </summary>
    public class JWKey
    {
        /// <summary>
        /// The "kty" (key type) parameter identifies the cryptographic algorithm
        /// family used with the key, such as "RSA" or "EC"
        /// </summary>
        [JsonProperty("kty", NullValueHandling = NullValueHandling.Ignore)]
        public string KeyType { get; set; }

        /// <summary>
        /// The "use" (public key use) parameter identifies the intended use of
        /// the public key.The "use" parameter is employed to indicate whether
        /// a public key is used for encrypting data or verifying the signature
        /// on data.
        /// </summary>
        [JsonProperty("use", NullValueHandling = NullValueHandling.Ignore)]
        public string Use { get; set; }

        /// <summary>
        /// The "key_ops" (key operations) parameter identifies the operation(s)
        /// for which the key is intended to be used.The "key_ops" parameter is
        /// intended for use cases in which public, private, or symmetric keys
        /// may be present.
        /// </summary>
        [JsonProperty("key_ops", NullValueHandling = NullValueHandling.Ignore)]
        public string KeyOps { get; set; }

        /// <summary>
        /// The "alg" (algorithm) parameter identifies the algorithm intended for
        /// use with the key.
        /// </summary>
        [JsonProperty("alg", NullValueHandling = NullValueHandling.Ignore)]
        public string Algorithm { get; set; }

        /// <summary>
        /// The "kid" (key ID) parameter is used to match a specific key. This
        /// is used, for instance, to choose among a set of keys within a JWK Set
        /// during key rollover.
        /// </summary>
        [JsonProperty("kid", NullValueHandling = NullValueHandling.Ignore)]
        public string KeyID { get; set; }

        #region Symmetric

        /// <summary>
        /// The "k" (key value) parameter contains the value of the symmetric (or
        /// other single-valued) key.It is represented as the base64url
        /// encoding of the octet sequence containing the key value.
        /// </summary>
        [JsonProperty("k", NullValueHandling = NullValueHandling.Ignore)]
        public string Key { get; set; }

        #endregion

        #region ECC

        /// <summary>
        /// The "crv" (curve) parameter identifies the cryptographic curve used
        /// with the key
        /// </summary>
        [JsonProperty("crv", NullValueHandling = NullValueHandling.Ignore)]
        public string ECCCurve { get; set; }

        /// <summary>
        /// The "x" (x coordinate) parameter contains the x coordinate for the 
        /// Elliptic Curve point
        /// </summary>
        [JsonProperty("x", NullValueHandling = NullValueHandling.Ignore)]
        public string ECCX { get; set; }

        /// <summary>
        /// The "y" (y coordinate) parameter contains the y coordinate for the
        /// Elliptic Curve point.
        /// </summary>
        [JsonProperty("y", NullValueHandling = NullValueHandling.Ignore)]
        public string ECCY { get; set; }

        #endregion

        #region RSA

        /// <summary>
        /// The "n" (modulus) parameter contains the modulus value for the RSA
        /// public key.It is represented as a Base64urlUInt-encoded value.
        /// </summary>
        [JsonProperty("n", NullValueHandling = NullValueHandling.Ignore)]
        public string RSAN { get; set; }

        /// <summary>
        /// The "e" (exponent) parameter contains the exponent value for the RSA
        /// public key.It is represented as a Base64urlUInt-encoded value.
        /// </summary>
        [JsonProperty("e", NullValueHandling = NullValueHandling.Ignore)]
        public string RSAE { get; set; }

        #endregion
    }
}
