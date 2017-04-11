using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using VkHunter.Domain.Entities;
using VkHunter.Domain.Interfaces;
using System.Data.Entity;

namespace VkHunter.Domain.Implementations
{
    public class EFPostRepository : EFRestRepository<Post>, IPostRepository
    {
        public EFPostRepository(VkDbContext dbContext) : base(dbContext)
        {   
        }
        
        public IEnumerable<Post> GetByVkId(string id)
        {
            return _dbContext
                .Posts
                .Include(x => x.Member)
                .Where(x => x.VkId == id);
        }
    }
}
