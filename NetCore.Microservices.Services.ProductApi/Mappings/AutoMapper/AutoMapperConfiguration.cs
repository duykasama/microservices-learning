using AutoMapper;
using NetCore.Microservices.Services.ProductApi.Domain.Dtos;
using NetCore.Microservices.Services.ProductApi.Domain.Entities;
using NetCore.Microservices.Services.ProductApi.Models.Requests;

namespace NetCore.Microservices.Services.ProductApi.Mappings.AutoMapper;

public static class AutoMapperConfiguration
{
    public static void RegisterMaps(IMapperConfigurationExpression mapper)
    {
        mapper.CreateMap<Product, DtoProduct>()
            .ForMember((dest) => dest.ProductId, 
                opt => opt.MapFrom(src => src.Id));
        
        mapper.CreateMap<ProductUpdateRequest, Product>();
    }
}