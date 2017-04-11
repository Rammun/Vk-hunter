using Newtonsoft.Json;

namespace VkHunter.Web.Models.DTO.Response
{
    [JsonObject(MemberSerialization.OptIn, Title = "search")]
    public class SearchResponseDTO
    {
        /// <summary>
        /// Идентификационный номер в бд.
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Поисковый запрос.
        /// </summary>
        [JsonProperty("query")]
        public string Query { get; set; }

        /// <summary>
        /// Флаг активности поискового запроса.
        /// </summary>
        [JsonProperty("active")]
        public bool Active { get; set; }

        /// <summary>
        /// Идентификационный номер проекта.
        /// </summary>
        [JsonProperty("projectId")]
        public int ProjectId { get; set; }
    }
}
