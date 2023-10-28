using System.Net;

namespace VooltTest.Domain.Services;

public class RepositoryResult
{
    public bool IsValid { get; }
    public string? ErrorMessage { get; }
    public bool IsInvalid => !IsValid;
    public HttpStatusCode StatusCode { get; }

    public RepositoryResult()
    {
        IsValid = true;
    }

    public RepositoryResult(HttpStatusCode statusCode, string errorMessage)
    {
        StatusCode = statusCode;
        ErrorMessage = errorMessage;
    }
}
