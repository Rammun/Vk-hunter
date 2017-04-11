using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VkHunter.DTO
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
