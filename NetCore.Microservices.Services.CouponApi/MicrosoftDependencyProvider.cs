using Autofac;
using NetCore.WebApiCommon.Core.Common.Interfaces;
using NetCore.WebApiCommon.Infrastructure.Implementations;

namespace NetCore.Microservices.Services.CouponApi;

public class MicrosoftDependencyProvider : IDependencyProvider
{
    private readonly IServiceProvider _serviceProvider;
    
    public MicrosoftDependencyProvider(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public T ResolveService<T>()
    {
        return _serviceProvider.GetService<T>() ?? throw new Exception();
    }

    public object ResolveService(Type serviceType)
    {
        throw new NotImplementedException();
    }
}