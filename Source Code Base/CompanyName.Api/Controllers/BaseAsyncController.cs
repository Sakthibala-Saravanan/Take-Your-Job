using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using AspireSystems.Api.Base.Responses.Contracts;
using AspireSystems.Api.BaseMapperContracts;
using AspireSystems.Api.ControllerContracts;
using AspireSystems.Api.DtoContracts;
using AspireSystems.Api.Dtos;
using AspireSystems.Infrastructure.Helpers;
using AspireSystems.Service.ModelContracts;
using AspireSystems.Service.Models;
using AspireSystems.Service.ServiceContracts;

namespace AspireSystems.Api.Controllers
{
    public class BaseAsyncController<TEntity, TDto> : Controller, IBaseAsyncController<TEntity, TDto>
        where TEntity : BaseModel, IBaseModel where TDto : BaseDto, IBaseDto
    {
        #region Members

        /// <summary>
        /// Base service instance
        /// </summary>
        protected readonly IBaseAsyncService<TEntity> _service;

        /// <summary>
        /// Entity to Dto mapper instance
        /// </summary>
        protected readonly IBaseModelToDtoMapper<TEntity, TDto> _dtoMapper;

        /// <summary>
        /// Dto to Entity mapper instance
        /// </summary>
        protected readonly IBaseDtoToModelMapper<TDto, TEntity> _modelMapper;

        /// <summary>
        /// Unified response format to be returned from all CompanyName apis
        /// </summary>
        protected IAspireSystemsApiMessage<IAspireSystemsApiResponse> _message;

        #endregion Members

        #region Constructor

        /// <summary>
        /// Initialize base controller with mappers and messagers
        /// </summary>
        /// <param name="service"></param>
        /// <param name="dtoMapper"></param>
        /// <param name="modelMapper"></param>
        /// <param name="message"></param>
        public BaseAsyncController(IBaseAsyncService<TEntity> service
            , IBaseModelToDtoMapper<TEntity, TDto> dtoMapper
            , IBaseDtoToModelMapper<TDto, TEntity> modelMapper
            , IAspireSystemsApiMessage<IAspireSystemsApiResponse> message)
        {
            _service = service;
            _dtoMapper = dtoMapper;
            _modelMapper = modelMapper;
            _message = message;
        }

        #endregion Constructor
        
        #region Public Methods

        /// <summary>
        /// Scaffold Get API to fetch a list of entities
        /// </summary>
        /// <returns>List of BaseDto objects as JSON</returns>
        [HttpGet]
        public async virtual Task<IActionResult> Get()
        {
            // Use an empty or void search condition predicate to retrieve all entity rows
            var voidSearchCondition = default(SearchCondition<TEntity>);

            // Using base service method SearchAsync with empty predicate to get all results
            var entities = await _service.SearchAsync(voidSearchCondition);

            if (entities == null || !entities.Any())
            {
                // Send NoContent response if no results found
                return NoContent();
            }

            // Transform entity to dtos
            var results = _dtoMapper.Map(entities.Values);

            // Return Api response with data
            return Ok(results);
        }

        /// <summary>
        /// Scaffold Get by Id API to fetch an entity by given Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>BaseDto JSON object</returns>
        [HttpGet("{id}")]
        public async virtual Task<IActionResult> Get(Guid id)
        {
            // Ensure Id param is valid
            Check.EmptyGuid("id", id);

            // Using base service method GetByIdAsync to fetch the entity
            var model = await _service.GetByIdAsync(id);

            if (model == null)
            {
                // Send NoContent response if no result found
                return NoContent();
            }

            // Tranform entity to dtos
            var result = _dtoMapper.Map(model);

            // Return Api response with data
            return Ok(result);
        }

        /// <summary>
        /// Scaffold Create API to add a new entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Created entity Id (Guid)</returns>
        [HttpPost]
        public async virtual Task<IActionResult> Post([FromBody]TDto entity)
        {
            // Ensure entity param is valid
            Check.Null("entity", entity);

            // Report conflict if an entity with the given Id exists already
            if (entity.Id != null)
            {
                // Try fetching the entity with given Id
                bool entityExists = await _service.GetByIdAsync(Guid.Parse(entity.Id), false) != null;

                if (entityExists)
                {
                    // Send a conflict response if a valid 
                    //  entity is returned from the service
                    return StatusCode(409);
                }
            }

            // Transform Dtos to BaseModel entity
            var model = _modelMapper.Map(entity);

            // Using CreateAsync base service method to save the new entity
            var id = await _service.CreateAsync(model);

            // Return the newly created entity Id as response
            return Ok(id);
        }

        /// <summary>
        /// Scaffold Update API to update an existing entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Not found result</returns>
        [HttpPut]
        public async virtual Task<IActionResult> Put([FromBody]TDto entity)
        {
            // Ensure entity param is valid
            Check.Null("entity", entity);

            // Transform Dtos to entity
            var model = _modelMapper.Map(entity);

            // Fetch existing entity using base service method GetByIdAsync
            var existingItem = await _service.GetByIdAsync(model.Id, false);

            if (existingItem == null)
            {
                // Send NotFound response if there is no existing entity found
                return NotFound();
            }

            // Using UpdateAsync base service method to save changes
            await _service.UpdateAsync(model);

            // Return Api response with data
            return Ok();
        }

        /// <summary>
        /// Scaffold Delete API to delete an entity of given Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async virtual Task<IActionResult> Delete(Guid id)
        {
            // Ensure Id param is valid
            Check.EmptyGuid("id", id);

            // Fetch existing entity using base service method GetByIdAsync
            var model = await _service.GetByIdAsync(id, false);

            if (model == null)
            {
                // Send NotFound response if there is no 
                //  existing entity found for it to be deleted
                return NotFound();
            }

            // Delete the entity using the service method DeleteAsync
            //var results = await _service.DeleteAsync(model);
            var results = await _service.SoftDeleteAsync(model);

            // Return Api response with status
            return Ok(results);
        }

        #endregion Public Methods
    }
}
