using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NetCore.Microservices.Services.AuthApi.Domain.Entities;
using NetCore.WebApiCommon.Core.Common.Constants;
using NetCore.WebApiCommon.Core.Common.Helpers;
using NetCore.WebApiCommon.Core.DAL.Interfaces;
using NetCore.WebApiCommon.Core.Entities;

namespace NetCore.Microservices.Services.AuthApi.Data;

public class AuthDbContext : IdentityDbContext<ApplicationUser>
{
    public AuthDbContext()
    {
    }

    public AuthDbContext(DbContextOptions options): base(options)
    {
    }

    public DbSet<ApplicationUser> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        if (optionsBuilder.IsConfigured)
        {
            return;
        }
        
        optionsBuilder.UseSqlServer(DataAccessHelper.GetDefaultConnectionString(), builder =>
        {
            builder.CommandTimeout(DataAccessConstants.COMMAND_TIMEOUT_IN_SECONDS);
        });
        optionsBuilder.EnableSensitiveDataLogging()
            .LogTo(Console.WriteLine, LogLevel.Information);
    }
}