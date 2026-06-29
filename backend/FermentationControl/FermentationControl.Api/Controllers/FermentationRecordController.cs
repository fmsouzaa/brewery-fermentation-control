using FermentationControl.Api.DTOs.FermentationRecord;
using FermentationControl.Api.Features.FermentationRecord.Commands;
using FermentationControl.Api.Features.FermentationRecord.Queries.GetRecordsByBatch;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FermentationControl.Api.Controllers
{
    /// <summary>
    /// Controller responsável pelos registros fermentativos.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class FermentationRecordController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FermentationRecordController(IMediator mediator)
        {
            _mediator = mediator;
        }
        /// <summary>
        /// Registra um novo registro fermentativo.
        /// A classificação (Dentro do Padrão, Atenção, Fora do Padrão) é gerada automaticamente com base nos parâmetros cadastrados para a cerveja.
        /// </summary>
        /// <param name="command">Dados do registro fermentativo.</param>
        /// <response code="200">Registro criado com sucesso.</response>
        /// <response code="400">Dados inválidos ou cerveja/tanque/parâmetros não encontrados.</response>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateFermentationRecordCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        /// <summary>
        /// Retorna todo o histórico fermentativo de um lote.
        /// </summary>
        /// <param name="batchNumber">Número do lote. Exemplo: LOTE001</param>
        /// <response code="200">Retorna a lista de registros do lote.</response>
        [HttpGet("batch/{batchNumber}")]
        public async Task<IActionResult> GetByBatch(string batchNumber)
        {
            var result = await _mediator.Send(new GetRecordsByBatchQuery(batchNumber));

            if (!result.Any())
            {
                return Ok(new List<FermentationRecordDetailDto>());
            }

            return Ok(result);
        }

    }
}
