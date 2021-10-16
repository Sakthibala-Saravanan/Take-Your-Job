using AspireSystems.TakeYourJob.BusinessService.Context;
using AspireSystems.TakeYourJob.BusinessService.Models;
using AspireSystems.TakeYourJob.BusinessService.Repository.RepositoryBase;
using AspireSystems.TakeYourJob.BusinessService.RepositoryContracts;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AspireSystems.TakeYourLogin.BusinessService.Repository
{
    public class LoginRepository : AspireSystemsRepository<Login>, ILoginRepository
    {
        #region Constructor
        public LoginRepository(IContext _context)
            : base(_context)
        { }
        #endregion
      public Login Authentication(string Email,string Password)
        {

            var user = this.Context.SetQuery<Login>().Include("RoleDetails").FirstOrDefault(a => a.Email.Equals(Email) && a.Password.Equals(Password));
            if (user == null)
            {
                return null;
            }
            else
            {
                return user;
            }
            
              
        }

    }
}
