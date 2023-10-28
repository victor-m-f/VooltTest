using Microsoft.Extensions.Logging;
using System.Net;
using VooltTest.Application.UseCases.Base;
using VooltTest.Domain.Services.BlockRepository;

namespace VooltTest.Application.UseCases.PageBlocks.UpdatePageBlock;

public sealed class DeletePageBlockUseCase : UseCaseBase, IDeletePageBlockUseCase
{
    private readonly IBlockRepository _blockRepository;

    public DeletePageBlockUseCase(ILogger<DeletePageBlockUseCase> logger, IBlockRepository blockRepository)
        : base(logger)
    {
        _blockRepository = blockRepository;
    }

    public async Task<DeletePageBlockOutput> Handle(DeletePageBlockInput input, CancellationToken cancellationToken)
    {
        LogStart(input);

        var getPageResult = await _blockRepository.GetPageAsync(input.Key);

        if (getPageResult.IsInvalid)
        {
            return OutputFailure<DeletePageBlockOutput>(
                getPageResult.StatusCode,
                getPageResult.ErrorMessage!);
        }

        getPageResult.Page!.DeleteBlock(input.SectionID);
        var overwritePageResult = await _blockRepository.CreateOrUpdatePageAsync(input.Key, getPageResult.Page, true);

        if (overwritePageResult.IsInvalid)
        {
            return OutputFailure<DeletePageBlockOutput>(
                overwritePageResult.StatusCode,
                overwritePageResult.ErrorMessage!);
        }

        LogSuccess();
        return new DeletePageBlockOutput(HttpStatusCode.OK);
    }
}
