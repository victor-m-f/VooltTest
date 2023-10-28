using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VooltTest.Api.Controllers.Base;
using VooltTest.Application.UseCases.PageBlocks.UpdatePageBlock;
using VooltTest.Shared.Requests.PageBlock;

namespace VooltTest.Api.Controllers
{
    [Route("Pages/{key}/[controller]")]
    public sealed class PageBlocksController : ApiControllerBase
    {
        public PageBlocksController(ILogger<PageBlocksController> logger, IMediator mediator)
            : base(logger, mediator)
        {
        }

        [AllowAnonymous]
        [HttpPut("{sectionID:int}", Name = nameof(UpdatePageBlock))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(List<string>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(List<string>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(List<string>))]
        public async Task<IActionResult> UpdatePageBlock(
            string key,
            int sectionID,
            UpdatePageBlockRequest request,
            CancellationToken cancellationToken)
        {
            using (StartUseCaseScope(nameof(UpdatePageBlock)))
            {
                var input = new UpdatePageBlockInput(key, sectionID, request.UpdatedBlock);
                var output = await Mediator.Send(input, cancellationToken);

                return output.IsValid ?
                    StatusCode(output.StatusCode) :
                    StatusCode(output.StatusCode, output.Errors);
            }
        }

        [AllowAnonymous]
        [HttpDelete("{sectionID:int}", Name = nameof(DeletePageBlock))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(List<string>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(List<string>))]
        public async Task<IActionResult> DeletePageBlock(
            string key,
            int sectionID,
            CancellationToken cancellationToken)
        {
            using (StartUseCaseScope(nameof(DeletePageBlock)))
            {
                var input = new DeletePageBlockInput(key, sectionID);
                var output = await Mediator.Send(input, cancellationToken);

                return output.IsValid ?
                    StatusCode(output.StatusCode) :
                    StatusCode(output.StatusCode, output.Errors);
            }
        }
    }
}
