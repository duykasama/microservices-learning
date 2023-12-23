using NetCore.Microservices.Services.AuthApi.Models.Requests;
using NetCore.WebApiCommon.Api.Models;
using NetCore.WebApiCommon.Core.Common.Interfaces;

namespace NetCore.Microservices.Services.AuthApi.Interfaces.Services;

public interface IAuthService : IBaseService
{
    Task<ApiActionResult> Register(UserRegisterRequest request);
    Task<ApiActionResult> Login(UserLoginRequest request);
    Task<ApiActionResult> AssignRole(string email, string roleName);
}