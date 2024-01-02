using NetCore.Microservices.Services.ShoppingCartApi.Interfaces.Services;
using NetCore.WebApiCommon.Infrastructure.Implementations;
using NetCore.WebApiCommon.Api.Models;
using Autofac;
using AutoMapper;
using NetCore.Microservices.Services.ShoppingCartApi.Domain.Dtos;
using NetCore.Microservices.Services.ShoppingCartApi.Domain.Entities;
using NetCore.Microservices.Services.ShoppingCartApi.Interfaces.Repositories;
using NetCore.WebApiCommon.Core.DAL.Interfaces;

namespace NetCore.Microservices.Services.ShoppingCartApi.Implementations.Services;

public class ShoppingCartService : GenericService, IShoppingCartService
{

    private readonly ICartHeaderRepository _cartHeaderRepository;
    private readonly ICartDetailsRepository _cartDetailsRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
	
    public ShoppingCartService(ILifetimeScope scope) : base(scope)
    {
        _cartHeaderRepository = Resolve<ICartHeaderRepository>();
        _cartDetailsRepository = Resolve<ICartDetailsRepository>();
        _mapper = Resolve<IMapper>();
        _unitOfWork = Resolve<IUnitOfWork>();
    }
	
    public async Task<ApiActionResult> UpsertCart(DtoCart dtoCart)
    {
        var retrievedCartHeader = await _cartHeaderRepository.GetAsync(c => c.UserId == dtoCart.CartHeader.UserId);
        if (retrievedCartHeader is null)
        {
            var cartHeader = _mapper.Map<CartHeader>(dtoCart.CartHeader);
            await _cartHeaderRepository.AddAsync(cartHeader);
            var cartDetails = _mapper.Map<CartDetails>(dtoCart.CartDetails.First());
            cartDetails.CartHeader = cartHeader;
            await _cartDetailsRepository.AddAsync(cartDetails);
        }
        else
        {
            var retrievedCartDetails = await _cartDetailsRepository.GetAsync(cd =>
                cd.ProductId == dtoCart.CartDetails.First().ProductId
                && cd.CartHeaderId == retrievedCartHeader.Id);
            if (retrievedCartDetails is null)
            {
                var cartDetails = _mapper.Map<CartDetails>(dtoCart.CartDetails.First());
                cartDetails.CartHeaderId = retrievedCartHeader.Id;
                await _cartDetailsRepository.AddAsync(cartDetails);
            }
            else
            {
                retrievedCartDetails.Count += dtoCart.CartDetails.First().Count;
                await _cartDetailsRepository.UpdateAsync(retrievedCartDetails);
            }
        }

        await _unitOfWork.CommitAsync();
        return new ApiActionResult(true);
    }
}