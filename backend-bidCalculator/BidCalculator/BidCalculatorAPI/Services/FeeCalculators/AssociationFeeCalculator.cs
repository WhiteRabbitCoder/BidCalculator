using BidCalculatorAPI.Models;
using BidCalculatorAPI.Services.Interfaces;

public class AssociationFeeCalculator : IFeeCalculator
{
    public decimal Calculate(Vehicle vehicle)
    {
        return 50m;
    }
}