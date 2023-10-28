using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VooltTest.Api.Controllers.Base;
using VooltTest.Application.UseCases.Pages.CreatePage;
using VooltTest.Application.UseCases.Pages.GetPage;
using VooltTest.Domain.Entities;
using VooltTest.Shared.Requests.PageBlock;

namespace VooltTest.Api.Controllers
{
    public sealed class PagesController : ApiControllerBase
    {
        public PagesController(ILogger<PagesController> logger, IMediator mediator)
            : base(logger, mediator)
        {
        }

        [AllowAnonymous]
        [HttpPost(Name = nameof(CreatePage))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(List<string>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(List<string>))]
        public async Task<IActionResult> CreatePage(
            CreatePageBlockRequest request,
            CancellationToken cancellationToken)
        {
            using (StartUseCaseScope(nameof(CreatePage)))
            {
                var input = new CreatePageInput(request.Key);
                var output = await Mediator.Send(input, cancellationToken);

                return output.IsValid?
                    StatusCode(output.StatusCode):
                    StatusCode(output.StatusCode, output.Errors);
            }
        }

        [AllowAnonymous]
        [HttpGet("{key}", Name = nameof(GetPage))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Page))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(List<string>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(List<string>))]
        public async Task<ActionResult<Page>> GetPage(
            string key,
            CancellationToken cancellationToken)
        {
            using (StartUseCaseScope(nameof(CreatePage)))
            {
                var input = new GetPageInput(key);
                var output = await Mediator.Send(input, cancellationToken);

                return output.IsValid ?
                    StatusCode(output.StatusCode, output.Page) :
                    StatusCode(output.StatusCode, output.Errors);
            }
        }
    }
}
