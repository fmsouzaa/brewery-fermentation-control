using FermentationControl.Api.Features.FermentationParameter.Commands;
using FermentationControl.Api.Features.FermentationParameter.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FermentationControl.Api.Controllers
{
    /// <summary>
    /// Controller responsável pelos parâmetros fermentativos das cervejas.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class FermentationParameterController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FermentationParameterController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Cadastra os parâmetros fermentativos de uma cerveja.
        /// Cada cerveja pode possuir apenas um conjunto de parâmetros cadastrados.
        /// </summary>
        /// <param name="command">Dados dos parâmetros fermentativos da cerveja.</param>
        /// <response code="200">Parâmetros cadastrados com sucesso.</response>
        /// <response code="400">Dados inválidos ou cerveja não encontrada.</response>
        [HttpPost]
        public async Task<IActionResult> CreateFermentationParameter([FromBody] CreateFermentationParameterCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        /// <summary>
        /// Busca os parâmetros fermentativos de uma cerveja pelo seu identificador.
        /// </summary>
        /// <param name="beerId">Identificador da cerveja.</param>
        /// <response code="200">Retorna os parâmetros fermentativos da cerveja.</response>
        /// <response code="404">Parâmetros não encontrados para a cerveja informada.</response>
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
