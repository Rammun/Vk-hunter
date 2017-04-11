using System;
using Newtonsoft.Json;

namespace VkHunter.DTO
{
    [JsonObject(MemberSerialization.OptIn, Title = "market")]
    public class MarketResponseDTO
    {
        /// <summary>
        /// Идентификационный номер магазина в бд
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public int Id { get; set; }

        /// <summary>
        /// Идентификационный номер магазина в vk
        /// </summary>
        [JsonProperty("vkId", NullValueHandling = NullValueHandling.Ignore)]
        public int VkId { get; set; }

        /// <summary>
        /// Название магазина
        /// </summary>
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        /// <summary>
        /// Дата обновления данных
        /// </summary>
        [JsonProperty("date", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime Date { get; set; }

        /// <summary>
        /// Идентификационный номер проекта в бд
        /// </summary>
        [JsonProperty("projectId", NullValueHandling = NullValueHandling.Ignore)]
        public int ProjectId { get; set; }
    }
}
