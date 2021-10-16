using AspireSystems.TakeYourJob.BusinessService.Models;
using AspireSystems.TakeYourJob.BusinessService.ServiceContracts.ServiceBaseContract;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace AspireSystems.TakeYourJob.BusinessService.ServiceContracts
{
    public interface IApplicantService : IAspireSystemsService<Applicant>
    {
        Guid GetApplicantRoleId(string roleName);
        bool EntityPassing(Applicant candidate);

        Guid GetId(string Email);
    }
}
