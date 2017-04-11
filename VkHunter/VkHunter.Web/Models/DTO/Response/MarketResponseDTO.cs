using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace VkHunter.Web.Models.DTO.Response
{
    [JsonObject(MemberSerialization.OptIn, Title = "market")]
    public class MarketResponseDTO
    {
        /// <summary>
        /// Идентификационный номер магазина в бд
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Идентификационный номер магазина в vk
        /// </summary>
        [JsonProperty("vkId")]
        public int VkId { get; set; }

        /// <summary>
        /// Название магазина
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Дата обновления данных
        /// </summary>
        [JsonProperty("date")]
        public DateTime Date { get; set; }

        /// <summary>
        /// Идентификационный номер проекта в бд
        /// </summary>
        [JsonProperty("projectId")]
        public int ProjectId { get; set; }
    }
}
