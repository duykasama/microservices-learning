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
        _dbContext.CreateSet<Coupon, int>().AddAsync(entity);
    }

    public async Task AddAsync(Coupon entity)
    {
        await _dbContext.CreateSet<Coupon, int>().AddAsync(entity);
    }

    public void AddMany(IEnumerable<Coupon> entities)
    {
        _dbContext.CreateSet<Coupon, int>().AddRange(entities);
    }

    public async Task AddManyAsync(IEnumerable<Coupon> entities)
    {
        await _dbContext.CreateSet<Coupon, int>().AddRangeAsync(entities);
    }

    public void Update(Coupon entity)
    {
        _dbContext.CreateSet<Coupon, int>().Entry(entity).State = EntityState.Modified;
    }

    public Task UpdateAsync(Coupon entity)
    {
        _dbContext.CreateSet<Coupon, int>().Entry(entity).State = EntityState.Modified;
        return Task.CompletedTask;
    }

    public void UpdateMany(IEnumerable<Coupon> entities)
    {
        foreach (var entity in entities)
        {
            _dbContext.Update<Coupon, int>(entity);
        }
    }

    public void UpdateMany(Expression<Func<Coupon, bool>> predicate)
    {
        var entities = _dbContext.CreateSet<Coupon, int>().Where(predicate);
        foreach (var entity in entities)
        {
            _dbContext.Update<Coupon, int>(entity);
        }
    }

    public Task UpdateManyAsync(IEnumerable<Coupon> entities)
    {
        foreach (var entity in entities)
        {
            _dbContext.Update<Coupon, int>(entity);
        }

        return Task.CompletedTask;
    }

    public async Task UpdateManyAsync(Expression<Func<Coupon, bool>> predicate)
    {
        var coupons = _dbContext.CreateSet<Coupon, int>().Where(predicate);
        await coupons.ForEachAsync(c => _dbContext.Update<Coupon, int>(c));
    }

    public void Delete(object id)
    {
        var couponToDelete = _dbContext.CreateSet<Coupon, int>().FirstOrDefault(c => c.Id == (int)id);
        if (couponToDelete is null)
        {
            return;
        }
        _dbContext.SetDeleted<Coupon, int>(couponToDelete);
    }

    public async Task DeleteAsync(object id)
    {
        var couponToDelete = await _dbContext.CreateSet<Coupon, int>().FirstOrDefaultAsync(c => c.Id == (int)id);
        if (couponToDelete is null)
        {
            return;
        }
        _dbContext.SetDeleted<Coupon, int>(couponToDelete);
    }

    public void DeleteMany(IEnumerable<object> ids)
    {
        var entities = _dbContext.CreateSet<Coupon, int>().Where(c => ids.Any(id => (int)id == c.Id));
        entities.ForEachAsync(c => _dbContext.SetDeleted<Coupon, int>(c));
    }

    public void DeleteMany(Expression<Func<Coupon, bool>> predicate)
    {
        var entities = _dbContext.CreateSet<Coupon, int>().Where(predicate);
        entities.ForEachAsync(c => _dbContext.SetDeleted<Coupon, int>(c));
    }

    public async Task DeleteManyAsync(IEnumerable<object> ids)
    {
        var entities = _dbContext.CreateSet<Coupon, int>().Where(c => ids.Any(id => (int)id == c.Id));
        await entities.ForEachAsync(c => _dbContext.SetDeleted<Coupon, int>(c));
    }

    public async Task DeleteManyAsync(Expression<Func<Coupon, bool>> predicate)
    {
        var entities = _dbContext.CreateSet<Coupon, int>().Where(predicate);
        await entities.ForEachAsync(c => _dbContext.SetDeleted<Coupon, int>(c));
    }

    public IQueryable<Coupon> GetAll()
    {
        return _dbContext.CreateSet<Coupon, int>().AsQueryable();
    }

    public async Task<IQueryable<Coupon>> GetAllAsync()
    {
        var queryableCoupons = _dbContext.CreateSet<Coupon, int>().AsQueryable();
        return await Task.FromResult(queryableCoupons);
    }

    public Coupon? Get(object id)
    {
        return _dbContext.CreateSet<Coupon, int>().SingleOrDefault(c => c.Id == (int)id);
    }

    public Coupon? Get(Expression<Func<Coupon, bool>> predicate)
    {
        return _dbContext.CreateSet<Coupon, int>().SingleOrDefault(predicate);
    }

    public async Task<Coupon?> GetAsync(object id)
    {
        return await _dbContext.CreateSet<Coupon, int>().SingleOrDefaultAsync(c => c.Id == (int)id);
    }

    public Task<Coupon?> GetAsync(Expression<Func<Coupon, bool>> predicate)
    {
        return _dbContext.CreateSet<Coupon, int>().FirstOrDefaultAsync(predicate);
    }

    public IQueryable<Coupon> Find(Expression<Func<Coupon, bool>> predicate)
    {
        return _dbContext.CreateSet<Coupon, int>().Where(predicate).AsQueryable();
    }

    public async Task<IQueryable<Coupon>> FindAsync(Expression<Func<Coupon, bool>> predicate)
    {
        return await Task.FromResult(_dbContext.CreateSet<Coupon, int>().Where(predicate).AsQueryable());
    }

    public long Count(Expression<Func<Coupon, bool>> predicate)
    {
        return _dbContext.CreateSet<Coupon, int>().Where(predicate).Count();
    }

    public async Task<long> CountAsync(Expression<Func<Coupon, bool>> predicate)
    {
        return await _dbContext.CreateSet<Coupon, int>().Where(predicate).CountAsync();
    }

    public bool Exists(Expression<Func<Coupon, bool>> predicate)
    {
        return _dbContext.CreateSet<Coupon, int>().Where(predicate).Any();
    }

    public async Task<bool> ExistsAsync(Expression<Func<Coupon, bool>> predicate)
    {
        return await _dbContext.CreateSet<Coupon, int>().Where(predicate).AnyAsync();
    }
}