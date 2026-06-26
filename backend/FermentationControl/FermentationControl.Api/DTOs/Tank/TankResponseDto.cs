namespace FermentationControl.Api.DTOs.Tank
{
    /// <summary>
    /// Dados de uma tanque retornados ao cliente.
    /// </summary>
    public class TankResponseDto
    {
        /// <summary>
        /// Identificador único do tanque.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nome do tanque (ex: Tanque B, Tanque 01).
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Capacidade do tanque em litros.
        /// </summary>
        public decimal Capacity { get; set; }
    }
}
