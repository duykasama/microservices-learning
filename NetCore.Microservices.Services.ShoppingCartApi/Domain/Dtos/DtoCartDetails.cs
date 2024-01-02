namespace NetCore.Microservices.Services.ShoppingCartApi.Domain.Dtos;

public class DtoCartDetails
{
    public int CartDetailsId { get; set; }
    public int CartHeaderId { get; set; }
    public DtoCartHeader? CartHeader { get; set; }
    public int ProductId { get; set; }
    public DtoProduct? Product { get; set; }
    public int Count { get; set; }
    
}