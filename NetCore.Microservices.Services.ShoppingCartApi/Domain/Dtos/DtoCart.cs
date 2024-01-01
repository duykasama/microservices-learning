namespace NetCore.Microservices.Services.ShoppingCartApi.Domain.Dtos;

public class DtoCart
{
    public DtoCartHeader CartHeader { get; set; }
    public IEnumerable<DtoCartDetails>? CartDetails { get; set; }
}