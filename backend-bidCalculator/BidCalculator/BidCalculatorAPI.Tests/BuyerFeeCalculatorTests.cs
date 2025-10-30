using Xunit;
using BidCalculatorAPI.Models;
using BidCalculatorAPI.Services.FeeCalculators;

namespace BidCalculatorAPI.Tests
{
    public class BuyerFeeCalculatorTests
    {
        [Fact]
        public void Calculate_ShouldReturn10PercentOfPrice()
        {
            var calc = new BuyerFeeCalculator();
            var vehicle = new Vehicle { Price = 10000, Type = "Common" };

            var result = calc.Calculate(vehicle);

            Assert.Equal(1000, result);
        }
    }
}