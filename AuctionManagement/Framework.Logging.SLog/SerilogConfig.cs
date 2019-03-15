using System;
using System.Collections.Generic;
using System.Text;
using Serilog;

namespace Framework.Logging.SLog
{
    public static class SerilogConfig
    {
        public static ILogger Config(string filepath)
        {
            //TODO: remove hard-coded settings
            return new LoggerConfiguration()
                .MinimumLevel.Error()      
                .WriteTo.File(filepath,
                    fileSizeLimitBytes: 50000000,
                    rollOnFileSizeLimit: true,
                    rollingInterval: RollingInterval.Day)
                .CreateLogger();
        }
    }
}
