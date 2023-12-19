namespace NetCore.Microservices.Services.CouponApi.Domain.Dtos;

public class DtoCoupon
{
    public int CouponId { get; set; }
    public string CouponCode { get; set; } = null!;
    public double DiscountAmount { get; set; }
    public int MinAmount { get; set; }
}