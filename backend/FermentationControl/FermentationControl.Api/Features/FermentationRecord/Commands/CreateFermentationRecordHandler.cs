using FermentationControl.Api.Data;
using FermentationControl.Api.DTOs.FermentationRecord;
using FermentationControl.Api.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FermentationControl.Api.Features.FermentationRecord.Commands
{
    public class CreateFermentationRecordHandler : IRequestHandler<CreateFermentationRecordCommand, FermentationRecordResponseDto>
    {
        public readonly AppDbContext _context;
        public readonly FermentationClassificationService _fermentationClassificationService;

        public CreateFermentationRecordHandler(AppDbContext context, FermentationClassificationService fermentationClassificationService)
        {
            _context = context;
            _fermentationClassificationService = fermentationClassificationService;
        }

        public async Task<FermentationRecordResponseDto> Handle(CreateFermentationRecordCommand request, CancellationToken cancellationToken)
        {
            // Verifica se a cerveja existe
            var beer = await _context.Beers
                .FirstOrDefaultAsync(b => b.Id == request.BeerId, cancellationToken);

            if (beer == null)
            {
                throw new Exception($"Cerveja com Id {request.BeerId} não encontrada.");

            }

            // Verifica se o tank existe
            var tank = await _context.Tanks
                .FirstOrDefaultAsync(t => t.Id == request.TankId, cancellationToken);

            if (beer == null)
            {
                throw new Exception($"Cerveja com Id {request.BeerId} não encontrada.");
            }

            // Busca os parâmetros cadastrados para a cerveja
            var parameter = await _context.FermentationParameters.FirstOrDefaultAsync(cancellationToken);

            if (parameter == null)
            {
                throw new Exception($"Parâmetros fermentativos não encontrados para a cerveja com Id {request.BeerId}.");
            }

            // Classifica o registro com base nos parâmetros cadastrados
            var category = _fermentationClassificationService.ClassifyRecord(
                request.Temperature,
                request.PH,
                request.Extract,
                parameter
            );

            
            var record = new Entities.FermentationRecord
            {
                BeerId = request.BeerId,
                TankId = request.TankId,
                DateTime = request.DateTime,
                BatchNumber = request.BatchNumber,
                Temperature = request.Temperature,
                PH = request.PH,
                Extract = request.Extract,
                Notes = request.Notes,
                Category = category
            };

            _context.FermentationRecords.Add(record);
            await _context.SaveChangesAsync(cancellationToken);

            return new FermentationRecordResponseDto
            {
                Id = record.Id,
                BeerId = record.BeerId,
                TankId = record.TankId,
                DateTime = record.DateTime,
                BatchNumber = record.BatchNumber,
                Temperature = record.Temperature,
                PH = record.PH,
                Extract = record.Extract,
                Notes = record.Notes,
                Category = category
            };
        }
    }
}
