using NetCore.Microservices.Services.ShoppingCartApi.Domain.Entities;
using NetCore.WebApiCommon.Core.DAL.Interfaces;

namespace NetCore.Microservices.Services.ShoppingCartApi.Implementations.Repositories;

public class ShoppingCartRepository : GenericRepository<ShoppingCart, int> 
{
	public ShoppingCartRepository(IAppDbContext dbContext) : base(dbContext)
	{
	}
}
