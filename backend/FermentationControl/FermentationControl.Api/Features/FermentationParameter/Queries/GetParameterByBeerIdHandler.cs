using FermentationControl.Api.Data;
using FermentationControl.Api.DTOs.FermentationParameter;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FermentationControl.Api.Features.FermentationParameter.Queries
{
    public class GetParameterByBeerIdHandler : IRequestHandler<GetParameterByBeerIdQuery, FermentationParameterResponseDto?>
    {
        private readonly AppDbContext _context;

        public GetParameterByBeerIdHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<FermentationParameterResponseDto?> Handle(GetParameterByBeerIdQuery request, CancellationToken cancellationToken)
        {
            var parameter = await _context.FermentationParameters
                .FirstOrDefaultAsync(p => p.BeerId == request.BeerId, cancellationToken);

            if (parameter == null)
            {
                return null;
            }                

            return new FermentationParameterResponseDto
            {
                Id = parameter.Id,
                BeerId = parameter.BeerId,
                TemperatureMin = parameter.TemperatureMin,
                TemperatureMax = parameter.TemperatureMax,
                TemperatureTolerance = parameter.TemperatureTolerance,
                PHMin = parameter.PHMin,
                PHMax = parameter.PHMax,
                PHTolerance = parameter.PHTolerance,
                ExtractMin = parameter.ExtractMin,
                ExtractMax = parameter.ExtractMax,
                ExtractTolerance = parameter.ExtractTolerance
            };
        }

    }
}
