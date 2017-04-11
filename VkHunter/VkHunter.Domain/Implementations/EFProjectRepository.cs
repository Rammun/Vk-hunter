using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using VkHunter.Domain.Entities;
using VkHunter.Domain.Interfaces;

namespace VkHunter.Domain.Implementations
{
    public class EFProjectRepository : EFRestRepository<Project>, IProjectRepository
    {
        public EFProjectRepository(VkDbContext dbContext) : base(dbContext)
        {
        }
        
        public override IEnumerable<Project> GetAll()
        {
            return _dbContext
                .Projects
                .Include(x => x.Searches);
        }

        public override Project GetById(int id)
        {
            return _dbContext
                .Projects
                .Include(x => x.Searches)
                .FirstOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// Если проект не существует - то создастся новый проект. Если существует - заменятся поисковые запросы.
        /// </summary>
        /// <param name="projectName">Имя проекта</param>
        /// <param name="queries">Список поисковых запросов</param>
        /// <returns><see cref="Project"/>Проект</returns>
        public Project AddProjectAndQueries(string projectName, IEnumerable<string> queries)
        {
            var project = _dbContext
                .Projects
                .Include(x => x.Searches)
                .FirstOrDefault(x => x.Name == projectName);

            if (project == null)
            {
                var newProject = new Project
                {
                    Name = projectName
                };

                foreach (var query in queries)
                {
                    newProject.Searches.Add(new Search
                    {
                        Query = query
                    });
                }

                return Create(newProject);
            }
            
            foreach (var search in project.Searches)
            {
                Delete(search.Id);
            }

            foreach (var query in queries)
            {
                project.Searches.Add(new Search
                {
                    Query = query
                });
            }

            return Update(project);
        }
    }
}
