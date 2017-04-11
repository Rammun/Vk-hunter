using System;
using Newtonsoft.Json;
using VkHunter.Domain.Constants;

namespace VkHunter.DTO
{
    [JsonObject(MemberSerialization.OptIn, Title = "history")]
    public class HistoryResponseDTO
    {
        /// <summary>
        /// Идентификационный номер в бд
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public int Id { get; set; }

        /// <summary>
        /// Статус мониторинга
        /// </summary>
        [JsonProperty("state", NullValueHandling = NullValueHandling.Ignore)]
        public HunterState State { get; set; }

        /// <summary>
        /// Дата изменения последнего статуса
        /// </summary>
        [JsonProperty("date", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime Date { get; set; }

        /// <summary>
        /// Идентификационный номер данных в бд
        /// </summary>
        [JsonProperty("memberId", NullValueHandling = NullValueHandling.Ignore)]
        public int MemberId { get; set; }
    }
}
