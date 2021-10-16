using AutoMapper;
using System;
using AspireSystems.Api.Dtos;
using AspireSystems.Service.Models;

namespace AspireSystems.Api.BaseMappers
{
    public class BaseModelMapperProfile : Profile
    {
        public BaseModelMapperProfile() : base("BaseMapperProfile")
        {
            // Map string to Guid 
            CreateMap<string, Guid>().ConvertUsing(s => string.IsNullOrEmpty(s) ? Guid.Empty : Guid.Parse(s));

            // Audit columns
            CreateMap<BaseModel, BaseDto>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id == Guid.Empty ? null : s.Id.ToString()))
                .ForMember(d => d.CreatedByUserId, opt => opt.MapFrom(s => s.CreatedByUserId.ToString()))
                .ForMember(d => d.UpdatedByUserId, opt => opt.MapFrom(s => s.UpdatedByUserId != null && s.UpdatedByUserId != Guid.Empty ? s.UpdatedByUserId.ToString() : null));
        }
    }
}
