﻿using AspireSystems.TakeYourJob.BusinessService.Models;
using AspireSystems.TakeYourJob.BusinessService.RepositoryContracts.RepositoryBaseContract;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspireSystems.TakeYourJob.BusinessService.RepositoryContracts
{
   public interface IAppliedCandidateRepository : IAspireSystemsRepository<AppliedCandidate>
    {
        AppliedCandidate GetCandidate(Guid id);
    }
}
