using System.Collections.Generic;
using VkHunter.Domain.Entities;

namespace VkHunter.Domain.Interfaces
{
    public interface IHistoryRepository : IRestRepository<History>
    {
        IEnumerable<History> GetByMemberId(int memberId);
    }
}
