using AutoMapper;
using AspireSystems.Api.Dtos;
using AspireSystems.TakeYourJob.BusinessService.Models;
using AspireSystems.TakeYourJob.Infrastructure.Dtos;
using AspireSystems.Service.Models;

namespace AspireSystems.TakeYourJob.WebApi.Mappers.Profiles
{
    public class ApplicantProfile : Profile
    {
        public ApplicantProfile()
        {
            CreateMap<Applicant, ApplicantDto>()
                .IncludeBase<BaseModel, BaseDto>()
                .ReverseMap();
        }
    }
}
