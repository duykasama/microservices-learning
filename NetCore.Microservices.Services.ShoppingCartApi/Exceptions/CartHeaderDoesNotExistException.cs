using NetCore.WebApiCommon.Core.Common.Exceptions;

namespace NetCore.Microservices.Services.ShoppingCartApi.Exceptions;

public class CartHeaderDoesNotExistException : ArgumentException, IAppException
{
    public CartHeaderDoesNotExistException()
    {
    }

    public CartHeaderDoesNotExistException(string message) : base(message)
    {
    }
}