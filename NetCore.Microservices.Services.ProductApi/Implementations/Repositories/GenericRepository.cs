using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using NetCore.WebApiCommon.Core.DAL.Interfaces;
using NetCore.WebApiCommon.Core.Entities;

namespace NetCore.Microservices.Services.ProductApi.Implementations.Repositories;

public abstract class GenericRepository<T, TKey> : IRepository<T, TKey> where T : BaseEntity<TKey>
{
    private readonly IAppDbContext _dbContext;

    protected GenericRepository(IAppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Add(T entity)
    {
        _dbContext.CreateSet<T, TKey>().AddAsync(entity);
    }

    public async Task AddAsync(T entity)
    {
        await _dbContext.CreateSet<T, TKey>().AddAsync(entity);
    }

    public void AddMany(IEnumerable<T> entities)
    {
        _dbContext.CreateSet<T, TKey>().AddRange(entities);
    }

    public async Task AddManyAsync(IEnumerable<T> entities)
    {
        await _dbContext.CreateSet<T, TKey>().AddRangeAsync(entities);
    }

    public void Update(T entity)
    {
        _dbContext.CreateSet<T, TKey>().Entry(entity).State = EntityState.Modified;
    }

    public Task UpdateAsync(T entity)
    {
        _dbContext.CreateSet<T, TKey>().Entry(entity).State = EntityState.Modified;
        return Task.CompletedTask;
    }

    public void UpdateMany(IEnumerable<T> entities)
    {
        foreach (var entity in entities)
        {
            _dbContext.Update<T, TKey>(entity);
        }
    }

    public void UpdateMany(Expression<Func<T, bool>> predicate)
    {
        var entities = _dbContext.CreateSet<T, TKey>().Where(predicate);
        foreach (var entity in entities)
        {
            _dbContext.Update<T, TKey>(entity);
        }
    }

    public Task UpdateManyAsync(IEnumerable<T> entities)
    {
        foreach (var entity in entities)
        {
            _dbContext.Update<T, TKey>(entity);
        }

        return Task.CompletedTask;
    }

    public async Task UpdateManyAsync(Expression<Func<T, bool>> predicate)
    {
        var entities = _dbContext.CreateSet<T, TKey>().Where(predicate);
        await entities.ForEachAsync(c => _dbContext.Update<T, TKey>(c));
    }

    public void Delete(object id)
    {
        var entityToDelete = _dbContext.CreateSet<T, TKey>().FirstOrDefault(c => Equals(id, c.Id));
        if (entityToDelete is null)
        {
            return;
        }
        _dbContext.SetDeleted<T, TKey>(entityToDelete);
    }

    public async Task DeleteAsync(object id)
    {
        var entityToDelete = await _dbContext.CreateSet<T, TKey>().FirstOrDefaultAsync(c => Equals(id, c.Id));
        if (entityToDelete is null)
        {
            return;
        }
        _dbContext.SetDeleted<T, TKey>(entityToDelete);
    }

    public void DeleteMany(IEnumerable<object> ids)
    {
        var entities = _dbContext.CreateSet<T, TKey>().Where(c => ids.Any(id => Equals(id, c.Id)));
        entities.ForEachAsync(c => _dbContext.SetDeleted<T, TKey>(c));
    }

    public void DeleteMany(Expression<Func<T, bool>> predicate)
    {
        var entities = _dbContext.CreateSet<T, TKey>().Where(predicate);
        entities.ForEachAsync(c => _dbContext.SetDeleted<T, TKey>(c));
    }

    public async Task DeleteManyAsync(IEnumerable<object> ids)
    {
        var entities = _dbContext.CreateSet<T, TKey>().Where(c => ids.Any(id => Equals(id, c.Id)));
        await entities.ForEachAsync(c => _dbContext.SetDeleted<T, TKey>(c));
    }

    public async Task DeleteManyAsync(Expression<Func<T, bool>> predicate)
    {
        var entities = _dbContext.CreateSet<T, TKey>().Where(predicate);
        await entities.ForEachAsync(c => _dbContext.SetDeleted<T, TKey>(c));
    }

    public IQueryable<T> GetAll()
    {
        return _dbContext.CreateSet<T, TKey>().AsQueryable();
    }

    public async Task<IQueryable<T>> GetAllAsync()
    {
        return await Task.FromResult(_dbContext.CreateSet<T, TKey>().AsQueryable());
    }

    public T? Get(object id)
    {
        return _dbContext.CreateSet<T, TKey>().SingleOrDefault(c => Equals(id, c.Id));
    }

    public T? Get(Expression<Func<T, bool>> predicate)
    {
        return _dbContext.CreateSet<T, TKey>().SingleOrDefault(predicate);
    }

    public async Task<T?> GetAsync(object id)
    {
        return await _dbContext.CreateSet<T, TKey>().SingleOrDefaultAsync(c => Equals(id, c.Id));
    }

    public Task<T?> GetAsync(Expression<Func<T, bool>> predicate)
    {
        return _dbContext.CreateSet<T, TKey>().FirstOrDefaultAsync(predicate);
    }

    public IQueryable<T> Find(Expression<Func<T, bool>> predicate)
    {
        return _dbContext.CreateSet<T, TKey>().Where(predicate).AsQueryable();
    }

    public async Task<IQueryable<T>> FindAsync(Expression<Func<T, bool>> predicate)
    {
        return await Task.FromResult(_dbContext.CreateSet<T, TKey>().Where(predicate).AsQueryable());
    }

    public long Count(Expression<Func<T, bool>> predicate)
    {
        return _dbContext.CreateSet<T, TKey>().Where(predicate).Count();
    }

    public async Task<long> CountAsync(Expression<Func<T, bool>> predicate)
    {
        return await _dbContext.CreateSet<T, TKey>().Where(predicate).CountAsync();
    }

    public bool Exists(Expression<Func<T, bool>> predicate)
    {
        return _dbContext.CreateSet<T, TKey>().Where(predicate).Any();
    }

    public async Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate)
    {
        return await _dbContext.CreateSet<T, TKey>().Where(predicate).AnyAsync();
    }
}