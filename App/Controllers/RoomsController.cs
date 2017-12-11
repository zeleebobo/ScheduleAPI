using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ScheduleApi.DataAccess;
using ScheduleApi.Domain.Entities;
using ScheduleApi.DtoModels;

namespace App.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class RoomsController : Controller
    {
        private IUnitOfWork unitOfWork = new UnitOfWork(new ScheduleContext());

        [HttpGet]
        public IEnumerable<RoomDto> Get()
        {
            return Mapper.Map<IEnumerable<RoomDto>>(unitOfWork.Rooms.GetAll());
        }

        [HttpGet("{id}", Name = "GetRooms")]
        public IActionResult Get(int id)
        {
            var value = unitOfWork.Rooms.GetById(id);
            if (value == null) return BadRequest();
            return Ok(Mapper.Map<RoomDto>(value));
        }

        [HttpPost]
        public IActionResult Post([FromBody]RoomDto room)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var roomEntity = Mapper.Map<Room>(room);
            unitOfWork.Rooms.Add(roomEntity);
            unitOfWork.Complete();

            return CreatedAtAction("Get", new {id = roomEntity.Id}, room);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var room = unitOfWork.Rooms.GetById(id);
            if (room == null) return BadRequest("Invalid Room Id");
            unitOfWork.Rooms.Delete(room);
            unitOfWork.Complete();
            return Ok();
        }
    }
}
