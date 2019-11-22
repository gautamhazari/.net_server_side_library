﻿namespace GSMA.MobileConnect.ServerSide.Web.Utils
{
    public class Constants
    {
        public static string OperatorDataFilePath = "~/App_Data/operatorData.json";
        public static string WithoutDiscoveryFilePath = "~/App_Data/WithoutDiscoveryData.json";
        public static string SectorIdentifierFilePath = "~/App_Data/sector_identifier_uri.json";
        public static string VERSION1_1 = "mc_v1.1";
        public static string VERSION3_0 = "mc_di_v3.0";
        public static string ContextBindingMsg = "demo context";
        public static string BindingMsg = "demo binding";
        public static int Response_OK = 200;
        public const string FailPage = "Views/Home/fail.cshtml";
        public const string SuccessPage = "Views/Home/success.cshtml";
    }
}