using System;

namespace AspireSystems.Diagnostics.ErrorHandler
{
    public interface IAspireSystemsExceptionHandler
    {
        // <summary>
        /// Handler to log error and exception details with trace category
        /// </summary>
        void HandleException(Exception ex);

        void HandleException(Exception ex, string userName,string url, string content);
    }
}
