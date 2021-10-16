using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using AspireSystems.Api.DtoContracts;
using AspireSystems.Service.ModelContracts;

namespace AspireSystems.Api.ControllerContracts
{
    public interface IBaseAsyncController<TEntity, TDto>
        where TDto : IBaseDto where TEntity : IBaseModel
    {
        /// <summary>
        /// Action method to get a list of entities of type BaseModel
        /// </summary>
        /// <returns></returns>
        /// <throws>ApiException</throws>
        Task<IActionResult> Get();
        /// <summary>
        /// Action method to get entity of type BaseModel
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <throws>ApiException</throws>
        Task<IActionResult> Get(Guid id);
        /// <summary>
        /// Action method to update an entity of type BaseModel
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <throws>ApiException</throws>
        Task<IActionResult> Put(TDto entity);
        /// <summary>
        /// Action method to create an entity of type BaseModel
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <throws>ApiException</throws>
        Task<IActionResult> Post(TDto entity);
        /// <summary>
        /// Action method to hard delete an entity of type BaseModel
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <throws>ApiException</throws>
        Task<IActionResult> Delete(Guid id);
    }
}
