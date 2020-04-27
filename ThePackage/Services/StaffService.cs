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
    public class StaffService : IService<Staff>
    {
        public BaseRepository<Staff> Repository { get; set; }

        public StaffService(PackageDbContext dbContext)
        {
            Repository = new BaseRepository<Staff>(dbContext);
        }

        public void Create(Staff item)
        {
            Repository.Create(item);
        }

        public void Delete(int id)
        {
            Repository.Remove(id);
        }

        public List<Staff> GetAll()
        {
            return Repository.GetAll().ToList();
        }

        public Staff Update(int id, Staff updatedItem)
        {
            Repository.Update(updatedItem);
            return updatedItem;
        }

        public Staff FindById(int id)
        {
            return Repository.FindById(id);
        }

        public IQueryable<Staff> GetQuery()
        {
            return Repository.GetAll();
        }
    }
}
