using System;

namespace VkHunter.Domain.Interfaces
{
    public interface IDataManager : IDisposable
    {
        IProjectRepository Projects { get; }
        ISearchRepository Searches { get; }
        IMemberRepository Members { get; }
        IPostRepository Posts { get; }
        IMarketRepository Markets { get; }
        IHistoryRepository Histories { get; }

        void Save();
    }
}
