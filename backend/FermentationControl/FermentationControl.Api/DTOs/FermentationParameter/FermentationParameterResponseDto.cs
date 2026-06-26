namespace FermentationControl.Api.DTOs.FermentationParameter
{
    /// <summary>
    /// Dados de parâmetro retornados ao cliente.
    /// </summary>
    public class FermentationParameterResponseDto
    {
        /// <summary>
        /// Identificador único do parâmetro.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Identificador da cerveja.
        /// </summary>
        public int BeerId { get; set; }

        /// <summary>
        /// Temperatura minima em graus Celsius.
        /// </summary>
        public decimal TemperatureMin { get; set; }

        /// <summary>
        /// Temperatura máxima em graus Celsius.
        /// </summary>
        public decimal TemperatureMax { get; set; }

        /// <summary>
        /// pH minimo.
        /// </summary>
        public decimal PHMin { get; set; }

        /// <summary>
        /// pH máximo.
        /// </summary>
        public decimal PHMax { get; set; }

        /// <summary>
        /// Extração minima.
        /// </summary>
        public decimal ExtractMin { get; set; }

        /// <summary>
        /// Extração máxima.
        /// </summary>
        public decimal ExtractMax { get; set; }
    }
}
