using Microsoft.EntityFrameworkCore.Migrations;

namespace EfCoreScaffold.Migrations
{
    public partial class a_isbn13_unique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Isbn13",
                table: "Book",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Book_Isbn13",
                table: "Book",
                column: "Isbn13",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Book_Isbn13",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "Isbn13",
                table: "Book");
        }
    }
}
