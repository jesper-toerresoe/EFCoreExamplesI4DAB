using Microsoft.EntityFrameworkCore.Migrations;

namespace EfCoreScaffold.Migrations
{
    public partial class dReviewVoterRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "VoterFirstName",
                table: "Review",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VoterLastName",
                table: "Review",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Review_VoterFirstName_VoterLastName",
                table: "Review",
                columns: new[] { "VoterFirstName", "VoterLastName" });

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Voter_VoterFirstName_VoterLastName",
                table: "Review",
                columns: new[] { "VoterFirstName", "VoterLastName" },
                principalTable: "Voter",
                principalColumns: new[] { "FirstName", "LastName" },
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Review_Voter_VoterFirstName_VoterLastName",
                table: "Review");

            migrationBuilder.DropIndex(
                name: "IX_Review_VoterFirstName_VoterLastName",
                table: "Review");

            migrationBuilder.DropColumn(
                name: "VoterFirstName",
                table: "Review");

            migrationBuilder.DropColumn(
                name: "VoterLastName",
                table: "Review");
        }
    }
}
