using System;
using Newtonsoft.Json;
using VkHunter.Domain.Constants;

namespace VkHunter.Web.Models.DTO.Response
{
    [JsonObject(MemberSerialization.OptIn, Title = "history")]
    public class HistoryResponseDTO
    {
        /// <summary>
        /// Идентификационный номер в бд
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Статус мониторинга
        /// </summary>
        [JsonProperty("state")]
        public HunterState State { get; set; }

        /// <summary>
        /// Дата изменения последнего статуса
        /// </summary>
        [JsonProperty("date")]
        public DateTime Date { get; set; }

        /// <summary>
        /// Идентификационный номер данных в бд
        /// </summary>
        [JsonProperty("memberId")]
        public int MemberId { get; set; }
    }
}
