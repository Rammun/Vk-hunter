using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VkHunter.Domain.Constants;

namespace VkHunter.DTO
{
    public class GetMembersRequestDTO
    {
        /// <summary>
        /// Статус участника.
        /// </summary>
        [Required]
        public IEnumerable<HunterState> States { get; set; }

        /// <summary>
        /// Идентификационный номер проекта в бд.
        /// </summary>
        public IEnumerable<int> ProjectIds { get; set; }

        /// <summary>
        /// Кол-во первых найденных участников.
        /// </summary>
        public int? Count { get; set; }
    }
}
