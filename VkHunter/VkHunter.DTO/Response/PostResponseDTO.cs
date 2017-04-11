using Newtonsoft.Json;

namespace VkHunter.DTO
{
    [JsonObject(MemberSerialization.OptIn, Title = "post")]
    public class PostResponseDTO
    {
        /// <summary>
        /// Идентификационный номер в бд
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public int Id { get; set; }

        /// <summary>
        /// Тело поста
        /// </summary>
        [JsonProperty("text", NullValueHandling = NullValueHandling.Ignore)]
        public string Text { get; set; }

        /// <summary>
        /// Описание
        /// </summary>
        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }

        /// <summary>
        /// Ссылки на прикоепленные картинки
        /// </summary>
        [JsonProperty("photoUri", NullValueHandling = NullValueHandling.Ignore)]
        public string PhotoUri { get; set; }

        /// <summary>
        /// Идентификационный номер автора поста в бд
        /// </summary>
        [JsonProperty("memberId", NullValueHandling = NullValueHandling.Ignore)]
        public int MemberId { get; set; }
    }
}
