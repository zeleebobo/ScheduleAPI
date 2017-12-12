using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ScheduleApi.DataAccess.Migrations
{
    public partial class TeacherDiscipline : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeacherDiscipline_Disciplines_DisciplineId",
                table: "TeacherDiscipline");

            migrationBuilder.DropForeignKey(
                name: "FK_TeacherDiscipline_Teachers_TeacherId",
                table: "TeacherDiscipline");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeacherDiscipline",
                table: "TeacherDiscipline");

            migrationBuilder.RenameTable(
                name: "TeacherDiscipline",
                newName: "TeacherDisciplines");

            migrationBuilder.RenameIndex(
                name: "IX_TeacherDiscipline_TeacherId",
                table: "TeacherDisciplines",
                newName: "IX_TeacherDisciplines_TeacherId");

            migrationBuilder.RenameIndex(
                name: "IX_TeacherDiscipline_DisciplineId",
                table: "TeacherDisciplines",
                newName: "IX_TeacherDisciplines_DisciplineId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeacherDisciplines",
                table: "TeacherDisciplines",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherDisciplines_Disciplines_DisciplineId",
                table: "TeacherDisciplines",
                column: "DisciplineId",
                principalTable: "Disciplines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherDisciplines_Teachers_TeacherId",
                table: "TeacherDisciplines",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeacherDisciplines_Disciplines_DisciplineId",
                table: "TeacherDisciplines");

            migrationBuilder.DropForeignKey(
                name: "FK_TeacherDisciplines_Teachers_TeacherId",
                table: "TeacherDisciplines");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeacherDisciplines",
                table: "TeacherDisciplines");

            migrationBuilder.RenameTable(
                name: "TeacherDisciplines",
                newName: "TeacherDiscipline");

            migrationBuilder.RenameIndex(
                name: "IX_TeacherDisciplines_TeacherId",
                table: "TeacherDiscipline",
                newName: "IX_TeacherDiscipline_TeacherId");

            migrationBuilder.RenameIndex(
                name: "IX_TeacherDisciplines_DisciplineId",
                table: "TeacherDiscipline",
                newName: "IX_TeacherDiscipline_DisciplineId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeacherDiscipline",
                table: "TeacherDiscipline",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherDiscipline_Disciplines_DisciplineId",
                table: "TeacherDiscipline",
                column: "DisciplineId",
                principalTable: "Disciplines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherDiscipline_Teachers_TeacherId",
                table: "TeacherDiscipline",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
