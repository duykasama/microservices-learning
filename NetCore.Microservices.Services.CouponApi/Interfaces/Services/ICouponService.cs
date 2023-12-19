using NetCore.Microservices.Services.CouponApi.Domain.Dtos;
using NetCore.WebApiCommon.Api.Models;

namespace NetCore.Microservices.Services.CouponApi.Interfaces.Services;

public interface ICouponService
{
    Task<ApiActionResult> CreateCouponAsync(DtoCoupon dtoCoupon);
}