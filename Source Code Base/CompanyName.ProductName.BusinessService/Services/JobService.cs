using AspireSystems.TakeYourJob.BusinessService.Models;
using AspireSystems.TakeYourJob.BusinessService.RepositoryContracts;
using AspireSystems.TakeYourJob.BusinessService.ServiceContracts;
using AspireSystems.TakeYourJob.BusinessService.Services.ServiceBase;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspireSystems.TakeYourJob.BusinessService.Services
{
    public class JobService : AspireSystemsService<Job>, IJobService
    {
        public IJobRepository repository;
        #region Constructor
        public JobService(IJobRepository _repository)
            : base(_repository)
        {
            this.repository = _repository;
        }
        #endregion
        public string Id()
        {
            var Id = this.repository.Id();
            return Id;
        }

    }
}
