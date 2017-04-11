using System;
using System.Linq;
using System.Threading;
using AutoMapper;
using VkHunter.BusinessLogic.Interfaces;
using VkHunter.BusinessLogic.Models;
using VkHunter.Domain.Constants;
using VkHunter.Domain.Entities;
using VkHunter.Domain.Interfaces;
using VkHunter.Web.Mapping;

namespace VkHunter.Web
{
    public class VkWorker
    {
        protected readonly IVkService _vkService;
        protected readonly IDataManager _dataManager;
        protected readonly IMapper _mapper;

        public VkWorker(IVkService vkService, IDataManager dataManager)
        {
            _vkService = vkService;
            _dataManager = dataManager;
            _mapper = AutoMapperConfiguration.CreateMappings();
        }

        /// <summary>
        /// Запускает обновление данных из vk.
        /// Метод использует библиотеку VkApiNet. Выбирает больше данных (1000 групп и 200 постов) за запрос, 
        /// но на один поиск уходит около 30 сек.
        /// </summary>
        public virtual void DataUpdate()
        {
            // Ищем старые статусы NoInfringement и обновляем их на New
            ChangeOldState();

            _dataManager.Save();

            var projects = _dataManager
                .Projects
                .GetAll()
                .ToList();

            foreach (var project in projects.Where(x => x.Active))
            {
                foreach (var search in project.Searches.Where(x => x.Active))
                {
                    // Собираем данные о группах
                    GroupHandler(search.Query, project);

                    // Собираем данные из постов
                    PostHandler(search.Query, project);
                }
            }
        }
        
        /// <summary>
        /// Изменяет статусы NoInfringement старше недели на New.
        /// </summary>
        protected void ChangeOldState()
        {
            var memberIds = _dataManager
                .Members
                .GetByIsOldState(HunterState.NoInfringement)
                .Select(x => x.Id);

            if(!memberIds.Any())
                return;

            _dataManager
                .Members
                .ChangeState(HunterState.New, memberIds);
        }

        /// <summary>
        /// На основе поискового запроса собирает данные о группах.
        /// </summary>
        /// <param name="query">Поисковая строка</param>
        /// <param name="project">Проект</param>
        protected void GroupHandler(string query, Project project)
        {
            var groupsVk = _vkService.GetGroups(query);

            var count = groupsVk.Count() / 400;  // Обновляем инфу о группах партиями по 400 шт

            for (var i = 0; i <= count; i++)
            {
                var ids = groupsVk
                    .Skip(i * 400)
                    .Take(400)
                    .Select(x => x.Id.ToString())
                    .ToArray();

                var groups = _vkService.GetGroupsByIds(ids);

                foreach (var group in groups)
                {
                    AddOrUpdateGroup(group, project);
                }
            }

            _dataManager.Save();
        }

        /// <summary>
        /// На основе поискового запроса собирает данные о постах и их владельцах.
        /// </summary>
        /// <param name="query">Поисковая строка</param>
        /// <param name="project">Проект</param>
        protected void PostHandler(string query, Project project)
        {
            var posts = _vkService.GetNewsfeeds(query);

            if (!posts.Any())   // Иногда запрос возвращает пустые данные, поэтому делаем контрольный запрос
            {
                Thread.Sleep(400);
                posts = _vkService.GetNewsfeeds(query);
            }

            var groupsPosts = posts.Where(x => x.FromId < 0);
            var usersPosts = posts.Where(x => x.FromId > 0);

            var gIds = groupsPosts.Select(x => (-x.FromId).ToString()).ToArray();
            var groups = _vkService.GetGroupsByIds(gIds);

            foreach (var group in groups)
            {
                var member = AddOrUpdateGroup(group, project);

                var post = groupsPosts.FirstOrDefault(x => -x.FromId == member.VkId);

                AddPost(member, post);
            }

            var uIds = usersPosts.Select(x => x.FromId).ToArray();
            var users = _vkService.GetUsersByIds(uIds);

            foreach (var user in users)
            {
                var member = AddOrUpdateUser(user, project);

                var post = usersPosts.FirstOrDefault(x => x.FromId == member.VkId);

                AddPost(member, post);
            }

            _dataManager.Save();
        }

        /// <summary>
        /// Добавляет или обновляет данные о группе.
        /// </summary>
        /// <param name="group">Группа в vk</param>
        /// <param name="project">Проект</param>
        /// <returns>Участник</returns>
        protected Member AddOrUpdateGroup(VkGroup group, Project project)
        {
            Member resultMember;

            var memberEntity = _dataManager.Members.GetByVkId(group.Id, MemberType.Group)
                .FirstOrDefault(x => x.ProjectId == project.Id);

            if (memberEntity == null)
            {
                var member = _mapper.Map<VkGroup, Member>(group);
                member.Project = project;
                member.Type = MemberType.Group;
                member.Date = DateTime.Now;
                member.State = HunterState.New;

                resultMember = _dataManager
                    .Members
                    .Create(member);
            }
            else
            {
                var tempMemeber = CheckStatus(memberEntity);

                tempMemeber.Name = group.Name;
                tempMemeber.Description = group.Description;
                tempMemeber.Ava = group.Ava;
                tempMemeber.MembersCount = group.MembersCount;

                resultMember = _dataManager
                    .Members
                    .Update(tempMemeber);
            }

            return resultMember;
        }

        /// <summary>
        /// Добавляет или обновляет данные о пользователе.
        /// </summary>
        /// <param name="user">Пользователь в vk</param>
        /// <param name="project">Проект</param>
        /// <returns>Участник</returns>
        protected Member AddOrUpdateUser(VkUser user, Project project)
        {
            Member resultMember;

            var memberEntity = _dataManager.Members.GetByVkId(user.Id, MemberType.User)
                .FirstOrDefault(x => x.ProjectId == project.Id);

            if (memberEntity == null)
            {
                var member = _mapper.Map<VkUser, Member>(user);
                member.Project = project;
                member.Type = MemberType.User;
                member.Date = DateTime.Now;
                member.State = HunterState.New;

                resultMember = _dataManager
                    .Members
                    .Create(member);
            }
            else
            {
                var tempMemeber = CheckStatus(memberEntity);

                tempMemeber.Name = user.Name;
                tempMemeber.Ava = user.Ava;
                tempMemeber.MembersCount = user.MembersCount;

                resultMember = _dataManager
                    .Members
                    .Update(tempMemeber);
            }

            return resultMember;
        }

        /// <summary>
        /// Добавляет пост в бд, если его там нет.
        /// </summary>
        /// <param name="member">Участник</param>
        /// <param name="post">Пост</param>
        protected void AddPost(Member member, VkPost post)
        {
            var temp = _dataManager
                .Posts
                .GetByVkId($"{member.VkId}_{post.Id}")
                .FirstOrDefault(x => x.MemberId == member.Id);

            if (temp != null)
                return;

            var postEntity = _mapper.Map<VkPost, Post>(post);
            member.Posts.Add(postEntity);
        }

        protected Member CheckStatus(Member member)
        {
            if (member.State == HunterState.Exported && member.Date < DateTime.Now - TimeSpan.FromDays(7))
            {
                var members = _dataManager
                .Members
                .ChangeState(HunterState.New, new[] { member.Id });

                return members.ElementAtOrDefault(0);
            }

            return member;
        }
    }
}
