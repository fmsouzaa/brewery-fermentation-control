
using FermentationControl.Api.DTOs.Tank;
using MediatR;

namespace FermentationControl.Api.Features.Tank.Commands
{
    public class CreateTankCommand : IRequest<TankResponseDto>
    {
        public string Name { get; set; }

        public decimal Capacity { get; set; }
    }
}
