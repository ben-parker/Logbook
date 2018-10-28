using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Logbook.Migrations
{
    public partial class UpdateOccurrenceTrackedModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MarkDone",
                table: "Tracked");

            migrationBuilder.RenameColumn(
                name: "Repeat",
                table: "Tracked",
                newName: "Completed");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DueDate",
                table: "Occurrences",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AddColumn<bool>(
                name: "Repeat",
                table: "Occurrences",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Repeat",
                table: "Occurrences");

            migrationBuilder.RenameColumn(
                name: "Completed",
                table: "Tracked",
                newName: "Repeat");

            migrationBuilder.AddColumn<bool>(
                name: "MarkDone",
                table: "Tracked",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DueDate",
                table: "Occurrences",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);
        }
    }
}
