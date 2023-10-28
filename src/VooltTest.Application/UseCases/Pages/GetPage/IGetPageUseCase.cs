using MediatR;

namespace VooltTest.Application.UseCases.Pages.GetPage;

public interface IGetPageUseCase : IRequestHandler<GetPageInput, GetPageOutput>
{
}
