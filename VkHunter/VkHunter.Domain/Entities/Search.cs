using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VkHunter.Domain.Entities
{
    public class Search
    {
        /// <summary>
        /// Идентификационный номер в бд
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Поисковй запрос
        /// </summary>
        public string Query { get; set; }

        /// <summary>
        /// Флаг активности поискового запроса
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        /// Идентификационный номер проекта в бд
        /// </summary>
        public int ProjectId { get; set; }

        /// <summary>
        /// Проект, по запросу которому принадлежит запрос
        /// </summary>
        [ForeignKey(nameof(ProjectId))]
        public virtual Project Project { get; set; }
    }
}
