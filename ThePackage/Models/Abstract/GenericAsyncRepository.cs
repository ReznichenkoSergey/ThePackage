using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThePackage.Models.Database;
using ThePackage.Services.Interfaces;

namespace ThePackage.Models.Abstract
{
    public class GenericAsyncRepository<T> : IAsyncRepository<T> where T : class
    {
        private readonly PackageDbContext dbContext;
        protected readonly DbSet<T> dbSet;

        public GenericAsyncRepository(PackageDbContext dbContext)
        {
            this.dbContext = dbContext;
            dbSet = this.dbContext.Set<T>();
        }

        public async Task CreateAsync(T item)
        {
            await dbSet.AddAsync(item);
            await dbContext.SaveChangesAsync();
        }

        public Task<T> FindById(int id)
        {
            return dbSet.FindAsync(id);
        }

        public IEnumerable<T> Get(Func<T, bool> predicate)
        {
            return dbSet.AsParallel().Where(predicate);
        }

        public IQueryable<T> GetAll()
        {
            return dbSet;
        }

        public async Task RemoveAsync(int id)
        {
            dbSet.Remove(await dbSet.FindAsync(id));
            await dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(T item)
        {
            dbSet.Update(item);
            await dbContext.SaveChangesAsync();
        }
    }
}
