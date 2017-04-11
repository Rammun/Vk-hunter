using System.Collections.Generic;
using VkHunter.Domain.Constants;
using VkHunter.Domain.Entities;

namespace VkHunter.Domain.Interfaces
{
    public interface IMemberRepository : IRestRepository<Member>
    {
        /// <summary>
        /// Добавляет данные об участнике в историю.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        History AddToHistory(int id);

        /// <summary>
        /// Возвращает список групп по статусу. 
        /// </summary>
        /// <returns></returns>
        IEnumerable<Member> GetMembers(IEnumerable<HunterState> states, IEnumerable<int> projectIds, int? count);

        /// <summary>
        /// Возвращает участников по идентификацилнному номеру в vk. 
        /// </summary>
        /// <returns></returns>
        IEnumerable<Member> GetByVkId(long vkId, MemberType type);

        /// <summary>
        /// Возвращает список групп по статусу вместе с историей. 
        /// </summary>
        /// <returns></returns>
        IEnumerable<Member> GetByStateWithHistory(HunterState state, int? projectId, int? count);

        /// <summary>
        /// Возвращает список групп, статус которых не менялся больше недели.
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        IEnumerable<Member> GetByIsOldState(HunterState state);

        /// <summary>
        /// Создает в бд и добавляет участника в проект
        /// </summary>
        /// <param name="member">Участник</param>
        /// <param name="projectId">Идентификационный номер проекта</param>
        /// <returns><see cref="Member"/>Участник</returns>
        Member Create(Member member, int projectId);

        /// <summary>
        /// Изменяет статус списку групп
        /// </summary>
        /// <param name="state">Новый статус</param>
        /// <param name="memberIds">Список идентификационных номеров данных в бд</param>
        /// <returns>Список данных</returns>
        IEnumerable<Member> ChangeState(HunterState state, IEnumerable<int> memberIds);
    }
}
