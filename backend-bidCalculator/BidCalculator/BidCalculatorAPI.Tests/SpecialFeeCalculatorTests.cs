using Xunit;
using BidCalculatorAPI.Models;
using BidCalculatorAPI.Services.FeeCalculators;

namespace BidCalculatorAPI.Tests
{
    public class SpecialFeeCalculatorTests
    {
        [Theory]
        [InlineData("Luxury", 200)]
        [InlineData("Common", 100)]
        public void Calculate_ShouldReturnCorrectFeeByType(string type, decimal expected)
        {
            var calc = new SpecialFeeCalculator();
            var vehicle = new Vehicle { Price = 5000, Type = type };

            var result = calc.Calculate(vehicle);

            Assert.Equal(expected, result);
        }
    }
}