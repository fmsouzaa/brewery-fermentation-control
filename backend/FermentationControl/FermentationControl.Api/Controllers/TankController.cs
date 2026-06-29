using FermentationControl.Api.Features.Tank.Commands;
using FermentationControl.Api.Features.Tank.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FermentationControl.Api.Controllers
{
    /// <summary>
    /// Controller responsável pelo gerenciamento de tanques.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class TankController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TankController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Cadastra um novo tanque.
        /// </summary>
        /// <param name="command">Dados do tanque a ser cadastrado.</param>
        /// <returns>Tanque cadastrado.</returns>
        /// <response code="200">Tanque cadastrado com sucesso.</response>
        /// <response code="400">Dados inválidos.</response>
        [HttpPost]
        public async Task<IActionResult> CreateTank([FromBody] CreateTankCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        /// <summary>
        /// Lista todos os tanques cadastrados.
        /// </summary>
        /// <returns>Lista de tanques.</returns>
        /// <response code="200">Retorna a lista de tanques.</response>
        [HttpGet]
        public async Task<IActionResult> GetAllTanks()
        {
            var result = await _mediator.Send(new GetAllTankQuery());
            return Ok(result);
        }
    }
}
