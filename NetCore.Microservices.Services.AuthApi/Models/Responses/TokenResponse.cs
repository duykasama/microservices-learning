﻿namespace NetCore.Microservices.Services.AuthApi.Models.Responses;

public class TokenResponse
{
    public string AccessToken { get; set; } = null!;
    public string RefreshToken { get; set; } = null!;
    public DateTimeOffset ExpiresAt { get; set; }
}