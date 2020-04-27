using System;
using System.Collections.Generic;
using System.Linq;
using ThePackage.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using ThePackage.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ThePackage.Controllers
{
    [Route("api/package")]
    [ApiController]
    public class PackageController : ControllerBase
    {
        readonly IService<Package> service;

        public PackageController(IService<Package> service)
        {
            this.service = service;
        }

        [HttpGet]
        public List<Package> Get()
        {
            return service
                .GetQuery()
                .Include(x=>x.Units)
                .ToList();
        }

        [HttpGet("{id}")]
        public Package Get(int id)
        {
            return service
                .FindById(id);
        }

        [HttpPost("save")]
        public List<Package> Post(Package value)
        {
            return service
                .GetAll()
                .Where(x => x.Id == value.Id)
                .ToList();
        }

        [HttpPut]
        public int Put(Package value)
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
