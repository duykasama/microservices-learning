using Autofac;
using AutoMapper;
using NetCore.Microservices.Services.CouponApi.Domain.Dtos;
using NetCore.Microservices.Services.CouponApi.Domain.Entities;
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
}