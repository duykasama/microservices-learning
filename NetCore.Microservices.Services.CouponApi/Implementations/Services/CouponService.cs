using Autofac;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NetCore.Microservices.Services.CouponApi.Domain.Dtos;
using NetCore.Microservices.Services.CouponApi.Domain.Entities;
using NetCore.Microservices.Services.CouponApi.Exceptions;
using NetCore.Microservices.Services.CouponApi.Interfaces.Repositories;
using NetCore.Microservices.Services.CouponApi.Interfaces.Services;
using NetCore.WebApiCommon.Api.Models;
using NetCore.WebApiCommon.Core.DAL.Interfaces;
using NetCore.WebApiCommon.Infrastructure.Implementations;

namespace NetCore.Microservices.Services.CouponApi.Implementations.Services;

public class CouponService : GenericService, ICouponService
{
    private readonly ICouponRepository _couponRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    
    public CouponService(ILifetimeScope scope) : base(scope)
    {
        _couponRepository = Resolve<ICouponRepository>();
        _unitOfWork = Resolve<IUnitOfWork>();
        _mapper = Resolve<IMapper>();
    }
    
    public async Task<ApiActionResult> CreateCouponAsync(DtoCoupon dtoCoupon)
    {
        await _couponRepository.AddAsync(_mapper.Map<Coupon>(dtoCoupon));
        await _unitOfWork.CommitAsync();
        return new ApiActionResult(true, "Coupon created successfully");
    }

    public async Task<ApiActionResult> GetAllCouponsAsync()
    {
        var coupons = await (await _couponRepository.GetAllAsync()).Where(c => !c.IsDeleted).ToListAsync();
        return new ApiActionResult(true) { Data = _mapper.Map<List<DtoCoupon>>(coupons) };
    }

    public async Task<ApiActionResult> GetCouponById(int id)
    {
        var coupon = await _couponRepository.GetAsync(c => !c.IsDeleted && c.Id == id);
        if (coupon is null)
        {
            throw new CouponDoesNotExistException($"Coupon with id '{id}' does not exist");
        }

        return new ApiActionResult(true) { Data = _mapper.Map<DtoCoupon>(coupon) };
    }

    public async Task<ApiActionResult> GetCouponByCode(string code)
    {
        var coupon = await _couponRepository.GetAsync(c => !c.IsDeleted && c.CouponCode == code);
        if (coupon is null)
        {
            throw new CouponDoesNotExistException($"Coupon with code '{code}' does not exist");
        }

        return new ApiActionResult(true) { Data = _mapper.Map<DtoCoupon>(coupon) };
    }

    public async Task<ApiActionResult> UpdateCouponAsync(int id, Guid auditor, DtoCoupon dtoCoupon)
    {
        var coupon = await _couponRepository.GetAsync(c => !c.IsDeleted && c.Id == id);
        if (coupon is null)
        {
            throw new CouponDoesNotExistException($"Coupon with id '{id}' does not exist");
        }

        _mapper.Map(dtoCoupon, coupon);
        coupon.SetAuditedInfo(auditor, DateTime.Now);
        coupon.Id = id;
        await _couponRepository.UpdateAsync(coupon);
        await _unitOfWork.CommitAsync();

        return new ApiActionResult(true, "Coupon updated successfully");
    }

    public async Task<ApiActionResult> DeleteCouponAsync(int id)
    {
        var coupon = await _couponRepository.GetAsync(c => !c.IsDeleted && c.Id == id);
        if (coupon is null)
        {
            throw new CouponDoesNotExistException($"Coupon with id '{id}' does not exist");
        }

        coupon.IsDeleted = true;
        await _couponRepository.UpdateAsync(coupon);
        await _unitOfWork.CommitAsync();

        return new ApiActionResult(true, "Coupon deleted successfully");
    }
}