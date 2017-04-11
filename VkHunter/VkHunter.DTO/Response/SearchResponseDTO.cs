using Newtonsoft.Json;

namespace VkHunter.DTO
{
    [JsonObject(MemberSerialization.OptIn, Title = "search")]
    public class SearchResponseDTO
    {
        /// <summary>
        /// Идентификационный номер в бд.
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public int Id { get; set; }

        /// <summary>
        /// Поисковый запрос.
        /// </summary>
        [JsonProperty("query", NullValueHandling = NullValueHandling.Ignore)]
        public string Query { get; set; }

        /// <summary>
        /// Флаг активности поискового запроса.
        /// </summary>
        [JsonProperty("active", NullValueHandling = NullValueHandling.Ignore)]
        public bool Active { get; set; }

        /// <summary>
        /// Идентификационный номер проекта.
        /// </summary>
        [JsonProperty("projectId", NullValueHandling = NullValueHandling.Ignore)]
        public int ProjectId { get; set; }
    }
}
