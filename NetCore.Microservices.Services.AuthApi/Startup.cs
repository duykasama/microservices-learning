using System.Reflection;
using Autofac;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NetCore.Microservices.Services.AuthApi.Data;
using NetCore.Microservices.Services.AuthApi.Domain.Entities;
using NetCore.Microservices.Services.AuthApi.Implementations.Repositories;
using NetCore.Microservices.Services.AuthApi.Implementations.Services;
using NetCore.Microservices.Services.AuthApi.Interfaces.Repositories;
using NetCore.Microservices.Services.AuthApi.Interfaces.Services;
using NetCore.Microservices.Services.AuthApi.Mappings.AutoMapper;
using NetCore.WebApiCommon.Api.Middlewares;
using NetCore.WebApiCommon.Core.Common.Helpers;
using NetCore.WebApiCommon.Core.Common.Implementations;
using NetCore.WebApiCommon.Core.Common.Interfaces;
using NetCore.WebApiCommon.Core.DAL.Implementations;
using NetCore.WebApiCommon.Core.DAL.Interfaces;
using NetCore.WebApiCommon.Infrastructure.Extensions;
using NetCore.WebApiCommon.Infrastructure.Implementations;
using ServiceCollectionExtensions = NetCore.WebApiCommon.Infrastructure.Extensions.ServiceCollectionExtensions;

namespace NetCore.Microservices.Services.AuthApi;

public class Startup
{
    public IConfiguration Configuration { get; set; }
    
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
        ServiceCollectionExtensions.InitConfiguration(Configuration);
    }
    
    public void ConfigureContainer(ContainerBuilder builder)
    {
        builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(NLogService))!)
            .As<ILogService>()
            .InstancePerLifetimeScope();
       
        builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(AutofacDependencyProvider))!)
            .As<IDependencyProvider>()
            .InstancePerLifetimeScope();
        
        builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(CorrelationIdGenerator))!)
            .As<ICorrelationIdGenerator>()
            .InstancePerLifetimeScope();

        builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(AuthDbContext))!)
            .InstancePerLifetimeScope();
        
        builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(UnitOfWork))!)
            .As<IUnitOfWork>()
            .InstancePerLifetimeScope();
        
        builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(UserRepository))!)
            .As<IUserRepository>()
            .InstancePerLifetimeScope();
        
        builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(AuthService))!)
            .As<IAuthService>()
            .InstancePerLifetimeScope();
        
        builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(JwtService))!)
            .As<IJwtService>()
            .InstancePerLifetimeScope();
        
        var config = new MapperConfiguration(AutoMapperConfiguration.RegisterMaps);
        var mapper = config.CreateMapper();
        builder.RegisterInstance(mapper).As<IMapper>();

        // var scope = builder.Build().BeginLifetimeScope();
        // DependencyInjectionHelper.InitProvider(scope.Resolve<IDependencyProvider>());
    }
    
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<AuthDbContext>()
            .AddDefaultTokenProviders();
        services.AddCustomSwagger();
        services.AddControllers();
        services.AddDefaultCorsPolicy();
    }

    public void Configure(IApplicationBuilder app)
    {
        DependencyInjectionHelper.InitProvider(app.ApplicationServices.GetService<IDependencyProvider>()!);
        EnsureMigrations();
        
        app.UseSwaggerInEnvironments("Development");
        app.UseDefaultCorsPolicy();
        app.UseRouting();
        app.UseHttpsRedirection();
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseMiddleware<CorrelationIdHandlerMiddleware>();
        app.UseMiddleware<GlobalExceptionHandlerMiddleware>();
        app.UseEndpoints(endpoints => endpoints.MapControllers());
    }

    private void EnsureMigrations()
    {
        if (DependencyInjectionHelper.ResolveService<AuthDbContext>() is { } authDbContext 
            && authDbContext.Database.GetPendingMigrations().Any())
        {
            authDbContext.Database.Migrate();
        }
    }
}