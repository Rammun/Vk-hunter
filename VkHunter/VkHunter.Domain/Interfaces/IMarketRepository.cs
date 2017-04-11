using VkHunter.Domain.Entities;

namespace VkHunter.Domain.Interfaces
{
    public interface IMarketRepository : IRestRepository<Market>
    {
        Market AddOrUpdate(Market model);
    }
}
