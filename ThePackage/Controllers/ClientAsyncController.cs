using System;
using System.Collections.Generic;
using System.Linq;
using ThePackage.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using ThePackage.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ThePackage.Controllers
{
    [Route("api/clientasync")]
    [ApiController]
    public class ClientAsyncController : ControllerBase
    {
        readonly IAsyncService<Client> service;

        public ClientAsyncController(IAsyncService<Client> service)
        {
            this.service = service;
        }

        [HttpGet]
        public List<Client> Get()
        {
            return service
                .GetQuery()
                .ToList();
        }

        [HttpGet("{id}")]
        public async Task<Client> GetAsync(int id)
        {
            return await service
                .FindByIdAsync(id);
        }

        [HttpPost("save/{id}")]
        public async Task Post(int id, Client value)
        {
            if (value.Id == id)
            {
                Client client = await service.FindByIdAsync(id);
                if (client != null)
                {
                    client.Code = value.Code;
                    client.DateUpdate = DateTime.UtcNow;
                    client.Name = value.Name;
                    client.EMail = value.EMail;
                    client.Phone = value.Phone;
                    client.Comment = value.Comment;
                    //
                    await service
                        .UpdateAsync(client);
                }
            }
        }

        [HttpPut]
        public async Task<Client> PutAsync(Client value)
        {
            await service
                .CreateAsync(value);
            return await service
                .FindByIdAsync(value.Id);
        }

        [HttpDelete("{id}")]
        public async Task DeleteAsync(int id)
        {
            await service
                .DeleteAsync(id);
        }
    }
}
