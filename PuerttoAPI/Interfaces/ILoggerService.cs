namespace PuerttoAPI.Interfaces
{
    public interface ILoggerService : IDisposable
    {
        void LogInfo(string message);

        void LogWarn(string message);

        void LogDebug(string message);

        void LogError(string message);

        void LogException(Exception exception);
    }
}
