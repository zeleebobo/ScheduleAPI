using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Db;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ScheduleApi.Models;

namespace App.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class TeachersController : Controller
    {
        [HttpGet]
        public IEnumerable<Teacher> Get()
        {
            using (var context = new ScheduleContext())
            {
                return context.Teachers.ToArray();
            }
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            using (var context = new ScheduleContext())
            {
                var value = context.Teachers.SingleOrDefault(x => x.Id == id);
                if (value == null) return BadRequest();
                return Ok(value);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody]Teacher teacher)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            using (var context = new ScheduleContext())
            {
                context.Teachers.Add(teacher);
                context.SaveChanges();
            }

            return CreatedAtAction("Get", new { id = teacher.Id }, teacher);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            using (var context = new ScheduleContext())
            {
                var teacher = context.Teachers.FirstOrDefault(x => x.Id == id);
                if (teacher == null) return BadRequest();
                context.Remove(teacher);
                context.SaveChanges();
            }

            return Ok();
        }
    }
}
