using BidCalculatorAPI.Models;
using BidCalculatorAPI.Services.Interfaces;

public class StorageFeeCalculator : IFeeCalculator
{
    public decimal Calculate(Vehicle vehicle)
    {
        return 30m;
    }
}