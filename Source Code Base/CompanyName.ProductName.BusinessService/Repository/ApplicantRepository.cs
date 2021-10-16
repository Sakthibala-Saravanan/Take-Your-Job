using AspireSystems.TakeYourJob.BusinessService.Context;
using AspireSystems.TakeYourJob.BusinessService.Models;
using AspireSystems.TakeYourJob.BusinessService.Repository.RepositoryBase;
using AspireSystems.TakeYourJob.BusinessService.RepositoryContracts;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace AspireSystems.TakeYourJob.BusinessService.Repository
{
    public class ApplicantRepository : AspireSystemsRepository<Applicant>, IApplicantRepository
    {
        #region Constructor
        public ApplicantRepository(IContext _context)
            : base(_context)
        { }
        #endregion

        string query = ("InsertCandidateDetails @p0,@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@p13,@p14,@p15,@p16,@p17,@p18,@p19,@p20,@p21,@p22,@p23,@p24,@p25,@p26,@p27,@p28,@p29,@p30,@p31,@p32,@p33,@p34,@p35,@p36");
        public List<SqlParameter> CandidateStoredProcedure(Applicant candidate)
        {
             List<SqlParameter> sqlParameter = new List<SqlParameter>()
               {
      
             new SqlParameter("@p0",candidate.Name),
             new SqlParameter("@p1",candidate.Email),
             new SqlParameter("@p2",candidate.MobileNumber),
             new SqlParameter("@p3",candidate.DateOfBirth),
             new SqlParameter("@p4",candidate.Gender),
             new SqlParameter("@p5",candidate.Password),
             new SqlParameter("@p6",candidate.ConfirmPassword),
             new SqlParameter("@p7",candidate.City),
             new SqlParameter("@p8",candidate.Question),
             new SqlParameter("@p9",candidate.Answer),
             new SqlParameter("@p10",candidate.HSCBoard),
             new SqlParameter("@p11",candidate.HSCSpecialization),
             new SqlParameter("@p12",candidate.HSCPassingYear),
             new SqlParameter("@p13",candidate.HSCMedium),
             new SqlParameter("@p14",candidate.HSCPercentage),
             new SqlParameter("@p15",candidate.SSLCBoard),
             new SqlParameter("@p16",candidate.SSLCPassingYear),
             new SqlParameter("@p17",candidate.SSLCMedium),
             new SqlParameter("@p18",candidate.SSLCPercentage),
             new SqlParameter("@p19",candidate.Qualification),
             new SqlParameter("@p20",candidate.Course),
             new SqlParameter("@p21",candidate.Specialization),
             new SqlParameter("@p22",candidate.CollegeName),
             new SqlParameter("@p23",candidate.CollegeType),
             new SqlParameter("@p24",candidate.PassingYear),
             new SqlParameter("@p25",candidate.ProfessionalBackground),
             new SqlParameter("@p26",candidate.Location),
             new SqlParameter("@p27",candidate.JobType),
             new SqlParameter("@p28",candidate.EmploymentType),
             new SqlParameter("@p29",candidate.Skills),
             new SqlParameter("@p30",candidate.Experience),
             new SqlParameter("@p31",candidate.RoleId),
             new SqlParameter("@p32",candidate.CreatedAt),
             new SqlParameter("@p33",candidate.Id),
             new SqlParameter("@p34",candidate.Status),
             new SqlParameter("@p35",candidate.CreatedByUserId),
             new SqlParameter("@p36",candidate.UpdatedByUserId),
             };
           
            return sqlParameter;
        }
        public bool EntityPassing(Applicant candidate)
        {
           this.DbSet.Add(candidate);
           this.CaptureAudit();
           this.AddQuery(this.query, this.CandidateStoredProcedure(candidate));
           return true;
        }
        public Guid GetById(string Email)
        {
            var Id = this.Context.SetQuery<Applicant>()
                .Where(a => a.Email == Email)
                .Select(b => b.Id)
                .FirstOrDefault();
            return Id;
        }

    }
}
