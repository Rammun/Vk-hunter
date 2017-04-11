using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VkHunter.Domain.Entities
{
    public class Project
    {
        /// <summary>
        /// Идентификационный номер в бд.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Идентификационный номер для внешнего .
        /// </summary>
        public int? ExternalId { get; set; }

        /// <summary>
        /// Имя проекта.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Флаг активности проекта
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        /// Список поисковых запросов.
        /// </summary>
        public virtual ICollection<Search> Searches { get; set; }
        
        /// <summary>
        /// Список найденых данных.
        /// </summary>
        public virtual ICollection<Member> Members { get; set; }

        public Project()
        {
            Searches = new List<Search>();
            Members = new List<Member>();
        }
    }
}
