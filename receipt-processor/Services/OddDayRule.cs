using receipt_processor.Models;
using receipt_processor.Services.Interfaces;

namespace receipt_processor.Services
{
    public class OddDayRule : IPointRule
    {
        public int CalculatePoints(Receipt receipt)
        {
            return DateTime.TryParse(receipt.purchaseDate, out DateTime date) &&
                   date.Day % 2 == 1 ? 6 : 0;
        }
    }
}
