
using Autofac.Extensions.DependencyInjection;
using NetCore.Microservices.Services.ShoppingCartApi;
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

LogManager.Shutdown();
