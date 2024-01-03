using NetCore.Microservices.Services.ShoppingCartApi.Domain.Entities;
using NetCore.Microservices.Services.ShoppingCartApi.Interfaces.Repositories;
using NetCore.WebApiCommon.Core.DAL.Interfaces;

namespace NetCore.Microservices.Services.ShoppingCartApi.Implementations.Repositories;

public class CartHeaderRepository : GenericRepository<CartHeader, int>, ICartHeaderRepository
{
    public CartHeaderRepository(IAppDbContext dbContext) : base(dbContext)
    {
    }
}