using Microsoft.Extensions.Logging;
using System.Net;
using VooltTest.Application.UseCases.Base;
using VooltTest.Domain.Entities;
using VooltTest.Domain.Services.BlockRepository;

namespace VooltTest.Application.UseCases.Pages.CreatePage;

public sealed class CreatePageUseCase : UseCaseBase, ICreatePageUseCase
{
    private readonly IBlockRepository _blockRepository;

    public CreatePageUseCase(ILogger<CreatePageUseCase> logger, IBlockRepository blockRepository)
        : base(logger)
    {
        _blockRepository = blockRepository;
    }

    public async Task<CreatePageOutput> Handle(CreatePageInput input, CancellationToken cancellationToken)
    {
        LogStart(input);

        var createPageResult = await _blockRepository.CreateOrUpdatePageAsync(input.Key, Page.CreateDefault());

        if (createPageResult.IsInvalid)
        {
            return OutputFailure<CreatePageOutput>(createPageResult.StatusCode, createPageResult.ErrorMessage!);
        }

        LogSuccess();
        return new CreatePageOutput(HttpStatusCode.Created);
    }
}
