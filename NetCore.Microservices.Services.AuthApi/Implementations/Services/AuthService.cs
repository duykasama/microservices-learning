using Autofac;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using NetCore.Microservices.Services.AuthApi.Domain.Dtos;
using NetCore.Microservices.Services.AuthApi.Domain.Entities;
using NetCore.Microservices.Services.AuthApi.Exceptions;
using NetCore.Microservices.Services.AuthApi.Interfaces.Repositories;
using NetCore.Microservices.Services.AuthApi.Interfaces.Services;
using NetCore.Microservices.Services.AuthApi.Requests;
using NetCore.WebApiCommon.Api.Models;
using NetCore.WebApiCommon.Infrastructure.Implementations;
using InvalidCredentialException = NetCore.Microservices.Services.AuthApi.Exceptions.InvalidCredentialException;

namespace NetCore.Microservices.Services.AuthApi.Implementations.Services;

public class AuthService : GenericService, IAuthService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly IJwtService _jwtService;

    public AuthService(ILifetimeScope scope) : base(scope)
    {
        _userManager = Resolve<UserManager<ApplicationUser>>();
        _roleManager = Resolve<RoleManager<IdentityRole>>();
        _userRepository = Resolve<IUserRepository>();
        _mapper = Resolve<IMapper>();
        _jwtService = Resolve<IJwtService>();
    }
    
    public async Task<ApiActionResult> Register(UserRegisterRequest request)
    {
        var user = _mapper.Map<ApplicationUser>(request);

        var result = await _userManager.CreateAsync(user, request.Password);
        if (result.Succeeded)
        {
            var userToReturn = await _userRepository.GetUserAsync(u => u.Email == request.Email);
            return new ApiActionResult(true) { Data = _mapper.Map<DtoApplicationUser>(userToReturn) };
        }

        var error = result.Errors.First();
        return new ApiActionResult(false, error.Description);
    }

    public async Task<ApiActionResult> Login(UserLoginRequest request)
    {
        var user = await _userRepository.GetUserAsync(u => u.UserName!.ToLower() == request.UserName.ToLower());
        if (user == null)
        {
            throw new UserDoesNotExistException($"User '{request.UserName}' does not exist.");
        }
        
        var validPassword = await _userManager.CheckPasswordAsync(user, request.Password);
        if (!validPassword)
        {
            throw new InvalidCredentialException("Invalid password");
        }

        return new ApiActionResult(true) { Data = _jwtService.GenerateToken(user) };
    }

    public async Task<ApiActionResult> AssignRole(string email, string roleName)
    {
        var user = await _userRepository.GetUserAsync(u => u.Email == email);
        if (user == null)
        {
            throw new UserDoesNotExistException($"User '{email}' does not exist.");
        }

        if (!await _roleManager.RoleExistsAsync(roleName))
        {
            await _roleManager.CreateAsync(new IdentityRole(roleName));
        }

        await _userManager.AddToRoleAsync(user, roleName);
        return new ApiActionResult(true);
    }
}