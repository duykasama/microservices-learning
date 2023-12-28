using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetCore.Microservices.Services.ProductApi.Constants;
using NetCore.Microservices.Services.ProductApi.Domain.Dtos;
using NetCore.Microservices.Services.ProductApi.Interfaces.Services;
using NetCore.WebApiCommon.Api.Controllers;

namespace NetCore.Microservices.Services.ProductApi.Controllers;

[Route("api/[controller]")]
public class ProductController : BaseController
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }
    
    [HttpGet("all")]
    public async Task<IActionResult> GetAllCoupons()
    {
        return await ExecuteApiAsync(
            async () => await _productService.GetAllProductsAsync().ConfigureAwait(false)
        ).ConfigureAwait(false);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetCouponById(int id)
    {
        return await ExecuteApiAsync(
            async () => await _productService.GetProductById(id).ConfigureAwait(false)
        ).ConfigureAwait(false);
    }
    
    [Authorize(Roles = UserRole.ADMIN)]
    [HttpPost("create")]
    public async Task<IActionResult> CreateCoupon(DtoProduct dtoProduct)
    {
        return await ExecuteApiAsync(
            async () => await _productService.CreateProductAsync(dtoProduct).ConfigureAwait(false)
        ).ConfigureAwait(false);
    }
    
    [Authorize(Roles = UserRole.ADMIN)]
    [HttpPut("update/{id:int}")]
    public async Task<IActionResult> UpdateCoupon(int id, DtoProduct dtoProduct)
    {
        return await ExecuteApiAsync(
            async () => await _productService.UpdateProductAsync(id, Guid.Empty, dtoProduct).ConfigureAwait(false)
        ).ConfigureAwait(false);
    }
    
    [Authorize(Roles = UserRole.ADMIN)]
    [HttpDelete("delete/{id:int}")]
    public async Task<IActionResult> DeleteCoupon(int id)
    {
        return await ExecuteApiAsync(
            async () => await _productService.DeleteProductAsync(id).ConfigureAwait(false)
        ).ConfigureAwait(false);
    }
}