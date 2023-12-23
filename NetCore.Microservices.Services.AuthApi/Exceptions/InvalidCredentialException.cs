using NetCore.WebApiCommon.Core.Common.Exceptions;

namespace NetCore.Microservices.Services.AuthApi.Exceptions;

public class InvalidCredentialException : ArgumentException, IAppException
{
    public InvalidCredentialException()
    {
    }

    public InvalidCredentialException(string message) : base(message)
    {
    }
}