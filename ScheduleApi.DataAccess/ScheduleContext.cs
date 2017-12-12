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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TeacherDiscipline>()
                .HasKey(td => new {td.TeacherId, td.DisciplineId});

            modelBuilder.Entity<TeacherDiscipline>()
                .HasOne(td => td.Teacher)
                .WithMany(t => t.TeacherDisciplines)
                .HasForeignKey(td => td.TeacherId);

            modelBuilder.Entity<TeacherDiscipline>()
                .HasOne(td => td.Discipline)
                .WithMany(d => d.TeacherDisciplines)
                .HasForeignKey(td => td.DisciplineId);

        }

        public DbSet<Room> Rooms { get; set; }

        public DbSet<Discipline> Disciplines { get; }

        public DbSet<Schedule> Schedules { get; }

        public DbSet<ScheduleEntry> ScheduleEntries { get; }

        public DbSet<Group> Groups { get; }

        public DbSet<Teacher> Teachers { get; }

        public DbSet<TeacherDiscipline> TeacherDisciplines { get; }


    }
}
