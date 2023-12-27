using System.ComponentModel.DataAnnotations;

namespace NetCore.Microservices.Services.AuthApi.Models.Requests;

public class UserRegisterRequest
{
    [Required]
    public string Email { get; set; } = null!;
    
    [Required]
    public string Name { get; set; } = null!;

    [Required] 
    public string PhoneNumber { get; set; } = null!;
    
    [Required]
    public string Password { get; set; } = null!;
}