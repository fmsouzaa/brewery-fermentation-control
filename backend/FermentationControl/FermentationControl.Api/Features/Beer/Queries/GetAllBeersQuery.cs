using FermentationControl.Api.DTOs.Beer;
using MediatR;

namespace FermentationControl.Api.Features.Beer.Queries
{
    public class GetAllBeersQuery : IRequest<List<BeerResponseDto>>
    {
    }
}
