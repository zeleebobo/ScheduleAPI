using System;
using System.Collections.Generic;
using System.Linq;
using App.DtoModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ScheduleApi.DataAccess;
using ScheduleApi.Domain.Entities;

namespace App.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class TeachersController : Controller
    {
        private IUnitOfWork unitOfWork = new UnitOfWork(new ScheduleContext());

        [HttpGet]
        public IEnumerable<TeacherDto> Get()
        {
            return Mapper.Map<IEnumerable<Teacher>, IEnumerable<TeacherDto>>(unitOfWork.Teachers.GetAll());
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            var value = unitOfWork.Teachers.GetById(id);
            if (value == null) return BadRequest("Invalid Teacher Id");
            return Ok(Mapper.Map<TeacherDto>(value));

        }

        [HttpPost]
        public IActionResult Post([FromBody]TeacherDto teacher)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var teacherEntity = Mapper.Map<Teacher>(teacher);
                unitOfWork.Teachers.Add(teacherEntity);
            unitOfWork.Complete();

            return CreatedAtAction("Get", new { id = teacherEntity.Id }, teacher);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var teacher = unitOfWork.Teachers.GetById(id);
            if (teacher == null) return BadRequest("Invalid Teacher Id");

            unitOfWork.Teachers.Delete(teacher);
            unitOfWork.Complete();

            return Ok();
        }
    }
}
