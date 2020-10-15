using Microsoft.EntityFrameworkCore.Migrations;

namespace EfCoreScaffold.Migrations
{
    public partial class iVoterOrg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "VoterOrg",
                table: "Voter",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VoterOrg",
                table: "Voter");
        }
    }
}
