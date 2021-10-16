using AspireSystems.Service.Attributes;
using AspireSystems.Service.Models;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspireSystems.TakeYourJob.BusinessService.Models
{
    [EntityIdentifier(Name ="Applicant")]
    public class Applicant : BaseModel
    {
        /// <summary>
        ///Candidate Personal details
        /// </summary>
        public Guid RoleId { get; set; }
        [ForeignKey("RoleId")]
        public Role RoleDetails { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public long MobileNumber { get; set; }
        public string DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string City { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        /// <summary>
        ///Candidate School details
        /// </summary>
        public string HSCBoard { get; set; }
        public string HSCSpecialization { get; set; }
        public int HSCPassingYear { get; set; }
        public string HSCMedium { get; set; }
        public int HSCPercentage { get; set; }
        public string SSLCBoard { get; set; }
        public int SSLCPassingYear { get; set; }
        public string SSLCMedium { get; set; }
        public int SSLCPercentage { get; set; }
        /// <summary>
        ///Candidate College details
        /// </summary>
        public string Qualification { get; set; }
        public string Course { get; set; }
        public string Specialization { get; set; }
        public string CollegeName { get; set; }
        public string CollegeType { get; set; }
        public int PassingYear { get; set; }
        /// <summary>
        ///Candidate Work details
        /// </summary>
        public string ProfessionalBackground { get; set; }
        public string Location { get; set; }
        public string JobType { get; set; }
        public string EmploymentType { get; set; }
        public string Skills { get; set; }
        public int Experience { get; set; }

    }
}

//var CandidatestoredProcedure = @"CREATE PROCEDURE InsertCandidateDetails
              
//               @Name Varchar(50),
//               @Email Varchar(100),
//               @MobileNumber bigint ,
//               @DateOfBirth Varchar(50),
//                @Gender Varchar(50),
//               @Password Varchar(50),
//                @ConfirmPassword Varchar(50),
//                @City Varchar(50),
//            @Question Varchar(50),
//             @Answer  Varchar(100),
//            @HSCBoard Varchar(100),
//@HSCSpecialization Varchar(50),
//@HSCPassingYear int,
//@HSCMedium Varchar(50),
//@HSCPercentage int,
//@SSLCBoard Varchar(50),
//@SSLCPassingYear int,
//@SSLCMedium Varchar(50),
//@SSLCPercentage int,
//@Qualification Varchar(50),
//@Course Varchar(50),
//@Specialization Varchar(50),
//@CollegeName Varchar(100),
//@CollegeType Varchar(50),
//@PassingYear int,
//@ProfessionalBackground Varchar(50),
//@Location Varchar(50),
//@JobType Varchar(50),
//@EmploymentType Varchar(50),
//@Skills Varchar(50),
//@Experience int,
//@RoleId uniqueidentifier,
//@CreatedAt Datetime,
//@Id uniqueidentifier,
//@Status bit,
//@CreatedByUserId uniqueidentifier
//             AS
//           BEGIN
//             SET NOCOUNT ON;
//            Insert into Candidate([Name],[Email],[MobileNumber],[DateOfBirth],[Gender],[Password],[ConfirmPassword],
//[City],[Question],[Answer],[HSCBoard],[HSCSpecialization],[HSCPassingYear],[HSCMedium],[HSCPercentage],
//[SSLCBoard],[SSLCPassingYear],[SSLCMedium],[SSLCPercentage],[Qualification],[Course],[Specialization],
//[CollegeName],[CollegeType],[PassingYear],[ProfessionalBackground],[Location],[JobType],[EmploymentType],
//[Skills],[Experience],[RoleId],[CreatedAt],[Id],[Status],[CreatedByUserId])
//             Values(@Name,@Email,@MobileNumber,@DateOfBirth,@Gender,@Password,@ConfirmPassword,@City,@Question,
//@Answer,@HSCBoard,@HSCSpecialization,@HSCPassingYear,@HSCMedium,@HSCPercentage,
//@SSLCBoard,@SSLCPassingYear,@SSLCMedium,@SSLCPercentage,@Qualification,@Course,@Specialization,
//@CollegeName,@CollegeType,@PassingYear,@ProfessionalBackground,@Location,@JobType,@EmploymentType,
//@Skills,@Experience,@RoleId,@CreatedAt,@Id,@Status,@CreatedByUserId);
           
//           Insert into Login([Id],[Status],[CreatedAt],[CreatedByUserId],[Email],[Password],[RoleId]) 
//Values(@Id,@Status,@CreatedAt,@CreatedByUserId,@Email,@Password,@RoleId);
 
//           END";
//migrationBuilder.Sql(CandidatestoredProcedure);