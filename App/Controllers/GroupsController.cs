using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ScheduleApi.DataAccess;
using ScheduleApi.DataAccess.Repos;
using ScheduleApi.Domain.Entities;
using ScheduleApi.DtoModels;

namespace App.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class GroupsController : Controller
    {
        private IUnitOfWork unitOfWork = new UnitOfWork(new ScheduleContext());

        [HttpGet]
        public IEnumerable<GroupDto> Get()
        {
            return Mapper.Map<IEnumerable<Group>, IEnumerable<GroupDto>>(unitOfWork.Groups.GetAll());
        }

        [HttpGet("{id}", Name = "GetGroups")]
        public IActionResult Get(int id)
        {
            var value = unitOfWork.Groups.GetById(id);
            if (value == null) return BadRequest();
            return Ok(Mapper.Map<GroupDto>(value));
        }

        [HttpPost]
        public IActionResult Post([FromBody]GroupDto group)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var groupEntity = Mapper.Map<Group>(group);
            unitOfWork.Groups.Add(groupEntity);
            unitOfWork.Complete();

            return CreatedAtAction("Get", new { id = groupEntity.Id }, group);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var group = unitOfWork.Groups.GetById(id);

            if (group == null) return BadRequest("Invalid Group Id");
            unitOfWork.Groups.Delete(group);
            unitOfWork.Complete();

            return Ok();
        }
    }
}
