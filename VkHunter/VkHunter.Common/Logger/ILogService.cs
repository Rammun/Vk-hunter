namespace VkHunter.Common.Logger
{
    /// <summary>
    /// Описывает методы логера.
    /// </summary>
    public interface ILogService
    {
        void Debug(string message, params object[] property);
        void Error(string message, params object[] property);
        void Warning(string message, params object[] property);
        void Information(string message, params object[] property);
    }
}
