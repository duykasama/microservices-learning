using NetCore.Microservices.Services.ShoppingCartApi.Domain.Dtos;
using NetCore.WebApiCommon.Core.Entities;

namespace NetCore.Microservices.Services.ShoppingCartApi.Domain.Entities;

public class CartDetails : BaseVersionableEntity<int, Guid>
{
    public int CartHeaderId { get; set; }
    public CartHeader CartHeader { get; set; }
    public int ProductId { get; set; }
    public DtoProduct Product { get; set; }
    public int Count { get; set; }
}