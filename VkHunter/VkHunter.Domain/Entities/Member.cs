using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VkHunter.Domain.Constants;

namespace VkHunter.Domain.Entities
{
    public class Member
    {
        /// <summary>
        /// Идентификационный номер в бд
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Идентификационный номер в vk
        /// </summary>
        public long VkId { get; set; }

        /// <summary>
        /// Название группы или имя пользователя
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Ссылка а группу или пользователя
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
        /// Описание
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Аватарка
        /// </summary>
        public string Ava { get; set; }

        /// <summary>
        /// Численность аудитории
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
        /// Статус мониторинга
        /// </summary>
        public HunterState State { get; set; }

        /// <summary>
        /// Дата последнего изменения статуса
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Указывает, группа или пользователь
        /// </summary>
        public MemberType Type { get; set; }

        /// <summary>
        /// Идентификационный номер проекта в бд
        /// </summary>
        public int ProjectId { get; set; }

        /// <summary>
        /// Проект, по запросу которого найдены данные
        /// </summary>
        [ForeignKey(nameof(ProjectId))]
        public virtual Project Project { get; set; }

        /// <summary>
        /// Список постов
        /// </summary>
        public virtual ICollection<Post> Posts { get; set; }

        /// <summary>
        /// Список историй изменения статусов
        /// </summary>
        public virtual ICollection<History> Histories { get; set; }

        public Member()
        {
            Histories = new List<History>();
            Posts = new List<Post>();
        }
    }
}
