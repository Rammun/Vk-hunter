namespace VkHunter.Web.Constants
{
    public class DefaultSetting
    {
        /// <summary>
        /// Имя используемой строки соединения с БД
        /// </summary>
        public const string ConnectionString = "DefaultConnection";

        /// <summary>
        /// Адрес хоста
        /// </summary>
        public const string BaseUrl = @"http://localhost:9000/";

        /// <summary>
        /// Время обновления данных по расписанию
        /// </summary>
        public const string TimeUpdate = "06:00";

        /// <summary>
        /// Тема email об ошибке
        /// </summary>
        public const string EmailSubject = "VkHelper";
    }
}
