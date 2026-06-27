using FermentationControl.Api.Data;
using FermentationControl.Api.DTOs.Tank;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FermentationControl.Api.Features.Tank.Queries
{
    public class GetAllTankHandler : IRequestHandler<GetAllTankQuery, List<TankResponseDto>>
    {
        private readonly AppDbContext _context;

        public GetAllTankHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<TankResponseDto>> Handle(GetAllTankQuery request, CancellationToken cancellationToken)
        {
            return await _context.Tanks
                .Select(t => new TankResponseDto
                {
                    Id = t.Id,
                    Name = t.Name,
                    Capacity = t.Capacity
                }).ToListAsync(cancellationToken);
        }
    }
}
