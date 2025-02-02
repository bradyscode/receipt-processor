using receipt_processor.Models;

namespace receipt_processor.Services.Interfaces
{
    public interface IPointRule
    {
        int CalculatePoints(Receipt receipt);
    }
}
