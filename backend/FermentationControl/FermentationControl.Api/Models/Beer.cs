namespace FermentationControl.Api.Models
{
    /// <summary>
    /// Cadastro de cerveja
    /// </summary>
    public class Beer
    {
        /// <summary>
        /// Identificador único da cerveja.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nome da cerveja (ex: RT166, Brux, Borck, Anbier).
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Estilo da cerveja (ex: IPA, Lager, Weiss).
        /// </summary>
        public string Style { get; set; } = string.Empty;


        public FermentationParameter? FermentationParameter { get; set; }

        public ICollection<FermentationRecord> FermentationRecords { get; set; } = new List<FermentationRecord>();
    }
}
