using NetCore.Microservices.Services.ShoppingCartApi.Domain.Entities;
using NetCore.Microservices.Services.ShoppingCartApi.Interfaces.Repositories;
using NetCore.WebApiCommon.Core.DAL.Interfaces;

namespace NetCore.Microservices.Services.ShoppingCartApi.Implementations.Repositories;

public class CartDetailsRepository : GenericRepository<CartDetails, int>, ICartDetailsRepository
{
    public CartDetailsRepository(IAppDbContext dbContext) : base(dbContext)
    {
    }
}