using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Logbook.Migrations
{
    public partial class RemodelDone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Repeat",
                table: "Done");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CompletedDate",
                table: "Done",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CompletedDate",
                table: "Done",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AddColumn<bool>(
                name: "Repeat",
                table: "Done",
                nullable: false,
                defaultValue: false);
        }
    }
}
