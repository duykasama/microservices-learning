using Microsoft.AspNetCore.Mvc;
using NetCore.Microservices.Services.ShoppingCartApi.Domain.Dtos;
using NetCore.Microservices.Services.ShoppingCartApi.Interfaces.Services;
using NetCore.WebApiCommon.Api.Controllers;

namespace NetCore.Microservices.Services.ShoppingCartApi.Controllers;

[Route("api/cart")]
public class ShoppingCartController : BaseController {
    private readonly IShoppingCartService _shoppingCartService;
    public ShoppingCartController(IShoppingCartService shoppingCartService) {
        _shoppingCartService = shoppingCartService;
    }

    [HttpGet("{userId}")]
    public async Task<IActionResult> GetCart(string userId)
    {
        return await ExecuteApiAsync(
            async () => await _shoppingCartService.GetCart(userId).ConfigureAwait(false)
        ).ConfigureAwait(false);
    }

    [HttpPost("upsert-cart")]
    public async Task<IActionResult> UpsertCart(DtoCart cart)
    {
        return await ExecuteApiAsync(
            async () => await _shoppingCartService.UpsertCart(cart).ConfigureAwait(false)
        ).ConfigureAwait(false);
    }

    [HttpPost("remove-cart")]
    public async Task<IActionResult> RemoveCart(int cartDetailsId)
    {
        return await ExecuteApiAsync(
            async () => await _shoppingCartService.RemoveCart(cartDetailsId).ConfigureAwait(false)
        ).ConfigureAwait(false);
    }
    
    [HttpPost("apply-coupon")]
    public async Task<IActionResult> ApplyCoupon(string couponCode)
    {
        return await ExecuteApiAsync(
            async () => await _shoppingCartService.ApplyCoupon(couponCode).ConfigureAwait(false)
        ).ConfigureAwait(false);
    }
    
    [HttpPost("remove-coupon")]
    public async Task<IActionResult> RemoveCoupon(string couponCode)
    {
        return await ExecuteApiAsync(
            async () => await _shoppingCartService.RemoveCoupon(couponCode).ConfigureAwait(false)
        ).ConfigureAwait(false);
    }
}