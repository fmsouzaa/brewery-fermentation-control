using FermentationControl.Api.DTOs.Beer;
using MediatR;

namespace FermentationControl.Api.Features.Beer.Commands
{
    public class CreateBeerCommand : IRequest<BeerResponseDto>
    {
        public string Name { get; set; }
        public string Style { get; set; }
    }
}
