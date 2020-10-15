using Microsoft.EntityFrameworkCore.Migrations;

namespace EfCoreScaffold.Migrations
{
    public partial class hNextInSeries : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NextBookIsbn10",
                table: "Book",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Book_NextBookIsbn10",
                table: "Book",
                column: "NextBookIsbn10",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Book_NextBookIsbn10",
                table: "Book",
                column: "NextBookIsbn10",
                principalTable: "Book",
                principalColumn: "Isbn10",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_Book_NextBookIsbn10",
                table: "Book");

            migrationBuilder.DropIndex(
                name: "IX_Book_NextBookIsbn10",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "NextBookIsbn10",
                table: "Book");
        }
    }
}
