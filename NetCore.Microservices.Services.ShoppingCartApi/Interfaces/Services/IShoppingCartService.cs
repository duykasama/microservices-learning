using NetCore.Microservices.Services.ShoppingCartApi.Domain.Dtos;
using NetCore.WebApiCommon.Core.Common.Interfaces;
using NetCore.WebApiCommon.Api.Models;
namespace NetCore.Microservices.Services.ShoppingCartApi.Interfaces.Services;

public interface IShoppingCartService : IBaseService {
	Task<ApiActionResult> UpsertCart(DtoCart cart);
}
