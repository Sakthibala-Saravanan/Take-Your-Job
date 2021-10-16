using AspireSystems.Service.Models;
using AspireSystems.Service.ServiceContracts;

namespace AspireSystems.TakeYourJob.BusinessService.ServiceContracts.ServiceBaseContract
{
    public interface IAspireSystemsService<TEntity> : IBaseAsyncService<TEntity> where TEntity : BaseModel
    {
        void GetCurrentTime(TEntity entity);
    }
}
