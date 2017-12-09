using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ScheduleApi.Infrastructure.Entities;

namespace ScheduleApi.Infrastructure.Db
{
    public class ScheduleContext : DbContext
    {
        public static string ConnectionString { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(ConnectionString);
        }

        public DbSet<Group> Groups { get; private set; }

        public DbSet<RoomEntity> Rooms { get; private set; }

        public DbSet<TeacherEntity> Teachers { get; private set; }

        public DbSet<DisciplineEntity> Disciplines { get; private set; }
    }
}
