using receipt_processor.Models;
using receipt_processor.Services.Interfaces;

namespace receipt_processor.Services
{
    public class ItemDescriptionLengthRule : IPointRule
    {
        public int CalculatePoints(Receipt receipt)
        {
            int points = 0;
            foreach (var item in receipt.items)
            {
                var trimmedLength = item.shortDescription.Trim().Length;
                if (trimmedLength % 3 == 0)
                {
                    if (decimal.TryParse(item.price, out decimal price))
                    {
                        points += (int)Math.Ceiling(price * 0.2m);
                    }
                }
            }
            return points;
        }
    }
}
