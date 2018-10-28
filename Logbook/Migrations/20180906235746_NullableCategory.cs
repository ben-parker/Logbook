using Microsoft.EntityFrameworkCore.Migrations;

namespace Logbook.Migrations
{
    public partial class NullableCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tracked_Category_CategoryId",
                table: "Tracked");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Tracked",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Tracked_Category_CategoryId",
                table: "Tracked",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tracked_Category_CategoryId",
                table: "Tracked");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Tracked",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tracked_Category_CategoryId",
                table: "Tracked",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
