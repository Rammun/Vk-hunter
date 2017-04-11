using System;

namespace VkHunter.DTO
{
    public class MarketRequestDTO
    {
        /// <summary>
        /// Идентификационный номер магазина в бд
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Идентификационный номер магазина в vk
        /// </summary>
        public int VkId { get; set; }

        /// <summary>
        /// Название магазина
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Дата обновления данных
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Идентификационный номер проекта в бд
        /// </summary>
        public int ProjectId { get; set; }
    }
}
