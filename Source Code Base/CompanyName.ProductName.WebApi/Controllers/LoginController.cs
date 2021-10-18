using AspireSystems.Api.Base.Responses.Contracts;
using AspireSystems.Api.BaseMapperContracts;
using AspireSystems.Api.Controllers;
using AspireSystems.TakeYourJob.Infrastructure.Dtos;
using AspireSystems.TakeYourJob.BusinessService.ServiceContracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspireSystems.TakeYourJob.BusinessService.RepositoryContracts;
using AspireSystems.TakeYourJob.BusinessService.Models;

namespace AspireSystems.TakeYourLogin.WebApi.Controllers
{
    [Route("api/Login")]
    [ApiController]
    public class LoginController : BaseAsyncController<Login, LoginDto>
    {
        #region Member
        private readonly ILoginService service;
        private readonly ILoginRepository repository;
        #endregion

        #region Constructor
        public LoginController(ILoginService _service,
            ILoginRepository _repository,
            IBaseModelToDtoMapper<Login, LoginDto> _dtoMapper,
            IBaseDtoToModelMapper<LoginDto, Login> _modelMapper,
            IAspireSystemsApiMessage<IAspireSystemsApiResponse> _message)
            : base(_service, _dtoMapper, _modelMapper, _message)
        {
            this.service = _service;
            this.repository = _repository;
        }
        #endregion

        #region Override & Public methods 
        [Route("LoginId")]
        [HttpPost]
        public IActionResult LoginId(LoginDto login)
        {
            var result = this.repository.GetId(login);
            if (result)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
        [Route("Token")]
        [HttpGet]
        public LoginToken GetToken(string Email, string Password)
        {
            var userId = new LoginToken();
            var user = service.Authentication(Email, Password);
            var token = service.GenerateToken(user.Email, user.RoleDetails.RoleName);
            userId.UserId = user.Id.ToString();
            userId.RoleName = user.RoleDetails.RoleName;
            userId.Token = token;
            return userId;
        }
        #endregion
    }
}
