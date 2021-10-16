using AspireSystems.TakeYourJob.BusinessService.Models;
using AspireSystems.TakeYourJob.BusinessService.ServiceContracts.ServiceBaseContract;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspireSystems.TakeYourJob.BusinessService.ServiceContracts
{
    public interface ILoginService : IAspireSystemsService<Login>
    {
        Login Authentication(string Email,string Password);
        string GenerateToken(string Email, string RoleName);
    }
}
