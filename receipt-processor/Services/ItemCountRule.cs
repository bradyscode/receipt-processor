using receipt_processor.Models;
using receipt_processor.Services.Interfaces;

namespace receipt_processor.Services
{
    public class ItemCountRule : IPointRule
    {
        public int CalculatePoints(Receipt receipt)
        {
            return (receipt.items.Count / 2) * 5;
        }
    }
}
