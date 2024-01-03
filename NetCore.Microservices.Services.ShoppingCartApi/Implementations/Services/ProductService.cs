using NetCore.Microservices.Services.ShoppingCartApi.Constants;
using NetCore.Microservices.Services.ShoppingCartApi.Domain.Dtos;
using NetCore.Microservices.Services.ShoppingCartApi.Interfaces.Services;
using NetCore.WebApiCommon.Api.Models;
using Newtonsoft.Json;

namespace NetCore.Microservices.Services.ShoppingCartApi.Implementations.Services;

public class ProductService : IProductService
{
    private readonly IHttpClientFactory _httpClientFactory;

    public ProductService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    
    public async Task<IEnumerable<DtoProduct>> GetProducts()
    {
        var client = _httpClientFactory.CreateClient(ClientServiceConstants.PRODUCT);
        var token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6ImR1eWthc2FtYUBnbWFpbC5jb20iLCJzdWIiOiJjYzdjYjJiYi1kZDBiLTRlNTYtYjVkNy1hMzEyNTFjZGIzYjUiLCJuYW1lIjoiRHV5Iiwicm9sZSI6IkFETUlOIiwibmJmIjoxNzA0MjAzMzAxLCJleHAiOjE3MDQyMDY5MDEsImlhdCI6MTcwNDIwMzMwMSwiaXNzIjoiaHR0cHM6Ly9sb2NhbGhvc3Q6MTcwMDIiLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0OjQyMDAifQ.j8KvrAW8fgLB6thCuSPs4tZpTIaGAzHuFHM20-Ljha4";
        client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
        var response = await client.GetAsync("api/Product/all");
        var responseContent = await response.Content.ReadAsStringAsync();
        var deserializedResponse = JsonConvert.DeserializeObject<ApiResponse>(responseContent);
        if (deserializedResponse is not { IsSuccess: false })
            return JsonConvert.DeserializeObject<IEnumerable<DtoProduct>>(Convert.ToString(deserializedResponse.Data));
        return new List<DtoProduct>();
    }
}