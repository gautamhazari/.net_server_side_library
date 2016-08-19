using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSMA.MobileConnect
{
    /// <summary>
    /// Static log class for handling all logging. Implementing applications should register an ILogger instance using <see cref="RegisterLogger(ILogger, LogLevel)"/>
    /// </summary>
    public static class Log
    {
        private static ILogger _log;
        private static LogLevel _level;

        /// <summary>
        /// Register ILogger instance to be used for logging. This class will route all logging through the registered ILogger
        /// </summary>
        /// <param name="log">ILogger to use for logging</param>
        /// <param name="levelToLog">Log level to log, all messages at this level or above will be sent to the ILogger</param>
        public static void RegisterLogger(ILogger log, LogLevel levelToLog = LogLevel.Warning)
        {
            _log = log;
            _level = levelToLog;
        }

        /// <summary>
        /// Log an info message
        /// </summary>
        /// <param name="message">Message to log</param>
        public static void Info(string message)
        {
            if (_log == null || _level < LogLevel.Info) return;
            _log.Info(message);
        }

        /// <summary>
        /// Log an info message, message will only be generated if a logger is registered and log level is enabled
        /// </summary>
        /// <param name="messageFunc">Message generating function</param>
        public static void Info(Func<string> messageFunc)
        {
            if (_log == null || messageFunc == null || _level < LogLevel.Info) return;
            _log.Info(messageFunc());
        }

        /// <summary>
        /// Log a debug message
        /// </summary>
        /// <param name="message">Message to log</param>
        public static void Debug(string message)
        {
            if (_log == null || _level < LogLevel.Debug) return;
            _log.Debug(message);
        }

        /// <summary>
        /// Log a debug message, message will only be generated if a logger is registered and log level is enabled
        /// </summary>
        /// <param name="messageFunc">Message generating function</param>
        public static void Debug(Func<string> messageFunc)
        {
            if (_log == null || messageFunc == null || _level < LogLevel.Debug) return;
            _log.Debug(messageFunc());
        }

        /// <summary>
        /// Log a warning message
        /// </summary>
        /// <param name="message">Message to log</param>
        public static void Warning(string message)
        {
            if (_log == null || _level < LogLevel.Warning) return;
            _log.Warning(message);
        }

        /// <summary>
        /// Log a warning message, message will only be generated if a logger is registered and log level is enabled
        /// </summary>
        /// <param name="messageFunc">Message generating function</param>
        public static void Warning(Func<string> messageFunc)
        {
            if (_log == null || messageFunc == null || _level < LogLevel.Warning) return;
            _log.Warning(messageFunc());
        }

        /// <summary>
        /// Log an error message
        /// </summary>
        /// <param name="message">Message to log</param>
        /// <param name="ex">Exception to log</param>
        public static void Error(string message, Exception ex = null)
        {
            if (_log == null || _level < LogLevel.Error) return;
            _log.Error(message, ex);
        }

        /// <summary>
        /// Log an error message, message will only be generated if a logger is registered and log level is enabled
        /// </summary>
        /// <param name="messageFunc">Message generating function</param>
        /// <param name="ex">Exception to log</param>
        public static void Error(Func<string> messageFunc, Exception ex = null)
        {
            if (_log == null || messageFunc == null || _level < LogLevel.Error) return;
            _log.Warning(messageFunc());
        }

        /// <summary>
        /// Log a fatal message
        /// </summary>
        /// <param name="message">Message to log</param>
        /// <param name="ex">Exception to log</param>
        public static void Fatal(string message, Exception ex)
        {
            if (_log == null || _level < LogLevel.Fatal) return;
            _log.Fatal(message, ex);
        }

        /// <summary>
        /// Log a fatal message, message will only be generated if a logger is registered and log level is enabled
        /// </summary>
        /// <param name="messageFunc">Message generating function</param>
        /// <param name="ex">Exception to log</param>
        public static void Fatal(Func<string> messageFunc, Exception ex)
        {
            if (_log == null || messageFunc == null || _level < LogLevel.Fatal) return;
            _log.Fatal(messageFunc(), ex);
        }
    }

    /// <summary>
    /// Level of logging to execute
    /// </summary>
    public enum LogLevel
    {
        /// <summary>
        /// No log messages will be logged
        /// </summary>
        None = 0,
        /// <summary>
        /// Messages Info level and above will be logged
        /// </summary>
        Info = 1,
        /// <summary>
        /// Messages Debug level and above will be logged
        /// </summary>
        Debug = 2,
        /// <summary>
        /// Messages Warning level and above will be logged
        /// </summary>
        Warning = 3,
        /// <summary>
        /// Messages Error level and above will be logged
        /// </summary>
        Error = 4,
        /// <summary>
        /// Messages fatal level and above will be logged
        /// </summary>
        Fatal = 5,
    }
}
