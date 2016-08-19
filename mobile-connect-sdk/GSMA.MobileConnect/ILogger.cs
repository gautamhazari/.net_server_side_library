using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSMA.MobileConnect
{
    /// <summary>
    /// Interface defining required logging methods
    /// </summary>
    /// <seealso cref="Log"/>
    public interface ILogger
    {
        /// <summary>
        /// Log info message
        /// </summary>
        /// <param name="message">Message to log</param>
        void Info(string message);
        /// <summary>
        /// Log debug message
        /// </summary>
        /// <param name="message">Message to log</param>
        void Debug(string message);
        /// <summary>
        /// Log warning message
        /// </summary>
        /// <param name="message">Message to log</param>
        void Warning(string message);

        /// <summary>
        /// Log error message
        /// </summary>
        /// <param name="message">Message to log</param>
        /// <param name="ex">Exception to log</param>
        void Error(string message, Exception ex);
        /// <summary>
        /// Log fatal message
        /// </summary>
        /// <param name="message">Message to log</param>
        /// <param name="ex">Exception to log</param>
        void Fatal(string message, Exception ex);
    }
}
