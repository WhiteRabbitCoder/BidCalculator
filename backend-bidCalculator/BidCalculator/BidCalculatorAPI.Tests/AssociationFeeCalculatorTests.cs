using BidCalculatorAPI.Models;
using BidCalculatorAPI.Services.FeeCalculators;
using Xunit;

namespace BidCalculatorAPI.Tests.Services.FeeCalculators
{
    public class AssociationFeeCalculatorTests
    {
        private readonly AssociationFeeCalculator _calculator;

        public AssociationFeeCalculatorTests()
        {
            _calculator = new AssociationFeeCalculator();
        }

        [Theory]
        [InlineData(100, 5)]
        [InlineData(500, 5)]
        [InlineData(501, 10)]
        [InlineData(1000, 10)]
        [InlineData(1001, 15)]
        [InlineData(3000, 15)]
        [InlineData(3001, 20)]
        [InlineData(5000, 20)]
        public void Calculate_ReturnsCorrectFee_BasedOnPrice(decimal price, decimal expected)
        {
            var vehicle = new Vehicle { Price = price };

            var result = _calculator.Calculate(vehicle);

            Assert.Equal(expected, result);
        }
    }
}
