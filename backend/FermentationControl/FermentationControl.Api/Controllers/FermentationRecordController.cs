using FermentationControl.Api.Features.FermentationRecord.Commands;
using FermentationControl.Api.Features.FermentationRecord.Queries.GetRecordsByBatch;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FermentationControl.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FermentationRecordController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FermentationRecordController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateFermentationRecordCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        /// <summary>
        /// Retorna histórico de um lote.
        /// </summary>
        [HttpGet("batch/{batchNumber}")]
        public async Task<IActionResult> GetByBatch(string batchNumber)
        {
            var result = await _mediator.Send(new GetRecordsByBatchQuery(batchNumber));

            if (!result.Any())
                return NotFound(new { message = $"Nenhum registro encontrado para o lote {batchNumber}." });

            return Ok(result);
        }

    }
}
