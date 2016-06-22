using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSMA.MobileConnect.Authentication
{
    /// <summary>
    /// Class to hold the response from <see cref="IAuthentication.StartAuthentication(string, string, string, string, string, string, int?, string, string, AuthenticationOptions)"/>
    /// </summary>
    /// <seealso cref="IAuthentication"/>
    public class StartAuthenticationResponse
    {
        /// <summary>
        /// The URL to use to authorize with the identified operator
        /// </summary>
        public string Url { get; set; }
    }
}
