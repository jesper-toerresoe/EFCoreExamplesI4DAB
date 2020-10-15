using Microsoft.EntityFrameworkCore.Migrations;

namespace EfCoreScaffold.Migrations
{
    public partial class gAEdtionNameConstrain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateCheckConstraint(
                name: "constraint_edition",
                table: "Edition",
                sql: "'name' = 'paperback' OR 'name' = 'e-book' OR 'name' = 'hardback' OR 'name' = 'audio'");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "constraint_edition",
                table: "Edition");
        }
    }
}
