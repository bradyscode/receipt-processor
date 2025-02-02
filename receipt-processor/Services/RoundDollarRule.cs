using receipt_processor.Models;
using receipt_processor.Services.Interfaces;

namespace receipt_processor.Services
{
    public class RoundDollarRule : IPointRule
    {
        public int CalculatePoints(Receipt receipt)
        {
            return decimal.TryParse(receipt.total, out decimal total) &&
                   total % 1 == 0 ? 50 : 0;
        }
    }
}
