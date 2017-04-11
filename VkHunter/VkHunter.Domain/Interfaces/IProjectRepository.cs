using System.Collections.Generic;
using VkHunter.Domain.Entities;

namespace VkHunter.Domain.Interfaces
{
    public interface IProjectRepository : IRestRepository<Project>
    {
        Project AddProjectAndQueries(string projectName, IEnumerable<string> queries);
    }
}
