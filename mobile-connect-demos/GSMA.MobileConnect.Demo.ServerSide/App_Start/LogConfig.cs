namespace GSMA.MobileConnect.ServerSide.Web
{
    public static class LogConfig
    {
        public static void Config()
        {
            log4net.Config.XmlConfigurator.Configure();
            Log.RegisterLogger(new Logger(), LogLevel.Info);
        }
    }
}