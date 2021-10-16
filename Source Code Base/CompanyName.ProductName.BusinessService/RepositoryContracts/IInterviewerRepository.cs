using AspireSystems.TakeYourJob.BusinessService.Models;
using AspireSystems.TakeYourJob.BusinessService.RepositoryContracts.RepositoryBaseContract;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace AspireSystems.TakeYourJob.BusinessService.RepositoryContracts
{
    public interface IInterviewerRepository : IAspireSystemsRepository<Interviewer>
    {
        List<SqlParameter> RecruiterStoredProcedure(Interviewer recruiter);
        bool EntityPassing(Interviewer recruiter);

    }
}
