using receipt_processor.Models;

namespace receipt_processor.Services.Interfaces
{
    public interface IPointsCalculator
    {
        int CalculatePoints(Receipt receipt);
    }
}
