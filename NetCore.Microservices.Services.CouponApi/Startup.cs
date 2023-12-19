using System.Reflection;
using Autofac;
using NetCore.WebApiCommon.Api.Middlewares;
using NetCore.WebApiCommon.Core.Common.Helpers;
using NetCore.WebApiCommon.Core.Common.Implementations;
using NetCore.WebApiCommon.Core.Common.Interfaces;
using NetCore.WebApiCommon.Infrastructure.Extensions;
using NetCore.WebApiCommon.Infrastructure.Implementations;

namespace NetCore.Microservices.Services.CouponApi;

public class Startup
{
    public IConfiguration Configuration { get; set; }
    
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
        TestExtensions.InitConfiguration(Configuration);
    }
    
    public void ConfigureContainer(ContainerBuilder builder)
    {
        builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(NLogService))!)
            .As<ILogService>()
            .InstancePerLifetimeScope();
       
        builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(MicrosoftDependencyProvider))!)
            .As<IDependencyProvider>()
            .InstancePerLifetimeScope();
        
        builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(CorrelationIdGenerator))!)
            .As<ICorrelationIdGenerator>()
            .InstancePerLifetimeScope();
    }
    
    public void ConfigureServices(IServiceCollection services)
    {
        // services.AddCustomSwagger();
        services.AddControllers();
    }

    public void Configure(IApplicationBuilder app)
    {
        
        // DependencyInjectionHelper.InitProvider(app.ApplicationServices.GetService<IDependencyProvider>()!);
        ((WebApplication)app).TestEnvironment("Development");
        // app.UseSwaggerUI();
        // app.UseSwagger();
        app.UseRouting();
        app.UseHttpsRedirection();
        app.UseMiddleware<CorrelationIdHandlerMiddleware>();
        app.UseMiddleware<GlobalExceptionHandlerMiddleware>();
        app.UseEndpoints(endpoints => endpoints.MapControllers());
    }
}