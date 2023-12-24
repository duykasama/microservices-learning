using Microsoft.AspNetCore.Mvc;
using NetCore.Microservices.Services.AuthApi.Interfaces.Services;
using NetCore.Microservices.Services.AuthApi.Models.Requests;
using NetCore.WebApiCommon.Api.Controllers;

namespace NetCore.Microservices.Services.AuthApi.Controllers;

[Route("api/[controller]")]
public class AuthController : BaseController
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(UserRegisterRequest request)
    {
        return await ExecuteApiAsync(
            async () => await _authService.Register(request).ConfigureAwait(false)
        ).ConfigureAwait(false);
    }
    
    [HttpPost("login")]
    public async Task<IActionResult> Login(UserLoginRequest request)
    {
        return await ExecuteApiAsync(
            async () => await _authService.Login(request).ConfigureAwait(false)
        ).ConfigureAwait(false);
    }

    [HttpPost("assign-role")]
    public async Task<IActionResult> AssignRole(AssignRoleRequest request)
    {
        return await ExecuteApiAsync(
            async () => await _authService.AssignRole(request.Email, request.RoleName.ToUpper()).ConfigureAwait(false)
        ).ConfigureAwait(false);
    }
}