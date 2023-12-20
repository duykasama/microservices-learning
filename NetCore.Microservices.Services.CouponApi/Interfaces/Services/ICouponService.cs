using NetCore.Microservices.Services.CouponApi.Domain.Dtos;
using NetCore.WebApiCommon.Api.Models;

namespace NetCore.Microservices.Services.CouponApi.Interfaces.Services;

public interface ICouponService
{
    Task<ApiActionResult> CreateCouponAsync(DtoCoupon dtoCoupon);
    Task<ApiActionResult> GetAllCouponsAsync();
    Task<ApiActionResult> GetCouponById(int id);
    Task<ApiActionResult> GetCouponByCode(string code);
    Task<ApiActionResult> UpdateCouponAsync(int id, Guid auditor, DtoCoupon dtoCoupon);
    Task<ApiActionResult> DeleteCouponAsync(int id);
}