﻿using System.ComponentModel.DataAnnotations;

namespace NetCore.Microservices.Services.AuthApi.Models.Requests;

public class AssignRoleRequest
{
    [Required] 
    public string Email { get; set; } = null!;
    
    [Required] 
    public string RoleName { get; set; } = null!;
}