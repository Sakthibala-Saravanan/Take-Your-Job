using AspireSystems.TakeYourJob.BusinessService.Models;
using AspireSystems.TakeYourJob.BusinessService.ServiceContracts.ServiceBaseContract;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspireSystems.TakeYourJob.BusinessService.ServiceContracts
{
    public interface IAppliedCandidateService : IAspireSystemsService<AppliedCandidate>
    {
        AppliedCandidate GetCandidate(Guid id);
        string Id();
    }
}
