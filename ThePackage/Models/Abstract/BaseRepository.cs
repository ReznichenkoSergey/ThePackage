﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ThePackage.Models.Database;
using ThePackage.Services.Interfaces;

namespace ThePackage.Models.Abstract
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        private readonly PackageDbContext dbContext;
        protected readonly DbSet<T> dbSet;

        public BaseRepository(PackageDbContext dbContext)
        {
            this.dbContext = dbContext;
            dbSet = this.dbContext.Set<T>();
        }

        public void Create(T item)
        {
            dbSet.Add(item);
            dbContext.SaveChanges();
        }

        public T FindById(int id)
        {
            return dbSet.Find(id);
        }

        public IQueryable<T> Get(Expression<Func<T, bool>> predicate)
        {
            return dbSet.Where(predicate);
        }

        public void Remove(int id)
        {
            dbSet.Remove(dbSet.Find(id));
            dbContext.SaveChanges();
        }

        public void Update(T item)
        {
            dbContext.Entry(item).State = EntityState.Modified;
            dbContext.SaveChanges();
        }

        public IQueryable<T> GetAll()
        {
            return dbSet;
        }
    }
}
