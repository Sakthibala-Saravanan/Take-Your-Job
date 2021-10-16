using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspireSystems.Service.ModelContracts;

namespace AspireSystems.Service.ServiceContracts
{
    public interface IBaseAsyncService<TEntity>
        where TEntity : IBaseModel
    {
        // <summary>
        /// Service scaffold to create a BaseModel entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <throws>ServiceException</throws>
        Task<Guid> CreateAsync(TEntity entity);
        /// <summary>
        /// Service scaffold to update a BaseModel entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <throws>ServiceException</throws>
        Task UpdateAsync(TEntity entity);
        /// <summary>
        /// Service scaffold to hard delete a BaseModel entity
        /// This search is restricted by Tenant i.e hard deletes entities for the tenant
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <throws>ServiceException</throws>
        Task<bool> DeleteAsync(TEntity entity);
        /// <summary>
        /// Service scaffold to soft delete a BaseModel entity
        /// This search is restricted by Tenant i.e soft deletes entities for the tenant
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <throws>ServiceException</throws>
        Task<bool> SoftDeleteAsync(TEntity entity);
        /// <summary>
        /// Service scaffold to get BaseModel entity by BaseModel.Id with EF tracking settings 
        /// This action is restricted by Tenant i.e returns resultSet for the tenant
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <throws>ServiceException</throws>
        Task<TEntity> GetByIdAsync(Guid id, bool isTracked = true);
        /// <summary>
        /// Service scaffold to search BaseModel entity using search condition predicate object
        /// This search is restricted by Tenant i.e returns resultSet for the tenant
        /// </summary>
        /// <param name="searchCondition"></param>
        /// <returns></returns>
        /// <throws>ServiceException</throws>
        Task<Dictionary<Guid, TEntity>> SearchAsync(ISearchCondition<TEntity> searchCondition = null);
        /// <summary>
        /// Service scaffold to search BaseModel entity using search condition predicate string
        /// This search is not restricted by Tenant i.e returns resultSet across tenants
        /// </summary>
        /// <param name="searchCondition"></param>
        /// <returns></returns>
        /// <throws>ServiceException</throws>
        Task<Dictionary<Guid, TEntity>> SearchUnrestrictedAsync(ISearchCondition<TEntity> searchCondition);
    }
}
