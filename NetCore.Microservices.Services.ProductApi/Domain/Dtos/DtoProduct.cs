namespace NetCore.Microservices.Services.ProductApi.Domain.Dtos;

public class DtoProduct
{
    public int ProductId { get; set; }
    public string Name { get; set; } = null!;
    public double Price { get; set; }
    public string Description { get; set; }
    public string CategoryName { get; set; }
    public string ImageUrl { get; set; }
}