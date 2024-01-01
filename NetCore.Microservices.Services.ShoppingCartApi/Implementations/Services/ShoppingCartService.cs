using NetCore.Microservices.Services.ShoppingCartApi.Interfaces.Services;
using NetCore.WebApiCommon.Infrastructure.Implementations;
using NetCore.WebApiCommon.Api.Models;
using Autofac;

namespace NetCore.Microservices.Services.ShoppingCartApi.Implementations.Services;

public class ShoppingCartService : GenericService, IShoppingCartService {
	public ShoppingCartService(ILifetimeScope scope) : base(scope) {
	}

	public async Task<ApiActionResult> GetAllAsync() {
		throw new NotImplementedException();
	}
}
