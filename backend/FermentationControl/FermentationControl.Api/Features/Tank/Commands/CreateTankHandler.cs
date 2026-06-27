using FermentationControl.Api.Data;
using FermentationControl.Api.DTOs.Tank;
using MediatR;

namespace FermentationControl.Api.Features.Tank.Commands
{
    public class CreateTankHandler : IRequestHandler<CreateTankCommand, TankResponseDto>
    {
        private readonly AppDbContext _context;

        public CreateTankHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<TankResponseDto> Handle(CreateTankCommand request, CancellationToken cancellationToken)
        {
            var tank = new Entities.Tank
            {
                Name = request.Name,
                Capacity = request.Capacity
            };

            _context.Tanks.Add(tank);
            await _context.SaveChangesAsync(cancellationToken);

            return new TankResponseDto
            {
                Id = tank.Id,
                Name = tank.Name,
                Capacity = tank.Capacity
            };
        }
    }
}
