using receipt_processor.Models;
using receipt_processor.Services.Interfaces;

namespace receipt_processor.Services
{
    public class AfternoonTimeRule : IPointRule
    {
        public int CalculatePoints(Receipt receipt)
        {
            if (TimeSpan.TryParse(receipt.purchaseTime, out TimeSpan time))
            {
                var afterTwo = time >= new TimeSpan(14, 0, 0);
                var beforeFour = time <= new TimeSpan(16, 0, 0);
                return (afterTwo && beforeFour) ? 10 : 0;
            }
            return 0;
        }
    }
}
