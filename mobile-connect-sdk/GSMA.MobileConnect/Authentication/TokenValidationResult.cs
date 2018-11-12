using System;

namespace GSMA.MobileConnect.Authentication
{
    /// <summary>
    /// Enum for available token validation results
    /// </summary>
    [Flags]
    public enum TokenValidationResult
    {
        /// <summary>
        /// No validation has occured
        /// </summary>
        None = 0,
        /// <summary>
        /// Token when signed does not match signature
        /// </summary>
        InvalidSignature = 1,
        /// <summary>
        /// Token passed all validation steps
        /// </summary>
        Valid = 2,
        /// <summary>
        /// Key was not retrieved from the jwks url or a jwks url was not present
        /// </summary>
        JWKSError = 4,
        /// <summary>
        /// The alg claim in the id token header does not match the alg requested or the default alg of RS256
        /// </summary>
        IncorrectAlgorithm = 8,
        /// <summary>
        /// Neither the azp nor the aud claim in the id token match the client id used to make the auth request
        /// </summary>
        InvalidAudAndAzp = 16,
        /// <summary>
        /// The iss claim in the id token does not match the expected issuer
        /// </summary>
        InvalidIssuer = 32,
        /// <summary>
        /// The IdToken has expired
        /// </summary>
        IdTokenExpired = 64,
        /// <summary>
        /// No key matching the requested key id was found
        /// </summary>
        NoMatchingKey = 128,
        /// <summary>
        /// Key does not contain the required information to validate against the requested algorithm
        /// </summary>
        KeyMisformed = 256,
        /// <summary>
        /// Algorithm is unsupported for validation
        /// </summary>
        UnsupportedAlgorithm = 512,
        /// <summary>
        /// The access token has expired
        /// </summary>
        AccessTokenExpired = 1024,
        /// <summary>
        /// The access token is null or empty in the token response
        /// </summary>
        AccessTokenMissing = 2048,
        /// <summary>
        /// The id token is null or empty in the token response
        /// </summary>
        IdTokenMissing = 4096,
        /// <summary>
        /// The id token is older than the max age specified in the auth stage
        /// </summary>
        MaxAgePassed = 8192,
        /// <summary>
        /// A longer time than the configured limit has passed since the token was issued
        /// </summary>
        TokenIssueTimeLimitPassed = 16384,
        /// <summary>
        /// The nonce in the id token claims does not match the nonce specified in the auth stage
        /// </summary>
        InvalidNonce = 32768,
        /// <summary>
        /// The token response is null or missing required data
        /// </summary>
        IncompleteTokenResponse = 65536,
        /// <summary>
        /// The token validation was skipped because the provider does not 
        /// support full validation of the token. Allow this result if you will be making requests to providers that only support mc_v1.1
        /// </summary>
        IdTokenValidationSkipped = 131072,
        INVALID_AT_HASH = 262144,
        INVALID_ACR = 524288,
        INVALID_AMR = 1048576,
        INVALID_HASHED_LOGIN_HINT = 2097152,

    }
}
