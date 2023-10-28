using Microsoft.Extensions.Logging;
using System.Net;
using VooltTest.Application.UseCases.Base;
using VooltTest.Domain.Entities;
using VooltTest.Domain.Services.BlockRepository;

namespace VooltTest.Application.UseCases.PageBlocks.UpdatePageBlock;

public sealed class UpdatePageBlockUseCase : UseCaseBase, IUpdatePageBlockUseCase
{
    private readonly IBlockRepository _blockRepository;

    public UpdatePageBlockUseCase(ILogger<UpdatePageBlockUseCase> logger, IBlockRepository blockRepository)
        : base(logger)
    {
        _blockRepository = blockRepository;
    }

    public async Task<UpdatePageBlockOutput> Handle(UpdatePageBlockInput input, CancellationToken cancellationToken)
    {
        LogStart(input);

        var getPageResult = await _blockRepository.GetPageAsync(input.Key);

        if (getPageResult.IsInvalid)
        {
            return new UpdatePageBlockOutput(getPageResult.StatusCode, getPageResult.ErrorMessage!);
        }

        var page = getPageResult.Page!;

        var pageUpdated = false;

        if (HeaderBlock.Parse(input.UpdatedBlock, out var headerBlock))
        {
            pageUpdated = page.UpdateHeader(input.SectionID, headerBlock);
        }
        else if (HeroBlock.Parse(input.UpdatedBlock, out var heroBlock))
        {
            pageUpdated = page.UpdateHero(input.SectionID, heroBlock);
        }
        else if (ServicesBlock.Parse(input.UpdatedBlock, out var servicesBlock))
        {
            pageUpdated = page.UpdateServices(input.SectionID, servicesBlock);
        }

        if (!pageUpdated)
        {
            return OutputFailure<UpdatePageBlockOutput>(
                HttpStatusCode.BadRequest,
                "Invalid block type or section ID mismatch.");
        }

        var updatePageResult = await _blockRepository.CreateOrUpdatePageAsync(input.Key, page, true);

        if (updatePageResult.IsInvalid)
        {
            return OutputFailure<UpdatePageBlockOutput>(
                updatePageResult.StatusCode,
                updatePageResult.ErrorMessage!);
        }

        LogSuccess();
        return new UpdatePageBlockOutput(HttpStatusCode.OK);
    }
}
