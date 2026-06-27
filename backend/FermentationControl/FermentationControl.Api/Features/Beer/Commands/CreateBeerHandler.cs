using FermentationControl.Api.Data;
using FermentationControl.Api.DTOs.Beer;
using MediatR;

namespace FermentationControl.Api.Features.Beer.Commands
{
    public class CreateBeerHandler : IRequestHandler<CreateBeerCommand, BeerResponseDto>
    {
        private readonly AppDbContext _context;

        public CreateBeerHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<BeerResponseDto> Handle(CreateBeerCommand request, CancellationToken cancellationToken)
        {
            var beer = new Entities.Beer
            {
                Name = request.Name,
                Style = request.Style
            };

            _context.Beers.Add(beer);
            await _context.SaveChangesAsync(cancellationToken);
            
            return new BeerResponseDto
            {
                Id = beer.Id,
                Name = beer.Name,
                Style = beer.Style
            };
        }
    }
}
