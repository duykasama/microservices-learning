using System.ComponentModel.DataAnnotations;

namespace NetCore.Microservices.Services.AuthApi.Requests;

public class UserLoginRequest
{
    [Required] 
    public string UserName { get; set; } = null!;
    
    [Required] 
    public string Password { get; set; } = null!;
}