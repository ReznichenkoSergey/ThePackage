using System;
using System.Collections.Generic;
using System.Linq;
using ThePackage.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using ThePackage.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ThePackage.Controllers
{
    [Route("api/point")]
    [ApiController]
    public class PointController : ControllerBase
    {
        readonly IService<Point> service;

        public PointController(IService<Point> service)
        {
            this.service = service;
        }

        [HttpGet]
        public List<Point> Get()
        {
            return service
                .GetQuery()
                .ToList();
        }

        [HttpGet("{id}")]
        public Point Get(int id)
        {
            return service.FindById(id);
        }

        [HttpPost("save")]
        public List<Point> Post(Point value)
        {
            return service
                .GetAll()
                .ToList();
        }

        [HttpPut]
        public int Put(Point value)
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
