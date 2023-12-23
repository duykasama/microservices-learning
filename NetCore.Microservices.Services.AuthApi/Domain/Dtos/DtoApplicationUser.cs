namespace NetCore.Microservices.Services.AuthApi.Domain.Dtos;

public class DtoApplicationUser
{
    public string Id { get; set; }
    public string Email { get; set; }
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
}