using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AspireSystems.TakeYourJob.BusinessService.Migrations
{
    public partial class AlterCandidate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "College");

            migrationBuilder.DropTable(
                name: "School");

            migrationBuilder.DropTable(
                name: "Work");

            migrationBuilder.AddColumn<string>(
                name: "CollegeName",
                table: "Candidate",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CollegeType",
                table: "Candidate",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Course",
                table: "Candidate",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmploymentType",
                table: "Candidate",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Experience",
                table: "Candidate",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "HSCBoard",
                table: "Candidate",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HSCMedium",
                table: "Candidate",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HSCPassingYear",
                table: "Candidate",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HSCPercentage",
                table: "Candidate",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "HSCSpecialization",
                table: "Candidate",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "JobType",
                table: "Candidate",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Candidate",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PassingYear",
                table: "Candidate",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ProfessionalBackground",
                table: "Candidate",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Qualification",
                table: "Candidate",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SSLCBoard",
                table: "Candidate",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SSLCMedium",
                table: "Candidate",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SSLCPassingYear",
                table: "Candidate",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SSLCPercentage",
                table: "Candidate",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Skills",
                table: "Candidate",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Specialization",
                table: "Candidate",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CandidateId",
                table: "AppliedCandidate",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_AppliedCandidate_CandidateId",
                table: "AppliedCandidate",
                column: "CandidateId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppliedCandidate_Candidate_CandidateId",
                table: "AppliedCandidate",
                column: "CandidateId",
                principalTable: "Candidate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppliedCandidate_Candidate_CandidateId",
                table: "AppliedCandidate");

            migrationBuilder.DropIndex(
                name: "IX_AppliedCandidate_CandidateId",
                table: "AppliedCandidate");

            migrationBuilder.DropColumn(
                name: "CollegeName",
                table: "Candidate");

            migrationBuilder.DropColumn(
                name: "CollegeType",
                table: "Candidate");

            migrationBuilder.DropColumn(
                name: "Course",
                table: "Candidate");

            migrationBuilder.DropColumn(
                name: "EmploymentType",
                table: "Candidate");

            migrationBuilder.DropColumn(
                name: "Experience",
                table: "Candidate");

            migrationBuilder.DropColumn(
                name: "HSCBoard",
                table: "Candidate");

            migrationBuilder.DropColumn(
                name: "HSCMedium",
                table: "Candidate");

            migrationBuilder.DropColumn(
                name: "HSCPassingYear",
                table: "Candidate");

            migrationBuilder.DropColumn(
                name: "HSCPercentage",
                table: "Candidate");

            migrationBuilder.DropColumn(
                name: "HSCSpecialization",
                table: "Candidate");

            migrationBuilder.DropColumn(
                name: "JobType",
                table: "Candidate");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Candidate");

            migrationBuilder.DropColumn(
                name: "PassingYear",
                table: "Candidate");

            migrationBuilder.DropColumn(
                name: "ProfessionalBackground",
                table: "Candidate");

            migrationBuilder.DropColumn(
                name: "Qualification",
                table: "Candidate");

            migrationBuilder.DropColumn(
                name: "SSLCBoard",
                table: "Candidate");

            migrationBuilder.DropColumn(
                name: "SSLCMedium",
                table: "Candidate");

            migrationBuilder.DropColumn(
                name: "SSLCPassingYear",
                table: "Candidate");

            migrationBuilder.DropColumn(
                name: "SSLCPercentage",
                table: "Candidate");

            migrationBuilder.DropColumn(
                name: "Skills",
                table: "Candidate");

            migrationBuilder.DropColumn(
                name: "Specialization",
                table: "Candidate");

            migrationBuilder.DropColumn(
                name: "CandidateId",
                table: "AppliedCandidate");

            migrationBuilder.CreateTable(
                name: "College",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CandidateId = table.Column<Guid>(nullable: false),
                    CollegeName = table.Column<string>(nullable: true),
                    CollegeType = table.Column<string>(nullable: true),
                    Course = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedByUserId = table.Column<Guid>(nullable: false),
                    PassingYear = table.Column<int>(nullable: false),
                    Qualification = table.Column<string>(nullable: true),
                    Specialization = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedByUserId = table.Column<Guid>(nullable: true)
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
                name: "School",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CandidateId = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedByUserId = table.Column<Guid>(nullable: false),
                    HSCBoard = table.Column<string>(nullable: true),
                    HSCMedium = table.Column<string>(nullable: true),
                    HSCPassingYear = table.Column<int>(nullable: false),
                    HSCPercentage = table.Column<int>(nullable: false),
                    HSCSpecialization = table.Column<string>(nullable: true),
                    SSLCBoard = table.Column<string>(nullable: true),
                    SSLCMedium = table.Column<string>(nullable: true),
                    SSLCPassingYear = table.Column<int>(nullable: false),
                    SSLCPercentage = table.Column<int>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedByUserId = table.Column<Guid>(nullable: true)
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
                    CandidateId = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedByUserId = table.Column<Guid>(nullable: false),
                    EmploymentType = table.Column<string>(nullable: true),
                    Experience = table.Column<int>(nullable: false),
                    JobType = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    ProfessionalBackground = table.Column<string>(nullable: true),
                    Skills = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedByUserId = table.Column<Guid>(nullable: true)
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

            migrationBuilder.CreateIndex(
                name: "IX_College_CandidateId",
                table: "College",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_School_CandidateId",
                table: "School",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_Work_CandidateId",
                table: "Work",
                column: "CandidateId");
        }
    }
}
