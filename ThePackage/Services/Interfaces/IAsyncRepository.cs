using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ThePackage.Services.Interfaces
{
    public interface IAsyncRepository<T>
    {
        Task CreateAsync(T item);
        Task<T> FindById(int id);
        IEnumerable<T> Get(Func<T, bool> predicate);
        IQueryable<T> GetAll();
        Task RemoveAsync(int id);
        Task UpdateAsync(T item);
    }
}
