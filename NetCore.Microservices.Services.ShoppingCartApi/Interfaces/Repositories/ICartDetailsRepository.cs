using NetCore.Microservices.Services.ShoppingCartApi.Domain.Entities;
using NetCore.WebApiCommon.Core.DAL.Interfaces;

namespace NetCore.Microservices.Services.ShoppingCartApi.Interfaces.Repositories;

public interface ICartDetailsRepository : IRepository<CartDetails, int>
{
}