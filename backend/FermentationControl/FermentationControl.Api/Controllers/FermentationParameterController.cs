using FermentationControl.Api.Features.FermentationParameter.Commands;
using FermentationControl.Api.Features.FermentationParameter.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FermentationControl.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FermentationParameterController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FermentationParameterController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateFermentationParameter([FromBody] CreateFermentationParameterCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("{beerId}")]
        public async Task<IActionResult> GetByBeerId(int beerId)
        {
            var result = await _mediator.Send(new GetParameterByBeerIdQuery(beerId));

            if (result == null)
            {
                return NotFound(new { message = $"Parâmetros de fermentação não encontrados para a cerveja com Id {beerId}." });
            }         

            return Ok(result);
        }
    }
}
