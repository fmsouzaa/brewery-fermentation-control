using FermentationControl.Api.Enums;

namespace FermentationControl.Api.DTOs.FermentationRecord
{
    /// <summary>
    /// Dados detalhados de um registro fermentativo para exibição no histórico de lotes.
    /// </summary>
    public class FermentationRecordDetailDto
    {
        /// <summary>
        /// Identificador único do registro.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Data e hora em que o registro foi realizado.
        /// </summary>
        public DateTime DateTime { get; set; }

        /// <summary>
        /// Nome da cerveja associada ao registro.
        /// </summary>
        public string BeerName { get; set; } = string.Empty;

        /// <summary>
        /// Nome do tanque utilizado no registro.
        /// </summary>
        public string TankName { get; set; } = string.Empty;

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

        /// <summary>
        /// Classificação automática do registro com base nos parâmetros da cerveja.
        /// Valores possíveis: 0 = Dentro do Padrão, 1 = Atenção, 2 = Fora do Padrão.
        /// Preenchido automaticamente pelo sistema ao salvar o registro.
        /// </summary>
        public FermentationCategory Category { get; set; }
    }
}
