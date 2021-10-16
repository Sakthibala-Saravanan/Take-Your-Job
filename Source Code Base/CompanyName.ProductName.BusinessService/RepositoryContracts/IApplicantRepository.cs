using AspireSystems.TakeYourJob.BusinessService.Models;
using AspireSystems.TakeYourJob.BusinessService.RepositoryContracts.RepositoryBaseContract;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace AspireSystems.TakeYourJob.BusinessService.RepositoryContracts
{
    public interface IApplicantRepository : IAspireSystemsRepository<Applicant>
    {
        List<SqlParameter> CandidateStoredProcedure(Applicant candidate);
        bool EntityPassing(Applicant candidate);
        Guid GetById(string Email);
    }
}
