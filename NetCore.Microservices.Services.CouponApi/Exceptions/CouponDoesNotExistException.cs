using NetCore.WebApiCommon.Core.Common.Exceptions;

namespace NetCore.Microservices.Services.CouponApi.Exceptions;

public class CouponDoesNotExistException : ArgumentException, IAppException
{
    public CouponDoesNotExistException()
    {
    }

    public CouponDoesNotExistException(string message) : base(message)
    {
    }
}