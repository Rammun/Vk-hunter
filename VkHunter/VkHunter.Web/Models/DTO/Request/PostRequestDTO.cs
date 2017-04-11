using System.Collections.Generic;

namespace VkHunter.Web.Models.DTO.Request
{
    public class PostRequestDTO
    {
        /// <summary>
        /// Идентификационный номер в бд
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Заголовок
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Описание
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Ссылки на прикоепленные картинки
        /// </summary>
        public IEnumerable<string> PhotoUri { get; set; }

        /// <summary>
        /// Идентификационный номер автора поста в бд
        /// </summary>
        public int MemberId { get; set; }
    }
}
