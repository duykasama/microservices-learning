using System.Linq.Expressions;
using NetCore.Microservices.Services.AuthApi.Domain.Entities;

namespace NetCore.Microservices.Services.AuthApi.Interfaces.Repositories;

public interface IUserRepository
{
    Task<ApplicationUser?> GetUserAsync(Expression<Func<ApplicationUser, bool>> predicate);
}