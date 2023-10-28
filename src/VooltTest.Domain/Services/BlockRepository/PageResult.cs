using System.Net;
using VooltTest.Domain.Entities;

namespace VooltTest.Domain.Services.BlockRepository;

public sealed class PageResult : RepositoryResult
{
    public Page? Page { get; set; }

    public PageResult(Page page)
        : base()
    {
        Page = page;
    }

    public PageResult(HttpStatusCode statusCode, string errorMessage)
        : base(statusCode, errorMessage)
    {
    }
}
