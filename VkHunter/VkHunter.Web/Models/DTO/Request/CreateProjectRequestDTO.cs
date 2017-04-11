using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VkHunter.Web.Models.DTO.Request
{
    public class CreateProjectRequestDTO
    {
        /// <summary>
        /// Имя проекта
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Список поисковых запросов
        /// </summary>
        public IEnumerable<string> Queries { get; set; }
    }
}
