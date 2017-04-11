using VkHunter.Domain.Entities;
using VkHunter.Domain.Interfaces;

namespace VkHunter.Domain.Implementations
{
    public class EFSearchRepository : EFRestRepository<Search>, ISearchRepository
    {
        public EFSearchRepository(VkDbContext dbContext) : base(dbContext)
        {
        }
    }
}
