using System;
using Newtonsoft.Json;
using VkHunter.Domain.Constants;

namespace VkHunter.DTO
{
    [JsonObject(MemberSerialization.OptIn, Title = "member")]
    public class MemberResponseDTO
    {
        /// <summary>
        /// Идентификационный номер в бд.
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public int Id { get; set; }

        /// <summary>
        /// Идентификационный номер в vk.
        /// </summary>
        [JsonProperty("vkId", NullValueHandling = NullValueHandling.Ignore)]
        public int VkId { get; set; }

        /// <summary>
        /// Название группы или имя пользователя.
        /// </summary>
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        /// <summary>
        /// Ссылка на группу или пользователя.
        /// </summary>
        [JsonProperty("uri", NullValueHandling = NullValueHandling.Ignore)]
        public string Uri { get; set; }

        /// <summary>
        /// Статус
        /// </summary>
        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; set; }

        /// <summary>
        /// Url сайт
        /// </summary>
        [JsonProperty("site", NullValueHandling = NullValueHandling.Ignore)]
        public string Site { get; set; }

        /// <summary>
        /// Активность группы
        /// </summary>
        [JsonProperty("activity", NullValueHandling = NullValueHandling.Ignore)]
        public string Activity { get; set; }
        
        /// <summary>
        /// Дополнительное описание.
        /// </summary>
        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }

        /// <summary>
        /// Аватарка
        /// </summary>
        [JsonProperty("ava", NullValueHandling = NullValueHandling.Ignore)]
        public string Ava { get; set; }

        /// <summary>
        /// Кол-во подписчиков
        /// </summary>
        [JsonProperty("membersCount", NullValueHandling = NullValueHandling.Ignore)]
        public int? MembersCount { get; set; }

        /// <summary>
        /// Друзья пользователя
        /// </summary>
        [JsonProperty("friendsCount", NullValueHandling = NullValueHandling.Ignore)]
        public int? FriendsCount { get; set; }

        /// <summary>
        /// Поле пользователя "о себе"
        /// </summary>
        [JsonProperty("about", NullValueHandling = NullValueHandling.Ignore)]
        public string About { get; set; }

        /// <summary>
        /// Интересы пользователя
        /// </summary>
        [JsonProperty("interests", NullValueHandling = NullValueHandling.Ignore)]
        public string Interests { get; set; }

        /// <summary>
        /// Деятельность пользователя
        /// </summary>
        [JsonProperty("activities", NullValueHandling = NullValueHandling.Ignore)]
        public string Activities { get; set; }

        /// <summary>
        /// Статус участника.
        /// </summary>
        [JsonProperty("state", NullValueHandling = NullValueHandling.Ignore)]
        public HunterState State { get; set; }

        /// <summary>
        /// Дата последнего изменения статуса.
        /// </summary>
        [JsonProperty("date", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime Date { get; set; }

        /// <summary>
        /// Указывает, группа или пользователь
        /// </summary>
        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public MemberType Type { get; set; }

        /// <summary>
        /// Идентификационные номера проектов в бд.
        /// </summary>
        [JsonProperty("projectId", NullValueHandling = NullValueHandling.Ignore)]
        public int ProjectId { get; set; }
    }
}
