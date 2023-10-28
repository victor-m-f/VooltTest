using System.Net;
using VooltTest.Application.UseCases.Base;

namespace VooltTest.Application.UseCases.PageBlocks.UpdatePageBlock;

public class DeletePageBlockOutput : OutputBase
{
    public DeletePageBlockOutput(HttpStatusCode httpStatusCode)
        : base(httpStatusCode)
    {
    }

    public DeletePageBlockOutput(HttpStatusCode httpStatusCode, params string[] errorMessages)
        : base(httpStatusCode, errorMessages)
    {
    }

    public DeletePageBlockOutput()
    {
    }
}
