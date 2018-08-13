namespace GSMA.MobileConnect.Authentication
{
    /// <summary>
    /// Class to hold the response from <see cref="IAuthenticationService.StartAuthentication(string, string, string, string, string, string, Discovery.SupportedVersions, AuthenticationOptions)"/>
    /// </summary>
    /// <seealso cref="IAuthenticationService"/>
    public class StartAuthenticationResponse
    {
        /// <summary>
        /// The URL to use to authorize with the identified operator
        /// </summary>
        public string Url { get; set; }
    }
}
