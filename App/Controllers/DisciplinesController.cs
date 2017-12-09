using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Db;
using App.Models;
using Microsoft.AspNetCore.Mvc;
using ScheduleApi.Models;

namespace App.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class DisciplinesController : Controller
    {
        [HttpGet]
        public IEnumerable<Discipline> Get()
        {
            using (var context = new ScheduleContext())
            {
                return context.Disciplines.ToArray();
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            using (var context = new ScheduleContext())
            {
                var value = context.Disciplines.SingleOrDefault(x => x.Id == id);
                if (value == null) return BadRequest();
                return Ok(value);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Discipline discipline)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            using (var context = new ScheduleContext())
            {
                context.Disciplines.Add(discipline);
                context.SaveChanges();
            }

            return CreatedAtAction("Get", new {id = discipline.Id}, discipline);
        }

        [HttpPost("{id}/teachers/{teacherId}")]
        public IActionResult AddTeacher(int id, int teacherId)
        {
            using (var context = new ScheduleContext())
            {
                if (!context.Disciplines.Any(x => x.Id == id) || 
                    !context.Teachers.Any(x => x.Id == teacherId))
                    return BadRequest();
                var discipline = context.Disciplines.First(x => x.Id == id);
                if (discipline.TeacherIds.Contains(teacherId))
                    return BadRequest();
                discipline.TeacherIds.Add(teacherId);
                context.SaveChanges();
                return Ok();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            using (var context = new ScheduleContext())
            {
                var discipline = context.Disciplines.FirstOrDefault(x => x.Id == id);
                if (discipline == null) return BadRequest();
                context.Remove(discipline);
                context.SaveChanges();
            }

            return Ok();
        }

        [HttpDelete("{id}/teachers/{teacherId}")]
        public IActionResult DeleteTeacher(int id, int teacherId)
        {
            using (var context = new ScheduleContext())
            {
                if (!context.Disciplines.Any(x => x.Id == id) ||
                    !context.Teachers.Any(x => x.Id == teacherId))
                    return BadRequest();
                var discipline = context.Disciplines.First(x => x.Id == id);
                if (discipline.TeacherIds.Contains(teacherId))
                    return BadRequest();
                discipline.TeacherIds.Remove(teacherId);
                context.SaveChanges();
                return Ok();
            }
        }
    }
}
