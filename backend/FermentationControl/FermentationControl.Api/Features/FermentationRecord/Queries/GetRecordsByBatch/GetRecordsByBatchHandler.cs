using FermentationControl.Api.Data;
using FermentationControl.Api.DTOs.FermentationRecord;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FermentationControl.Api.Features.FermentationRecord.Queries.GetRecordsByBatch
{
    public class GetRecordsByBatchHandler : IRequestHandler<GetRecordsByBatchQuery, List<FermentationRecordDetailDto>>
    {
        public readonly AppDbContext _context;

        public GetRecordsByBatchHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<FermentationRecordDetailDto>> Handle(GetRecordsByBatchQuery request, CancellationToken cancellationToken)
        {
            return await _context.FermentationRecords
                .Include(r => r.Beer)
                .Include(r => r.Tank)
                .Where(r => r.BatchNumber == request.BatchNumber)
                .OrderBy(r => r.DateTime)
                .Select(r => new FermentationRecordDetailDto
                {
                    Id = r.Id,
                    BeerName = r.Beer.Name,
                    TankName = r.Tank.Name,
                    DateTime = r.DateTime,
                    BatchNumber = r.BatchNumber,
                    Temperature = r.Temperature,
                    PH = r.PH,
                    Extract = r.Extract,
                    Notes = r.Notes,
                    Category = r.Category
                })
                .ToListAsync(cancellationToken);

        }
    }
}
