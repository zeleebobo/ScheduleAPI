using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.DtoModels;
using AutoMapper;
using ScheduleApi.Domain.Entities;
using ScheduleApi.DtoModels;

namespace App.Services
{
    public static class AutoMapperInitializer
    {
        public static void Initialize()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<RoomDto, Room>();
                cfg.CreateMap<Room, RoomDto>();

                cfg.CreateMap<GroupDto, Group>();
                cfg.CreateMap<Group, GroupDto>();

                cfg.CreateMap<DisciplineDto, Discipline>();
                cfg.CreateMap<Discipline, DisciplineDto>();

                cfg.CreateMap<TeacherDto, Teacher>();
                cfg.CreateMap<Teacher, OpenTeacherDto>();
                cfg.CreateMap<Teacher, TeacherDto>();

                cfg.CreateMap<ScheduleWithEntriesDto, Schedule>();
                cfg.CreateMap<Schedule, ScheduleWithEntriesDto>();
                cfg.CreateMap<ScheduleDto, Schedule>();
                cfg.CreateMap<Schedule, ScheduleDto>();

                cfg.CreateMap<Schedule, IEnumerable<ScheduleGroupDto>>().ConvertUsing<ScheduleConverter>();

                cfg.CreateMap<ScheduleEntry, ScheduleEntryDto>();
                cfg.CreateMap<ScheduleEntry, ScheduleGroupEntryDto>();
                cfg.CreateMap<ScheduleEntryDto, ScheduleEntry>();
            });
        }
    }
}
