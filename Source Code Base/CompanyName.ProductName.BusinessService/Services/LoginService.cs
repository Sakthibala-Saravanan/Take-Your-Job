using AspireSystems.TakeYourJob.BusinessService.Models;
using AspireSystems.TakeYourJob.BusinessService.RepositoryContracts;
using AspireSystems.TakeYourJob.BusinessService.ServiceContracts;
using AspireSystems.TakeYourJob.BusinessService.Services.ServiceBase;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AspireSystems.TakeYourJob.BusinessService.Services
{
   public class LoginService : AspireSystemsService<Login>, ILoginService
    {
        public IConfiguration configuration;
        public ILoginRepository repository;
        #region Constructor
        public LoginService(ILoginRepository _repository,IConfiguration _configuration)
            : base(_repository)
        {
            this.repository = _repository;
            this.configuration = _configuration;
                }
        #endregion
        public Login Authentication(string Email, string Password)
        {
            var user = repository.Authentication(Email,Password);
            return user;
        }
        public string GenerateToken(string Email, string RoleName)
        {
            var _key = configuration.GetValue<string>("JWT:Secret");
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(_key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] {
new Claim(ClaimTypes.Email, Email),
new Claim(ClaimTypes.Role,RoleName)



}),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey),
            SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

    }
}
