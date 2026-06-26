using FermentationControl.Api.Enums;

namespace FermentationControl.Api.Entities
{
    /// <summary>
    /// Cadastro de registros de fermentação
    /// </summary>
    public class FermentationRecord
    {
        /// <summary>
        /// Identificador único do registro.
        /// </summary>
        /// 
        public int Id { get; set; }

        public int BeerId { get; set; }

        public int TankId { get; set; }

        /// <summary>
        /// Data e hora em que o registro foi realizado.
        /// </summary>
        public DateTime DateTime { get; set; }

        /// <summary>
        /// Número do lote (ex: IPA001, LAGER002).
        /// </summary>
        public string BatchNumber { get; set; } = string.Empty;

        /// <summary>
        /// Temperatura medida no momento do registro em graus Celsius.
        /// </summary>
        public decimal Temperature { get; set; }

        /// <summary>
        /// pH medido no momento do registro.
        /// </summary>
        public decimal PH { get; set; }

        /// <summary>
        /// Extrato medido no momento do registro.
        /// </summary>
        public decimal Extract { get; set; }

        /// <summary>
        /// Observações adicionais sobre o registro (campo opcional).
        /// </summary>
        public string? Notes { get; set; }

        /// <summary>
        /// Categorias de classificação automática de um registro de fermentação.
        /// Valores: "Dentro do Padrão", "Atenção", "Fora do Padrão".
        /// Preenchido automaticamente pelo sistema ao salvar o registro.
        /// </summary>
        public FermentationCategory Category { get; set; }

        public Beer? Beer { get; set; }

        public Tank? Tank { get; set; }
    }
}
