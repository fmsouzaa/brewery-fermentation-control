using FermentationControl.Api.DTOs.Beer;
using MediatR;

namespace FermentationControl.Api.Features.Beer.Commands
{
    /// <summary>
    /// Command para cadastro de uma nova cerveja.
    /// </summary>
    public class CreateBeerCommand : IRequest<BeerResponseDto>
    {
        /// <summary>
        /// Nome da cerveja (ex: RT166, Brux, Borck, Anbier).
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Estilo da cerveja (ex: IPA, Lager, Weiss).
        /// </summary>
        public string Style { get; set; }
    }
}
