using Microsoft.Extensions.Logging;
using System.Net;

namespace VooltTest.Application.UseCases.Base;

public abstract class UseCaseBase
{
    private const string StartingLogMessage = "Starting with input: {@input}.";
    private const string SuccessLogMessage = "Executed successfully.";
    private const string FailLogMessage = "Execution failed with errors: {@useCaseErrors}.";

    protected ILogger Logger { get; }

    public UseCaseBase(
        ILogger logger)
    {
        Logger = logger;
    }

    protected void LogStart(object input) =>
        Logger.LogInformation(StartingLogMessage, input);

    protected void LogSuccess() =>
        Logger.LogInformation(SuccessLogMessage);

    protected void LogFailure(OutputBase output) =>
        Logger.LogWarning(FailLogMessage, output.Errors);

    protected TOutput OutputFailure<TOutput>(HttpStatusCode statusCode, string errorMessage)
        where TOutput : OutputBase, new()
    {
        var output = new TOutput()
        {
            HttpStatusCode = statusCode,
        };
        output.AddError(errorMessage);
        return output;
    }
}
