﻿using System.ComponentModel.DataAnnotations;

namespace VkHunter.Web.Models.DTO.Request
{
    public class LoginRequestDTO
    {
        /// <summary>
        /// Логин пользователя
        /// </summary>
        [Required, StringLength(60)]
        public string UserName { get; set; }

        /// <summary>
        /// Пароль пользователя
        /// </summary>
        [Required, StringLength(60), MinLength(6)]
        public string Password { get; set; }
    }
}
