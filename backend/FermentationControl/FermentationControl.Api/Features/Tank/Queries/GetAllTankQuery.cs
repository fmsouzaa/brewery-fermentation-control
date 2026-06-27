using FermentationControl.Api.DTOs.Tank;
using MediatR;

namespace FermentationControl.Api.Features.Tank.Queries
{
    public class GetAllTankQuery : IRequest<List<TankResponseDto>>
    {
    }
}