namespace FermentationControl.Api.Enums
{
    /// <summary>
    /// Categorias de classificação automática de um registro de fermentação.
    /// Valores: "Dentro do Padrão", "Atenção", "Fora do Padrão".
    /// </summary>
    public enum FermentationCategory
    {
        WithinStandard = 0,
        Attention = 1,
        OutOfStandard = 2
    }
}
