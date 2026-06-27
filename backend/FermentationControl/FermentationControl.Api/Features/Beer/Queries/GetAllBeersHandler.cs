using FermentationControl.Api.Data;
using FermentationControl.Api.DTOs.Beer;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FermentationControl.Api.Features.Beer.Queries
{
    public class GetAllBeersHandler : IRequestHandler<GetAllBeersQuery, List<BeerResponseDto>>
    {
        private readonly AppDbContext _context;

        public GetAllBeersHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<BeerResponseDto>> Handle(GetAllBeersQuery request, CancellationToken cancellationToken)
        {
            return await _context.Beers
                .Select(b => new BeerResponseDto
                {
                    Id = b.Id,
                    Name = b.Name,
                    Style = b.Style
                })
                .ToListAsync(cancellationToken);
        }
    }
}
