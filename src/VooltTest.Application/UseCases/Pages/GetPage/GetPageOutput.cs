using System.Net;
using VooltTest.Application.UseCases.Base;
using VooltTest.Domain.Entities;

namespace VooltTest.Application.UseCases.Pages.GetPage;

public class GetPageOutput : OutputBase
{
    public Page? Page { get; set; }

    public GetPageOutput(HttpStatusCode httpStatusCode, Page page)
        : base(httpStatusCode)
    {
        Page = page;
    }

    public GetPageOutput(HttpStatusCode httpStatusCode, params string[] errorMessages)
        : base(httpStatusCode, errorMessages)
    {
    }

    public GetPageOutput()
    {
    }
}
