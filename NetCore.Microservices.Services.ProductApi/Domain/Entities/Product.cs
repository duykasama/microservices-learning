using System.ComponentModel.DataAnnotations;
using NetCore.WebApiCommon.Core.Entities;

namespace NetCore.Microservices.Services.ProductApi.Domain.Entities;

public class Product : BaseVersionableEntity<int, Guid>
{
    public string Name { get; set; } = null!;
    [Range(0, 1000)]
    public double Price { get; set; }
    public string Description { get; set; }
    public string CategoryName { get; set; }
    public string ImageUrl { get; set; }
}