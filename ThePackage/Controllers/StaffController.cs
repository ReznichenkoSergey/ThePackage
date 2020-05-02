using System;
using System.Collections.Generic;
using System.Linq;
using ThePackage.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using ThePackage.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using ThePackage.Models.DtoClasses;

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

        [HttpGet("dto")]
        public List<StaffDto> GetStaffDto()
        {
            return service
                .GetQuery()
                .Include(x => x.Units)
                .Include(y => y.StaffToPoint)
                .ThenInclude(z => z.Point)
                .Select(x=> new StaffDto ()
                {
                    Id = x.Id,
                    Code = x.Code,
                    Name = x.Name,
                    Phone = x.Phone,
                    EMail = x.Name,
                    UnitsId = x.UnitsId,
                    UnitsCipher = x.Units.Name,
                    Comment = x.Comment
                })
                .ToList();
        }

        [HttpGet("dto/{login}")]
        public StaffDto GetStaffByLoginDto(string login)
        {
            return service
                .GetQuery()
                .Where(x=>x.Login.Equals(login, StringComparison.OrdinalIgnoreCase))
                .Include(x => x.Units)
                .Include(x => x.StaffToPoint)
                .ThenInclude(x => x.Point)
                .Select(x => new StaffDto()
                {
                    Id = x.Id,
                    Code = x.Code,
                    Name = x.Name,
                    Phone = x.Phone,
                    EMail = x.Name,
                    UnitsId = x.UnitsId,
                    UnitsCipher = x.Units.Name,
                    Comment = x.Comment
                }).SingleOrDefault();
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

        [HttpPost("save/{id}")]
        public void Post(int id, Staff value)
        {
            if (value.Id == id)
            {
                Staff staff = service.FindById(id);
                if (staff != null)
                {
                    staff.Code = value.Name;
                    staff.Name = value.Name;
                    staff.Phone = value.Phone;
                    staff.DateUpdate = DateTime.UtcNow;
                    staff.UnitsId = value.UnitsId;
                    //
                    service.Update(id, staff);
                }
            }
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
