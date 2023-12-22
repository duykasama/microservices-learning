using System.Reflection;
using Autofac;
using AutoMapper;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;
using NetCore.Microservices.Services.CouponApi.Data;
using NetCore.Microservices.Services.CouponApi.Implementations.Repositories;
using NetCore.Microservices.Services.CouponApi.Implementations.Services;
using NetCore.Microservices.Services.CouponApi.Interfaces.Repositories;
using NetCore.Microservices.Services.CouponApi.Interfaces.Services;
using NetCore.Microservices.Services.CouponApi.Mappings.AutoMapper;
using NetCore.WebApiCommon.Api.Middlewares;
using NetCore.WebApiCommon.Core.Common.Helpers;
using NetCore.WebApiCommon.Core.Common.Implementations;
using NetCore.WebApiCommon.Core.Common.Interfaces;
using NetCore.WebApiCommon.Core.DAL.Implementations;
using NetCore.WebApiCommon.Core.DAL.Interfaces;
using NetCore.WebApiCommon.Core.Settings;
using NetCore.WebApiCommon.Infrastructure.Exceptions;
using NetCore.WebApiCommon.Infrastructure.Extensions;
using NetCore.WebApiCommon.Infrastructure.Implementations;
using ServiceCollectionExtensions = NetCore.WebApiCommon.Infrastructure.Extensions.ServiceCollectionExtensions;

namespace NetCore.Microservices.Services.CouponApi;

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
        
        builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(CouponDbContext))!)
            .As<IAppDbContext>()
            .InstancePerLifetimeScope();
        
        builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(UnitOfWork))!)
            .As<IUnitOfWork>()
            .InstancePerLifetimeScope();
        
        builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(CouponRepository))!)
            .As<ICouponRepository>()
            .InstancePerLifetimeScope();
        
        builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(CouponService))!)
            .As<ICouponService>()
            .InstancePerLifetimeScope();

        var config = new MapperConfiguration(AutoMapperConfiguration.RegisterMaps);
        var mapper = config.CreateMapper();
        builder.RegisterInstance(mapper).As<IMapper>();

        // var scope = builder.Build().BeginLifetimeScope();
        // DependencyInjectionHelper.InitProvider(scope.Resolve<IDependencyProvider>());
    }
    
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddCustomSwagger();
        services.AddControllers();
        // services.AddDefaultCorsPolicy();
        // CorsSettings corsSettings = Configuration.GetSection("CorsSettings").Get<CorsSettings>() ?? throw new MissingCorsSettingsException();
        // services.AddCors((Action<CorsOptions>) (options => options.AddPolicy("APP_CORS_POLICY", (Action<CorsPolicyBuilder>) (builder =>
        // {
        //     builder.WithOrigins(corsSettings.GetAllowedOriginsArray()).WithHeaders(corsSettings.GetAllowedHeadersArray()).WithMethods(corsSettings.GetAllowedMethodsArray());
        //     if (corsSettings.AllowCredentials)
        //         builder.AllowCredentials();
        //     builder.Build();
        // }))));
    }

    public void Configure(IApplicationBuilder app)
    {
        DependencyInjectionHelper.InitProvider(app.ApplicationServices.GetService<IDependencyProvider>()!);
        EnsureMigrations();
        
        app.UseSwaggerInEnvironments("Development");
        app.UseAppCors();
        app.UseRouting();
        app.UseHttpsRedirection();
        app.UseMiddleware<CorrelationIdHandlerMiddleware>();
        app.UseMiddleware<GlobalExceptionHandlerMiddleware>();
        app.UseEndpoints(endpoints => endpoints.MapControllers());
    }

    private void EnsureMigrations()
    {
        if (DependencyInjectionHelper.ResolveService<IAppDbContext>() is CouponDbContext couponDbContext 
            && couponDbContext.Database.GetPendingMigrations().Any())
        {
            couponDbContext.Database.Migrate();
        }
    }
}