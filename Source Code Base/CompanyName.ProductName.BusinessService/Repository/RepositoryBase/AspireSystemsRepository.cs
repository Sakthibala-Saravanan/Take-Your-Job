using AspireSystems.TakeYourJob.BusinessService.Context;
using AspireSystems.TakeYourJob.BusinessService.RepositoryContracts.RepositoryBaseContract;
using AspireSystems.Service.Models;
using AspireSystems.Service.Repository;
using System.Collections.Generic;
using System.Data.SqlClient;
using System;
using AspireSystems.TakeYourJob.BusinessService.Models;
using System.Linq;
using AspireSystems.TakeYourJob.Infrastructure.Dtos;

namespace AspireSystems.TakeYourJob.BusinessService.Repository.RepositoryBase
{
    /// <summary>
    /// Class Repository.
    /// </summary>
    /// <typeparam name="TEntity">The type of the t entity.</typeparam>
    /// <seealso cref="Context.BaseRepositoryAsync{TEntity}" />
    /// <seealso cref="RepositoryContracts.RepositoryBaseContract.ICompanyNameRepository{TEntity}" />
    public class AspireSystemsRepository<TEntity> : BaseRepositoryAsync<TEntity>, IAspireSystemsRepository<TEntity> where TEntity : BaseModel
    {
        public Guid RecruiterId;
        /// <summary>
        /// Initializes a new instance of the <see cref="CompanyNameRepository{TEntity}"/> class.
        /// </summary>
        /// <param name="_context">The context.</param>

        public AspireSystemsRepository(IContext _context) : base(_context)
        {
        }
        
        public Guid GetCandidateRoleId(string roleName)
        {
            var RoleId = this.Context.SetQuery<Role>()
                .Where(a => a.RoleName == roleName)
                .Select(b => b.Id)
                .FirstOrDefault();
            return RoleId;
        }
        public bool GetId(LoginDto login)
        {
            this.RecruiterId = this.Context.SetQuery<Login>()
                .Where(a => a.Email == login.Email && a.Password == login.Password)
                .Select(b => b.Id)
                .FirstOrDefault();
            return true;
           
        }

        public string Id()
        {
            return this.RecruiterId.ToString();
        }


    }
}
