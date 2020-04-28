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
        public Task<Client> Get(int id)
        {
            return service
                .FindById(id);
        }

        [HttpPost("save")]
        public List<Client> Post(Client value)
        {
            return service
                .GetAll()
                .AsParallel()
                .Where(x => x.Id == value.Id)
                .ToList();
        }

        [HttpPut]
        public Task Put(Client value)
        {
            return service
                .CreateAsync(value);
        }

        [HttpDelete("{id}")]
        public Task DeleteAsync(int id)
        {
            return service
                .DeleteAsync(id);
        }
    }
}
