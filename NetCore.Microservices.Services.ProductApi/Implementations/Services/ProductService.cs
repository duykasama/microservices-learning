using Autofac;
using NetCore.Microservices.Services.ProductApi.Domain.Dtos;
using NetCore.Microservices.Services.ProductApi.Interfaces.Repositories;
using NetCore.Microservices.Services.ProductApi.Interfaces.Services;
using NetCore.WebApiCommon.Api.Models;
using NetCore.WebApiCommon.Infrastructure.Implementations;

namespace NetCore.Microservices.Services.ProductApi.Implementations.Services;

public class ProductService : GenericService, IProductService
{
    private readonly IProductRepository _productRepository;
    
    public ProductService(ILifetimeScope scope) : base(scope)
    {
        _productRepository = Resolve<IProductRepository>();
    }

    public async Task<ApiActionResult> GetProductById(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<ApiActionResult> CreateProductAsync(DtoProduct dtoProduct)
    {
        throw new NotImplementedException();
    }

    public async Task<ApiActionResult> UpdateProductAsync(int id, Guid empty, DtoProduct dtoProduct)
    {
        throw new NotImplementedException();
    }

    public async Task<ApiActionResult> DeleteProductAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<ApiActionResult> GetAllProductsAsync()
    {
        throw new NotImplementedException();
    }
}