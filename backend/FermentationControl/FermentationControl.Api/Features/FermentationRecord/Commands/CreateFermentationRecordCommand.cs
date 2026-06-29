using FermentationControl.Api.DTOs.FermentationRecord;
using MediatR;

namespace FermentationControl.Api.Features.FermentationRecord.Commands
{
    public class CreateFermentationRecordCommand : IRequest<FermentationRecordResponseDto>
    {
        /// <summary>
        /// Identificador da cerveja associada ao registro.
        /// </summary>
        public int BeerId { get; set; }

        /// <summary>
        /// Identificador do tanque associada ao registro.
        /// </summary>
        public int TankId { get; set; }

        /// <summary>
        /// Data e hora em que o registro foi realizado.
        /// </summary>
        public DateTime DateTime { get; set; }

        /// <summary>
        /// Número do lote (ex: LOTE001, LOTE002).
        /// </summary>
        public string BatchNumber { get; set; } = string.Empty;

        /// <summary>
        /// Temperatura medida no momento do registro em graus Celsius (°C).
        /// </summary>
        public decimal Temperature { get; set; }

        /// <summary>
        /// pH medido no momento do registro.
        /// </summary>
        public decimal PH { get; set; }

        /// <summary>
        /// Extrato medido no momento do registro em graus Plato (°P).
        /// </summary>
        public decimal Extract { get; set; }

        /// <summary>
        /// Observações adicionais sobre o registro (campo opcional).
        /// </summary>
        public string? Notes { get; set; }

    }
}
