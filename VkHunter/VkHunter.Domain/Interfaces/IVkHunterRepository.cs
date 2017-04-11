using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace VkHunter.Domain.Interfaces
{
    public interface IVkHunterRepository
    {
        IEnumerable<Group> AddProjectAndSeaches(string projectName, IEnumerable<string> seaches);
    }
}
