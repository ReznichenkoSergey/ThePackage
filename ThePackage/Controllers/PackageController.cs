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
                .Include(x=>x.PointDestination)
                .Include(x => x.PointSource)
                .Include(x => x.ClientReceiver)
                .Include(x => x.ClientSender)
                .ToList();
        }

        [HttpGet("{id}")]
        public Package Get(int id)
        {
            return service
                .GetQuery()
                .Where(x=>x.Id == id)
                .Include(x => x.Units)
                .Include(x => x.PointDestination)
                .Include(x => x.PointSource)
                .Include(x => x.ClientReceiver)
                .Include(x => x.ClientSender)
                .SingleOrDefault();
        }

        [HttpPost("save/{id}")]
        public void Post(int id, Package value)
        {
            if (value.Id == id)
            {
                Package package = service.FindById(id);
                if (package != null)
                {
                    package.StatusId = value.StatusId;
                    package.DateUpdate = DateTime.UtcNow;
                    //
                    service.Update(id, package);
                }
            }
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
