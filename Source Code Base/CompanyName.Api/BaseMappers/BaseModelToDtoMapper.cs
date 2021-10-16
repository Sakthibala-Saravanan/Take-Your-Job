using System.Collections.Generic;
using System.Linq;
using AspireSystems.Api.BaseMapperContracts;
using AspireSystems.Api.Dtos;
using AspireSystems.Service.Models;

namespace AspireSystems.Api.BaseMappers
{
    public class BaseModelToDtoMapper<TSource, TDestination> : IBaseModelToDtoMapper<TSource, TDestination>
        where TSource : BaseModel where TDestination : BaseDto
    {
        /// <summary>
        /// Enumerable BaseModel to DTO mapper
        /// </summary>
        public IEnumerable<TDestination> Map(IEnumerable<TSource> sources)
        {
            return sources.Select(this.Map);
        }

        /// <summary>
        /// Maps model to dto
        /// </summary>
        public TDestination Map(TSource source)
        {
            return AutoMapper.Mapper.Map<TDestination>(source);
        }
    }
}
