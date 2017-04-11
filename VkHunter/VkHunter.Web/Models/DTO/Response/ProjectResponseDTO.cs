using System.Collections.Generic;
using Newtonsoft.Json;

namespace VkHunter.Web.Models.DTO.Response
{
    [JsonObject(MemberSerialization.OptIn, Title = "project")]
    public class ProjectResponseDTO
    {
        /// <summary>
        /// Идентификационный номер в бд
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Идентификационный номер для внешнего использования
        /// </summary>
        [JsonProperty("externalId")]
        public int? ExternalId { get; set; }

        /// <summary>
        /// Имя проекта
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Флаг активности проекта.
        /// </summary>
        [JsonProperty("active")]
        public bool Active { get; set; }

        /// <summary>
        /// Список поисковых запросов.
        /// </summary>
        [JsonProperty("searches")]
        public IEnumerable<SearchResponseDTO> Searches { get; set; } 
    }
}
