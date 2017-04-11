using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using VkHunter.Domain.Constants;
using VkHunter.Domain.Entities;
using VkHunter.Domain.Interfaces;

namespace VkHunter.Domain.Implementations
{
    public class EFMemberRepository : EFRestRepository<Member>, IMemberRepository
    {
        public EFMemberRepository(VkDbContext dbContext) : base(dbContext)
        {
        }

        /// <summary>
        /// Возвращает список всех участников.
        /// </summary>
        /// <returns>Список участников</returns>
        public override IEnumerable<Member> GetAll()
        {
            return _dbContext
                .Members
                .Include(x => x.Project);
        }

        /// <summary>
        /// По идентификатору в бд возвращает участника.
        /// </summary>
        /// <param name="id">Идентификатор в бд</param>
        /// <returns>Участник</returns>
        public override Member GetById(int id)
        {
            return _dbContext
                .Members
                .Include(x => x.Project)
                .FirstOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// Возвращает список участников по статусу. 
        /// </summary>
        /// <returns>Список участников</returns>
        public IEnumerable<Member> GetMembers(IEnumerable<HunterState> states, IEnumerable<int> projectIds, int? count)
        {
            var result = _dbContext
                .Members
                .Include(x => x.Project);

            if (states != null)
            {
                result = result.Where(x => states.Contains(x.State));
            }
            
            if (projectIds != null)
            {
                result = result.Where(x => projectIds.Contains(x.ProjectId));
            }
            
            return count == null
                ? result 
                : result.Take((int)count);
        }

        /// <summary>
        /// Возвращает участника по идентификацинному номеру в vk. 
        /// </summary>
        /// <returns>Участник</returns>
        public IEnumerable<Member> GetByVkId(long vkId, MemberType type)
        {
            return _dbContext
                .Members
                .Where(x => x.VkId == vkId && x.Type == type);
        }

        /// <summary>
        /// По статусу возвращает список участников с историей.
        /// </summary>
        /// <param name="state">Статус</param>
        /// <param name="projectId">Идентификатор проекта</param>
        /// <param name="count">Кол-во записей в ответе</param>
        /// <returns>Список участников</returns>
        public IEnumerable<Member> GetByStateWithHistory(HunterState state, int? projectId, int? count)
        {
            IEnumerable<Member> result = null;

            var groups = _dbContext
                .Members
                .Include(x => x.Histories)
                .Where(x => x.State == state);
            result = groups;

            if (projectId != null)
                result = groups.Where(x => x.ProjectId == projectId);

            return count == null
                ? result
                : result.Take((int)count);
        }

        /// <summary>
        /// Возвращает список групп, статус которых не менялся больше недели.
        /// </summary>
        /// <param name="state">Статус участника</param>
        /// <returns>Список участников</returns>
        public IEnumerable<Member> GetByIsOldState(HunterState state)
        {
            IEnumerable<Member> members = _dbContext
                .Members
                .Where(x => x.State == state)
                .ToList();

            var groups = members.Where(x => x.Date < (DateTime.Now - TimeSpan.FromDays(7)));
            return groups;
        }

        /// <summary>
        /// Создает в бд и добавляет участника в проект
        /// </summary>
        /// <param name="member">Участник</param>
        /// <param name="projectId">Идентификационный номер проекта</param>
        /// <returns><see cref="Member"/>Участник</returns>
        public Member Create(Member member, int projectId)
        {
            var project = _dbContext.Projects.Find(projectId);
            if (project == null)
                throw new Exception($"{ErrorMessage.NotFound} <{nameof(Project)}>");

            member.Project = project;
            member.Date = DateTime.Now;

            var result = this.Create(member);
            return result;
        }

        /// <summary>
        /// Изменяет статус списку групп
        /// </summary>
        /// <param name="state">Новый статус</param>
        /// <param name="memberIds">Список идентификационных номеров участников в бд</param>
        /// <returns>Список участников</returns>
        public IEnumerable<Member> ChangeState(HunterState state, IEnumerable<int> memberIds)
        {
            if (memberIds == null || !memberIds.Any())
                return default(IEnumerable<Member>);

            var members = _dbContext
                .Members
                .Where(x => memberIds.Contains(x.Id));

            foreach (var member in members)
            {
                if(member.State == state)
                    continue;

                AddNewHistory(member);

                member.State = state;
                member.Date = DateTime.Now;
                Update(member);
            }

            return members;
        }

        /// <summary>
        /// Добавляет состояние участника в историю
        /// </summary>
        /// <param name="id">Идентификатор участника в бд</param>
        /// <returns><see cref="History"/>История</returns>
        public History AddToHistory(int id)
        {
            var member = GetById(id);

            if (member == null)
                return null;

            var newHistory = AddNewHistory(member);
            return newHistory;
        }

        #region PRIVATE METHODS

        /// <summary>
        /// Сохраняет состояние участника в истории
        /// </summary>
        /// <param name="member">Участник</param>
        /// <returns><see cref="History"/>История</returns>
        private History AddNewHistory(Member member)
        {
            var newHistory = new History
            {
                State = member.State,
                Date = member.Date,
                Member = member
            };

            var result = _dbContext.Histories.Add(newHistory);
            return result;
        }

        #endregion
    }
}
