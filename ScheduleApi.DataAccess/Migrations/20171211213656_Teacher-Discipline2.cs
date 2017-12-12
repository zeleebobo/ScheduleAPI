using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ScheduleApi.DataAccess.Migrations
{
    public partial class TeacherDiscipline2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropIndex(
                name: "IX_TeacherDisciplines_TeacherId",
                table: "TeacherDisciplines");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "TeacherDisciplines");

            migrationBuilder.AlterColumn<int>(
                name: "TeacherId",
                table: "TeacherDisciplines",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DisciplineId",
                table: "TeacherDisciplines",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeacherDisciplines",
                table: "TeacherDisciplines",
                columns: new[] { "TeacherId", "DisciplineId" });

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherDisciplines_Disciplines_DisciplineId",
                table: "TeacherDisciplines",
                column: "DisciplineId",
                principalTable: "Disciplines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherDisciplines_Teachers_TeacherId",
                table: "TeacherDisciplines",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.AlterColumn<int>(
                name: "DisciplineId",
                table: "TeacherDisciplines",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "TeacherId",
                table: "TeacherDisciplines",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "TeacherDisciplines",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeacherDisciplines",
                table: "TeacherDisciplines",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherDisciplines_TeacherId",
                table: "TeacherDisciplines",
                column: "TeacherId");

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
    }
}
