using AspireSystems.TakeYourJob.BusinessService.Models;
using AspireSystems.Service.Context;
using Microsoft.EntityFrameworkCore;

namespace AspireSystems.TakeYourJob.BusinessService.Context
{
    public partial class Dbcontext : BaseContext, IContext
    {
        public DbSet<Applicant> Candidates { get; set; }
        public DbSet<Interviewer> Recruiters { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Login> Logins { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<AppliedCandidate> AppliedCandidates { get; set; }

    }
}
