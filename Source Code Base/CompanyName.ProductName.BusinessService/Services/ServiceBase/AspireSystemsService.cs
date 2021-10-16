using AspireSystems.TakeYourJob.BusinessService.RepositoryContracts.RepositoryBaseContract;
using AspireSystems.TakeYourJob.BusinessService.ServiceContracts.ServiceBaseContract;
using AspireSystems.Service.Models;
using AspireSystems.Service.Services;
using AspireSystems.Service.ServiceContracts;

namespace AspireSystems.TakeYourJob.BusinessService.Services.ServiceBase
{
    /// <summary>
    /// Class Service.
    /// </summary>
    /// <typeparam name="TEntity">The type of the t entity.</typeparam>
    /// <seealso cref="Service.Services.BaseAsyncService{TEntity}" />
    /// <seealso cref="ServiceContracts.ServiceBaseContract.ICompanyNameService{TEntity}" />
    public class AspireSystemsService<TEntity> : BaseAsyncService<TEntity>, IAspireSystemsService<TEntity> where TEntity : BaseModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Service{TEntity}"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        public AspireSystemsService(IAspireSystemsRepository<TEntity> repository) 
            : base(repository)
        {
           
        }

        public void GetCurrentTime(TEntity entity)
        {
            this.SetCreateAuditFields(entity);
        }

    }
}
