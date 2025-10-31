using BidCalculatorAPI.Models;
using BidCalculatorAPI.Services.FeeCalculators;
using Xunit;

namespace BidCalculatorAPI.Tests.Services.FeeCalculators
{
    public class StorageFeeCalculatorTests
    {
        private readonly StorageFeeCalculator _calculator;

        public StorageFeeCalculatorTests()
        {
            _calculator = new StorageFeeCalculator();
        }

        [Fact]
        public void Calculate_AlwaysReturns100()
        {
            var vehicle = new Vehicle { Price = 1000 };

            var result = _calculator.Calculate(vehicle);

            Assert.Equal(100m, result);
        }
    }
}