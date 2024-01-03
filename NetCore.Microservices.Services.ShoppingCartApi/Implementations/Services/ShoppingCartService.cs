using NetCore.Microservices.Services.ShoppingCartApi.Interfaces.Services;
using NetCore.WebApiCommon.Infrastructure.Implementations;
using NetCore.WebApiCommon.Api.Models;
using Autofac;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using NetCore.Microservices.Services.ShoppingCartApi.Domain.Dtos;
using NetCore.Microservices.Services.ShoppingCartApi.Domain.Entities;
using NetCore.Microservices.Services.ShoppingCartApi.Exceptions;
using NetCore.Microservices.Services.ShoppingCartApi.Interfaces.Repositories;
using NetCore.WebApiCommon.Core.DAL.Interfaces;

namespace NetCore.Microservices.Services.ShoppingCartApi.Implementations.Services;

public class ShoppingCartService : GenericService, IShoppingCartService
{

    private readonly ICartHeaderRepository _cartHeaderRepository;
    private readonly ICartDetailsRepository _cartDetailsRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IProductService _productService;
    private readonly ICouponService _couponService;
	
    public ShoppingCartService(ILifetimeScope scope) : base(scope)
    {
        _cartHeaderRepository = Resolve<ICartHeaderRepository>();
        _cartDetailsRepository = Resolve<ICartDetailsRepository>();
        _mapper = Resolve<IMapper>();
        _unitOfWork = Resolve<IUnitOfWork>();
        _productService = Resolve<IProductService>();
        _couponService = Resolve<ICouponService>();
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

    public async Task<ApiActionResult> RemoveCart(int cartDetailsId)
    {
        var retrievedCartDetails = await _cartDetailsRepository.GetAsync(c => c.Id == cartDetailsId);
        if (retrievedCartDetails is null)
        {
            throw new CartDetailsDoesNotExistException();
        }

        await _cartDetailsRepository.DeleteAsync(cartDetailsId);
        var totalCountOfCartItem = await _cartDetailsRepository.CountAsync(c => c.CartHeaderId == retrievedCartDetails.CartHeaderId);
        if (totalCountOfCartItem == 1)
        {
            var cartHeaderToRemove =
                await _cartHeaderRepository.GetAsync(ch => ch.Id == retrievedCartDetails.CartHeaderId);
            if (cartHeaderToRemove is null)
            {
                throw new CartHeaderDoesNotExistException($"Cart header with id {retrievedCartDetails.CartHeaderId} does not exist");
            }

            await _cartHeaderRepository.DeleteAsync(cartHeaderToRemove.Id);
        }

        await _unitOfWork.CommitAsync();
        return new ApiActionResult(true);
    }

    public async Task<ApiActionResult> GetCart(string userId)
    {
        var cartHeader = _mapper.Map<DtoCartHeader>((await _cartHeaderRepository.GetAsync(ch => ch.UserId == userId)) ?? new CartHeader());
        var cartDetails =
            _mapper.Map<IEnumerable<DtoCartDetails>>(
                (await _cartDetailsRepository.FindAsync(cd => cd.CartHeaderId == cartHeader.CartHeaderId)).ProjectTo<DtoCartDetails>(_mapper.ConfigurationProvider));
        var dtoProducts = await _productService.GetProducts();
        var dtoCartDetailsList = cartDetails.ToList();
        cartHeader.CartTotal = dtoCartDetailsList.Aggregate(cartHeader.CartTotal, (total, details) =>
        {
            details.Product = dtoProducts.FirstOrDefault(p => p.ProductId == details.ProductId) ?? new DtoProduct();
            return total + details.Count * details.Product.Price;
        });
        if (!string.IsNullOrEmpty(cartHeader.CouponCode))
        {
            var coupon = await _couponService.GetCoupon(cartHeader.CouponCode);
            var originalCartTotal = cartHeader.CartTotal;
            cartHeader.CartTotal = Math.Max(coupon.MinAmount, cartHeader.CartTotal - coupon.DiscountAmount);
            cartHeader.Discount = Math.Min(coupon.DiscountAmount, originalCartTotal - cartHeader.CartTotal);
        }
        var cart = new DtoCart
        {
            CartHeader = cartHeader,
            CartDetails = dtoCartDetailsList,
        };
        
        return new ApiActionResult(true) {Data = cart};
    }

    public async Task<ApiActionResult> ApplyCoupon(string couponCode)
    {
        throw new NotImplementedException();
    }

    public async Task<ApiActionResult> RemoveCoupon(string couponCode)
    {
        throw new NotImplementedException();
    }
}