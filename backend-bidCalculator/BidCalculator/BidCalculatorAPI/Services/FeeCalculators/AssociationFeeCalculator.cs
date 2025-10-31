using BidCalculatorAPI.Models;
using BidCalculatorAPI.Services.Interfaces;

namespace BidCalculatorAPI.Services.FeeCalculators
{
    public class AssociationFeeCalculator : IFeeCalculator
    {
        public decimal Calculate(Vehicle vehicle)
        {
            if (vehicle.Price <= 500) return 5m;
            if (vehicle.Price <= 1000) return 10m;
            if (vehicle.Price <= 3000) return 15m;
            return 20m;
        }
    }
}