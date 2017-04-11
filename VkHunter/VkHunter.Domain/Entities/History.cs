using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VkHunter.Domain.Constants;

namespace VkHunter.Domain.Entities
{
    public class History
    {
        /// <summary>
        /// Идентификационный номер в бд
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Статус мониторинга
        /// </summary>
        public HunterState State { get; set; }

        /// <summary>
        /// Дата изменения последнего статуса
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Идентификационный номер данных в бд
        /// </summary>
        public int MemberId { get; set; }

        /// <summary>
        /// Данные, которым принадлежит история
        /// </summary>
        [ForeignKey(nameof(MemberId))]
        public Member Member { get; set; }
    }
}
