using MediatR;

namespace VooltTest.Application.UseCases.Pages.CreatePage;

public interface ICreatePageUseCase : IRequestHandler<CreatePageInput, CreatePageOutput>
{
}
