using System.Collections.Generic;
using System.Linq;
using ThePackage.Models.Abstract;
using ThePackage.Models.Database;
using ThePackage.Models.Entities;
using ThePackage.Services.Interfaces;

namespace ThePackage.Services
{
    public class PointService : IService<Point>
    {
        public BaseRepository<Point> Repository { get; set; }

        public PointService(PackageDbContext dbContext)
        {
            Repository = new BaseRepository<Point>(dbContext);
        }

        public void Create(Point item)
        {
            Repository.Create(item);
        }

        public void Delete(int id)
        {
            Repository.Remove(id);
        }

        public List<Point> GetAll()
        {
            return Repository.GetAll().ToList();
        }

        public Point Update(int id, Point updatedItem)
        {
            Repository.Update(updatedItem);
            return updatedItem;
        }

        public Point FindById(int id)
        {
            return Repository.FindById(id);
        }

        public IQueryable<Point> GetQuery()
        {
            return Repository.GetAll();
        }
    }
}
