using Autofac.Extensions.DependencyInjection;
using NetCore.Microservices.Services.CouponApi;
using NetCore.WebApiCommon.Core.Common.Models;
using NLog;

namespace NetCore.Microservices.Services.CouponApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            GlobalData.ModuleName = AppDomain.CurrentDomain.FriendlyName;

            LogManager.Setup()
                .LoadConfigurationFromFile($"{Directory.GetCurrentDirectory()}/Configurations/nlog.config")
                .GetCurrentClassLogger();

            var host = Host.CreateDefaultBuilder(args)
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureWebHostDefaults(builder =>
                {
                    builder.UseStartup<Startup>();
                })
                .Build();

            host.Run();

            LogManager.Shutdown();
        }
    }
}


