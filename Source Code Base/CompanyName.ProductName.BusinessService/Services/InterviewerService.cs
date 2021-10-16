using AspireSystems.TakeYourJob.BusinessService.Models;
using AspireSystems.TakeYourJob.BusinessService.RepositoryContracts;
using AspireSystems.TakeYourJob.BusinessService.ServiceContracts;
using AspireSystems.TakeYourJob.BusinessService.Services.ServiceBase;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspireSystems.TakeYourJob.BusinessService.Services
{
    public class InterviewerService : AspireSystemsService<Interviewer>, IInterviewerService
    {
        public IInterviewerRepository repository;
        #region Constructor
        public InterviewerService(IInterviewerRepository _repository)
            : base(_repository)
        {
            this.repository = _repository;
        }
        #endregion
        public Guid GetRecruiterRoleId(string roleName)
        {
            var RoleId = this.repository.GetCandidateRoleId(roleName);
            return RoleId;
        }
        public bool EntityPassing(Interviewer recruiter)
        {
            var result = this.repository.EntityPassing(recruiter);
            return result;
        }

    }
}
