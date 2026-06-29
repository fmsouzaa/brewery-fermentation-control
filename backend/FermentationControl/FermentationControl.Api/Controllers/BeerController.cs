using FermentationControl.Api.Features.Beer.Commands;
using FermentationControl.Api.Features.Beer.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FermentationControl.Api.Controllers
{
    /// <summary>
    /// Controller responsável pelo gerenciamento de cervejas.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class BeerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BeerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Cadastra uma nova cerveja.
        /// </summary>
        /// <param name="command">Dados da cerveja a ser cadastrada.</param>
        /// <returns>Cerveja cadastrada.</returns>
        /// <response code="200">Cerveja cadastrada com sucesso.</response>
        /// <response code="400">Dados inválidos.</response>
        [HttpPost]
        public async Task<IActionResult> CreateBeer([FromBody] CreateBeerCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        /// <summary>
        /// Lista todas as cervejas cadastradas.
        /// </summary>
        /// <returns>Lista de cervejas.</returns>
        /// <response code="200">Retorna a lista de cervejas.</response>
        [HttpGet]
        public async Task<IActionResult> GetAllBeers()
        {
            var result = await _mediator.Send(new GetAllBeersQuery());
            return Ok(result);
        }
    }
}