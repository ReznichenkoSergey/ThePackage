﻿using System;
using System.Collections.Generic;
using System.Linq;
using ThePackage.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using ThePackage.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ThePackage.Controllers
{
    [Route("api/staff")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        readonly IService<Staff> service;

        public StaffController(IService<Staff> service)
        {
            this.service = service;
        }

        [HttpGet]
        public List<Staff> Get()
        {
            return service
                .GetQuery()
                .Include(x=>x.Units)
                .Include(x=>x.StaffToPoint)
                .ThenInclude(x=>x.Point)
                .ToList();
        }

        [HttpGet("{id}")]
        public Staff Get(int id)
        {
            return service.FindById(id);
        }

        /// <summary>
        /// Поиск по должности
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        [HttpGet("role/{roleId}")]
        public List<Staff> GetByStaffByRoleId(int roleId)
        {
            return service
                .GetQuery()
                .Include(x => x.Units)
                .Where(x=>x.UnitsId == roleId)
                .Include(x => x.StaffToPoint)
                .ThenInclude(x => x.Point)
                .ToList();
        }

        [HttpPost("save")]
        public List<Staff> Post(Staff value)
        {
            return service
                .GetAll()
                .Where(x => x.Id == value.Id)
                .ToList();
        }

        [HttpPut]
        public int Put(Staff value)
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
