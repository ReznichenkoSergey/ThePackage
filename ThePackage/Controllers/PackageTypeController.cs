using System;
using System.Collections.Generic;
using System.Linq;
using ThePackage.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using ThePackage.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ThePackage.Controllers
{
    [Route("api/packagetype")]
    [ApiController]
    public class PackageTypeController : ControllerBase
    {
        readonly IService<PackageType> service;

        public PackageTypeController(IService<PackageType> service)
        {
            this.service = service;
        }

        [HttpGet]
        public List<PackageType> Get()
        {
            return service
                .GetQuery()
                .ToList();
        }

        [HttpGet("{id}")]
        public PackageType Get(int id)
        {
            return service.FindById(id);
        }

        [HttpPost("save")]
        public List<PackageType> Post(PackageType value)
        {
            return service
                .GetAll()
                .Where(x=> x.Id == value.Id)
                .ToList();
        }

        [HttpPut]
        public int Put(PackageType value)
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
