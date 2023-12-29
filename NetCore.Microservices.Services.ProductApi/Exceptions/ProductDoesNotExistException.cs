using NetCore.WebApiCommon.Core.Common.Exceptions;

namespace NetCore.Microservices.Services.ProductApi.Exceptions;

public class ProductDoesNotExistException : ArgumentException, IAppException
{
    public ProductDoesNotExistException()
    {
    }

    public ProductDoesNotExistException(string message) : base(message)
    {
    }
}