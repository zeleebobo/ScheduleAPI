using System;
using System.Collections.Generic;
using System.Text;
using ScheduleApi.DataAccess.Repos;
using ScheduleApi.Domain.Entities;

namespace ScheduleApi.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private ScheduleContext context;
        public UnitOfWork(ScheduleContext context)
        {
            this.context = context;
            Disciplines = new Repository<Discipline>(context);
            Groups = new Repository<Group>(context);
            Teachers = new Repository<Teacher>(context);
            Rooms = new Repository<Room>(context);
            Schedules = new Repository<Schedule>(context);
            ScheduleEntries = new Repository<ScheduleEntry>(context);
        }

        public IRepository<Discipline> Disciplines { get; }
        public IRepository<Group> Groups { get; }
        public IRepository<Teacher> Teachers { get; }
        public IRepository<Room> Rooms { get; }
        public IRepository<Schedule> Schedules { get; }
        public IRepository<ScheduleEntry> ScheduleEntries { get; }

        public int Complete()
        {
            return context.SaveChanges();
        }

        public void Dispose()
        {
            context?.Dispose();
        }
    }
}
