using System.Reflection;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NetCore.Microservices.Services.CouponApi;
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
using NetCore.WebApiCommon.Core.Common.Models;
using NetCore.WebApiCommon.Core.DAL.Implementations;
using NetCore.WebApiCommon.Core.DAL.Interfaces;
using NetCore.WebApiCommon.Infrastructure.Extensions;
using NetCore.WebApiCommon.Infrastructure.Implementations;
using NLog;
using ServiceCollectionExtensions = NetCore.WebApiCommon.Infrastructure.Extensions.ServiceCollectionExtensions;

GlobalData.ModuleName = AppDomain.CurrentDomain.FriendlyName;
GlobalData.CurrentEnvironment = "Development";

LogManager.Setup()
    .LoadConfigurationFromFile($"{Directory.GetCurrentDirectory()}/Configurations/nlog.config")
    .GetCurrentClassLogger();

#region Create host with startup class

var host = Host.CreateDefaultBuilder(args)
    .UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureWebHostDefaults(builder =>
    {
        builder.UseStartup<Startup>();
    })
    .Build();

host.Run();

#endregion

#region Create default host

// var builder = WebApplication.CreateBuilder();
// var containerBuilder = new ContainerBuilder();
//
// ServiceCollectionExtensions.InitConfiguration(builder.Configuration);
//
// builder.Services.AddCustomSwagger();
// builder.Services.AddControllers();
//
// #region Register dependencies
//
// containerBuilder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(NLogService))!)
//     .As<ILogService>()
//     .InstancePerLifetimeScope();
//        
// containerBuilder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(AutofacDependencyProvider))!)
//     .As<IDependencyProvider>()
//     .InstancePerLifetimeScope();
//         
// containerBuilder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(CorrelationIdGenerator))!)
//     .As<ICorrelationIdGenerator>()
//     .InstancePerLifetimeScope();
//         
// containerBuilder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(CouponDbContext))!)
//     .As<IAppDbContext>()
//     .InstancePerLifetimeScope();
//         
// containerBuilder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(UnitOfWork))!)
//     .As<IUnitOfWork>()
//     .InstancePerLifetimeScope();
//         
// containerBuilder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(CouponRepository))!)
//     .As<ICouponRepository>()
//     .InstancePerLifetimeScope();
//         
// containerBuilder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(CouponService))!)
//     .As<ICouponService>()
//     .InstancePerLifetimeScope();
//
// containerBuilder.RegisterInstance(builder.Configuration)
//     .As<IConfiguration>();
//
// var config = new MapperConfiguration(AutoMapperConfiguration.RegisterMaps);
// var mapper = config.CreateMapper();
// containerBuilder.RegisterInstance(mapper).As<IMapper>();
//
// #endregion
//
// var app = builder.Build();
// var container = containerBuilder.Build();
//
// DependencyInjectionHelper.InitProvider(container.Resolve<IDependencyProvider>());
//
// EnsureMigrations();
//
// app.UseSwaggerInEnvironments("Development");
// app.UseRouting();
// app.UseHttpsRedirection();
// app.UseMiddleware<GlobalExceptionHandlerMiddleware>();
// app.UseMiddleware<CorrelationIdHandlerMiddleware>();
// app.MapControllers();
// app.Run();

#endregion

LogManager.Shutdown();
return;

void EnsureMigrations()
{
    if (DependencyInjectionHelper.ResolveService<IAppDbContext>() is CouponDbContext couponDbContext 
        && couponDbContext.Database.GetPendingMigrations().Any())
    {
        couponDbContext.Database.Migrate();
    }
}