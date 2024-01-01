using NetCore.WebApiCommon.Api.Controllers;
using NetCore.Microservices.Services.ShoppingCartApi.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace NetCore.Microservices.Services.ShoppingCartApi;

[Route("api/[controller]")]
class ShoppingCartController : BaseController {
	private readonly IShoppingCartService _shoppingCartService;
	public ShoppingCartController(IShoppingCartService shoppingCartService) {
		_shoppingCartService = shoppingCartService;
	}


	public async Task<IActionResult> GetAll(){
		return await ExecuteApiAsync(
			async () => await _shoppingCartService.GetAllAsync().ConfigureAwait(false)
		).ConfigureAwait(false);
	}
}
