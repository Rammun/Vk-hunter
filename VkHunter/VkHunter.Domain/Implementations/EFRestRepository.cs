using System.Collections.Generic;
using System.Linq;
using VkHunter.Domain.Interfaces;

namespace VkHunter.Domain.Implementations
{
    public class EFRestRepository<T> : IRestRepository<T> where T : class
    {
        protected readonly VkDbContext _dbContext;

        public EFRestRepository(VkDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _dbContext.Set<T>().ToList();
        }

        public virtual T GetById(int id)
        {
            return _dbContext.Set<T>().Find(id);
        }

        public virtual T Create(T model)
        {
            var entity = _dbContext.Set<T>().Add(model);
            return entity;
        }

        public virtual T Update(T model)
        {
            _dbContext.Entry(model);
            return model;
        }

        public virtual T Delete(int id)
        {
            var model = _dbContext.Set<T>().Find(id);
            var entity = _dbContext.Set<T>().Remove(model);

            return entity;
        }
    }
}
