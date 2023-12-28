using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Autofac;
using Microsoft.IdentityModel.Tokens;
using NetCore.Microservices.Services.AuthApi.Domain.Entities;
using NetCore.Microservices.Services.AuthApi.Interfaces.Services;
using NetCore.WebApiCommon.Core.Settings;
using NetCore.WebApiCommon.Infrastructure.Exceptions;
using NetCore.WebApiCommon.Infrastructure.Implementations;

namespace NetCore.Microservices.Services.AuthApi.Implementations.Services;

public class JwtService : GenericService, IJwtService
{
    private readonly JwtSettings _jwtSettings;

    public JwtService(ILifetimeScope scope) : base(scope)
    {
        _jwtSettings = scope.Resolve<IConfiguration>().GetSection(nameof(JwtSettings)).Get<JwtSettings>() ?? throw new MissingJwtSettingsException();
    }
    
    public string GenerateToken(ApplicationUser user, IEnumerable<string> roles)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SigningKey));
        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Email, user.Email ?? ""),
            new(JwtRegisteredClaimNames.Sub, user.Id),
            new(JwtRegisteredClaimNames.Name, user.Name),
        };
        
        claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

        var tokenDescriptor = new SecurityTokenDescriptor()
        {
            Issuer = _jwtSettings.Issuer,
            Audience = _jwtSettings.Audience,
            Subject = new ClaimsIdentity(claims),
            IssuedAt = DateTime.Now,
            Expires = DateTime.Now.AddHours(1),
            SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature)
        };
        
        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}