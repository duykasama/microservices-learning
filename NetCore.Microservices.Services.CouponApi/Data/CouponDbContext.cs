using Microsoft.EntityFrameworkCore;
using NetCore.Microservices.Services.CouponApi.Interfaces;
using NetCore.WebApiCommon.Core.Common.Constants;
using NetCore.WebApiCommon.Core.Common.Helpers;
using NetCore.WebApiCommon.Core.DAL.Implementations;

namespace NetCore.Microservices.Services.CouponApi.Data;

public class CouponDbContext : AppDbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (optionsBuilder.IsConfigured)
        {
            return;
        }

        optionsBuilder.UseSqlServer(DataAccessHelper.GetDefaultConnectionString(),
            options =>
            {
                options.CommandTimeout(DataAccessConstants.COMMAND_TIMEOUT_IN_SECONDS);
            })
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors()
            .LogTo(Console.WriteLine, LogLevel.Information);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        var types = AppDomain.CurrentDomain
            .GetAssemblies()
            .SelectMany(a => a.GetTypes())
            .Where(t => !t.IsAbstract && t.IsAssignableTo(typeof(IDatabaseModelMapper)));
        
        foreach (var type in types)
        {
            var instance = Activator.CreateInstance(type) as IDatabaseModelMapper;
            instance?.Map(modelBuilder);
        }
    }
}