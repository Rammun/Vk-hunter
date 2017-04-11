using System;
using VkHunter.Domain.Constants;

namespace VkHunter.DTO
{
    public class HistoryRequestDTO
    {
        /// <summary>
        /// Идентификационный номер в бд
        /// </summary>
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
    }
}
