using System;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
using System.Text;

namespace VkHunter.Common.Helpers
{
    public class CommonHelper
    {
        /// <summary>
        /// Получает значение параметра настроек приложения по ключу.
        /// </summary>
        /// <param name="key">Ключ параметра настроек.</param>
        /// <returns>Значение параметра настроек приложения.</returns>
        public static string GetConfigByKey(string key)
        {
            return ConfigurationManager.AppSettings.AllKeys.Contains(key)
               ? ConfigurationManager.AppSettings[key]
               : null;
        }

        /// <summary>
        /// Возвращает значение параметра настроек приложения по ключу в app.config,
        /// если отсутствует - значение по умолчанию.
        /// </summary>
        /// <param name="key">Ключ параметра настроек в app.config.</param>
        /// <param name="defaultVale">Значение по умолчанию</param>
        /// <returns>Значение параметра настроек приложения.</returns>
        public static string GetConfigOrDefault(string key, string defaultVale)
        {
            return ConfigurationManager.AppSettings.AllKeys.Contains(key)
                ? ConfigurationManager.AppSettings[key]
                : defaultVale;
        }

        public static bool SendEmail(string destination, string body)
        {
            const string from = "admin@market.com";
            const string subject = "VkHunter";

            // создаем письмо: message.Destination - адрес получателя
            var mail = new MailMessage(from, destination, subject, body);

            var client = new SmtpClient();

            try
            {
                client.SendMailAsync(mail).Wait();
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return false;
            }
        }

        /// <summary>
        /// Исключает из строки непачатные символы
        /// </summary>
        /// <param name="word">Строка</param>
        /// <returns>Строка</returns>
        public static string GetReg(string word)
        {
            var res = new StringBuilder();
            foreach (var ch in word.Where(ch => ch >= 5 && ch <= 1120))
            {
                res.Append(ch);
            }

            return res.ToString();

            // Не работает, всеравно пропускает непечатные символы
            //var temp = Regex.Replace(word, @"(![\w\s\d\p{P}]+)", "", RegexOptions.CultureInvariant);
            //return temp;
        }
    }
}
