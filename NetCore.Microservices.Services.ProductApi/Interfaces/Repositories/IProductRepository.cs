using NetCore.Microservices.Services.ProductApi.Domain.Entities;
using NetCore.WebApiCommon.Core.DAL.Interfaces;

namespace NetCore.Microservices.Services.ProductApi.Interfaces.Repositories;

public interface IProductRepository : IRepository<Product, int>
{
}