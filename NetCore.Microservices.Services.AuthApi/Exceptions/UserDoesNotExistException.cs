using NetCore.WebApiCommon.Core.Common.Exceptions;

namespace NetCore.Microservices.Services.AuthApi.Exceptions;

public class UserDoesNotExistException : ArgumentException, IAppException
{
    public UserDoesNotExistException()
    {
    }

    public UserDoesNotExistException(string message) : base(message)
    {
    }
}