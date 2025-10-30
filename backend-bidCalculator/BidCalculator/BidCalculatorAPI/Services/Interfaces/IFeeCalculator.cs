using BidCalculatorAPI.Models;

namespace BidCalculatorAPI.Services.Interfaces
{
    public interface IFeeCalculator
    {
        decimal Calculate(Vehicle vehicle);
    }
}