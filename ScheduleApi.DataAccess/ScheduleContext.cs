﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ScheduleApi.Domain.Entities;

namespace ScheduleApi.DataAccess
{
    public class ScheduleContext : DbContext
    {
        public static string ConnectionString { get; set; }

        public ScheduleContext(): base() { }

        public ScheduleContext(DbContextOptions<ScheduleContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
             //if (ConnectionString == null) ConnectionString = "Host=localhost;Port=5432;Database=schedule_api_db_3;Username=postgres;Password=5525854565";
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
