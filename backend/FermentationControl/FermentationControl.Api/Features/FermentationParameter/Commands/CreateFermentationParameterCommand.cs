using FermentationControl.Api.DTOs.FermentationParameter;
using MediatR;

namespace FermentationControl.Api.Features.FermentationParameter.Commands
{
    /// <summary>
    /// Command para cadastro de uma nova cerveja.
    /// </summary>
    public class CreateFermentationParameterCommand : IRequest<FermentationParameterResponseDto>
    {
        /// <summary>
        /// Identificador da cerveja associada aos parâmetros.
        /// </summary>
        public int BeerId { get; set; }

        /// <summary>
        /// Temperatura mínima em graus Celsius (°C).
        /// </summary>
        public decimal TemperatureMin { get; set; }

        /// <summary>
        /// Temperatura máxima em graus Celsius (°C).
        /// </summary>
        public decimal TemperatureMax { get; set; }

        /// <summary>
        /// Tolerância aplicada à faixa de temperatura. Valores fora do Min/Max, mas dentro de (Min - Tolerância) e (Max + Tolerância), geram alerta de Atenção.
        /// </summary>
        public decimal TemperatureTolerance { get; set; }

        /// <summary>
        /// pH mínimo.
        /// </summary>
        public decimal PHMin { get; set; }

        /// <summary>
        /// pH máximo.
        /// </summary>
        public decimal PHMax { get; set; }

        /// <summary>
        /// Tolerância aplicada à faixa de pH. Valores fora do Min/Max, mas dentro de (Min - Tolerância) e (Max + Tolerância), geram alerta de Atenção.
        /// </summary>
        public decimal PHTolerance { get; set; }

        /// <summary>
        /// Extrato mínimo em graus Plato (°P).
        /// </summary>
        public decimal ExtractMin { get; set; }

        /// <summary>
        /// Extrato máximo em graus Plato (°P).
        /// </summary>
        public decimal ExtractMax { get; set; }

        /// <summary>
        /// Tolerância aplicada à faixa de extrato. Valores fora do Min/Max, mas dentro de (Min - Tolerância) e (Max + Tolerância), geram alerta de Atenção.
        /// </summary>
        public decimal ExtractTolerance { get; set; }
    }
}
