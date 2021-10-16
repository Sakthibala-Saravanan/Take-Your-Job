using System;

namespace AspireSystems.Diagnostics.Logging
{
    public interface IDefaultLogger
    {
        void LogTrace(string message);
        void LogDebug(string message);
        void LogWarning(string message);
        void LogError(string message);
        void LogError(string message, Exception exp);
    }
}
