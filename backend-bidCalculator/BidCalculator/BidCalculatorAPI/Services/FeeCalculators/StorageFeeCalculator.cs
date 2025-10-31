using BidCalculatorAPI.Models;
using BidCalculatorAPI.Services.Interfaces;

namespace BidCalculatorAPI.Services.FeeCalculators
{
    public class StorageFeeCalculator : IFeeCalculator
    {
        public decimal Calculate(Vehicle vehicle)
        {
            return 100m;
        }
    }
}