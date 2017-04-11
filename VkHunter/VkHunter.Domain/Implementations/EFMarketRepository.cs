using System;
using System.Linq;
using VkHunter.Domain.Entities;
using VkHunter.Domain.Interfaces;

namespace VkHunter.Domain.Implementations
{
    public class EFMarketRepository : EFRestRepository<Market>, IMarketRepository
    {
        public EFMarketRepository(VkDbContext dbContext) : base(dbContext)
        {
        }

        public Market AddOrUpdate(Market model)
        {
            var market = _dbContext.Markets.FirstOrDefault(x => x.VkId == model.VkId);

            if (market == null)
            {
                model.Date = DateTime.Now;
                market = base.Create(model);
            }
            else
            {
                // ...

                base.Update(market);
            }

            return market;
        }
    }
}
