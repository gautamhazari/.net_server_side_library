using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSMA.MobileConnect.Authentication
{
    /// <summary>
    /// Options for handling token validation
    /// </summary>
    public class TokenValidationOptions
    {
        /// <summary>
        /// Bit flag specifying which validation results should be accepted as "OK", if any results
        /// not specified are returned from validation an error status to be returned when requesting a token.
        /// By default only tokens that pass all validation steps will be accepted, allowing others to be accepted
        /// is at the SDK users own risk and is not advised.
        /// </summary>
        public TokenValidationResult AcceptedValidationResults { get; set; } = TokenValidationResult.Valid;
    }
}
