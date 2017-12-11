using System;
using System.Collections.Generic;
using System.Linq;
using App.DtoModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ScheduleApi.DataAccess;
using ScheduleApi.DataAccess.Repos;
using ScheduleApi.Domain.Entities;
using ScheduleApi.DtoModels;


namespace App.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class DisciplinesController : Controller
    {
        private IUnitOfWork unitOfWork = new UnitOfWork(new ScheduleContext());

        [HttpGet]
        public IEnumerable<DisciplineDto> Get()
        {
            return Mapper.Map<IEnumerable<Discipline>, List<DisciplineDto>>(unitOfWork.Disciplines.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var value = unitOfWork.Disciplines.GetById(id);
            if (value == null) return BadRequest();
            return Ok(Mapper.Map<Discipline, DisciplineDto>(value));
        }
        
        [HttpPost]
        public IActionResult Post([FromBody] DisciplineDto discipline)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var disciplineEntity = Mapper.Map<DisciplineDto, Discipline>(discipline);
            unitOfWork.Disciplines.Add(disciplineEntity);
            unitOfWork.Complete();

            return CreatedAtAction("Get", new {id = disciplineEntity.Id}, discipline);
        }
        

        [HttpPost("{id}/teachers/{teacherId}")]
        public IActionResult AddTeacher(int id, int teacherId)
        {
            var discipline = unitOfWork.Disciplines.GetById(id);
            var teacher = unitOfWork.Teachers.GetById(teacherId);
            if (discipline == null || teacher == null) return BadRequest();

            discipline.TeacherDisciplines.Add(new TeacherDiscipline(discipline, teacher));
            unitOfWork.Complete();

            return Ok();

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var discipline = unitOfWork.Disciplines.GetById(id);
            if (discipline == null) return BadRequest();
            unitOfWork.Disciplines.Delete(discipline);
            unitOfWork.Complete();

            return Ok();
        }

        
        [HttpDelete("{id}/teachers/{teacherId}")]
        public IActionResult DeleteTeacher(int id, int teacherId)
        {
            var discipline = unitOfWork.Disciplines.GetById(id);
            if (discipline == null) return BadRequest("Invalid discipline Id");

            var teacherDiscipline = discipline.TeacherDisciplines.FirstOrDefault(x => x.Teacher.Id == teacherId);
            if (teacherDiscipline == null) return BadRequest("Invalid teacher Id");

            discipline.TeacherDisciplines.Remove(teacherDiscipline);
            unitOfWork.Complete();

            return Ok();
        }
    }
}
