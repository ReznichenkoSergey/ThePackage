using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThePackage.Models.Abstract;

namespace ThePackage.Services.Interfaces
{
    public interface IService<T> where T : class
    {
        BaseRepository<T> Repository { get; set; }
        List<T> GetAll();
        T FindById(int id);
        void Create(T item);
        void Delete(int id);
        T Update(int id, T updatedItem);
        IQueryable<T> GetQuery();
    }
}
