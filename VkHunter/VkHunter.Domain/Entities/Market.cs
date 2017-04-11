using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VkHunter.Domain.Entities
{
    public class Market
    {
        /// <summary>
        /// Идентификационный номер магазина в бд
        /// </summary>
        [Key]
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

        /// <summary>
        /// Проект, по запросу которого найден магазин
        /// </summary>
        [ForeignKey(nameof(ProjectId))]
        public virtual Project Project { get; set; } 
    }
}
