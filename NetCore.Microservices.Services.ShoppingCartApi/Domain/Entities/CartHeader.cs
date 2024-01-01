using NetCore.WebApiCommon.Core.Entities;

namespace NetCore.Microservices.Services.ShoppingCartApi.Domain.Entities;

public class CartHeader : BaseVersionableEntity<int, Guid>
{
    public string UserId { get; set; }
    public string CouponId { get; set; }
    public double Discount { get; set; }
    public double CartTotal { get; set; }
}