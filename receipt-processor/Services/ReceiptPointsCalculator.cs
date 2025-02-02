using receipt_processor.Models;
using receipt_processor.Services.Interfaces;

namespace receipt_processor.Services
{
    public class ReceiptPointsCalculator : IPointsCalculator
    {
        private readonly IPointRule[] _rules;

        public ReceiptPointsCalculator()
        {
            _rules = new IPointRule[]
            {
                new RetailerNameRule(),
                new RoundDollarRule(),
                new QuarterMultipleRule(),
                new ItemCountRule(),
                new ItemDescriptionLengthRule(),
                new OddDayRule(),
                new AfternoonTimeRule()
            };
        }

        public int CalculatePoints(Receipt receipt)
        {
            return _rules.Sum(rule => rule.CalculatePoints(receipt));
        }
    }
}
