using log4net;
using Microsoft.Extensions.Options;
using System;
using System.IO;
using System.Reflection;
using AspireSystems.Diagnostics.Logging;
using AspireSystems.Infrastructure.Helpers;
using AspireSystems.Infrastructure.Models;

namespace AspireSystems.Infrastructure.Logging
{
    public class AspireSystemsDBLogger : IDefaultLogger
    {
        #region Private members
        private AppSettings _appSettings { get; set; }
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        #endregion

        #region Constructor
        public AspireSystemsDBLogger(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());

            //Load configuration from log4net.config file
            log4net.Config.XmlConfigurator.Configure(logRepository, new FileInfo(_appSettings.Log4NetConfig));
        }
        #endregion

        #region Public methods
        /// <summary>
        /// Logs the trace and activity for debug purpose
        /// </summary>
        public void LogTrace(string message)
        {
            this.SetContext();
            log.Info(message);
        }

        /// <summary>
        /// Logs the trace and activity for debug purpose
        /// </summary>
        public void LogDebug(string message)
        {
            this.SetContext();
            log.Debug(message);
        }

        /// <summary>
        /// Logs the trace and activity for debug purpose
        /// </summary>
        public void LogWarning(string message)
        {
            this.SetContext();
            log.Warn(message);
        }

        /// <summary>
        /// Logs the exception and error
        /// </summary>
        public void LogError(string message)
        {
            this.SetContext();
            log.Error(message);
        }

        /// <summary>
        /// Logs the exception and error
        /// </summary>
        public void LogError(string message, Exception exp)
        {
            this.SetContext();
            log.Info(message, exp);
        }
        #endregion

        #region Private methods
        private void SetContext()
        {
            log4net.MDC.Set("UserName", UserIdentity.UserName);
            log4net.MDC.Set("URL", HttpContext.Current.Request.Path);
            log4net.MDC.Set("HostName", Environment.MachineName);
            log4net.MDC.Set("Body", "");
        }
        #endregion
    }
}
