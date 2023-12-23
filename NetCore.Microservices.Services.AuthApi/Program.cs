using Autofac.Extensions.DependencyInjection;
using NetCore.Microservices.Services.AuthApi;
using NetCore.WebApiCommon.Core.Common.Models;
using NLog;

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