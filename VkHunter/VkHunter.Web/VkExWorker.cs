using System.Diagnostics;
using System.Linq;
using VkHunter.BusinessLogic.Interfaces;
using VkHunter.Domain.Constants;
using VkHunter.Domain.Entities;
using VkHunter.Domain.Interfaces;

namespace VkHunter.Web
{
    public class VkExWorker : VkWorker
    {
        public VkExWorker(IVkService vkService, IDataManager dataManager)
            : base(vkService, dataManager)
        {
        }

        /// <summary>
        /// Запускает обновление данных из vk.
        /// Использует метод execute vk api. Выбирает меньше данных (200 групп и 200 постов) за запрос,
        /// но на один поисковой шаблон уходит около 5 сек.
        /// </summary>
        public override void DataUpdate()
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
                    var result = _vkService.DataExecute(search.Query);

                    foreach (var group in result.Groups)
                    {
                        AddOrUpdateGroup(group, project);
                    }
                    _dataManager.Save();

                    foreach (var user in result.Users)
                    {
                        AddOrUpdateUser(user, project);
                    }
                    _dataManager.Save();

                    foreach (var post in result.Posts)
                    {
                        Member member;
                        if (post.FromId < 0)
                        {
                            member = _dataManager.Members.GetByVkId(-post.FromId, MemberType.Group)
                                .FirstOrDefault(x => x.ProjectId == project.Id);
                        }
                        else
                        {
                            member = _dataManager.Members.GetByVkId(post.FromId, MemberType.User)
                                .FirstOrDefault(x => x.ProjectId == project.Id);
                        }

                        if (member != null)
                        {
                            AddPost(member, post);
                        }
                        else
                        {
                            Debug.WriteLine($"В БД не найден владелец поста id={post.Id}, fromId={post.FromId}");
                        }
                    }
                    _dataManager.Save();
                }
            }
        }
    }
}
