using BidCalculatorAPI.Constants;
using BidCalculatorAPI.Models;
using BidCalculatorAPI.Services.FeeCalculators;
using Xunit;

namespace BidCalculatorAPI.Tests.Services.FeeCalculators
{
    public class SpecialFeeCalculatorTests
    {
        private readonly SpecialFeeCalculator _calculator;

        public SpecialFeeCalculatorTests()
        {
            _calculator = new SpecialFeeCalculator();
        }

        [Theory]
        [InlineData(1000, FeeTypes.Common, 20)]
        [InlineData(500, FeeTypes.Common, 10)]
        [InlineData(1500, FeeTypes.Common, 30)]
        public void Calculate_ReturnsCorrectFee_ForCommonVehicles(decimal price, string type, decimal expected)
        {
            var vehicle = new Vehicle { Price = price, Type = type };

            var result = _calculator.Calculate(vehicle);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(1000, FeeTypes.Luxury, 40)]
        [InlineData(500, FeeTypes.Luxury, 20)]
        [InlineData(1500, FeeTypes.Luxury, 60)]
        public void Calculate_ReturnsCorrectFee_ForLuxuryVehicles(decimal price, string type, decimal expected)
        {
            var vehicle = new Vehicle { Price = price, Type = type };

            var result = _calculator.Calculate(vehicle);

            Assert.Equal(expected, result);
        }
    }
}