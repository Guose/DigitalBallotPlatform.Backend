using Serilog;

namespace DigitalBallotPlatform.Shared.Logger
{
    public static class LoggerConfigurationHelper
    {
        public static void ConfigureLogging()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();
        }
    }
}
