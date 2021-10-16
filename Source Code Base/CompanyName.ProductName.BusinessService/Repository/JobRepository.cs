using AspireSystems.TakeYourJob.BusinessService.Context;
using AspireSystems.TakeYourJob.BusinessService.Models;
using AspireSystems.TakeYourJob.BusinessService.Repository.RepositoryBase;
using AspireSystems.TakeYourJob.BusinessService.RepositoryContracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspireSystems.TakeYourJob.BusinessService.Repository
{
    public class JobRepository : AspireSystemsRepository<Job>, IJobRepository
    {
        #region Constructor
        public JobRepository(IContext _context)
            : base(_context)
        { }
        #endregion

       


    }
}
