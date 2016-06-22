using GSMA.MobileConnect.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSMA.MobileConnect.Utils
{
    internal static class RequiredCookies
    {
        private static IEnumerable<string> _discoveryCookieNames = new List<string>
        {
            Cookies.ENUM_NONCE, Cookies.MOST_RECENT_SELECTED_OPERATOR, Cookies.MOST_RECENT_SELECTED_OPERATOR_EXPIRY
        };

        internal static IEnumerable<string> Discovery
        {
            get
            {
                return _discoveryCookieNames;
            }
        }
    }
}
