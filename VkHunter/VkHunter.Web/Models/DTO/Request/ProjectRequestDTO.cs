namespace VkHunter.Web.Models.DTO.Request
{
    public class ProjectRequestDTO
    {
        /// <summary>
        /// Идентификационный номер в бд
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Идентификационный номер для внешнего использования.
        /// </summary>
        public int? ExternalId { get; set; }

        /// <summary>
        /// Имя проекта.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Флаг активности проекта
        /// </summary>
        public bool Active { get; set; }
    }
}
