using Microsoft.EntityFrameworkCore.Migrations;

namespace EfCoreScaffold.Migrations
{
    public partial class gEditionPlusRelationshipToBook : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Edition",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    BookIsbn10 = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edition", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Edition_Book_BookIsbn10",
                        column: x => x.BookIsbn10,
                        principalTable: "Book",
                        principalColumn: "Isbn10",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Edition_BookIsbn10",
                table: "Edition",
                column: "BookIsbn10");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Edition");
        }
    }
}
