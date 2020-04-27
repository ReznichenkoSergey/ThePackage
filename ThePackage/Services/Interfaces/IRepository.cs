using System;
using System.Linq;
using System.Linq.Expressions;

namespace ThePackage.Services.Interfaces
{
    public interface IRepository<T>
    {
        void Create(T item);
        T FindById(int id);
        IQueryable<T> Get(Expression<Func<T, bool>> predicate);
        IQueryable<T> GetAll();
        void Remove(int id);
        void Update(T item);
    }
}
