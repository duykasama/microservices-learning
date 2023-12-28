using NetCore.Microservices.Services.ProductApi.Domain.Dtos;
using NetCore.WebApiCommon.Api.Models;
using NetCore.WebApiCommon.Core.Common.Interfaces;

namespace NetCore.Microservices.Services.ProductApi.Interfaces.Services;

public interface IProductService : IBaseService
{
    Task<ApiActionResult> GetProductById(int id);
    Task<ApiActionResult> CreateProductAsync(DtoProduct dtoProduct);
    Task<ApiActionResult> UpdateProductAsync(int id, Guid empty, DtoProduct dtoProduct);
    Task<ApiActionResult> DeleteProductAsync(int id);
    Task<ApiActionResult> GetAllProductsAsync();
}