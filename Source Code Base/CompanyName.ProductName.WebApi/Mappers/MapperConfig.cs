using AutoMapper;
using AspireSystems.Api.BaseMappers;

namespace AspireSystems.TakeYourJob.WebApi.Mappers
{
    public static class MapperConfig
    {
        public static void Configure() =>
            Mapper.Initialize(configMapper =>
            {
                configMapper.AddProfile<BaseModelMapperProfile>();
                configMapper.AddProfiles("AspireSystems.TakeYourJob.WebApi");
            });
    }
}
