using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AspireSystems.TakeYourJob.BusinessService.Migrations
{
    public partial class Tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "College",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedByUserId = table.Column<Guid>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedByUserId = table.Column<Guid>(nullable: true),
                    CandidateId = table.Column<Guid>(nullable: false),
                    Qualification = table.Column<string>(nullable: true),
                    Course = table.Column<string>(nullable: true),
                    Specialization = table.Column<string>(nullable: true),
                    CollegeName = table.Column<string>(nullable: true),
                    CollegeType = table.Column<string>(nullable: true),
                    PassingYear = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_College", x => x.Id);
                    table.ForeignKey(
                        name: "FK_College_Candidate_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Candidate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Recruiter",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedByUserId = table.Column<Guid>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedByUserId = table.Column<Guid>(nullable: true),
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
                    table.PrimaryKey("PK_Recruiter", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedByUserId = table.Column<Guid>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedByUserId = table.Column<Guid>(nullable: true),
                    RoleName = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "School",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedByUserId = table.Column<Guid>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedByUserId = table.Column<Guid>(nullable: true),
                    CandidateId = table.Column<Guid>(nullable: false),
                    HSCBoard = table.Column<string>(nullable: true),
                    HSCSpecialization = table.Column<string>(nullable: true),
                    HSCPassingYear = table.Column<int>(nullable: false),
                    HSCMedium = table.Column<string>(nullable: true),
                    HSCPercentage = table.Column<int>(nullable: false),
                    SSLCBoard = table.Column<string>(nullable: true),
                    SSLCPassingYear = table.Column<int>(nullable: false),
                    SSLCMedium = table.Column<string>(nullable: true),
                    SSLCPercentage = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_School", x => x.Id);
                    table.ForeignKey(
                        name: "FK_School_Candidate_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Candidate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Work",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedByUserId = table.Column<Guid>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedByUserId = table.Column<Guid>(nullable: true),
                    CandidateId = table.Column<Guid>(nullable: false),
                    ProfessionalBackground = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    JobType = table.Column<string>(nullable: true),
                    EmploymentType = table.Column<string>(nullable: true),
                    Skills = table.Column<string>(nullable: true),
                    Experience = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Work", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Work_Candidate_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Candidate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Job",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedByUserId = table.Column<Guid>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedByUserId = table.Column<Guid>(nullable: true),
                    RecruiterId = table.Column<Guid>(nullable: false),
                    Role = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    Experience = table.Column<int>(nullable: false),
                    Salary = table.Column<int>(nullable: false),
                    Skills = table.Column<string>(nullable: true),
                    Qualification = table.Column<string>(nullable: true),
                    SSLCPercentage = table.Column<int>(nullable: false),
                    HSCPercenatge = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Job", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Job_Recruiter_RecruiterId",
                        column: x => x.RecruiterId,
                        principalTable: "Recruiter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Login",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedByUserId = table.Column<Guid>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedByUserId = table.Column<Guid>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    RoleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Login", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Login_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppliedCandidate",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedByUserId = table.Column<Guid>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedByUserId = table.Column<Guid>(nullable: true),
                    JobId = table.Column<Guid>(nullable: false),
                    JobRole = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppliedCandidate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppliedCandidate_Job_JobId",
                        column: x => x.JobId,
                        principalTable: "Job",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppliedCandidate_JobId",
                table: "AppliedCandidate",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_College_CandidateId",
                table: "College",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_Job_RecruiterId",
                table: "Job",
                column: "RecruiterId");

            migrationBuilder.CreateIndex(
                name: "IX_Login_RoleId",
                table: "Login",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_School_CandidateId",
                table: "School",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_Work_CandidateId",
                table: "Work",
                column: "CandidateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppliedCandidate");

            migrationBuilder.DropTable(
                name: "College");

            migrationBuilder.DropTable(
                name: "Login");

            migrationBuilder.DropTable(
                name: "School");

            migrationBuilder.DropTable(
                name: "Work");

            migrationBuilder.DropTable(
                name: "Job");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Recruiter");
        }
    }
}
