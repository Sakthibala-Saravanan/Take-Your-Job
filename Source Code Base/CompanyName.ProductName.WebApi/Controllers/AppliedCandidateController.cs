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
    [Route("api/[controller]")]
    [ApiController]
    public class AppliedCandidateController : BaseAsyncController<AppliedCandidate, AppliedCandidateDto>
    {
        #region Member
        private readonly IAppliedCandidateService service;
        #endregion

        #region Constructor
        public AppliedCandidateController(IAppliedCandidateService _service,
            IBaseModelToDtoMapper<AppliedCandidate, AppliedCandidateDto> _dtoMapper,
            IBaseDtoToModelMapper<AppliedCandidateDto, AppliedCandidate> _modelMapper,
            IAspireSystemsApiMessage<IAspireSystemsApiResponse> _message)
            : base(_service, _dtoMapper, _modelMapper, _message)
        {
            this.service = _service;
        }
        #endregion

        #region Override & Public methods 
        [Route("PostAppliedCandidates")]
        [HttpPost]
        public Task<IActionResult> PostAppliedCandidate(AppliedCandidateDto appliedCandidateDto)
        {
            appliedCandidateDto.CandidateId = this.service.Id();
            return Post(appliedCandidateDto);
        }
        [Route("GetAppliedCandidates")]
        [HttpPost]
        public IActionResult GetAppliedCandidate(Guid id)
        {
            var result = this.service.GetCandidate(id);
            return Ok(result);
        }
        #endregion        
    }
}
