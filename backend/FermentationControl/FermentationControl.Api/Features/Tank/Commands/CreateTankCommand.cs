
using FermentationControl.Api.DTOs.Tank;
using MediatR;

namespace FermentationControl.Api.Features.Tank.Commands
{
    /// <summary>
    /// Command para cadastro de uma novo tanque.
    /// </summary>
    public class CreateTankCommand : IRequest<TankResponseDto>
    {
        /// <summary>
        /// Nome do tanque (ex: Tanque B, Tanque 01).
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Capacidade do tanque em litros.
        /// </summary>
        public decimal Capacity { get; set; }
    }
}
