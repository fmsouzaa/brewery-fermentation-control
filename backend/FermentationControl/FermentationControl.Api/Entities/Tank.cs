namespace FermentationControl.Api.Entities
{
    /// <summary>
    /// Cadastro de tanques
    /// </summary>
    public class Tank
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


        public ICollection<FermentationRecord> FermentationRecords { get; set; } = new List<FermentationRecord>();
    }
}
