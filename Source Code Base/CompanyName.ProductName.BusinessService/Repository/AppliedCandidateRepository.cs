using AspireSystems.TakeYourJob.BusinessService.Context;
using AspireSystems.TakeYourJob.BusinessService.Models;
using AspireSystems.TakeYourJob.BusinessService.Repository.RepositoryBase;
using AspireSystems.TakeYourJob.BusinessService.RepositoryContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AspireSystems.TakeYourJob.BusinessService.Repository
{
    public class AppliedCandidateRepository : AspireSystemsRepository<AppliedCandidate>, IAppliedCandidateRepository
    {
        #region Constructor
        public AppliedCandidateRepository(IContext _context)
            : base(_context)
        { }

        public AppliedCandidate GetCandidate(Guid id)
        {
            var candidate = this.Context.SetQuery<AppliedCandidate>().FirstOrDefault(a => a.JobId.Equals(id));
            return candidate;
        }
        #endregion

    }
}
