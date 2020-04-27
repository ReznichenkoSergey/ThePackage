using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThePackage.Models.Abstract;
using ThePackage.Models.Database;
using ThePackage.Models.Entities;
using ThePackage.Services.Interfaces;

namespace ThePackage.Services
{
    public class ReferencesService : IService<Units>
    {
        public BaseRepository<Units> Repository { get; set; }

        public ReferencesService(PackageDbContext dbContext)
        {
            Repository = new BaseRepository<Units>(dbContext);
        }

        public void Create(Units item)
        {
            Repository.Create(item);
        }

        public void Delete(int id)
        {
            Repository.Remove(id);
        }

        public List<Units> GetAll()
        {
            return Repository.GetAll().ToList();
        }

        public Units Update(int id, Units updatedItem)
        {
            Repository.Update(updatedItem);
            return updatedItem;
        }

        public Units FindById(int id)
        {
            return Repository.FindById(id);
        }

        public IQueryable<Units> GetQuery()
        {
            return Repository.GetAll();
        }
    }
}
