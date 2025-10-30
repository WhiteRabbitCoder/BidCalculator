using BidCalculatorAPI.Models;
using BidCalculatorAPI.Services.Interfaces;

public class SpecialFeeCalculator : IFeeCalculator
{
    public decimal Calculate(Vehicle vehicle)
    {
        return vehicle.Type == "Luxury" ? 200m : 100m;
    }
}