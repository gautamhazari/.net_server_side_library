using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSMA.MobileConnect.Constants
{
    internal static class Parameters
    {
        //Required param for discovery
        internal const string REDIRECT_URL = "Redirect_URL";

        //Optional params for discovery
        internal const string MANUALLY_SELECT = "Manually-Select";
        internal const string IDENTIFIED_MCC = "Identified-MCC";
        internal const string IDENTIFIED_MNC = "Identified-MNC";
        internal const string SELECTED_MCC = "Selected-MCC";
        internal const string SELECTED_MNC = "Selected-MNC";
        internal const string USING_MOBILE_DATA = "Using-Mobile-Data";
        internal const string LOCAL_CLIENT_IP = "Local-Client-IP";
        internal const string MSISDN = "MSISDN";

        internal const string MCC_MNC = "mcc_mnc";
        internal const string SUBSCRIBER_ID = "subscriber_id";

        //Required params for authentication
        internal const string CLIENT_ID = "client_id";
        internal const string RESPONSE_TYPE = "response_type";
        internal const string AUTHENTICATION_REDIRECT_URI = "redirect_uri";
        internal const string SCOPE = "scope";
        internal const string ACR_VALUES = "acr_values";
        internal const string STATE = "state";
        internal const string NONCE = "nonce";

        //Optional params for authentication
        internal const string DISPLAY = "display";
        internal const string PROMPT = "prompt";
        internal const string MAX_AGE = "max-age";
        internal const string UI_LOCALES = "ui-locales";
        internal const string CLAIMS_LOCALES = "claims_locales";
        internal const string ID_TOKEN_HINT = "id_token_hint";
        internal const string LOGIN_HINT = "login_hint";
        internal const string DTBS = "dtbs";

        //Required params for authorization
        internal const string CLIENT_NAME = "client_name";
        internal const string CONTEXT = "context";
        internal const string BINDING_MESSAGE = "binding_message";

        //Params for AuthorizationResponse
        internal const string ERROR = "error";
        internal const string ERROR_DESCRIPTION = "error_description";
        internal const string ERROR_URI = "error_uri";
        internal const string CODE = "code";

        //Params for Token
        internal const string GRANT_TYPE = "grant_type";
    }
}
