﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using ScheduleApi.DataAccess;
using ScheduleApi.Domain.Entities;
using System;

namespace ScheduleApi.DataAccess.Migrations
{
    [DbContext(typeof(ScheduleContext))]
    partial class ScheduleContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125");

            modelBuilder.Entity("ScheduleApi.Domain.Entities.Discipline", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Disciplines");
                });

            modelBuilder.Entity("ScheduleApi.Domain.Entities.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("ScheduleApi.Domain.Entities.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("ScheduleApi.Domain.Entities.Schedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Schedules");
                });

            modelBuilder.Entity("ScheduleApi.Domain.Entities.ScheduleEntry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DayOfWeek");

                    b.Property<int>("DisciplineId");

                    b.Property<int>("GroupId");

                    b.Property<int>("RoomId");

                    b.Property<int?>("ScheduleId");

                    b.Property<int>("SubGroupNum");

                    b.Property<int>("TeacherId");

                    b.Property<int>("WeekNumber");

                    b.HasKey("Id");

                    b.HasIndex("DisciplineId");

                    b.HasIndex("GroupId");

                    b.HasIndex("RoomId");

                    b.HasIndex("ScheduleId");

                    b.HasIndex("TeacherId");

                    b.ToTable("ScheduleEntries");
                });

            modelBuilder.Entity("ScheduleApi.Domain.Entities.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("ScheduleApi.Domain.Entities.TeacherDiscipline", b =>
                {
                    b.Property<int>("TeacherId");

                    b.Property<int>("DisciplineId");

                    b.HasKey("TeacherId", "DisciplineId");

                    b.HasIndex("DisciplineId");

                    b.ToTable("TeacherDisciplines");
                });

            modelBuilder.Entity("ScheduleApi.Domain.Entities.ScheduleEntry", b =>
                {
                    b.HasOne("ScheduleApi.Domain.Entities.Discipline", "Discipline")
                        .WithMany("Entries")
                        .HasForeignKey("DisciplineId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ScheduleApi.Domain.Entities.Group", "Group")
                        .WithMany("Entries")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ScheduleApi.Domain.Entities.Room", "Room")
                        .WithMany("Entries")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ScheduleApi.Domain.Entities.Schedule", "Schedule")
                        .WithMany("Entries")
                        .HasForeignKey("ScheduleId");

                    b.HasOne("ScheduleApi.Domain.Entities.Teacher", "Teacher")
                        .WithMany("Entries")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ScheduleApi.Domain.Entities.TeacherDiscipline", b =>
                {
                    b.HasOne("ScheduleApi.Domain.Entities.Discipline", "Discipline")
                        .WithMany("TeacherDisciplines")
                        .HasForeignKey("DisciplineId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ScheduleApi.Domain.Entities.Teacher", "Teacher")
                        .WithMany("TeacherDisciplines")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
