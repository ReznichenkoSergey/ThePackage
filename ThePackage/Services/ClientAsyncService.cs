using System.Linq;
using System.Threading.Tasks;
using ThePackage.Models.Abstract;
using ThePackage.Models.Database;
using ThePackage.Models.Entities;
using ThePackage.Services.Interfaces;

namespace ThePackage.Services
{
    public class ClientAsyncService : IAsyncService<Client>
    {
        public GenericAsyncRepository<Client> Repository { get; set; }

        public ClientAsyncService(PackageDbContext dbContext)
        {
            Repository = new GenericAsyncRepository<Client>(dbContext);
        }

        public Task CreateAsync(Client item)
        {
            return Repository.CreateAsync(item);
        }

        public Task DeleteAsync(int id)
        {
            return Repository.RemoveAsync(id);
        }

        public IQueryable<Client> GetAll()
        {
            return Repository.GetAll().AsQueryable();
        }

        public Task UpdateAsync(Client updatedItem)
        {
            return Repository.UpdateAsync(updatedItem);
        }

        public Task<Client> FindByIdAsync(int id)
        {
            return Repository.FindByIdAsync(id);
        }

        public IQueryable<Client> GetQuery()
        {
            return Repository.GetAll();
        }
    }
}
