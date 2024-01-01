using NetCore.WebApiCommon.Core.DAL.Interfaces;
using NetCore.Microservices.Services.ShoppingCartApi.Domain.Entities;
namespace NetCore.Microservices.Services.ShoppingCartApi.Interfaces.Repositories;

public interface IShoppingCartRepository : IRepository<ShoppingCart, int> {

}
