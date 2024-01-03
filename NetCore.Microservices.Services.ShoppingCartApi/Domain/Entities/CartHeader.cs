using NetCore.WebApiCommon.Core.Entities;

namespace NetCore.Microservices.Services.ShoppingCartApi.Domain.Entities;

public class CartHeader : BaseVersionableEntity<int, Guid>
{
    public string UserId { get; set; }
    public string CouponCode { get; set; }
    public double Discount { get; set; }
    public double CartTotal { get; set; }
    public IEnumerable<CartDetails> CartDetails { get; set; } = new List<CartDetails>();
}