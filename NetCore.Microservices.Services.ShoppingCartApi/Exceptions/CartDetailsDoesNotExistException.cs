using NetCore.WebApiCommon.Core.Common.Exceptions;

namespace NetCore.Microservices.Services.ShoppingCartApi.Exceptions;

public class CartDetailsDoesNotExistException : ArgumentException, IAppException
{
    public CartDetailsDoesNotExistException()
    {
    }

    public CartDetailsDoesNotExistException(string message) : base(message)
    {
    }
}