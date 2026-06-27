using FermentationControl.Api.Entities;
using FermentationControl.Api.Enums;

namespace FermentationControl.Api.Services
{
    /// <summary>
    /// Classifica um registro fermentativo comparando os valores medidos com os parâmetros cadastrados e suas tolerâncias.
    /// </summary>
    public class FermentationClassificationService
    {
        public FermentationCategory ClassifyRecord(
            decimal temperature,
            decimal ph,
            decimal extract,
            FermentationParameter parameter) 
        {
            
            bool isOutOfStandard = IsOutsideTolerance(temperature, parameter.TemperatureMin, parameter.TemperatureMax, parameter.TemperatureTolerance) ||
                                 IsOutsideTolerance(ph, parameter.PHMin, parameter.PHMax, parameter.PHTolerance) ||
                                 IsOutsideTolerance(extract, parameter.ExtractMin, parameter.ExtractMax, parameter.ExtractTolerance);

            bool needAttention = IsOutsideRange(temperature, parameter.TemperatureMin, parameter.TemperatureMax) ||
                             IsOutsideRange(ph, parameter.PHMin, parameter.PHMax) ||
                             IsOutsideRange(extract, parameter.ExtractMin, parameter.ExtractMax);

            if (isOutOfStandard)
            {
                return FermentationCategory.OutOfStandard;
            }

            if (needAttention)
            {
                return FermentationCategory.Attention;
            }

            return FermentationCategory.WithinStandard;
        }

        // Verifica se o valor ultrapassa a faixa de tolerância
        private bool IsOutsideTolerance(decimal value, decimal min, decimal max, decimal tolerance)
        {
            return value < (min - tolerance) || value > (max + tolerance);
        }

        // Verifica se o valor está fora da faixa cadastrada (min/max)
        private bool IsOutsideRange(decimal value, decimal min, decimal max) 
        {
            return value < min || value > max;
        }
    }
}
