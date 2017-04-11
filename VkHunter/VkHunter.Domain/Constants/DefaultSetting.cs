using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VkHunter.Domain.Constants
{
    public class DefaultSetting
    {
        /// <summary>
        /// Имя ключа параметра, указывающий email администратора
        /// </summary>
        public const string AdminUserNameKey = "adminUser";

        /// <summary>
        /// Имя ключа параметра, указывающий пароль администратора
        /// </summary>
        public const string AdminPasswordKey = "adminPassword";

        /// <summary>
        /// Значение по умолчанию для email администратора
        /// </summary>
        public const string AdminUserName = "admin@admin.com";

        /// <summary>
        /// Значение по умолчанию для пароля администратора
        /// </summary>
        public const string AdminPassword = "qwerty";
    }
}
