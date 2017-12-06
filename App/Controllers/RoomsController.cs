﻿using System;
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
    public class RoomsController : Controller
    {
        // GET: api/Rooms
        [HttpGet]
        public IEnumerable<Room> Get()
        {
            using (var context = new ScheduleContext())
            {
                return context.Rooms.ToArray();
            }
        }

        // GET: api/Rooms/5
        [HttpGet("{id}", Name = "GetRooms")]
        public IActionResult Get(int id)
        {
            using (var context = new ScheduleContext())
            {
                var value = context.Rooms.SingleOrDefault(x => x.Id == id);
                if (value is default(Room)) return BadRequest();
                return Ok(value);
            }
        }
        
        // POST: api/Rooms
        [HttpPost]
        public IActionResult Post([FromBody]Room room)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            using (var context = new ScheduleContext())
            {
                context.Rooms.Add(room);
                context.SaveChanges();
            }

            return CreatedAtAction("Get", new {id = room.Id}, room);
        }
        
        // PUT: api/Rooms/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{

        //}
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            using (var context = new ScheduleContext())
            {
                var room = context.Rooms.FirstOrDefault(x => x.Id == id);
                if (room == null) return BadRequest();
                context.Remove(room);
                context.SaveChanges();
            }

            return Ok();
        }
    }
}
