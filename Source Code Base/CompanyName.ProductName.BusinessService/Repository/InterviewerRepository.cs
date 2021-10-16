using AspireSystems.TakeYourJob.BusinessService.Context;
using AspireSystems.TakeYourJob.BusinessService.Models;
using AspireSystems.TakeYourJob.BusinessService.Repository.RepositoryBase;
using AspireSystems.TakeYourJob.BusinessService.RepositoryContracts;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace AspireSystems.TakeYourJob.BusinessService.Repository
{
    public class InterviewerRepository : AspireSystemsRepository<Interviewer>, IInterviewerRepository
    {
        #region Constructor
        public InterviewerRepository(IContext _context)
            : base(_context)
        { }
        #endregion
        string query = ("InsertRecruiterDetails @p0,@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@p13,@p14");
        public List<SqlParameter> RecruiterStoredProcedure(Interviewer recruiter)
        {
            List<SqlParameter> sqlParameter = new List<SqlParameter>()
               {
             new SqlParameter("@p0",recruiter.RoleId),
             new SqlParameter("@p1",recruiter.CreatedAt),
             new SqlParameter("@p2",recruiter.Id),
             new SqlParameter("@p3",recruiter.Status),
             new SqlParameter("@p4",recruiter.CreatedByUserId),
             new SqlParameter("@p5",recruiter.UpdatedByUserId),
             new SqlParameter("@p6",recruiter.CompanyName),
             new SqlParameter("@p7",recruiter.Email),
             new SqlParameter("@p8",recruiter.MobileNumber),
             new SqlParameter("@p9",recruiter.Password),
             new SqlParameter("@p10",recruiter.ConfirmPassword),
             new SqlParameter("@p11",recruiter.Name),
             new SqlParameter("@p12",recruiter.CompanyType),
             new SqlParameter("@p13",recruiter.CompanyAddress),
             new SqlParameter("@p14",recruiter.Pincode)
            
                };

            return sqlParameter;
        }
        public bool EntityPassing(Interviewer recruiter)
        {
            this.DbSet.Add(recruiter);
            this.CaptureAudit();
            this.AddQuery(this.query, this.RecruiterStoredProcedure(recruiter));
            return true;
        }

    }
}
