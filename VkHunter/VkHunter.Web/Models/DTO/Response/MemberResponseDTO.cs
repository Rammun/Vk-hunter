using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using VkHunter.Domain.Constants;

namespace VkHunter.Web.Models.DTO.Response
{
    [JsonObject(MemberSerialization.OptIn, Title = "member")]
    public class MemberResponseDTO
    {
        /// <summary>
        /// Идентификационный номер в бд.
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Идентификационный номер в vk.
        /// </summary>
        [JsonProperty("vkId")]
        public int VkId { get; set; }

        /// <summary>
        /// Название группы или имя пользователя.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Ссылка на группу или пользователя.
        /// </summary>
        [JsonProperty("uri")]
        public string Uri { get; set; }

        /// <summary>
        /// Дополнительное описание.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Аватарка
        /// </summary>
        [JsonProperty("ava")]
        public string Ava { get; set; }

        /// <summary>
        /// Кол-во подписчиков
        /// </summary>
        [JsonProperty("membersCount")]
        public int? MembersCount { get; set; }

        /// <summary>
        /// Статус участника.
        /// </summary>
        [JsonProperty("state")]
        public HunterState State { get; set; }

        /// <summary>
        /// Дата последнего изменения статуса.
        /// </summary>
        [JsonProperty("date")]
        public DateTime Date { get; set; }

        /// <summary>
        /// Указывает, группа или пользователь
        /// </summary>
        [JsonProperty("type")]
        public MemberType Type { get; set; }

        /// <summary>
        /// Идентификационные номера проектов в бд.
        /// </summary>
        [JsonProperty("projects")]
        public IEnumerable<int> Projects { get; set; }
    }
}
