using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ScheduleApi.DataAccess.Migrations
{
    public partial class PreRelease : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Disciplines_DisciplineId",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Teachers_DisciplineId",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "DisciplineId",
                table: "Teachers");

            migrationBuilder.AddColumn<int>(
                name: "Position",
                table: "ScheduleEntries",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Position",
                table: "ScheduleEntries");

            migrationBuilder.AddColumn<int>(
                name: "DisciplineId",
                table: "Teachers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_DisciplineId",
                table: "Teachers",
                column: "DisciplineId");

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Disciplines_DisciplineId",
                table: "Teachers",
                column: "DisciplineId",
                principalTable: "Disciplines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
