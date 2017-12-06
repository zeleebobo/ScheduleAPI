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
    public class GroupsController : Controller
    {
        // GET: api/Groups
        [HttpGet]
        public IEnumerable<Group> Get()
        {
            using (var context = new ScheduleContext())
            {
                return context.Groups.ToArray();
            }
        }

        // GET: api/Groups/5
        [HttpGet("{id}", Name = "GetGroups")]
        public IActionResult Get(int id)
        {
            using (var context = new ScheduleContext())
            {
                var value = context.Groups.SingleOrDefault(x => x.Id == id);
                if (value == null) return BadRequest();
                return Ok(value);
            }
        }
        
        // POST: api/Groups
        [HttpPost]
        public IActionResult Post([FromBody]Group group)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            using (var context = new ScheduleContext())
            {
                context.Groups.Add(group);
                context.SaveChanges();
            }

            return CreatedAtAction("Get", new { id = group.Id }, group);
        }
        
        // PUT: api/Groups/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            using (var context = new ScheduleContext())
            {
                var group = context.Groups.FirstOrDefault(x => x.Id == id);
                if (group == null) return BadRequest();
                context.Remove(group);
                context.SaveChanges();
            }

            return Ok();
        }
    }
}
