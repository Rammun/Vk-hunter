using System.Collections.Generic;
using Newtonsoft.Json;

namespace VkHunter.DTO
{
    [JsonObject(MemberSerialization.OptIn, Title = "project")]
    public class ProjectResponseDTO
    {
        /// <summary>
        /// Идентификационный номер в бд
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public int Id { get; set; }

        /// <summary>
        /// Идентификационный номер для внешнего использования
        /// </summary>
        [JsonProperty("externalId", NullValueHandling = NullValueHandling.Ignore)]
        public int? ExternalId { get; set; }

        /// <summary>
        /// Имя проекта
        /// </summary>
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        /// <summary>
        /// Флаг активности проекта.
        /// </summary>
        [JsonProperty("active", NullValueHandling = NullValueHandling.Ignore)]
        public bool Active { get; set; }

        /// <summary>
        /// Список поисковых запросов.
        /// </summary>
        [JsonProperty("searches", NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<SearchResponseDTO> Searches { get; set; } 
    }
}
