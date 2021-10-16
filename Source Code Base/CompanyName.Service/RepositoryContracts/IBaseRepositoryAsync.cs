using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspireSystems.Service.ModelContracts;
using AspireSystems.Service.Models;

namespace AspireSystems.Service.RepositoryContracts
{
    public interface IBaseRepositoryAsync<TEntity> where TEntity : BaseModel
    {
        /// <summary>
        /// Repository scaffold to create a new BaseModel entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <throws>RepositoryException</throws>
        Task<Guid> CreateAsync(TEntity entity);
        /// <summary>
        /// Repository scaffold to hard delete a BaseModel entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <throws>RepositoryException</throws>
        Task DeleteAsync(TEntity entity);
        /// <summary>
        /// Repository scaffold to soft delete a BaseModel entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <throws>RepositoryException</throws>
        Task SoftDeleteAsync(TEntity entity);

        /// <summary>
        /// Repository scaffold to update a BaseModel entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <throws>RepositoryException</throws>
        Task UpdateAsync(TEntity entity);

        /// <summary>
        /// Repository scaffold to search a BaseModel entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <throws>RepositoryException</throws>
        Task<Dictionary<Guid, TEntity>> SearchUnrestrictedAsync(ISearchCondition<TEntity> searchCondition);

        /// <summary>
        /// Repository scaffold to fetch a BaseModel entity by id
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <throws>RepositoryException</throws>
        Task<TEntity> FetchAsync(Guid id, bool isTracked = true);

        /// <summary>
        /// Repository scaffold to update the status
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task RetrieveAsync(TEntity entity);

    }
}
