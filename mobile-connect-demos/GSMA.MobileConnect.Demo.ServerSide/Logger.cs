using log4net;
using System;

namespace GSMA.MobileConnect.ServerSide.Web
{
    public class Logger : ILogger
    {
        private static readonly ILog _log = LogManager.GetLogger("demo");
        public void Debug(string message)
        {
            _log.Debug(message);
        }

        public void Error(string message, Exception ex)
        {
            _log.Error(message, ex);
        }

        public void Fatal(string message, Exception ex)
        {
            _log.Fatal(message, ex);
        }

        public void Info(string message)
        {
            _log.Info(message);
        }

        public void Warning(string message)
        {
            _log.Warn(message);
        }
    }
}