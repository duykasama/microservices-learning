using System.ComponentModel.DataAnnotations;

namespace NetCore.Microservices.Services.ProductApi.Models.Requests;

public class ProductUpdateRequest
{
    [Required]
    public string Name { get; set; } = null!;
    public double Price { get; set; }
    public string Description { get; set; }
    public string CategoryName { get; set; }
    public string ImageUrl { get; set; }
}