using System.Collections.Generic;
using AspireSystems.Api.Dtos;
using AspireSystems.Service.Models;

namespace AspireSystems.Api.BaseMapperContracts
{
    /// <summary>
    /// Interface for base model to Dto mapper
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <typeparam name="TDestination"></typeparam>
    public interface IBaseModelToDtoMapper<TSource, TDestination>
        where TSource : BaseModel where TDestination : BaseDto
    {
        /// <summary>
        /// Maps Models to Dtos
        /// </summary>
        IEnumerable<TDestination> Map(IEnumerable<TSource> sources);
        /// <summary>
        /// Maps Model to Dto
        /// </summary>
        TDestination Map(TSource source);
    }
}
