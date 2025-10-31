using BidCalculatorAPI.Constants;
using BidCalculatorAPI.Models;
using BidCalculatorAPI.Services.Interfaces;

namespace BidCalculatorAPI.Services.FeeCalculators
{
    public class BuyerFeeCalculator : IFeeCalculator
    {
        /// <inheritdoc/>
        public decimal Calculate(Vehicle vehicle)
        {
            decimal fee = vehicle.Price * 0.10m;

            if (vehicle.Type == FeeTypes.Common)
            {
                fee = Math.Clamp(fee, 10m, 50m);
            }
            else if (vehicle.Type == FeeTypes.Luxury)
            {
                fee = Math.Clamp(fee, 25m, 200m);
            }

            return Math.Round(fee, 2);
        }
    }
}