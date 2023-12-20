using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using NetCore.Microservices.Services.CouponApi.Domain.Entities;
using NetCore.Microservices.Services.CouponApi.Interfaces.Repositories;
using NetCore.WebApiCommon.Core.DAL.Interfaces;

namespace NetCore.Microservices.Services.CouponApi.Implementations.Repositories;

public class CouponRepository : ICouponRepository
{
    private readonly IAppDbContext _dbContext;

    public CouponRepository(IAppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Add(Coupon entity)
    {
        throw new NotImplementedException();
    }

    public async Task AddAsync(Coupon entity)
    {
        await _dbContext.CreateSet<Coupon, int>().AddAsync(entity);
    }

    public void AddMany(IEnumerable<Coupon> entities)
    {
        throw new NotImplementedException();
    }

    public async Task AddManyAsync(IEnumerable<Coupon> entities)
    {
        throw new NotImplementedException();
    }

    public void Update(Coupon entity)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Coupon entity)
    {
        _dbContext.CreateSet<Coupon, int>().Entry(entity).State = EntityState.Modified;
        return Task.CompletedTask;
    }

    public void UpdateMany(IEnumerable<Coupon> entities)
    {
        throw new NotImplementedException();
    }

    public void UpdateMany(Expression<Func<Coupon, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateManyAsync(IEnumerable<Coupon> entities)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateManyAsync(Expression<Func<Coupon, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public void Delete(object id)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteAsync(object id)
    {
        throw new NotImplementedException();
    }

    public void DeleteMany(IEnumerable<object> ids)
    {
        throw new NotImplementedException();
    }

    public void DeleteMany(Expression<Func<Coupon, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteManyAsync(IEnumerable<object> ids)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteManyAsync(Expression<Func<Coupon, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public IQueryable<Coupon> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<IQueryable<Coupon>> GetAllAsync()
    {
        var queryableCoupons = _dbContext.CreateSet<Coupon, int>().AsQueryable();
        return Task.FromResult(queryableCoupons);
    }

    public Coupon? Get(object id)
    {
        throw new NotImplementedException();
    }

    public Coupon? Get(Expression<Func<Coupon, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public Task<Coupon?> GetAsync(object id)
    {
        return _dbContext.CreateSet<Coupon, int>().SingleOrDefaultAsync(c => c.Id == (int)id);
    }

    public Task<Coupon?> GetAsync(Expression<Func<Coupon, bool>> predicate)
    {
        return _dbContext.CreateSet<Coupon, int>().FirstOrDefaultAsync(predicate);
    }

    public IQueryable<Coupon> Find(Expression<Func<Coupon, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public async Task<IQueryable<Coupon>> FindAsync(Expression<Func<Coupon, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public long Count(Expression<Func<Coupon, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public async Task<long> CountAsync(Expression<Func<Coupon, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public bool Exists(Expression<Func<Coupon, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> ExistsAsync(Expression<Func<Coupon, bool>> predicate)
    {
        throw new NotImplementedException();
    }
}