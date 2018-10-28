using Microsoft.EntityFrameworkCore.Migrations;

namespace Logbook.Migrations
{
    public partial class UpdateModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Public",
                table: "Category");

            migrationBuilder.AlterColumn<decimal>(
                name: "Cost",
                table: "Occurrences",
                nullable: true,
                oldClrType: typeof(decimal));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Cost",
                table: "Occurrences",
                nullable: false,
                oldClrType: typeof(decimal),
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Public",
                table: "Category",
                nullable: false,
                defaultValue: false);
        }
    }
}
