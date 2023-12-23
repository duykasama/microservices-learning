using AutoMapper;
using NetCore.Microservices.Services.AuthApi.Domain.Dtos;
using NetCore.Microservices.Services.AuthApi.Domain.Entities;
using NetCore.Microservices.Services.AuthApi.Requests;

namespace NetCore.Microservices.Services.AuthApi.Mappings.AutoMapper;

public class AutoMapperConfiguration
{
    public static void RegisterMaps(IMapperConfigurationExpression mapper)
    {
        mapper.CreateMap<ApplicationUser, DtoApplicationUser>();
        mapper.CreateMap<UserRegisterRequest, ApplicationUser>()
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.NormalizedEmail, opt => opt.MapFrom(src => src.Email.ToUpper()));
    }
}