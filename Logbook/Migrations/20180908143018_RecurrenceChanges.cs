using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Logbook.Migrations
{
    public partial class RecurrenceChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tracked_Categories_CategoryId",
                table: "Tracked");

            migrationBuilder.DropTable(
                name: "Occurrences");

            migrationBuilder.RenameColumn(
                name: "Completed",
                table: "Tracked",
                newName: "IsRecurring");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Tracked",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RecurString",
                table: "Tracked",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Complete",
                table: "Tracked",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DueDate",
                table: "Tracked",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Tracked",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Done",
                columns: table => new
                {
                    DoneId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DueDate = table.Column<DateTime>(nullable: true),
                    Repeat = table.Column<bool>(nullable: false),
                    CompletedDate = table.Column<DateTime>(nullable: true),
                    Cost = table.Column<decimal>(nullable: true),
                    TrackedId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Done", x => x.DoneId);
                    table.ForeignKey(
                        name: "FK_Done_Tracked_TrackedId",
                        column: x => x.TrackedId,
                        principalTable: "Tracked",
                        principalColumn: "TrackedId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Done_TrackedId",
                table: "Done",
                column: "TrackedId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tracked_Categories_CategoryId",
                table: "Tracked",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tracked_Categories_CategoryId",
                table: "Tracked");

            migrationBuilder.DropTable(
                name: "Done");

            migrationBuilder.DropColumn(
                name: "RecurString",
                table: "Tracked");

            migrationBuilder.DropColumn(
                name: "Complete",
                table: "Tracked");

            migrationBuilder.DropColumn(
                name: "DueDate",
                table: "Tracked");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Tracked");

            migrationBuilder.RenameColumn(
                name: "IsRecurring",
                table: "Tracked",
                newName: "Completed");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Tracked",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateTable(
                name: "Occurrences",
                columns: table => new
                {
                    OccurrenceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CompletedDate = table.Column<DateTime>(nullable: true),
                    Cost = table.Column<decimal>(nullable: true),
                    DueDate = table.Column<DateTime>(nullable: true),
                    Repeat = table.Column<bool>(nullable: false),
                    TrackedId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Occurrences", x => x.OccurrenceId);
                    table.ForeignKey(
                        name: "FK_Occurrences_Tracked_TrackedId",
                        column: x => x.TrackedId,
                        principalTable: "Tracked",
                        principalColumn: "TrackedId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Occurrences_TrackedId",
                table: "Occurrences",
                column: "TrackedId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tracked_Categories_CategoryId",
                table: "Tracked",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
