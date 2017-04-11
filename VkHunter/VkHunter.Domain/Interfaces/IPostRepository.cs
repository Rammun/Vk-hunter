using System.Collections.Generic;
using VkHunter.Domain.Entities;

namespace VkHunter.Domain.Interfaces
{
    public interface IPostRepository : IRestRepository<Post>
    {
        IEnumerable<Post> GetByVkId(string id);
    }
}
