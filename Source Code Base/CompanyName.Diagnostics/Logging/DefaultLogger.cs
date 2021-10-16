using log4net;
using System;
using System.IO;
using System.Reflection;

namespace AspireSystems.Diagnostics.Logging
{
    /// <summary>
    /// Wrapper class that consumes log4net to log trace and error
    /// </summary>
    public class DefaultLogger : IDefaultLogger
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public DefaultLogger()
        {
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());

            //Load configuration from log4net.config file
            log4net.Config.XmlConfigurator.Configure(logRepository,
                                                     new FileInfo("Config\\log4net.config"));
        }

        /// <summary>
        /// Logs the trace and activity for debug purpose
        /// </summary>
        public void LogTrace(string message)
        {
            log.Info(message);
        }

        /// <summary>
        /// Logs the debug and activity for debug purpose
        /// </summary>
        public void LogDebug(string message)
        {
            log.Debug(message);
        }

        /// <summary>
        /// Logs the warnings and activity for debug purpose
        /// </summary>
        public void LogWarning(string message)
        {
            log.Warn(message);
        }

        /// <summary>
        /// Logs the exception and error
        /// </summary>
        public void LogError(string message)
        {
            log.Error(message);
        }

        /// <summary>
        /// Logs the exception and error
        /// </summary>
        public void LogError(string message, Exception exp)
        {
            log.Error(message, exp);
        }
    }
}
