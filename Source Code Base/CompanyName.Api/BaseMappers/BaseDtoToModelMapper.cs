using System.Collections.Generic;
using System.Linq;
using AspireSystems.Api.BaseMapperContracts;
using AspireSystems.Api.Dtos;
using AspireSystems.Service.Models;

namespace AspireSystems.Api.BaseMappers
{
    public class BaseDtoToModelMapper<TSource, TDestination> : IBaseDtoToModelMapper<TSource, TDestination>
        where TSource : BaseDto where TDestination : BaseModel
    {
        /// <summary>
        /// Enumerable BaseDto to Model mapper
        /// </summary>
        public IEnumerable<TDestination> Map(IEnumerable<TSource> sources)
        {
            return sources.Select(this.Map);
        }
        /// <summary>
        /// Maps dto to model
        /// </summary>
        public TDestination Map(TSource source)
        {
            return AutoMapper.Mapper.Map<TDestination>(source);
        }
    }
}
