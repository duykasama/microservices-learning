using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using NetCore.Microservices.Services.AuthApi.Data;
using NetCore.Microservices.Services.AuthApi.Domain.Entities;
using NetCore.Microservices.Services.AuthApi.Interfaces.Repositories;
using NetCore.WebApiCommon.Core.DAL.Interfaces;

namespace NetCore.Microservices.Services.AuthApi.Implementations.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AuthDbContext _dbContext;

    public UserRepository(AuthDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<ApplicationUser?> GetUserAsync(Expression<Func<ApplicationUser, bool>> predicate)
    {
        return await _dbContext.Users.FirstOrDefaultAsync(predicate);
    }
}