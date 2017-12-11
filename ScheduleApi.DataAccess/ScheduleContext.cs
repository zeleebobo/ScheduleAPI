using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ScheduleApi.Domain.Entities;

namespace ScheduleApi.DataAccess
{
    public class ScheduleContext : DbContext
    {
        public static string ConnectionString { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(ConnectionString);
        }

        public DbSet<Room> Rooms { get; set; }

        public DbSet<Discipline> Disciplines { get; }

        public DbSet<Schedule> Schedules { get; }

        public DbSet<ScheduleEntry> ScheduleEntries { get; }

        public DbSet<Group> Groups { get; }

        public DbSet<Teacher> Teachers { get; }


    }
}
