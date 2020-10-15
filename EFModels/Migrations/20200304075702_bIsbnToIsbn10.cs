using Microsoft.EntityFrameworkCore.Migrations;

namespace EfCoreScaffold.Migrations
{
    public partial class bIsbnToIsbn10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookAuthors_Book_BookIsbn",
                table: "BookAuthors");

            migrationBuilder.DropForeignKey(
                name: "FK_PriceOffer_Book_BookIsbn",
                table: "PriceOffer");

            migrationBuilder.DropForeignKey(
                name: "FK_Review_Book_BookIsbn",
                table: "Review");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Book",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "Isbn",
                table: "Book");

            migrationBuilder.AddColumn<int>(
                name: "Isbn10",
                table: "Book",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Book",
                table: "Book",
                column: "Isbn10");

            migrationBuilder.AddForeignKey(
                name: "FK_BookAuthors_Book_BookIsbn",
                table: "BookAuthors",
                column: "BookIsbn",
                principalTable: "Book",
                principalColumn: "Isbn10",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PriceOffer_Book_BookIsbn",
                table: "PriceOffer",
                column: "BookIsbn",
                principalTable: "Book",
                principalColumn: "Isbn10",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Book_BookIsbn",
                table: "Review",
                column: "BookIsbn",
                principalTable: "Book",
                principalColumn: "Isbn10",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookAuthors_Book_BookIsbn",
                table: "BookAuthors");

            migrationBuilder.DropForeignKey(
                name: "FK_PriceOffer_Book_BookIsbn",
                table: "PriceOffer");

            migrationBuilder.DropForeignKey(
                name: "FK_Review_Book_BookIsbn",
                table: "Review");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Book",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "Isbn10",
                table: "Book");

            migrationBuilder.AddColumn<int>(
                name: "Isbn",
                table: "Book",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Book",
                table: "Book",
                column: "Isbn");

            migrationBuilder.AddForeignKey(
                name: "FK_BookAuthors_Book_BookIsbn",
                table: "BookAuthors",
                column: "BookIsbn",
                principalTable: "Book",
                principalColumn: "Isbn",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PriceOffer_Book_BookIsbn",
                table: "PriceOffer",
                column: "BookIsbn",
                principalTable: "Book",
                principalColumn: "Isbn",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Book_BookIsbn",
                table: "Review",
                column: "BookIsbn",
                principalTable: "Book",
                principalColumn: "Isbn",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
