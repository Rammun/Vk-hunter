using System.Collections.Generic;
using System.Linq;
using VkHunter.Domain.Entities;
using VkHunter.Domain.Interfaces;

namespace VkHunter.Domain.Implementations
{
    public class EFHistoryRepository : EFRestRepository<History>, IHistoryRepository
    {
        public EFHistoryRepository(VkDbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<History> GetByMemberId(int memberId)
        {
            return _dbContext
                .Histories
                .Where(x => x.MemberId == memberId);
        }
    }
}
