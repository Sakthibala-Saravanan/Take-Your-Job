using AspireSystems.TakeYourJob.BusinessService.Models;
using AspireSystems.TakeYourJob.BusinessService.ServiceContracts.ServiceBaseContract;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspireSystems.TakeYourJob.BusinessService.ServiceContracts
{
    public interface IInterviewerService : IAspireSystemsService<Interviewer>
    {
        Guid GetRecruiterRoleId(string roleName);
        bool EntityPassing(Interviewer recruiter);
    }
}
