using FermentationControl.Api.DTOs.FermentationRecord;
using MediatR;

namespace FermentationControl.Api.Features.FermentationRecord.Queries.GetRecordsByBatch
{
    public class GetRecordsByBatchQuery : IRequest<List<FermentationRecordDetailDto>>
    {
        /// <summary>
        /// Número do lote.
        /// </summary>
        public string BatchNumber { get; set; }

        public GetRecordsByBatchQuery(string batchNumber)
        {
            BatchNumber = batchNumber;
        }
    }
}
