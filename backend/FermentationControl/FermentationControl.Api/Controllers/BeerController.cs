using FermentationControl.Api.Features.Beer.Commands;
using FermentationControl.Api.Features.Beer.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FermentationControl.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BeerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BeerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBeer([FromBody] CreateBeerCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBeers()
        {
            var result = await _mediator.Send(new GetAllBeersQuery());
            return Ok(result);
        }
    }
}