using System;
using Framework.Core;
using Serilog.Events;

namespace Framework.Logging.SLog
{
    public class SerilogAdapter : ILogger
    {
        private readonly Serilog.ILogger _logger;
        public SerilogAdapter(Serilog.ILogger logger)
        {
            _logger = logger;
        }
        public void LogFatal(string template, params object[] parameters)
        {
            _logger.Write(LogEventLevel.Fatal, template, parameters);
        }

        public void LogFatal(Exception exception)
        {
            _logger.Write(LogEventLevel.Fatal, exception,"");
        }

        public void LogError(string template, params object[] parameters)
        {
            _logger.Write(LogEventLevel.Error, template, parameters);
        }

        public void LogError(Exception exception)
        {
            _logger.Write(LogEventLevel.Error, exception,"");
        }

        public void LogWarning(string template, params object[] parameters)
        {
            _logger.Write(LogEventLevel.Warning, template, parameters);
        }

        public void LogInfo(string template, params object[] parameters)
        {
            _logger.Write(LogEventLevel.Information, template, parameters);
        }

        public void LogDebug(string template, params object[] parameters)
        {
            _logger.Write(LogEventLevel.Debug, template, parameters);
        }
    }
}
