using System;
using System.Collections.Generic;
using System.Linq;
using ThePackage.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using ThePackage.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ThePackage.Controllers
{
    [Route("api/units")]
    [ApiController]
    public class UnitsController : ControllerBase
    {
        readonly IService<Units> service;

        public UnitsController(IService<Units> service)
        {
            this.service = service;
        }

        [HttpGet]
        public List<Units> Get()
        {
            return service
                .GetQuery()
                .ToList();
        }

        [HttpGet("{id}")]
        public Units Get(int id)
        {
            return service.FindById(id);
        }

        [HttpGet("type/{typeid}")]
        public List<Units> GetByTypeId(int typeId)
        {
            return service
                .GetQuery()
                .Where(x => x.TypeId == typeId)
                .ToList();
        }

        [HttpPost("save")]
        public List<Units> Post(Units value)
        {
            return service
                .GetAll()
                .Where(x => x.Id == value.Id)
                .ToList();
        }

        [HttpPut]
        public int Put(Units value)
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
