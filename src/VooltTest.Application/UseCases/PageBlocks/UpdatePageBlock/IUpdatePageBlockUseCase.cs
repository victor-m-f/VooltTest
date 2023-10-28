using MediatR;

namespace VooltTest.Application.UseCases.PageBlocks.UpdatePageBlock;

public interface IUpdatePageBlockUseCase : IRequestHandler<UpdatePageBlockInput, UpdatePageBlockOutput>
{
}
