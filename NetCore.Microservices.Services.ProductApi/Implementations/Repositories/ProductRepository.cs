using NetCore.Microservices.Services.ProductApi.Domain.Entities;
using NetCore.Microservices.Services.ProductApi.Interfaces.Repositories;
using NetCore.WebApiCommon.Core.DAL.Interfaces;

namespace NetCore.Microservices.Services.ProductApi.Implementations.Repositories;

public class ProductRepository : GenericRepository<Product, int>, IProductRepository
{
    public ProductRepository(IAppDbContext dbContext) : base(dbContext)
    {
    }
}