using Microsoft.EntityFrameworkCore.Migrations;

namespace EfCoreScaffold.Migrations
{
    public partial class dPrimaryAuthorOnBook : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AuthorFirstName",
                table: "Book",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AuthorLastName",
                table: "Book",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Book_AuthorFirstName_AuthorLastName",
                table: "Book",
                columns: new[] { "AuthorFirstName", "AuthorLastName" });

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Author_AuthorFirstName_AuthorLastName",
                table: "Book",
                columns: new[] { "AuthorFirstName", "AuthorLastName" },
                principalTable: "Author",
                principalColumns: new[] { "FirstName", "LastName" },
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_Author_AuthorFirstName_AuthorLastName",
                table: "Book");

            migrationBuilder.DropIndex(
                name: "IX_Book_AuthorFirstName_AuthorLastName",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "AuthorFirstName",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "AuthorLastName",
                table: "Book");
        }
    }
}
