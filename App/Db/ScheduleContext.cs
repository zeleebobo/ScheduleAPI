using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ScheduleApi.Models;

namespace App.Db
{
    public class ScheduleContext : DbContext
    {
        public static string ConnectionString { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(ConnectionString);
        }

        public DbSet<Group> Groups { get; private set; }

        public DbSet<Room> Rooms { get; private set; }

        public DbSet<Teacher> Teachers { get; private set; }

    }
}
