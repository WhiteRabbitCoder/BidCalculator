using BidCalculatorAPI.Constants;
using BidCalculatorAPI.Models;
using BidCalculatorAPI.Services;
using BidCalculatorAPI.Services.FeeCalculators;
using Xunit;

namespace BidCalculatorAPI.Tests.Services
{
    public class TotalFeeServiceTests
    {
        private readonly TotalFeeService _service;

        public TotalFeeServiceTests()
        {
            _service = new TotalFeeService(
                new BuyerFeeCalculator(),
                new SpecialFeeCalculator(),
                new AssociationFeeCalculator(),
                new StorageFeeCalculator()
            );
        }

        [Fact]
        public void CalculateBreakdown_ReturnsCorrectBreakdown_ForCommonVehicle()
        {
            var vehicle = new Vehicle { Price = 1000, Type = FeeTypes.Common };

            var result = _service.CalculateBreakdown(vehicle);

            Assert.Equal(50m, result.BuyerFee);
            Assert.Equal(20m, result.SpecialFee);
            Assert.Equal(10m, result.AssociationFee);
            Assert.Equal(100m, result.StorageFee);
            Assert.Equal(180m, result.TotalFees);
            Assert.Equal(1180m, result.BidTotal);
        }

        [Fact]
        public void CalculateBreakdown_ReturnsCorrectBreakdown_ForLuxuryVehicle()
        {
            var vehicle = new Vehicle { Price = 1800, Type = FeeTypes.Luxury };

            var result = _service.CalculateBreakdown(vehicle);

            Assert.Equal(180m, result.BuyerFee);
            Assert.Equal(72m, result.SpecialFee);
            Assert.Equal(15m, result.AssociationFee);
            Assert.Equal(100m, result.StorageFee);
            Assert.Equal(367m, result.TotalFees);
            Assert.Equal(2167m, result.BidTotal);
        }
    }
}