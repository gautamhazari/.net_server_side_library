using GSMA.MobileConnect.Discovery;
using System;

namespace GSMA.MobileConnect.Demo.Web
{

    class Config
    {
        public static string redirectUrl = "http://localhost:8001/mobileconnect.html";
        public static DiscoveryResponse response = null;
        public static OperatorUrls setOperatorUrlsR2()
        {
            var operatorUrls = new OperatorUrls()
            {
                ProviderMetadataUrl = "https://operator-g.integration.sandbox.mobileconnect.io/.well-known/openid-configuration"
            };

            return operatorUrls;
        }

        public static OperatorUrls setOperatorUrlsR1()
        {

            var operatorUrls = new OperatorUrls()
            {
                AuthorizationUrl = "https://operator-a.integration.sandbox.mobileconnect.io/oidc/authorize",
                UserInfoUrl = "https://operator-a.integration.sandbox.mobileconnect.io/oidc/userinfo",
                RequestTokenUrl = "https://operator-a.integration.sandbox.mobileconnect.io/oidc/accesstoken",
                RevokeTokenUrl = "https://operator-a.integration.sandbox.mobileconnect.io/oidc/revoke"
            };

            return operatorUrls;
        }

    }

}
