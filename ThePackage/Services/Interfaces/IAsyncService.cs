using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThePackage.Models.Abstract;

namespace ThePackage.Services.Interfaces
{
    public interface IAsyncService<T> where T : class
    {
        GenericAsyncRepository<T> Repository { get; set; }
        IQueryable<T> GetAll();
        Task<T> FindByIdAsync(int id);
        Task CreateAsync(T item);
        Task DeleteAsync(int id);
        Task UpdateAsync(T updatedItem);
        IQueryable<T> GetQuery();
    }
}
