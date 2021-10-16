using Microsoft.EntityFrameworkCore;
using System.Linq;
using AspireSystems.Service.ContextContracts;
using AspireSystems.Service.Models;

namespace AspireSystems.Service.Context
{
    public class BaseContext : DbContext, IBaseContext
    {

        public BaseContext(DbContextOptions<BaseContext> options) : base(options)
        {

        }

        public virtual DbSet<TEntity> SetEntity<TEntity>() where TEntity : BaseModel
        {
            return base.Set<TEntity>();
        }
        public virtual IQueryable<TEntity> SetQuery<TEntity>() where TEntity : BaseModel
        {
            return SetEntity<TEntity>().AsQueryable();
        }
        public virtual void SetModified<TEntity>(TEntity entity) where TEntity : BaseModel
        {
            Entry(entity).State = EntityState.Modified;
        }
        public virtual void SetAdded<TEntity>(TEntity entity) where TEntity : BaseModel
        {
            Entry(entity).State = EntityState.Added;
        }
        public virtual void SetDeleted<TEntity>(TEntity entity) where TEntity : BaseModel
        {
            Entry(entity).State = EntityState.Deleted;
        }

      
        #region
        public DbContext DbContext
        {
            get
            {
                return this;
            }
        }
        #endregion
    }
}
