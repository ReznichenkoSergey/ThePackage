using System;
using System.Collections.Generic;
using System.Linq;
using ThePackage.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using ThePackage.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ThePackage.Controllers
{
    [Route("api/client")]
    [ApiController]
    public class UserController : ControllerBase
    {
        readonly IService<Client> service;

        public UserController(IService<Client> service)
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
        public Client Get(int id)
        {
            return service.FindById(id);
        }

        [HttpPost("save/{id}")]
        public void Post(int id, Client value)
        {
            if (value.Id == id)
            {
                Client client = service.FindById(id);
                if (client != null)
                {
                    client.Code = value.Code;
                    client.DateUpdate = DateTime.UtcNow;
                    client.Name = value.Name;
                    client.EMail = value.EMail;
                    client.Phone = value.Phone;
                    client.Comment = value.Comment;
                    //
                    service.Update(id, client);
                }
            }
        }

        [HttpPut]
        public int Put(Client value)
        {
            service.Create(value);
            return value.Id;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            service.Delete(id);
        }
    }
}
