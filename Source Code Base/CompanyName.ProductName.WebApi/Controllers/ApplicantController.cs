using AspireSystems.Api.Base.Responses.Contracts;
using AspireSystems.Api.BaseMapperContracts;
using AspireSystems.Api.Controllers;
using AspireSystems.Infrastructure.Helpers;
using AspireSystems.TakeYourJob.BusinessService.Models;
using AspireSystems.TakeYourJob.BusinessService.RepositoryContracts;
using AspireSystems.TakeYourJob.BusinessService.ServiceContracts;
using AspireSystems.TakeYourJob.Infrastructure.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data.Entity;
using System.Threading.Tasks;

namespace AspireSystems.TakeYourJob.WebApi.Controllers
{
    [Route("api/Applicant")]
    [ApiController]
    public class ApplicantController : BaseAsyncController<Applicant, ApplicantDto>
    {
        #region Member
        private readonly IApplicantService service;

        #endregion

        #region Constructor
        public ApplicantController(IApplicantService _service,
            IBaseModelToDtoMapper<Applicant, ApplicantDto> _dtoMapper,
            IBaseDtoToModelMapper<ApplicantDto, Applicant> _modelMapper,
            IAspireSystemsApiMessage<IAspireSystemsApiResponse> _message)
            : base(_service, _dtoMapper, _modelMapper, _message)
        {
            this.service = _service;

        }
        #endregion

        //#region Override & Public methods
        //[Route("delete/{id}")]
        //[HttpDelete]
        //public async Task<IActionResult> DeletAsync(Guid id)
        //{
        //    Check.EmptyGuid("Id", id);
        //    var entity = await this.service.GetByIdAsync(id);
        //    if (entity != null)
        //    {
        //        var status = await this.service.SoftDeleteAsync(entity);
        //    }
        //    return NotFound();
        //}
        //#endregion
        #region
        [Route("PostApplicant")]
        [HttpPost]
        public IActionResult PostApplicant(ApplicantDto Applicant)
        {

            var modelMapper = _modelMapper.Map(Applicant);
            this.service.GetCurrentTime(modelMapper);
            modelMapper.RoleId = this.service.GetApplicantRoleId("Applicant");
            var result = this.service.EntityPassing(modelMapper);
            if (result)
            {
                return Ok();
            }
            return NotFound();
        }
        [Route("GetApplicant")]
        [HttpGet]
        public async Task<IActionResult> GetApplicantById(string Email)
        {
            var Id = service.GetId(Email);
            var result=await this.Get(Id);
            if(result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }
        #endregion
    }
}