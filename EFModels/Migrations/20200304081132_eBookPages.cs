using Microsoft.EntityFrameworkCore.Migrations;

namespace EfCoreScaffold.Migrations
{
    public partial class eBookPages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateCheckConstraint(
                name: "constraint_pages_positive",
                table: "Book",
                sql: "'pages' > 0");

            migrationBuilder.AddColumn<int>(
                name: "Pages",
                table: "Book",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "constraint_pages_positive",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "Pages",
                table: "Book");
        }
    }
}
