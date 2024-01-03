using System.Reflection;
using Autofac;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NetCore.Microservices.Services.ShoppingCartApi.Constants;
using NetCore.Microservices.Services.ShoppingCartApi.Data;
using NetCore.Microservices.Services.ShoppingCartApi.Implementations.Repositories;
using NetCore.Microservices.Services.ShoppingCartApi.Implementations.Services;
using NetCore.Microservices.Services.ShoppingCartApi.Interfaces.Repositories;
using NetCore.Microservices.Services.ShoppingCartApi.Interfaces.Services;
using NetCore.Microservices.Services.ShoppingCartApi.Mappings.AutoMapper;
using NetCore.WebApiCommon.Api.Middlewares;
using NetCore.WebApiCommon.Core.Common.Helpers;
using NetCore.WebApiCommon.Core.Common.Implementations;
using NetCore.WebApiCommon.Core.Common.Interfaces;
using NetCore.WebApiCommon.Core.DAL.Implementations;
using NetCore.WebApiCommon.Core.DAL.Interfaces;
using NetCore.WebApiCommon.Infrastructure.Extensions;
using NetCore.WebApiCommon.Infrastructure.Implementations;
using Newtonsoft.Json;
using ServiceCollectionExtensions = NetCore.WebApiCommon.Infrastructure.Extensions.ServiceCollectionExtensions;

namespace NetCore.Microservices.Services.ShoppingCartApi;

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
        
        builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(ShoppingCartDbContext))!)
            .As<IAppDbContext>()
            .InstancePerLifetimeScope();
        
        builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(ShoppingCartRepository))!)
            .As<IShoppingCartRepository>()
            .InstancePerLifetimeScope();
        
        builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(CartHeaderRepository))!)
            .As<ICartHeaderRepository>()
            .InstancePerLifetimeScope();
        
        builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(CartDetailsRepository))!)
            .As<ICartDetailsRepository>()
            .InstancePerLifetimeScope();
        
        builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(ShoppingCartService))!)
            .As<IShoppingCartService>()
            .InstancePerLifetimeScope();
        
        builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(UnitOfWork))!)
            .As<IUnitOfWork>()
            .InstancePerLifetimeScope();

        builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(ProductService))!)
            .As<IProductService>()
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
        services.AddControllers().AddNewtonsoftJson(opts =>
        {
            opts.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
        });
        services.AddDefaultCorsPolicy();
        services.AddJwtAuthentication();
        services.AddHttpClient(ClientServiceConstants.PRODUCT, client => client.BaseAddress = new Uri(Configuration["ServiceUrls:ProductApi"] ?? "https://localhost:9999"));
        services.AddHttpClient(ClientServiceConstants.COUPON, client => client.BaseAddress = new Uri(Configuration["ServiceUrls:CouponApi"] ?? "https://localhost:9999"));
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
        if (DependencyInjectionHelper.ResolveService<IAppDbContext>() is ShoppingCartDbContext shoppingCartDbContext 
           && shoppingCartDbContext.Database.GetPendingMigrations().Any())
        {
            shoppingCartDbContext.Database.Migrate();
        }
    }
}
