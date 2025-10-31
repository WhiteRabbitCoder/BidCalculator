using BidCalculatorAPI.Constants;
using BidCalculatorAPI.Models;
using BidCalculatorAPI.Services.Interfaces;

namespace BidCalculatorAPI.Services.FeeCalculators
{
    public class SpecialFeeCalculator : IFeeCalculator
    {
        public decimal Calculate(Vehicle vehicle)
        {
            decimal rate = vehicle.Type == FeeTypes.Luxury ? 0.04m : 0.02m;
            return Math.Round(vehicle.Price * rate, 2);
        }
    }
}