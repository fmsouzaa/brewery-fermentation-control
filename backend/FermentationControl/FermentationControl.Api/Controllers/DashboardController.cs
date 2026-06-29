using FermentationControl.Api.Features.Dashboard.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FermentationControl.Api.Controllers
{
    /// <summary>
    /// Controller responsável pelos indicadores do dashboard.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class DashboardController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DashboardController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Retorna os indicadores gerais do dashboard, incluindo o total de registros fermentativos e a quantidade por classificação (Dentro do Padrão, Atenção e Fora do Padrão).
        /// </summary>
        /// <response code="200">Retorna os indicadores do dashboard.</response>
        [HttpGet]
        public async Task<IActionResult> GetDashboard()
        {
            var result = await _mediator.Send(new GetDashboardQuery());
            return Ok(result);
        }
    }
}
