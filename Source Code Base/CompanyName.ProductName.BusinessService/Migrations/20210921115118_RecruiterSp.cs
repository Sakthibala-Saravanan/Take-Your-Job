using Microsoft.EntityFrameworkCore.Migrations;

namespace AspireSystems.TakeYourJob.BusinessService.Migrations
{
    public partial class RecruiterSp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var RecruiterstoredProcedure = @"CREATE PROCEDURE InsertRecruiterDetails
             @RoleId uniqueidentifier,
             @CreatedAt Datetime,
             @Id uniqueidentifier,
             @Status bit,
             @CreatedByUserId uniqueidentifier,
             @UpdatedByUserId uniqueidentifier, 
              @CompanyName Varchar(50),
               @Email Varchar(100),
               @MobileNumber bigint ,
               @Password Varchar(50),
               @ConfirmPassword Varchar(50),
               @Name Varchar(50),
               @CompanyType varchar(50),
               @CompanyAddress varchar(50),
               @Pincode bigint
             AS
           BEGIN
             SET NOCOUNT ON;
            Insert into Interviewer([RoleId],[CreatedAt],[Id],[Status],[CreatedByUserId],[UpdatedByUserId],
[CompanyName],[Email],[MobileNumber],[Password],[ConfirmPassword],[Name],[CompanyType],[CompanyAddress],[Pincode])
   values(@RoleId,@CreatedAt,@Id,@Status,@CreatedByUserId,@UpdatedByUserId,@CompanyName,
@Email,@MobileNumber,@Password,@ConfirmPassword,@Name,@CompanyType,@CompanyAddress,@Pincode);
           
           Insert into Login([Id],[Status],[CreatedAt],[CreatedByUserId],[Email],[Password],[RoleId],[UpdatedByUserId]) 
Values(@Id,@Status,@CreatedAt,@CreatedByUserId,@Email,@Password,@RoleId,@UpdatedByUserId);
 
           END";
            migrationBuilder.Sql(RecruiterstoredProcedure);
        }
          

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
