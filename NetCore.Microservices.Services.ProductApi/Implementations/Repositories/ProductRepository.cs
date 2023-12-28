using System.Linq.Expressions;
using NetCore.Microservices.Services.ProductApi.Domain.Entities;
using NetCore.Microservices.Services.ProductApi.Interfaces.Repositories;

namespace NetCore.Microservices.Services.ProductApi.Implementations.Repositories;

public class ProductRepository : IProductRepository
{
    public void Add(Product entity)
    {
        throw new NotImplementedException();
    }

    public async Task AddAsync(Product entity)
    {
        throw new NotImplementedException();
    }

    public void AddMany(IEnumerable<Product> entities)
    {
        throw new NotImplementedException();
    }

    public async Task AddManyAsync(IEnumerable<Product> entities)
    {
        throw new NotImplementedException();
    }

    public void Update(Product entity)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateAsync(Product entity)
    {
        throw new NotImplementedException();
    }

    public void UpdateMany(IEnumerable<Product> entities)
    {
        throw new NotImplementedException();
    }

    public void UpdateMany(Expression<Func<Product, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateManyAsync(IEnumerable<Product> entities)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateManyAsync(Expression<Func<Product, bool>> predicate)
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

    public void DeleteMany(Expression<Func<Product, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteManyAsync(IEnumerable<object> ids)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteManyAsync(Expression<Func<Product, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public IQueryable<Product> GetAll()
    {
        throw new NotImplementedException();
    }

    public async Task<IQueryable<Product>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Product? Get(object id)
    {
        throw new NotImplementedException();
    }

    public Product? Get(Expression<Func<Product, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public async Task<Product?> GetAsync(object id)
    {
        throw new NotImplementedException();
    }

    public async Task<Product?> GetAsync(Expression<Func<Product, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public IQueryable<Product> Find(Expression<Func<Product, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public async Task<IQueryable<Product>> FindAsync(Expression<Func<Product, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public long Count(Expression<Func<Product, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public async Task<long> CountAsync(Expression<Func<Product, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public bool Exists(Expression<Func<Product, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> ExistsAsync(Expression<Func<Product, bool>> predicate)
    {
        throw new NotImplementedException();
    }
}