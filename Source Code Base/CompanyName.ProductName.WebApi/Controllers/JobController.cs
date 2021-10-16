using AspireSystems.Api.Base.Responses.Contracts;
using AspireSystems.Api.BaseMapperContracts;
using AspireSystems.Api.Controllers;
using AspireSystems.TakeYourJob.BusinessService.Models;
using AspireSystems.TakeYourJob.BusinessService.RepositoryContracts;
using AspireSystems.TakeYourJob.BusinessService.ServiceContracts;
using AspireSystems.TakeYourJob.Infrastructure.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspireSystems.TakeYourJob.WebApi.Controllers
{
    [Route("api/Job")]
    [ApiController]
    public class JobController : BaseAsyncController<Job, JobDto>
    {
        #region Member
        private readonly IJobService service;
        #endregion

        #region Constructor
        public JobController(IJobService _service,
            IBaseModelToDtoMapper<Job, JobDto> _dtoMapper,
            IBaseDtoToModelMapper<JobDto, Job> _modelMapper,
            IAspireSystemsApiMessage<IAspireSystemsApiResponse> _message)
            : base(_service, _dtoMapper, _modelMapper, _message)
        {
            this.service = _service;
           
        }
        #endregion

        #region Override & Public methods 
        [Route("PostJob")]
        [HttpPost]
        public Task<IActionResult> PostJob(JobDto job)
        {
            job.RecruiterId = this.service.Id();
            return Post(job); 
        }
        #endregion
    }
    }
