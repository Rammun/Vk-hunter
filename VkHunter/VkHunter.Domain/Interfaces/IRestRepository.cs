using System.Collections.Generic;

namespace VkHunter.Domain.Interfaces
{
    public interface IRestRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        T Create(T model);
        T Update(T model);
        T Delete(int id);
    }
}
