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
    public class PackageService : IService<Package>
    {
        public BaseRepository<Package> Repository { get; set; }

        public PackageService(PackageDbContext dbContext)
        {
            Repository = new BaseRepository<Package>(dbContext);
        }

        public void Create(Package item)
        {
            Repository.Create(item);
        }

        public void Delete(int id)
        {
            Repository.Remove(id);
        }

        public List<Package> GetAll()
        {
            return Repository.GetAll().ToList();
        }

        public Package Update(int id, Package updatedItem)
        {
            Repository.Update(updatedItem);
            return updatedItem;
        }

        public Package FindById(int id)
        {
            return Repository.FindById(id);
        }

        public IQueryable<Package> GetQuery()
        {
            return Repository.GetAll();
        }
    }
}
