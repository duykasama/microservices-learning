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

    [HttpGet("all")]
    public Task<IActionResult> GetAllCoupons()
    {
        return ExecuteApiAsync(() => _couponService.GetAllCouponsAsync());
    }

    [HttpGet("{id:int}")]
    public Task<IActionResult> GetCouponById(int id)
    {
        return ExecuteApiAsync(() => _couponService.GetCouponById(id));
    }
    
    [HttpGet("get-by-code/{code}")]
    public Task<IActionResult> GetCouponByCode(string code)
    {
        return ExecuteApiAsync(() => _couponService.GetCouponByCode(code));
    }
    
    [HttpPost("create")]
    public Task<IActionResult> CreateCoupon(DtoCoupon coupon)
    {
        return ExecuteApiAsync(() => _couponService.CreateCouponAsync(coupon));
    }
    
    [HttpPut("update/{id:int}")]
    public Task<IActionResult> UpdateCoupon(int id, DtoCoupon dtoCoupon)
    {
        return ExecuteApiAsync(() => _couponService.UpdateCouponAsync(id, Guid.Empty, dtoCoupon));
    }
    
    [HttpDelete("{id:int}")]
    public Task<IActionResult> DeleteCoupon(int id)
    {
        return ExecuteApiAsync(() => _couponService.DeleteCouponAsync(id));
    }
}