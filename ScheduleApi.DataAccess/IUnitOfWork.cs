﻿using System;
using System.Collections.Generic;
using System.Text;
using ScheduleApi.Domain.Entities;

namespace ScheduleApi.DataAccess
{
    public interface IUnitOfWork : IDisposable
    {
        IDisciplineRepository Disciplines { get; }
        IRepository<Group> Groups { get; }
        IRepository<Teacher> Teachers { get; }
        IRepository<Room> Rooms { get; }
        IRepository<Schedule> Schedules { get; }
        IRepository<ScheduleEntry> ScheduleEntries { get; }
        IRepository<TeacherDiscipline> TeacherDisciplines { get; }

        int Complete();
    }
}
