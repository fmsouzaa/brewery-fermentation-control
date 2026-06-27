using FermentationControl.Api.Features.Tank.Commands;
using FermentationControl.Api.Features.Tank.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FermentationControl.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TankController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TankController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTank([FromBody] CreateTankCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTanks()
        {
            var result = await _mediator.Send(new GetAllTankQuery());
            return Ok(result);
        }
    }
}
