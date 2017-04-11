using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VkHunter.Domain.Constants;

namespace VkHunter.Web.Models.DTO.Request
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
        public int VkId { get; set; }

        /// <summary>
        /// Название группы или имя пользователя.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Ссылка на группу или пользователя.
        /// </summary>
        public string Uri { get; set; }

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
        /// Идентификационные номера проектов в бд.
        /// </summary>
        public IEnumerable<int> ProjectIds { get; set; }
    }
}
