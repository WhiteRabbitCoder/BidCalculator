using BidCalculatorAPI.Models;
using BidCalculatorAPI.Services.Interfaces;

namespace BidCalculatorAPI.Services.FeeCalculators
{
    public class BuyerFeeCalculator : IFeeCalculator
    {
        public decimal Calculate(Vehicle vehicle)
        {
            return vehicle.Price * 0.10m; // Example: 10% fee
        }
    }
}