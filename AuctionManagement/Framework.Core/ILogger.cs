using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Core
{
    public interface ILogger
    {
        void LogFatal(string template, params object[] parameters);
        void LogFatal(Exception exception);
        void LogError(string template, params object[] parameters);
        void LogError(Exception exception);
        void LogWarning(string template, params object[] parameters);
        void LogInfo(string template, params object[] parameters);
        void LogDebug(string template, params object[] parameters);
    }
}
