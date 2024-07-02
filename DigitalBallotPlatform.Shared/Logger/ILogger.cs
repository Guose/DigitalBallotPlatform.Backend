namespace DigitalBallotPlatform.Shared.Logger
{
    public interface ILogger
    {
        void LogInformation(string message, params object[] args);
        void LogWarning(string message, params object[] args);
        void LogError(string message, params object[] args);
        void LogError(Exception exception, string message, params object[] args);
        void LogAudit(string action, int userId, string details, params object[] args);
        void CloseAndFlush();
    }
}
