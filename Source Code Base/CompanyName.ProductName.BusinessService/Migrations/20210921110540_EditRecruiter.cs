using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AspireSystems.TakeYourJob.BusinessService.Migrations
{
    public partial class EditRecruiter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Interviewer",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedByUserId = table.Column<Guid>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedByUserId = table.Column<Guid>(nullable: true),
                    RoleId = table.Column<Guid>(nullable: false),
                    CompanyName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    MobileNumber = table.Column<long>(nullable: false),
                    Password = table.Column<string>(nullable: true),
                    ConfirmPassword = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    CompanyType = table.Column<string>(nullable: true),
                    CompanyAddress = table.Column<string>(nullable: true),
                    Pincode = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interviewer", x => x.Id);
                    table.ForeignKey(
    name: "FK_Interviewer_Role_RoleId",
    column: x => x.RoleId,
    principalTable: "Role",
    principalColumn: "Id",
    onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateIndex(
        name: "IX_Interviewer_RoleId",
        table: "Interviewer",
        column: "RoleId");

        }
    

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
             name: "Interviewer");
        }
    }
}
