using AspireSystems.Api.Dtos;
using AspireSystems.Service.Models;
using AspireSystems.TakeYourJob.BusinessService.Models;
using AspireSystems.TakeYourJob.Infrastructure.Dtos;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspireSystems.TakeYourJob.WebApi.Mappers.Profiles
{
    public class LoginProfile : Profile
    {
        public LoginProfile()
        {
            CreateMap<Login, LoginDto>()
                .IncludeBase<BaseModel, BaseDto>()
                .ReverseMap();
        }

    }
}
