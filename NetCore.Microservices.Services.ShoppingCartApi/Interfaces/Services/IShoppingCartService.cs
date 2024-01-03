using NetCore.Microservices.Services.ShoppingCartApi.Domain.Dtos;
using NetCore.WebApiCommon.Core.Common.Interfaces;
using NetCore.WebApiCommon.Api.Models;
namespace NetCore.Microservices.Services.ShoppingCartApi.Interfaces.Services;

public interface IShoppingCartService : IBaseService {
	Task<ApiActionResult> UpsertCart(DtoCart cart);
	Task<ApiActionResult> RemoveCart(int cartDetailsId);
	Task<ApiActionResult> GetCart(string userId);
	Task<ApiActionResult> ApplyCoupon(string couponCode);
	Task<ApiActionResult> RemoveCoupon(string couponCode);
}
