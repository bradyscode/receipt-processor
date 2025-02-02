using receipt_processor.Models;
using receipt_processor.Services.Interfaces;

namespace receipt_processor.Services
{
    public class RetailerNameRule : IPointRule
    {
        public int CalculatePoints(Receipt receipt)
        {
            return receipt.retailer.Count(char.IsLetterOrDigit);
        }
    }
}
