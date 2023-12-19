using NetCore.WebApiCommon.Core.Entities;

namespace NetCore.Microservices.Services.CouponApi.Domain.Entities;

public class Coupon : BaseVersionableEntity<int, Guid>
{
    public string CouponCode { get; set; } = null!;
    public double DiscountAmount { get; set; }
    public int MinAmount { get; set; }
}