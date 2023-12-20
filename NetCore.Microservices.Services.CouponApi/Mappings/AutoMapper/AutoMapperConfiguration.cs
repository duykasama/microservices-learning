using AutoMapper;
using NetCore.Microservices.Services.CouponApi.Domain.Dtos;
using NetCore.Microservices.Services.CouponApi.Domain.Entities;

namespace NetCore.Microservices.Services.CouponApi.Mappings.AutoMapper;

public static class AutoMapperConfiguration
{
    public static void RegisterMaps(IMapperConfigurationExpression mapper)
    {
        mapper.CreateMap<DtoCoupon, Coupon>()
            .ForMember(dest => dest.Id, options => options.MapFrom(src => src.CouponId))
            .AfterMap((_, dest) => dest.Id = default);

        mapper.CreateMap<Coupon, DtoCoupon>()
            .ForMember(dest => dest.CouponId, options => options.MapFrom(src => src.Id));
    }
}