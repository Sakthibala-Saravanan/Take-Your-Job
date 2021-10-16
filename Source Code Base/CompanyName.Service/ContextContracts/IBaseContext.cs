using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AspireSystems.Service.Models;

namespace AspireSystems.Service.ContextContracts
{
    public interface IBaseContext : IDisposable
    {
        /// <summary>
        /// Configure override to setup BaseModel entity
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        DbSet<TEntity> SetEntity<TEntity>() where TEntity : BaseModel;
        /// <summary>
        /// Configure override to setup BaseModel entity as queryable
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        IQueryable<TEntity> SetQuery<TEntity>() where TEntity : BaseModel;
        /// <summary>
        /// Configure override mark entity state as changed
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        void SetModified<TEntity>(TEntity entity) where TEntity : BaseModel;
        /// <summary>
        /// Configure override to mark entity state as deleted
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        void SetDeleted<TEntity>(TEntity entity) where TEntity : BaseModel;
        /// <summary>
        /// Configure override to mark entity state as added
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        void SetAdded<TEntity>(TEntity entity) where TEntity : BaseModel;

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));

        #region 
        DbContext DbContext { get; }
        #endregion
    }
}
