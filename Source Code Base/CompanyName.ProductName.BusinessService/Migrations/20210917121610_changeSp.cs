using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace AspireSystems.TakeYourJob.BusinessService.Migrations
{
    public partial class changeSp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
   name: "Applicant",
   columns: table => new
   {
       Id = table.Column<Guid>(nullable: false),
       Status = table.Column<bool>(nullable: false),
       CreatedAt = table.Column<DateTime>(nullable: false),
       CreatedByUserId = table.Column<Guid>(nullable: false),
       UpdatedAt = table.Column<DateTime>(nullable: true),
       UpdatedByUserId = table.Column<Guid>(nullable: true),
       RoleId = table.Column<Guid>(nullable: false),
       Name = table.Column<string>(nullable: true),
       Email = table.Column<string>(nullable: true),
       MobileNumber = table.Column<long>(nullable: false),
       DateOfBirth = table.Column<string>(nullable: true),
       Gender = table.Column<string>(nullable: true),
       Password = table.Column<string>(nullable: true),
       ConfirmPassword = table.Column<string>(nullable: true),
       City = table.Column<string>(nullable: true),
       Question = table.Column<string>(nullable: true),
       Answer = table.Column<string>(nullable: true),
       HSCBoard = table.Column<string>(nullable: true),
       HSCSpecialization = table.Column<string>(nullable: true),
       HSCPassingYear = table.Column<int>(nullable: false),
       HSCMedium = table.Column<string>(nullable: true),
       HSCPercentage = table.Column<int>(nullable: false),
       SSLCBoard = table.Column<string>(nullable: true),
       SSLCPassingYear = table.Column<int>(nullable: false),
       SSLCMedium = table.Column<string>(nullable: true),
       SSLCPercentage = table.Column<int>(nullable: false),
       Qualification = table.Column<string>(nullable: true),
       Course = table.Column<string>(nullable: true),
       Specialization = table.Column<string>(nullable: true),
       CollegeName = table.Column<string>(nullable: true),
       CollegeType = table.Column<string>(nullable: true),
       PassingYear = table.Column<int>(nullable: false),
       ProfessionalBackground = table.Column<string>(nullable: true),
       Location = table.Column<string>(nullable: true),
       JobType = table.Column<string>(nullable: true),
       EmploymentType = table.Column<string>(nullable: true),
       Skills = table.Column<string>(nullable: true),
       Experience = table.Column<int>(nullable: false)
   },
   constraints: table =>
   {
       table.PrimaryKey("PK_Applicant", x => x.Id);
       table.ForeignKey(
    name: "FK_Applicant_Role_RoleId",
    column: x => x.RoleId,
    principalTable: "Role",
    principalColumn: "Id",
    onDelete: ReferentialAction.Cascade);
   });

            migrationBuilder.CreateIndex(
           name: "IX_Applicant_RoleId",
           table: "Applicant",
           column: "RoleId");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
            name: "Applicant");
        }
    }
}
