using System.ComponentModel.DataAnnotations;

namespace NetCore.Microservices.Services.AuthApi.Requests;

public class UserRegisterRequest
{
    [Required]
    public string Email { get; set; } = null!;
    
    [Required]
    public string Name { get; set; } = null!;
    
    public string PhoneNumber { get; set; }
    
    [Required]
    public string Password { get; set; } = null!;
}