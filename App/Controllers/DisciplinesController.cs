using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using App.DtoModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.CodeAnalysis.CSharp.Syntax;
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
        public IEnumerable<DisciplineDto> Get([FromQuery] int? courseNum)
        {
            var disciplineEntities = courseNum == null ? unitOfWork.Disciplines.GetAll() : unitOfWork.Disciplines.GetByCourse((int) courseNum);
            var disciplines = Mapper.Map<IEnumerable<Discipline>, List<DisciplineDto>>(disciplineEntities);
            return disciplines;
        }

        /// <summary>
        /// Gets a specific discipline.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Founded discipline</returns>
        /// <response code="201">Returns founded discipline</response>
        /// <response code="400">If id is not found</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(DisciplineDto), 200)]
        [ProducesResponseType(typeof(string), 400)]
        public IActionResult Get(int id)
        {
            var value = unitOfWork.Disciplines.GetById(id);
            if (value == null) return BadRequest();
            return Ok(Mapper.Map<Discipline, DisciplineDto>(value));
        }


        /// <summary>
        /// Creates a Discipline.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/disciplines
        ///     {
        ///        "id": 0,
        ///        "name": "DisciplineName",
        ///        "teachers": [
        ///             {
        ///                 "id": 0
        ///             }
        ///         ]
        ///     }
        ///
        /// </remarks>
        /// <returns>A newly-created discipline</returns>
        /// <response code="201">Returns the newly-created discipline</response>
        /// <response code="400">If the item is null</response>
        [HttpPost]
        [ProducesResponseType(typeof(DisciplineDto), 201)]
        [ProducesResponseType(typeof(string), 400)]
        public IActionResult Post([FromBody] DisciplineDto discipline)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var disciplineEntity = Mapper.Map<DisciplineDto, Discipline>(discipline);
            unitOfWork.Disciplines.Add(disciplineEntity);

            foreach (var teacher in discipline.Teachers)
            {
                var teacherEntity = unitOfWork.Teachers.GetById(teacher.Id);
                if (teacherEntity == null) return BadRequest($"Invalid Teacher Id ({teacher.Id})");
                disciplineEntity.AddTeacher(teacherEntity);
            }
            
            unitOfWork.Complete();

            return CreatedAtAction("Get", new {id = disciplineEntity.Id}, Mapper.Map<DisciplineDto>(disciplineEntity));
        }


        /// <summary>
        /// Adds a teacher to specific discipline.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="teacherId"></param>
        /// <returns>A newly-created discipline</returns>
        /// <response code="201">Returns the updated discipline</response>
        /// <response code="400">If the id's incorrect</response> 
        [HttpPost("{id}/teachers/{teacherId}")]
        [ProducesResponseType(typeof(DisciplineDto), 201)]
        [ProducesResponseType(typeof(string), 400)]
        public IActionResult AddTeacher(int id, int teacherId)
        {
            var disciplineEntity = unitOfWork.Disciplines.GetById(id);
            var teacherEntity = unitOfWork.Teachers.GetById(teacherId);
            if (disciplineEntity == null) return BadRequest("Invalid discipline Id");
            if (teacherEntity == null) return BadRequest("Invalid teacher Id");

            if (disciplineEntity.Teachers.Any(x => x.Id == teacherId))
                return BadRequest("Discipline has a teacher already");

            disciplineEntity.AddTeacher(teacherEntity);
            unitOfWork.Complete();

            return CreatedAtAction("Get", new { id = disciplineEntity.Id }, Mapper.Map<DisciplineDto>(disciplineEntity));

        }

        /// <summary>
        /// Deletes a specific discipline teacher.
        /// </summary>
        /// <param name="id"></param>      
        /// <response code="200">Ok</response> 
        /// <response code="400">If id's incorrect</response> 
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(DisciplineDto), 200)]
        [ProducesResponseType(typeof(string), 400)]
        public IActionResult Delete(int id)
        {
            var discipline = unitOfWork.Disciplines.GetById(id);
            if (discipline == null) return BadRequest();
            unitOfWork.Disciplines.Delete(discipline);
            unitOfWork.Complete();

            return Ok();
        }
        

        /// <summary>
        /// Deletes a specific discipline teacher.
        /// </summary>
        /// <param name="id"></param>     
        /// <param name="teacherId"></param>    
        /// <response code="200">Ok</response> 
        /// <response code="400">If id's incorrect</response> 
        [HttpDelete("{id}/teachers/{teacherId}")]
        [ProducesResponseType(typeof(TeacherDto), 200)]
        [ProducesResponseType(typeof(string), 400)]
        public IActionResult DeleteTeacher(int id, int teacherId)
        {
            var discipline = unitOfWork.Disciplines.GetById(id);
            var teacher = unitOfWork.Teachers.GetById(teacherId);
            if (discipline == null) return BadRequest("Invalid discipline Id");
            if (teacher == null) return BadRequest("Invalid teacher Id");

            discipline.RemoveTeacher(teacher);
            unitOfWork.Complete();

            return Ok();
        }
    }
}
