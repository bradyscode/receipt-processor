using receipt_processor.Models;
using receipt_processor.Services.Interfaces;

namespace receipt_processor.Services
{
    public class QuarterMultipleRule : IPointRule
    {
        public int CalculatePoints(Receipt receipt)
        {
            return decimal.TryParse(receipt.total, out decimal total) &&
                   (total * 100) % 25 == 0 ? 25 : 0;
        }
    }
}
