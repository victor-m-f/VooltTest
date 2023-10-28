using System.Net;
using VooltTest.Application.UseCases.Base;

namespace VooltTest.Application.UseCases.PageBlocks.UpdatePageBlock;

public class UpdatePageBlockOutput : OutputBase
{
    public UpdatePageBlockOutput(HttpStatusCode httpStatusCode)
        : base(httpStatusCode)
    {
    }

    public UpdatePageBlockOutput(HttpStatusCode httpStatusCode, params string[] errorMessages)
        : base(httpStatusCode, errorMessages)
    {
    }

    public UpdatePageBlockOutput()
    {
    }
}
