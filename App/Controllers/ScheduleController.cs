using System;
using System.Collections.Generic;
using App.DtoModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ScheduleApi.DataAccess;
using ScheduleApi.Domain.Entities;

namespace App.Controllers
{
    [Route("api/[controller]")]
    public class ScheduleController : Controller
    {
        private IUnitOfWork unitOfWork = new UnitOfWork(new ScheduleContext());

        [HttpGet]
        public IEnumerable<ScheduleDto> Get()
        {
            return Mapper.Map<IEnumerable<Schedule>, IEnumerable<ScheduleDto>>(unitOfWork.Schedules.GetAll());
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(IEnumerable<ScheduleGroupDto>), 201)]
        [ProducesResponseType(typeof(string), 400)]
        public IActionResult Get(int id)
        {
            var scheduleEntity = unitOfWork.Schedules.GetById(id);
            if (scheduleEntity == null) return BadRequest($"Invalid Schedule Id ({id})");
            var schedule = Mapper.Map<Schedule, IEnumerable<ScheduleGroupDto>>(scheduleEntity);
            return Ok(schedule);
        }

        /// <response code="201">Returns the newly-created schedule ID</response>
        /// <response code="400">If the data incorrect</response>
        [HttpPost]
        [ProducesResponseType(typeof(int), 201)]
        [ProducesResponseType(typeof(string), 400)]
        public IActionResult Post([FromBody] ScheduleWithEntriesDto schedule)
        {
            if (!ModelState.IsValid) return BadRequest("Invalid Model Fields");

            var entries = schedule.Entries;
            var scheduleEntity = new Schedule() {Created = schedule.Created, Name = schedule.Name};
            
            foreach (var scheduleEntryDto in entries)
            {
                var scheduleEntry = new ScheduleEntry
                {
                    Schedule = scheduleEntity,
                    DayOfWeek = scheduleEntryDto.DayOfWeek,
                    SubGroupNum = scheduleEntryDto.SubGroupNum,
                    WeekNumber = scheduleEntryDto.WeekNumber,
                    Position = scheduleEntryDto.Position
                };

                var teacher = unitOfWork.Teachers.GetById(scheduleEntryDto.TeacherId); // TODO: fix this for next release (can be any teacher, must be only which in list of teachers discipline)
                if (teacher == null) return BadRequest($"Invalid Teacher Id ({scheduleEntryDto.TeacherId})");

                var discipline = unitOfWork.Disciplines.GetById(scheduleEntryDto.DisciplineId);
                if (discipline == null) return BadRequest($"Invalid Discipline Id ({scheduleEntryDto.DisciplineId})");

                var room = unitOfWork.Rooms.GetById(scheduleEntryDto.RoomId);
                if (room == null) return BadRequest($"Invalid Room Id ({scheduleEntryDto.RoomId})");

                var group = unitOfWork.Groups.GetById(scheduleEntryDto.GroupId);
                if (group == null) return BadRequest($"Invalid Group Id ({scheduleEntryDto.GroupId})");

                scheduleEntry.Teacher = teacher;
                scheduleEntry.Discipline = discipline;
                scheduleEntry.Room = room;
                scheduleEntry.Group = group;

                scheduleEntity.Entries.Add(scheduleEntry);
            }

            if (!scheduleEntity.IsCorrect)
                return BadRequest("error"); // TODO: create error class
            unitOfWork.Schedules.Add(scheduleEntity);
            unitOfWork.Complete();
            return CreatedAtAction("Get", scheduleEntity.Id);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var schedule = unitOfWork.Schedules.GetById(id);
            if (schedule == null) return BadRequest($"Invalid Schedule Id ({id})");
            unitOfWork.Schedules.Delete(schedule);
            unitOfWork.Complete();
            return Ok();
        }


    }
}

   
