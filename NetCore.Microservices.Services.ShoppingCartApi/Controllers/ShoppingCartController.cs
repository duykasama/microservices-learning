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

    [HttpPost("cart-upsert")]
    public async Task<IActionResult> UpsertCart(DtoCart cart)
    {
        return await ExecuteApiAsync(
            async () => await _shoppingCartService.UpsertCart(cart).ConfigureAwait(false)
        ).ConfigureAwait(false);
    }
}