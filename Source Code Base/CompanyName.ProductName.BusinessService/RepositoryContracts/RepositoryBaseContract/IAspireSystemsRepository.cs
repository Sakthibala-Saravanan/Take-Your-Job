using AspireSystems.Service.Models;
using AspireSystems.Service.RepositoryContracts;
using AspireSystems.TakeYourJob.BusinessService.Models;
using AspireSystems.TakeYourJob.Infrastructure.Dtos;
using System;

namespace AspireSystems.TakeYourJob.BusinessService.RepositoryContracts.RepositoryBaseContract
{
    public interface IAspireSystemsRepository<TEntity> : IBaseRepositoryAsync<TEntity> where TEntity : BaseModel
    {
        
        Guid GetCandidateRoleId(string roleName);
        bool GetId(LoginDto login);
        string Id();

    }
}
