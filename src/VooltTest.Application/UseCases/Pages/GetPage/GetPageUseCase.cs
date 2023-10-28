using Microsoft.Extensions.Logging;
using System.Net;
using VooltTest.Application.UseCases.Base;
using VooltTest.Domain.Services.BlockRepository;

namespace VooltTest.Application.UseCases.Pages.GetPage;

public sealed class GetPageUseCase : UseCaseBase, IGetPageUseCase
{
    private readonly IBlockRepository _blockRepository;

    public GetPageUseCase(ILogger<GetPageUseCase> logger, IBlockRepository blockRepository)
        : base(logger)
    {
        _blockRepository = blockRepository;
    }

    public async Task<GetPageOutput> Handle(GetPageInput input, CancellationToken cancellationToken)
    {
        LogStart(input);

        var getPageResult = await _blockRepository.GetPageAsync(input.Key);

        if (getPageResult.IsInvalid)
        {
            return OutputFailure<GetPageOutput>(getPageResult.StatusCode, getPageResult.ErrorMessage!);
        }

        LogSuccess();
        return new GetPageOutput(HttpStatusCode.OK, getPageResult.Page!);
    }
}
