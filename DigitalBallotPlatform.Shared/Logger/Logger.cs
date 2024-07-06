using Serilog;

namespace DigitalBallotPlatform.Shared.Logger
{
    public class Logger : ILogger
    {
        static Logger()
        {
            LoggerConfigurationHelper.ConfigureLogging();
        }

        public void CloseAndFlush()
        {
            Log.CloseAndFlush();
        }

        private string GetTimestamp()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        public void LogAudit(string action, int userId, string details, params object[] args)
        {
            string timestamp = GetTimestamp();
            Log.Information("[{Timestamp}] Audit: Action={Action}, UserId={UserId}, Details={Details}", timestamp, action, userId, details, args);
        }

        public void LogError(string message, params object[] args)
        {
            string timestamp = GetTimestamp();
            Log.Error("[{Timestamp}] " + message, timestamp, args);
        }

        public void LogError(Exception exception, string message, params object[] args)
        {
            string timestamp = GetTimestamp();
            Log.Error(exception, "[{Timestamp}] " + message, timestamp, args);
        }

        public void LogInformation(string message, params object[] args)
        {
            string timestamp = GetTimestamp();
            Log.Information("[{Timestamp}] " + message, timestamp, args);
        }

        public void LogWarning(string message, params object[] args)
        {
            string timestamp = GetTimestamp();
            Log.Warning("[{Timestamp}] " + message, timestamp, args);
        }
    }
}
