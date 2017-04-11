namespace VkHunter.Domain.Constants
{
    public enum HunterState
    {
        /// <summary>
        /// Ссылки при первом добавлении получают данный статус
        /// </summary>
        New,

        /// <summary>
        /// Данный статус получается снаружи.
        /// </summary>
        Authorized,

        /// <summary>
        /// Статус означает, что для этой группы или пользователя нет нарушения на неделю. 
        /// </summary>
        NoInfringement,

        /// <summary>
        /// Проставляется для групп/пользователей вместо No infringement, если No infringement статус был проставлен ранее.
        /// </summary>
        Blocked,

        /// <summary>
        /// Нет дополнительной логики. Проставляется снаружи.
        /// </summary>
        Infringing,

        /// <summary>
        /// Данный статус проставляется после Infringing.
        /// </summary>
        Exported
    }
}
