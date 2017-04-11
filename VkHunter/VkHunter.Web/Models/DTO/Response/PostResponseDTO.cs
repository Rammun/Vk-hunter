using System.Collections.Generic;
using Newtonsoft.Json;

namespace VkHunter.Web.Models.DTO.Response
{
    [JsonObject(MemberSerialization.OptIn, Title = "post")]
    public class PostResponseDTO
    {
        /// <summary>
        /// Идентификационный номер в бд
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Тело поста
        /// </summary>
        [JsonProperty("text")]
        public string Text { get; set; }

        /// <summary>
        /// Описание
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Ссылки на прикоепленные картинки
        /// </summary>
        [JsonProperty("photoUri")]
        public string PhotoUri { get; set; }

        /// <summary>
        /// Идентификационный номер автора поста в бд
        /// </summary>
        [JsonProperty("memberId")]
        public int MemberId { get; set; }
    }
}
