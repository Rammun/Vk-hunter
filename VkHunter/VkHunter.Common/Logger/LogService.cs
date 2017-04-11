using NLog;

namespace VkHunter.Common.Logger
{
    /// <summary>
    /// Кокретная реализация логера через NLog
    /// </summary>
    public class LogService : ILogService
    {
        ILogger logger = LogManager.GetLogger(nameof(VkHunter));

        public void Debug(string message, params object[] property)
        {
            logger.Debug(message);
        }

        public void Error(string message, params object[] property)
        {
            logger.Error(message);
        }

        public void Warning(string message, params object[] property)
        {
            logger.Warn(message);
        }

        public void Information(string message, params object[] property)
        {
            logger.Info(message);
        }
    }
}
