using NetCore.Microservices.Services.ShoppingCartApi.Domain.Dtos;

namespace NetCore.Microservices.Services.ShoppingCartApi.Interfaces.Services;

public interface IProductService
{
    Task<IEnumerable<DtoProduct>> GetProducts();
}