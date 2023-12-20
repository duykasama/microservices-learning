using NetCore.Microservices.Services.CouponApi.Domain.Entities;
using NetCore.WebApiCommon.Core.DAL.Interfaces;

namespace NetCore.Microservices.Services.CouponApi.Interfaces.Repositories;

public interface ICouponRepository : IRepository<Coupon, int>
{
}