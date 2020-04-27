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
    public class PackageTypeService : IService<PackageType>
    {
        public BaseRepository<PackageType> Repository { get; set; }

        public PackageTypeService(PackageDbContext dbContext)
        {
            Repository = new BaseRepository<PackageType>(dbContext);
        }

        public void Create(PackageType item)
        {
            Repository.Create(item);
        }

        public void Delete(int id)
        {
            Repository.Remove(id);
        }

        public List<PackageType> GetAll()
        {
            return Repository.GetAll().ToList();
        }

        public PackageType Update(int id, PackageType updatedItem)
        {
            Repository.Update(updatedItem);
            return updatedItem;
        }

        public PackageType FindById(int id)
        {
            return Repository.FindById(id);
        }

        public IQueryable<PackageType> GetQuery()
        {
            return Repository.GetAll();
        }
    }
}
