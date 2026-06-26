namespace FermentationControl.Api.DTOs.Dashboard
{
    public class DashboardResponseDto
    {
        /// <summary>
        /// Total de registros fermentativos cadastrados no sistema.
        /// </summary>
        public int TotalRecords { get; set; }

        /// <summary>
        /// Quantidade de registros classificados como "Dentro do Padrão".
        /// </summary>
        public int WithinStandardCount { get; set; }

        /// <summary>
        /// Quantidade de registros classificados como "Atenção".
        /// </summary>
        public int AttentionCount { get; set; }

        /// <summary>
        /// Quantidade de registros classificados como "Fora do Padrão".
        /// </summary>
        public int OutOfStandardCount { get; set; }
    }
}
