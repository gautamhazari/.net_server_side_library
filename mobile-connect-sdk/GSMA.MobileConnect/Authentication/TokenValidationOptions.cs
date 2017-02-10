
namespace GSMA.MobileConnect.Authentication
{
    /// <summary>
    /// Options for handling token validation
    /// </summary>
    public class TokenValidationOptions
    {
        private TokenValidationResult _accepted = TokenValidationResult.Valid;

        /// <summary>
        /// Bit flag specifying which validation results should be accepted as "OK", if any results
        /// not specified are returned from validation an error status to be returned when requesting a token.
        /// By default only tokens that pass all validation steps will be accepted, allowing others to be accepted
        /// is at the SDK users own risk and is not advised.
        /// </summary>
        public TokenValidationResult AcceptedValidationResults
        {
            get { return _accepted; }
            set
            {
                if(value != TokenValidationResult.Valid)
                {
                    Log.Warning(() => $"TokenValidationOptions.AcceptedValidationResults set to {value}");
                }

                _accepted = value;
            }
        }
    }
}
