using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSMA.MobileConnect.Constants
{
    internal static class DefaultOptions
    {
        internal const int TIMEOUT = 300000;

        internal const bool MANUAL_SELECT = false;
        internal const bool COOKIES_ENABLED = true;

        internal const string DISPLAY = "page";

        internal const bool CHECK_ID_TOKEN_SIGNATURE = true;

        internal const long MIN_TTL_MS = 300000;
        internal const long MAX_TTL_MS = 15552000000;

        internal const string AUTHENTICATION_ACR_VALUES = "2";
        internal const string AUTHENTICATION_SCOPE = "openid";
        internal const int AUTHENTICATION_MAX_AGE = 3600;
        internal const string AUTHENTICATION_RESPONSE_TYPE = "code";
        internal const string AUTHENTICATION_DEFAULT_VERSION = "mc_v1.1";

        internal const string GRANT_TYPE = "authorization_code";

        internal const int PROVIDER_METADATA_TTL_SECONDS = 600;

        internal const string VERSION_MOBILECONNECT = "mc_v1.1";
        internal const string VERSION_MOBILECONNECTAUTHN = "mc_v1.1";
        internal const string VERSION_MOBILECONNECTAUTHZ = "mc_v1.2";
        internal const string VERSION_MOBILECONNECTIDENTITY = "mc_v1.2";
    }
}
