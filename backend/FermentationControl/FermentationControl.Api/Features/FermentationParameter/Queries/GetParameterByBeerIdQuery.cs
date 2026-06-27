using FermentationControl.Api.DTOs.FermentationParameter;
using MediatR;

namespace FermentationControl.Api.Features.FermentationParameter.Queries
{
    public class GetParameterByBeerIdQuery : IRequest<FermentationParameterResponseDto>
    {
        /// <summary>
        /// Identificador da cerveja.
        /// </summary>
        public int BeerId { get; set; }

        public GetParameterByBeerIdQuery(int beerId)
        {
            BeerId = beerId;
        }
    }
}
