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

        [HttpPost("save/{id}")]
        public void Post(int id, PackageType value)
        {
            if (value.Id == id)
            {
                PackageType packageType = service.FindById(id);
                if (packageType != null)
                {
                    packageType.Name = value.Name;
                    packageType.Comment = value.Comment;
                    //
                    service.Update(id, packageType);
                }
            }
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
