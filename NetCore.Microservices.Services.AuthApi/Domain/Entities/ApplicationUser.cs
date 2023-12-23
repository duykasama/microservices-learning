using Microsoft.AspNetCore.Identity;

namespace NetCore.Microservices.Services.AuthApi.Domain.Entities;

public class ApplicationUser : IdentityUser
{
    public string Name { get; set; }
}