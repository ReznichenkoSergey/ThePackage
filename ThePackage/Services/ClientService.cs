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
    public class ClientService : IService<Client>
    {
        public BaseRepository<Client> Repository { get; set; }

        public ClientService(PackageDbContext dbContext)
        {
            Repository = new BaseRepository<Client>(dbContext);
        }

        public void Create(Client item)
        {
            Repository.Create(item);
        }

        public void Delete(int id)
        {
            Repository.Remove(id);
        }

        public List<Client> GetAll()
        {
            return Repository.GetAll().ToList();
        }

        public Client Update(int id, Client updatedItem)
        {
            Repository.Update(updatedItem);
            return updatedItem;
        }

        public Client FindById(int id)
        {
            return Repository.FindById(id);
        }

        public IQueryable<Client> GetQuery()
        {
            return Repository.GetAll();
        }
    }
}
