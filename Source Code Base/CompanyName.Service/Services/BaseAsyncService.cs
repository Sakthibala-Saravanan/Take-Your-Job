using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspireSystems.Service.ModelContracts;
using AspireSystems.Service.Models;
using AspireSystems.Service.RepositoryContracts;
using AspireSystems.Service.ServiceContracts;

namespace AspireSystems.Service.Services
{
    public class BaseAsyncService<TEntity> : IBaseAsyncService<TEntity> where TEntity : BaseModel
    {
        #region Members

        /// <summary>
        /// Base async repository instance
        /// </summary>
        protected readonly IBaseRepositoryAsync<TEntity> Dal;

        #endregion Members

        #region Constructor

        /// <summary>
        /// Create service instance
        /// </summary>
        /// <param name="dal"></param>
        public BaseAsyncService(IBaseRepositoryAsync<TEntity> dal)
        {
            Dal = dal;
        }

        #endregion Constructor

        #region CRUD methods

        /// <summary>
        /// Service scaffold to create a BaseModel entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <throws>ServiceException</throws>
        public async virtual Task<Guid> CreateAsync(TEntity entity)
        {

            // Do the preprocessing activities like model validation, entry logging etc
            CreatePreProcessor(entity);

            // Populate audit fields
            SetCreateAuditFields(entity);

            var result = await Dal.CreateAsync(entity);

            // Do the postprocessing like exit logging, Guard etc
            CreatePostProcessor(entity);

            return result;
        }

        /// <summary>
        /// Service scaffold to update a BaseModel entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <throws>ServiceException</throws>
        public async virtual Task UpdateAsync(TEntity entity)
        {
            // Do the preprocessing activities like model validation, entry logging etc
            UpdatePreProcessor(entity);

            // Populate audit fields
            SetUpdateAuditFields(entity);

            await Dal.UpdateAsync(entity);

            // Do the postprocessing like exit logging, Guard etc
            UpdatePostProcessor(entity);
        }

        /// <summary>
        /// Service scaffold to hard delete a BaseModel entity
        /// This search is restricted by Tenant i.e hard deletes entities for the tenant
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <throws>ServiceException</throws>
        public async virtual Task<bool> DeleteAsync(TEntity entity)
        {
            // Do the preprocessing activities like model validation, entry logging etc
            DeletePreProcessor(entity);

            await Dal.DeleteAsync(entity);

            // Do the postprocessing like exit logging, Guard etc
            DeletePostProcessor(entity);

            return true;
        }

        /// <summary>
        /// Service scaffold to soft delete a BaseModel entity
        /// This search is restricted by Tenant i.e soft deletes entities for the tenant
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <throws>ServiceException</throws>
        public async virtual Task<bool> SoftDeleteAsync(TEntity entity)
        {
            // Do the preprocessing activities like model validation, entry logging etc
            DeletePreProcessor(entity);

            // Populate audit fields
            SetUpdateAuditFields(entity);

            await Dal.SoftDeleteAsync(entity);

            // Do the postprocessing like exit logging, Guard etc
            DeletePostProcessor(entity);

            return true;
        }

        /// <summary>
        /// Service scaffold to get BaseModel entity by BaseModel.Id with EF tracking settings
        /// This action is restricted by Tenant i.e returns resultSet for the tenant
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <throws>ServiceException</throws>
        public async virtual Task<TEntity> GetByIdAsync(Guid id, bool isTracked = true)
        {
            var entity = await Dal.FetchAsync(id, isTracked);
            return entity;
        }

        #endregion CRUD methods

        #region Search

        /// <summary>
        /// Service scaffold to search BaseModel entity using search condition predicate object
        /// This search is restricted by Tenant i.e returns resultSet for the tenant
        /// </summary>
        /// <param name="searchCondition"></param>
        /// <returns></returns>
        /// <throws>ServiceException</throws>
        public async virtual Task<Dictionary<Guid, TEntity>> SearchAsync(ISearchCondition<TEntity> searchCondition = null)
        {
            var entities = await Dal.SearchUnrestrictedAsync(searchCondition);

            return entities;
        }

        /// <summary>
        /// Service scaffold to search BaseModel entity using search condition predicate string
        /// This search is not restricted by Tenant i.e returns resultSet across tenants
        /// </summary>
        /// <param name="searchCondition"></param>
        /// <returns></returns>
        /// <throws>ServiceException</throws>
        public async virtual Task<Dictionary<Guid, TEntity>> SearchUnrestrictedAsync(ISearchCondition<TEntity> searchCondition)
        {
            return await Dal.SearchUnrestrictedAsync(searchCondition);
        }

        #endregion        

        #region Pre and Post Processors

        /// <summary>
        /// Include create preprocessing actions like logging, entity field validations, Guards etc., here
        /// </summary>
        /// <param name="entity"></param>
        protected virtual void CreatePreProcessor(TEntity entity)
        {
            // Do the preprocessing actions like logging, entity field validations, Guards etc., here
        }

        /// <summary>
        /// Include update preprocessing actions like logging, entity field validations, Guards etc., here
        /// </summary>
        /// <param name="entity"></param>
        protected virtual void UpdatePreProcessor(TEntity entity)
        {
            // Do the preprocessing actions like logging, entity field validations, Guards etc., here
        }

        /// <summary>
        /// Include delete preprocessing actions like logging, entity field validations, Guards etc., here
        /// </summary>
        /// <param name="entity"></param>
        protected virtual void DeletePreProcessor(TEntity entity)
        {
            // Do the preprocessing actions like logging, entity field validations, Guards etc., here
        }

        /// <summary>
        /// Include create postprocessing actions like logging, null result handling etc., here
        /// </summary>
        /// <param name="entity"></param>
        protected virtual void CreatePostProcessor(TEntity entity)
        {
            // Do the postprocessing actions like logging, null result handling etc., here
        }

        /// <summary>
        /// Include update postprocessing actions like logging, null result handling etc., here
        /// </summary>
        /// <param name="entity"></param>
        protected virtual void UpdatePostProcessor(TEntity entity)
        {
            // Do the postprocessing actions like logging, null result handling etc., here
        }

        /// <summary>
        /// Include delete postprocessing actions like logging, Guard etc., here
        /// </summary>
        /// <param name="entity"></param>
        protected virtual void DeletePostProcessor(TEntity entity)
        {
            // Do the postprocessing actions like logging, null result handling etc., here
        }

        #endregion

        /// <summary>
        /// Populate audit fields for create action
        /// </summary>
        /// <param name="entity"></param>
        protected virtual void SetCreateAuditFields(TEntity entity)
        {
            entity.CreatedAt = DateTime.UtcNow;
        }

        /// <summary>
        /// Populate audit fields for update action
        /// </summary>
        /// <param name="entity"></param>
        protected virtual void SetUpdateAuditFields(TEntity entity)
        {
            entity.UpdatedAt = DateTime.UtcNow;
        }
    }
}
