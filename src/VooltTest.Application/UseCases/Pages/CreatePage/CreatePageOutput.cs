using System.Net;
using VooltTest.Application.UseCases.Base;

namespace VooltTest.Application.UseCases.Pages.CreatePage;

public class CreatePageOutput : OutputBase
{
    public CreatePageOutput(HttpStatusCode httpStatusCode)
        : base(httpStatusCode)
    {
    }

    public CreatePageOutput(HttpStatusCode httpStatusCode, params string[] errorMessages)
        : base(httpStatusCode, errorMessages)
    {
    }

    public CreatePageOutput()
    {
    }
}
