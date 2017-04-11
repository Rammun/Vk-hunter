using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VkHunter.Domain.Entities
{
    public class Post
    {
        /// <summary>
        /// Идентификационный номер в бд
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Идентификационный номер владельца в vk плюс идентификатор поста.
        /// </summary>
        public string VkId { get; set; }

        /// <summary>
        /// Заголовок
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Ссылка на пост
        /// </summary>
        public string Uri { get; set; }

        /// <summary>
        /// Ссылки на прикоепленные картинки
        /// </summary>
        public string PhotoUri { get; set; }

        /// <summary>
        /// Идентификационный номер автора поста в бд
        /// </summary>
        public int MemberId { get; set; }

        /// <summary>
        /// Автор поста
        /// </summary>
        [ForeignKey(nameof(MemberId))]
        public Member Member { get; set; }

    }
}
