using System;
using VkHunter.Domain.Implementations;
using VkHunter.Domain.Interfaces;

namespace VkHunter.Domain
{
    public class DataManager : IDataManager
    {
        private VkDbContext _dbContext;

        private IProjectRepository _projectRepository;
        private ISearchRepository _searchRepository;
        private IMemberRepository _memberRepository;
        private IPostRepository _postRepository;
        private IMarketRepository _marketRepository;
        private IHistoryRepository _historyRepository;

        public IProjectRepository Projects => 
            _projectRepository ?? (_projectRepository = new EFProjectRepository(_dbContext));

        public ISearchRepository Searches => 
            _searchRepository ?? (_searchRepository = new EFSearchRepository(_dbContext));

        public IMemberRepository Members =>
            _memberRepository ?? (_memberRepository = new EFMemberRepository(_dbContext));
        
        public IPostRepository Posts => 
            _postRepository ?? (_postRepository = new EFPostRepository(_dbContext));

        public IMarketRepository Markets => 
            _marketRepository ?? (_marketRepository = new EFMarketRepository(_dbContext));

        public IHistoryRepository Histories => 
            _historyRepository ?? (_historyRepository = new EFHistoryRepository(_dbContext));

        public DataManager()
        {
            _dbContext = new VkDbContext();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        #region DISPOSE

        private bool disposed = false;

        public void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
