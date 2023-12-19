using NetCore.WebApiCommon.Core.Settings;

namespace NetCore.Microservices.Services.CouponApi;

public static class TestExtensions
{
    public static IConfiguration Configuration { get; set; }

    public static void InitConfiguration(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    
    public static void TestExtension(this IServiceCollection services)
    {
        var a = Configuration.GetSection(nameof(SwaggerSettings)).Get<SwaggerSettings>();
    }
    
    public static void TestEnvironment(this WebApplication app, params string[] environments)
    {
        if (!environments.Contains(app.Environment.EnvironmentName)) return;
        
        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            options.DisplayRequestDuration();
            options.EnableTryItOutByDefault();
        });
    }
}