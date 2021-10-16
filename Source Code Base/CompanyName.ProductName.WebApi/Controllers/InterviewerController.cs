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
    [Route("api/Interviewer")]
    [ApiController]
    public class InterviewerController : BaseAsyncController<Interviewer,InterviewerDto>
    {
        #region Member
        private readonly IInterviewerService service;
        #endregion

        #region Constructor
        public InterviewerController(IInterviewerService _service,
            IBaseModelToDtoMapper<Interviewer, InterviewerDto> _dtoMapper,
            IBaseDtoToModelMapper<InterviewerDto, Interviewer> _modelMapper,
            IAspireSystemsApiMessage<IAspireSystemsApiResponse> _message)
            : base(_service, _dtoMapper, _modelMapper, _message)
        {
            this.service = _service;
            
        }
        #endregion

        #region Override & Public methods
        [Route("PostInterviewer")]
        [HttpPost]
        public IActionResult PostRecruiter(InterviewerDto recruiter)
        {

            var modelMapper = _modelMapper.Map(recruiter);
            this.service.GetCurrentTime(modelMapper);
            modelMapper.RoleId = this.service.GetRecruiterRoleId("Recruiter");
            var result = this.service.EntityPassing(modelMapper);
            if (result)
            {
                return Ok();
            }
            return NotFound();
        }

        #endregion
    }
}
