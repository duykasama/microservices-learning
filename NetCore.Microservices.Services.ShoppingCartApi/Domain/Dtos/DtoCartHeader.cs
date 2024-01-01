namespace NetCore.Microservices.Services.ShoppingCartApi.Domain.Dtos;

public class DtoCartHeader
{
    public int CartHeaderId { get; set; }
    public string UserId { get; set; }
    public string CouponId { get; set; }
    public DtoCoupon Coupon { get; set; }
    public double Discount { get; set; }
    public double CartTotal { get; set; }
}