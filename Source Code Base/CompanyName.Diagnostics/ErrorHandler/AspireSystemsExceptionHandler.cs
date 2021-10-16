using System;
using AspireSystems.Diagnostics.Logging;

namespace AspireSystems.Diagnostics.ErrorHandler
{
    public class AspireSystemsExceptionHandler : IAspireSystemsExceptionHandler
    {
        #region Members
        private IDefaultLogger DefaultLogger { get; set; }
        #endregion

        #region Constructor
        public AspireSystemsExceptionHandler(IDefaultLogger defaultLogger)
        {
            DefaultLogger = defaultLogger;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Custom handler that logs the exception through default logger
        /// </summary>

        public void HandleException(Exception ex)
        {
            DefaultLogger.LogError(ex.Message, ex);
        }

        public void HandleException(Exception ex, string userName, string url, string content)
        {
            string error = string.Format("{0}\r\nUser Name : {1}\r\nURL : {2}\r\nContent : {3}\n", ex.ToString(), userName, url, content);
            DefaultLogger.LogError(error);
        }

        #endregion
    }
}
