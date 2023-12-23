using NetCore.Microservices.Services.AuthApi.Domain.Entities;
using NetCore.WebApiCommon.Core.Common.Interfaces;

namespace NetCore.Microservices.Services.AuthApi.Interfaces.Services;

public interface IJwtService : IBaseService
{
    string GenerateToken(ApplicationUser user);
}