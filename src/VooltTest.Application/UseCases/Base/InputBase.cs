using MediatR;

namespace VooltTest.Application.UseCases.Base;

public abstract class InputBase<TOutput> : IRequest<TOutput>
    where TOutput : OutputBase
{
}
