using Microsoft.EntityFrameworkCore.Migrations;

namespace AspireSystems.TakeYourJob.BusinessService.Migrations
{
    public partial class AlterLogin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Login",
                newName: "Email");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Login",
                newName: "Name");
        }
    }
}
