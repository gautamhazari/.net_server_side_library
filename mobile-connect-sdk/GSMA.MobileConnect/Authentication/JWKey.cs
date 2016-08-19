using GSMA.MobileConnect.Exceptions;
using Newtonsoft.Json;
using PCLCrypto;
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
        private object _key;
        private JosePCL.Jws.IJwsSigner _signer;

        /// <summary>
        /// The "kty" (key type) parameter identifies the cryptographic algorithm
        /// family used with the key, such as "RSA" or "EC"
        /// </summary>
        [JsonProperty("kty", NullValueHandling = NullValueHandling.Ignore)]
        public string KeyType { get; private set; }

        /// <summary>
        /// The "use" (public key use) parameter identifies the intended use of
        /// the public key.The "use" parameter is employed to indicate whether
        /// a public key is used for encrypting data or verifying the signature
        /// on data.
        /// </summary>
        [JsonProperty("use", NullValueHandling = NullValueHandling.Ignore)]
        public string Use { get; private set; }

        /// <summary>
        /// The "key_ops" (key operations) parameter identifies the operation(s)
        /// for which the key is intended to be used.The "key_ops" parameter is
        /// intended for use cases in which public, private, or symmetric keys
        /// may be present.
        /// </summary>
        [JsonProperty("key_ops", NullValueHandling = NullValueHandling.Ignore)]
        public string KeyOps { get; private set; }

        /// <summary>
        /// The "alg" (algorithm) parameter identifies the algorithm intended for
        /// use with the key.
        /// </summary>
        [JsonProperty("alg", NullValueHandling = NullValueHandling.Ignore)]
        public string Algorithm { get; private set; }

        /// <summary>
        /// The "kid" (key ID) parameter is used to match a specific key. This
        /// is used, for instance, to choose among a set of keys within a JWK Set
        /// during key rollover.
        /// </summary>
        [JsonProperty("kid", NullValueHandling = NullValueHandling.Ignore)]
        public string KeyID { get; private set; }

        #region Symmetric

        [JsonIgnore]
        internal bool IsSymmetric
        {
            get { return string.Equals(KeyType, "OCT", StringComparison.OrdinalIgnoreCase); }
        }

        /// <summary>
        /// The "k" (key value) parameter contains the value of the symmetric (or
        /// other single-valued) key.It is represented as the base64url
        /// encoding of the octet sequence containing the key value.
        /// </summary>
        [JsonProperty("k", NullValueHandling = NullValueHandling.Ignore)]
        public string Key { get; private set; }

        #endregion

        #region ECC

        [JsonIgnore]
        internal bool IsECC
        {
            get { return string.Equals(KeyType, "EC", StringComparison.OrdinalIgnoreCase); }
        }

        /// <summary>
        /// The "crv" (curve) parameter identifies the cryptographic curve used
        /// with the key
        /// </summary>
        [JsonProperty("crv", NullValueHandling = NullValueHandling.Ignore)]
        public string ECCCurve { get; private set; }

        /// <summary>
        /// The "x" (x coordinate) parameter contains the x coordinate for the 
        /// Elliptic Curve point
        /// </summary>
        [JsonProperty("x", NullValueHandling = NullValueHandling.Ignore)]
        public string ECCX { get; private set; }

        /// <summary>
        /// The "y" (y coordinate) parameter contains the y coordinate for the
        /// Elliptic Curve point.
        /// </summary>
        [JsonProperty("y", NullValueHandling = NullValueHandling.Ignore)]
        public string ECCY { get; private set; }

        #endregion

        #region RSA

        [JsonIgnore]
        internal bool IsRSA
        {
            get { return string.Equals(KeyType, "RSA", StringComparison.OrdinalIgnoreCase); }
        }

        /// <summary>
        /// The "n" (modulus) parameter contains the modulus value for the RSA
        /// public key.It is represented as a Base64urlUInt-encoded value.
        /// </summary>
        [JsonProperty("n", NullValueHandling = NullValueHandling.Ignore)]
        public string RSAN { get; private set; }

        /// <summary>
        /// The "e" (exponent) parameter contains the exponent value for the RSA
        /// public key.It is represented as a Base64urlUInt-encoded value.
        /// </summary>
        [JsonProperty("e", NullValueHandling = NullValueHandling.Ignore)]
        public string RSAE { get; private set; }

        #endregion

        #region Verification

        /// <summary>
        /// Verify that the input when signed with this key and the requested algorithm matches
        /// the expected signature
        /// </summary>
        /// <param name="input">JWT Header+Payload to sign and verify</param>
        /// <param name="expected">Expected signature</param>
        /// <param name="alg">Algorithm requested in the JWT header, if the algorithm is not a valid algorithm for the key type then an exception will be thrown</param>
        /// <exception cref="MobileConnectInvalidJWKException">Thrown if the available properties do not match the key type</exception>
        /// <exception cref="MobileConnectUnsupportedJWKException">Thrown if the requested algorithm is unsupported or does not match the key type</exception>
        /// <returns>True if token is verified</returns>
        public bool Verify(string input, string expected, string alg)
        {
            var signature = Utils.StringUtils.DecodeFromBase64Url(expected);
            var securedInput = Encoding.UTF8.GetBytes(input);

            var signer = GetSigner(alg);
            return signer.Verify(signature, securedInput, GetKey());
        }

        private object GetKey()
        {
            if(_key != null)
            {
                return _key;
            }

            if(IsRSA)
            {
                _key = CreateRSAKey();
                return _key;
            }
            else if(IsSymmetric)
            {
                _key = CreateHMACKey();
                return _key;
            }

            Log.Warning(() => $"Unsupported was used for token signing KeyType={KeyType}");
            throw new MobileConnectUnsupportedJWKException($"Unsupported key type {KeyType}");
        }

        private ICryptographicKey CreateRSAKey()
        {
            if(string.IsNullOrEmpty(RSAE) || string.IsNullOrEmpty(RSAN))
            {
                throw new MobileConnectInvalidJWKException("RSA key does not have required Modulus and Exponent components");
            }

            var modulus = JosePCL.Serialization.Base64Url.Decode(RSAN);
            var exponent = JosePCL.Serialization.Base64Url.Decode(RSAE);
            return JosePCL.Keys.Rsa.PublicKey.New(exponent, modulus);
        }

        private byte[] CreateHMACKey()
        {
            if(string.IsNullOrEmpty(Key))
            {
                Log.Warning(() => $"HMAC key does not have a secret Algorithm={Algorithm}");
                throw new MobileConnectInvalidJWKException("HMAC key does not have secret");
            }

            return Encoding.UTF8.GetBytes(Key);
        }

        private JosePCL.Jws.IJwsSigner GetSigner(string alg)
        {
            if(_signer != null)
            {
                return _signer;
            }

            if(IsRSA && alg.StartsWith("RS", StringComparison.OrdinalIgnoreCase))
            {
                _signer = new JosePCL.Jws.RsaUsingSha(GetKeySize(alg));
                return _signer;
            }
            else if (IsSymmetric && alg.StartsWith("HS", StringComparison.OrdinalIgnoreCase))
            {
                _signer = new JosePCL.Jws.HmacUsingSha(GetKeySize(alg));
                return _signer;
            }

            Log.Warning(() => $"Unsupported alogrithm was used for token signing Algorithm={alg}");
            throw new MobileConnectUnsupportedJWKException($"Unsupported algorithm {alg} for key type {KeyType}");
        }

        private int GetKeySize(string alg)
        {
            int firstNumberIndex = 0;
            for (int i = alg.Length - 1; i >= 0; i--)
            {
                if(!char.IsNumber(alg[i]))
                {
                    break;
                }

                firstNumberIndex = i;
            }

            return int.Parse(alg.Substring(firstNumberIndex));
        }

        #endregion
    }
}
