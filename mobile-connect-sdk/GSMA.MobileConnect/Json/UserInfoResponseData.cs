using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSMA.MobileConnect.Json
{
    /// <summary>
    /// Object for deserialization of UserInfo response content
    /// </summary>
    public class UserInfoResponseData
    {
        /// <summary>
        /// Parsed from JSON response
        /// </summary>
        public string error { get; set; }
        /// <summary>
        /// Parsed from JSON response
        /// </summary>
        public string description { get; set; }
        /// <summary>
        /// Parsed from JSON response
        /// </summary>
        public string sub { get; set; }
    }
}
