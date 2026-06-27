using FermentationControl.Api.Data;
using FermentationControl.Api.DTOs.Dashboard;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FermentationControl.Api.Features.Dashboard.Queries
{
    public class GetDashboardHandler : IRequestHandler<GetDashboardQuery, DashboardResponseDto>
    {
        private readonly AppDbContext _context;

        public GetDashboardHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<DashboardResponseDto> Handle(GetDashboardQuery request, CancellationToken cancellationToken)
        {
            // Busca todos os registros fermentativos
            var records = await _context.FermentationRecords.ToListAsync(cancellationToken);

            return new DashboardResponseDto
            {
                TotalRecords = records.Count,
                WithinStandardCount = records.Count(r => r.Category == Enums.FermentationCategory.WithinStandard),
                AttentionCount = records.Count(r => r.Category == Enums.FermentationCategory.Attention),
                OutOfStandardCount = records.Count(r => r.Category == Enums.FermentationCategory.OutOfStandard)     
            };
        }
    }
}
