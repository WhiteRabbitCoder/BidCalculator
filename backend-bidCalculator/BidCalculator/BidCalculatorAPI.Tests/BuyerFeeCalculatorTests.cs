using BidCalculatorAPI.Constants;
using BidCalculatorAPI.Models;
using BidCalculatorAPI.Services.FeeCalculators;
using Xunit;

namespace BidCalculatorAPI.Tests.Services.FeeCalculators
{
    public class BuyerFeeCalculatorTests
    {
        private readonly BuyerFeeCalculator _calculator;

        public BuyerFeeCalculatorTests()
        {
            _calculator = new BuyerFeeCalculator();
        }

        [Theory]
        [InlineData(100, FeeTypes.Common, 10)]
        [InlineData(200, FeeTypes.Common, 20)]
        [InlineData(500, FeeTypes.Common, 50)]
        [InlineData(1000, FeeTypes.Common, 50)]
        public void Calculate_ReturnsCorrectFee_ForCommonVehicles(decimal price, string type, decimal expected)
        {
            var vehicle = new Vehicle { Price = price, Type = type };

            var result = _calculator.Calculate(vehicle);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(100, FeeTypes.Luxury, 25)]
        [InlineData(500, FeeTypes.Luxury, 50)]
        [InlineData(2000, FeeTypes.Luxury, 200)]
        [InlineData(5000, FeeTypes.Luxury, 200)]
        public void Calculate_ReturnsCorrectFee_ForLuxuryVehicles(decimal price, string type, decimal expected)
        {
            var vehicle = new Vehicle { Price = price, Type = type };

            var result = _calculator.Calculate(vehicle);

            Assert.Equal(expected, result);
        }
    }
}