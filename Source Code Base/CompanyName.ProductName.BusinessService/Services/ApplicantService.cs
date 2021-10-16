using AspireSystems.TakeYourJob.BusinessService.Models;
using AspireSystems.TakeYourJob.BusinessService.RepositoryContracts;
using AspireSystems.TakeYourJob.BusinessService.ServiceContracts;
using AspireSystems.TakeYourJob.BusinessService.Services.ServiceBase;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace AspireSystems.TakeYourJob.BusinessService.Services
{
    public class ApplicantService : AspireSystemsService<Applicant>, IApplicantService
    {
        public IApplicantRepository repository;
        #region Constructor
        public ApplicantService(IApplicantRepository _repository)
            : base(_repository)
        {
            this.repository = _repository;
        }
        #endregion
        public Guid GetApplicantRoleId(string roleName)
        {
            var RoleId = this.repository.GetCandidateRoleId(roleName);
            return RoleId;
        }
        public bool EntityPassing(Applicant candidate)
        {
            var result = this.repository.EntityPassing(candidate);
            return result;
        }
        public Guid GetId(string Email)
        {
            var Id = this.repository.GetById(Email);
            return Id;
        }
    }
}
