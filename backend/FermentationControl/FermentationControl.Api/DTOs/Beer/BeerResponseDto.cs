namespace FermentationControl.Api.DTOs.Beer
{
    /// <summary>
    /// Dados de uma cerveja retornados ao cliente.
    /// </summary>
    public class BeerResponseDto
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
    }
}
