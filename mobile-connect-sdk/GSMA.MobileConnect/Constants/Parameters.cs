namespace GSMA.MobileConnect.Constants
{
    public static class Parameters
    {
        //Required param for discovery
        public const string REDIRECT_URL = "Redirect_URL";

        //Optional params for discovery
        public const string MANUALLY_SELECT = "Manually-Select";
        public const string IDENTIFIED_MCC = "Identified-MCC";
        public const string IDENTIFIED_MNC = "Identified-MNC";
        public const string SELECTED_MCC = "Selected-MCC";
        public const string SELECTED_MNC = "Selected-MNC";
        public const string USING_MOBILE_DATA = "Using-Mobile-Data";
        public const string LOCAL_CLIENT_IP = "Local-Client-IP";
        public const string MSISDN = "MSISDN";
        public const string X_REDIRECT = "X-Redirect";
        public const string X_REDIRECT_DEFAULT_VALUE = "App";
        public const string MCC_MNC = "mcc_mnc";
        public const string SUBSCRIBER_ID = "subscriber_id";
        public const string SUBSCRIBER_ID_TOKEN = "subscriber_id_token";

        //Required params for authentication
        public const string CLIENT_ID = "client_id";
        public const string CORRELATION_ID = "correlation_id";
        public const string RESPONSE_TYPE = "response_type";
        public const string AUTHENTICATION_REDIRECT_URI = "redirect_uri";
        public const string SCOPE = "scope";
        public const string ACR_VALUES = "acr_values";
        public const string STATE = "state";
        public const string NONCE = "nonce";
        public const string VERSION = "version";

        //Optional params for authentication
        public const string DISPLAY = "display";
        public const string PROMPT = "prompt";
        public const string MAX_AGE = "max_age";
        public const string UI_LOCALES = "ui_locales";
        public const string CLAIMS_LOCALES = "claims_locales";
        public const string ID_TOKEN_HINT = "id_token_hint";
        public const string LOGIN_HINT = "login_hint";
        public const string LOGIN_HINT_TOKEN = "login_hint_token";
        public const string DTBS = "dtbs";
        public const string CLAIMS = "claims";

        //Required params for authorization
        public const string CLIENT_NAME = "client_name";
        public const string CONTEXT = "context";
        public const string BINDING_MESSAGE = "binding_message";

        //Params for AuthorizationResponse
        public const string ERROR = "error";
        public const string ERROR_DESCRIPTION = "error_description";
        public const string ERROR_URI = "error_uri";
        public const string CODE = "code";

        //Params for Token
        public const string GRANT_TYPE = "grant_type";
        public const string REFRESH_TOKEN = "refresh_token";
        public const string TOKEN = "token";
        public const string TOKEN_TYPE_HINT = "token_type_hint";

        public const string ACCESS_TOKEN_HINT = "access_token";
        public const string REFRESH_TOKEN_HINT = "refresh_token";
    }
}
