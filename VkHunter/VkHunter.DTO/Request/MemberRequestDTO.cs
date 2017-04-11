using System;
using System.ComponentModel.DataAnnotations;
using VkHunter.Domain.Constants;

namespace VkHunter.DTO
{
    public class MemberRequestDTO
    {
        /// <summary>
        /// Идентификационный номер в бд.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Идентификационный номер в vk.
        /// </summary>
        [Required]
        public int? VkId { get; set; }

        /// <summary>
        /// Название группы или имя пользователя.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Ссылка на группу или пользователя.
        /// </summary>
        public string Uri { get; set; }
        
        /// <summary>
        /// Статус
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Url сайт
        /// </summary>
        public string Site { get; set; }

        /// <summary>
        /// Активность группы
        /// </summary>
        public string Activity { get; set; }
        
        /// <summary>
        /// Дополнительное описание.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Аватарка
        /// </summary>
        public string Ava { get; set; }

        /// <summary>
        /// Кол-во подписчиков
        /// </summary>
        public int? MembersCount { get; set; }

        /// <summary>
        /// Друзья пользователя
        /// </summary>
        public int? FriendsCount { get; set; }

        /// <summary>
        /// Поле пользователя "о себе"
        /// </summary>
        public string About { get; set; }

        /// <summary>
        /// Интересы пользователя
        /// </summary>
        public string Interests { get; set; }

        /// <summary>
        /// Деятельность пользователя
        /// </summary>
        public string Activities { get; set; }

        /// <summary>
        /// Статус участника.
        /// </summary>
        public HunterState State { get; set; }

        /// <summary>
        /// Дата последнего изменения статуса.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Указывает, группа или пользователь
        /// </summary>
        public MemberType Type { get; set; }

        /// <summary>
        /// Идентификационный номер проекта в бд.
        /// </summary>
        public int ProjectId { get; set; }
    }
}
