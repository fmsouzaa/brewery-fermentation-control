using FermentationControl.Api.Data;
using FermentationControl.Api.DTOs.FermentationParameter;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FermentationControl.Api.Features.FermentationParameter.Commands
{
    public class CreateFermentationParameterHandler : IRequestHandler<CreateFermentationParameterCommand, FermentationParameterResponseDto>
    {
        private readonly AppDbContext _context;

        public CreateFermentationParameterHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<FermentationParameterResponseDto> Handle(CreateFermentationParameterCommand request, CancellationToken cancellationToken)
        {
            // Verifica se a cerveja existe
            var beer = await _context.Beers
                .FirstOrDefaultAsync(b => b.Id == request.BeerId, cancellationToken);

            if (beer == null)
                throw new Exception($"Cerveja com Id {request.BeerId} não encontrada.");

            // Verifica se já existe parâmetro cadastrado para essa cerveja
            var existingParameter = await _context.FermentationParameters
                .FirstOrDefaultAsync(p => p.BeerId == request.BeerId, cancellationToken);

            if (existingParameter != null)
                throw new Exception($"Já existe um Parâmetro de fermentação cadastrado para a cerveja com Id {request.BeerId}.");

            var parameter = new Entities.FermentationParameter
            {
                BeerId = request.BeerId,
                TemperatureMin = request.TemperatureMin,
                TemperatureMax = request.TemperatureMax,
                TemperatureTolerance = request.TemperatureTolerance,
                PHMin = request.PHMin,
                PHMax = request.PHMax,
                PHTolerance = request.PHTolerance,
                ExtractMin = request.ExtractMin,
                ExtractMax = request.ExtractMax,
                ExtractTolerance = request.ExtractTolerance
            };

            _context.FermentationParameters.Add(parameter);
            await _context.SaveChangesAsync(cancellationToken);

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
