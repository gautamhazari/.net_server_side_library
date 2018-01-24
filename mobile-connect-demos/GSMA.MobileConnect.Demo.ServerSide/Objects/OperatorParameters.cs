namespace GSMA.MobileConnect.ServerSide.Web.Objects
{
    
    public class OperatorParameters
    {
        public string msisdn { get; set; }
        public string clientID { get; set; }
        public string clientSecret { get; set; }
        public string discoveryURL { get; set; }
        public string redirectURL { get; set; }
        public string xRedirect { get; set; }
        public string includeRequestIP { get; set; }
        public string apiVersion { get; set; }
        public string scope { get; set; }
        public string acrValues { get; set; }
        public string userInfo { get; set; }
        public string identity { get; set; }
    }
}