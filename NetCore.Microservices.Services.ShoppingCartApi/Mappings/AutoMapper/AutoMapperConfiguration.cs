using AutoMapper;
using NetCore.Microservices.Services.ShoppingCartApi.Domain.Dtos;
using NetCore.Microservices.Services.ShoppingCartApi.Domain.Entities;

namespace NetCore.Microservices.Services.ShoppingCartApi.Mappings.AutoMapper;

public static class AutoMapperConfiguration {
	public static void RegisterMaps(IMapperConfigurationExpression mapper)
	{
		mapper.CreateMap<DtoCartDetails, CartDetails>()
			.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.CartDetailsId));

		mapper.CreateMap<DtoCartHeader, CartHeader>()
			.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.CartHeaderId));

	}
}
