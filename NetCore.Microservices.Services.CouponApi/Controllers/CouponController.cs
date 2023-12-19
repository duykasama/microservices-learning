using Microsoft.AspNetCore.Mvc;
using NetCore.Microservices.Services.CouponApi.Domain.Dtos;
using NetCore.Microservices.Services.CouponApi.Interfaces.Services;
using NetCore.WebApiCommon.Api.Controllers;

namespace NetCore.Microservices.Services.CouponApi.Controllers;

[Route("api/[controller]")]
public class CouponController : BaseController
{
    private readonly ICouponService _couponService;

    public CouponController(ICouponService couponService)
    {
        _couponService = couponService;
    }

    [HttpGet]
    public Task<IActionResult> GetCoupons(DtoCoupon coupon)
    {
        return ExecuteApiAsync(() => _couponService.CreateCouponAsync(coupon));
    }
    
    [HttpPost("create")]
    public Task<IActionResult> CreateCoupon(DtoCoupon coupon)
    {
        return ExecuteApiAsync(() => _couponService.CreateCouponAsync(coupon));
    }
}