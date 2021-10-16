using Microsoft.EntityFrameworkCore.Migrations;

namespace AspireSystems.TakeYourJob.BusinessService.Migrations
{
    public partial class StoredProcedure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var CandidatestoredProcedure = @"CREATE PROCEDURE InsertCandidateDetails
              
               @Name Varchar(50),
               @Email Varchar(100),
               @MobileNumber bigint ,
               @DateOfBirth Varchar(50),
                @Gender Varchar(50),
               @Password Varchar(50),
                @ConfirmPassword Varchar(50),
                @City Varchar(50),
            @Question Varchar(50),
             @Answer  Varchar(100),
            @HSCBoard Varchar(100),
@HSCSpecialization Varchar(50),
@HSCPassingYear int,
@HSCMedium Varchar(50),
@HSCPercentage int,
@SSLCBoard Varchar(50),
@SSLCPassingYear int,
@SSLCMedium Varchar(50),
@SSLCPercentage int,
@Qualification Varchar(50),
@Course Varchar(50),
@Specialization Varchar(50),
@CollegeName Varchar(100),
@CollegeType Varchar(50),
@PassingYear int,
@ProfessionalBackground Varchar(50),
@Location Varchar(50),
@JobType Varchar(50),
@EmploymentType Varchar(50),
@Skills Varchar(50),
@Experience int,
@RoleId uniqueidentifier,
 @CreatedAt Datetime,
@Id uniqueidentifier
             AS
           BEGIN
             SET NOCOUNT ON;
            Insert into Candidate([Name],[Email],[MobileNumber],[DateOfBirth],[Gender],[Password],[ConfirmPassword],
[City],[Question],[Answer],[HSCBoard],[HSCSpecialization],[HSCPassingYear],[HSCMedium],[HSCPercentage],
[SSLCBoard],[SSLCPassingYear],[SSLCMedium],[SSLCPercentage],[Qualification],[Course],[Specialization],
[CollegeName],[CollegeType],[PassingYear],[ProfessionalBackground],[Location],[JobType],[EmploymentType],
[Skills],[Experience],[RoleId],[CreatedAt],[Id])
             Values(@Name,@Email,@MobileNumber,@DateOfBirth,@Gender,@Password,@ConfirmPassword,@City,@Question,
@Answer,@HSCBoard,@HSCSpecialization,@HSCPassingYear,@HSCMedium,@HSCPercentage,
@SSLCBoard,@SSLCPassingYear,@SSLCMedium,@SSLCPercentage,@Qualification,@Course,@Specialization,
@CollegeName,@CollegeType,@PassingYear,@ProfessionalBackground,@Location,@JobType,@EmploymentType,
@Skills,@Experience,@RoleId,@CreatedAt,Id);
           
           Insert into Login([CreatedAt],[Email],[Password],[RoleId]) Values(@CreatedAt,@Email,@Password,@RoleId);
 
           END";
            migrationBuilder.Sql(CandidatestoredProcedure);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
