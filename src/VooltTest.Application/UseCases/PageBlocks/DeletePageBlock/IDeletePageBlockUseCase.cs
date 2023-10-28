using MediatR;

namespace VooltTest.Application.UseCases.PageBlocks.UpdatePageBlock;

public interface IDeletePageBlockUseCase : IRequestHandler<DeletePageBlockInput, DeletePageBlockOutput>
{
}
