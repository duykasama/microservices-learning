using Autofac;
using AutoMapper;
using NetCore.Microservices.Services.ProductApi.Domain.Dtos;
using NetCore.Microservices.Services.ProductApi.Domain.Entities;
using NetCore.Microservices.Services.ProductApi.Exceptions;
using NetCore.Microservices.Services.ProductApi.Interfaces.Repositories;
using NetCore.Microservices.Services.ProductApi.Interfaces.Services;
using NetCore.WebApiCommon.Api.Models;
using NetCore.WebApiCommon.Core.DAL.Interfaces;
using NetCore.WebApiCommon.Infrastructure.Implementations;

namespace NetCore.Microservices.Services.ProductApi.Implementations.Services;

public class ProductService : GenericService, IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    
    public ProductService(ILifetimeScope scope) : base(scope)
    {
        _productRepository = Resolve<IProductRepository>();
        _mapper = Resolve<IMapper>();
        _unitOfWork = Resolve<IUnitOfWork>();
    }

    public async Task<ApiActionResult> GetProductById(int id)
    {
        var product = await _productRepository.GetAsync(id);
        if (product is null || product.IsDeleted)
        {
            throw new ProductDoesNotExistException($"Product with id '{id}' does not exist");
        }

        return new ApiActionResult(true) { Data = _mapper.Map<DtoProduct>(product) };
    }

    public async Task<ApiActionResult> CreateProductAsync(DtoProduct dtoProduct)
    {
        await _productRepository.AddAsync(_mapper.Map<Product>(dtoProduct));
        await _unitOfWork.CommitAsync();
        return new ApiActionResult(true, "Product created successfully");
    }

    public async Task<ApiActionResult> UpdateProductAsync(int id, Guid auditor, DtoProduct dtoProduct)
    {
        var product = await _productRepository.GetAsync(id);
        if (product is null || product.IsDeleted)
        {
            throw new ProductDoesNotExistException($"Product with id '{id}' does not exist");
        }

        _mapper.Map(dtoProduct, product);
        product.SetAuditedInfo(auditor, DateTime.Now);
        await _productRepository.UpdateAsync(product);
        await _unitOfWork.CommitAsync();
        return new ApiActionResult(true, "Product updated successfully");
    }

    public async Task<ApiActionResult> DeleteProductAsync(int id)
    {
        var product = await _productRepository.GetAsync(id);
        if (product is null || product.IsDeleted)
        {
            throw new ProductDoesNotExistException($"Product with id '{id}' does not exist");
        }
        
        product.SetDeletedInfo(Guid.Empty);
        await _unitOfWork.CommitAsync();
        return new ApiActionResult(true, "Product deleted successfully");
    }

    public async Task<ApiActionResult> GetAllProductsAsync()
    {
        var products = await _productRepository.FindAsync(p => !p.IsDeleted);
        return new ApiActionResult(true) { Data = _mapper.Map<IEnumerable<DtoProduct>>(products) };
    }
}