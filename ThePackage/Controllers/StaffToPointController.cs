using System.Collections.Generic;
using System.Linq;
using ThePackage.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using ThePackage.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ThePackage.Controllers
{
    [Route("api/positions")]
    [ApiController]
    public class StaffToPointController : ControllerBase
    {
        readonly IService<StaffToPoint> service;

        public StaffToPointController(IService<StaffToPoint> service)
        {
            this.service = service;
        }

        [HttpGet]
        public List<StaffToPoint> Get()
        {
            return service
                .GetQuery()
                .Include(x=>x.Staff)
                .ThenInclude(y=>y.Units)
                .Include(x=>x.Point)
                .ToList();
        }

        [HttpGet("{id}")]
        public StaffToPoint Get(int id)
        {
            return service.FindById(id);
        }

        [HttpPost("save")]
        public List<StaffToPoint> Post(StaffToPoint value)
        {
            return service
                .GetAll()
                .Where(x => x.Id == value.Id)
                .ToList();
        }

        [HttpPut]
        public int Put(StaffToPoint value)
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
