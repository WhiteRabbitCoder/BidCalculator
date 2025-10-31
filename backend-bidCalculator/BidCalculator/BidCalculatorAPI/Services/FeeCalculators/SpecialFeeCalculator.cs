using BidCalculatorAPI.Constants;
using BidCalculatorAPI.Models;
using BidCalculatorAPI.Services.Interfaces;

public class SpecialFeeCalculator : IFeeCalculator
{
    public decimal Calculate(Vehicle vehicle)
    {
        return vehicle.Type == FeeTypes.Luxury ? 200m : 100m;
    }
}