using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GSMA.MobileConnect.Demo.Web
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