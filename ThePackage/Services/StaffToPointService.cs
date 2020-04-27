using System.Collections.Generic;
using System.Linq;
using ThePackage.Models.Abstract;
using ThePackage.Models.Database;
using ThePackage.Models.Entities;
using ThePackage.Services.Interfaces;

namespace ThePackage.Services
{
    public class StaffToPointService : IService<StaffToPoint>
    {
        public BaseRepository<StaffToPoint> Repository { get; set; }

        public StaffToPointService(PackageDbContext dbContext)
        {
            Repository = new BaseRepository<StaffToPoint>(dbContext);
        }

        public void Create(StaffToPoint item)
        {
            Repository.Create(item);
        }

        public void Delete(int id)
        {
            Repository.Remove(id);
        }

        public List<StaffToPoint> GetAll()
        {
            return Repository.GetAll().ToList();
        }

        public StaffToPoint Update(int id, StaffToPoint updatedItem)
        {
            Repository.Update(updatedItem);
            return updatedItem;
        }

        public StaffToPoint FindById(int id)
        {
            return Repository.FindById(id);
        }

        public IQueryable<StaffToPoint> GetQuery()
        {
            return Repository.GetAll();
        }
    }
}
