using AspireSystems.TakeYourJob.BusinessService.Models;
using AspireSystems.TakeYourJob.BusinessService.RepositoryContracts;
using AspireSystems.TakeYourJob.BusinessService.ServiceContracts;
using AspireSystems.TakeYourJob.BusinessService.Services.ServiceBase;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspireSystems.TakeYourJob.BusinessService.Services
{
    public class AppliedCandidateService : AspireSystemsService<AppliedCandidate>, IAppliedCandidateService
    {
        public IAppliedCandidateRepository repository;
        #region Constructor
        public AppliedCandidateService(IAppliedCandidateRepository _repository)
            : base(_repository)
        {
            this.repository = _repository;
        }
        #endregion
        public string Id()
        {
            var Id = repository.Id();
            return Id;
        }
        public AppliedCandidate GetCandidate(Guid id)
        {
            var candidate = repository.GetCandidate(id);
            return candidate;
        }
    }
}
