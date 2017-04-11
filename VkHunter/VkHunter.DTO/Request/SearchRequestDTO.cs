namespace VkHunter.DTO
{
    public class SearchRequestDTO
    {
        /// <summary>
        /// Идентификационный номер в бд.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Поисковый запрос.
        /// </summary>
        public string Query { get; set; }

        /// <summary>
        /// Флаг активности поискового запроса.
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        /// Идентификационный номер проекта.
        /// </summary>
        public int ProjectId { get; set; }
    }
}
