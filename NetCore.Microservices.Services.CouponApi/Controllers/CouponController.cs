using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetCore.Microservices.Services.CouponApi.Constants;
using NetCore.Microservices.Services.CouponApi.Domain.Dtos;
using NetCore.Microservices.Services.CouponApi.Interfaces.Services;
using NetCore.WebApiCommon.Api.Controllers;

namespace NetCore.Microservices.Services.CouponApi.Controllers;

[Route("api/[controller]")]
[Authorize]
public class CouponController : BaseController
{
    private readonly ICouponService _couponService;

    public CouponController(ICouponService couponService)
    {
        _couponService = couponService;
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetAllCoupons()
    {
        return await ExecuteApiAsync(
            async () => await _couponService.GetAllCouponsAsync().ConfigureAwait(false)
        ).ConfigureAwait(false);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetCouponById(int id)
    {
        return await ExecuteApiAsync(
            async () => await _couponService.GetCouponById(id).ConfigureAwait(false)
        ).ConfigureAwait(false);
    }
    
    [HttpGet("get-by-code/{code}")]
    public async Task<IActionResult> GetCouponByCode(string code)
    {
        return await ExecuteApiAsync(
            async () => await _couponService.GetCouponByCode(code).ConfigureAwait(false)
        ).ConfigureAwait(false);
    }
    
    [Authorize(Roles = UserRole.ADMIN)]
    [HttpPost("create")]
    public async Task<IActionResult> CreateCoupon(DtoCoupon coupon)
    {
        return await ExecuteApiAsync(
            async () => await _couponService.CreateCouponAsync(coupon).ConfigureAwait(false)
        ).ConfigureAwait(false);
    }
    
    [Authorize(Roles = UserRole.ADMIN)]
    [HttpPut("update/{id:int}")]
    public async Task<IActionResult> UpdateCoupon(int id, DtoCoupon dtoCoupon)
    {
        return await ExecuteApiAsync(
            async () => await _couponService.UpdateCouponAsync(id, Guid.Empty, dtoCoupon).ConfigureAwait(false)
        ).ConfigureAwait(false);
    }
    
    [Authorize(Roles = UserRole.ADMIN)]
    [HttpDelete("delete/{id:int}")]
    public async Task<IActionResult> DeleteCoupon(int id)
    {
        return await ExecuteApiAsync(
            async () => await _couponService.DeleteCouponAsync(id).ConfigureAwait(false)
        ).ConfigureAwait(false);
    }
}