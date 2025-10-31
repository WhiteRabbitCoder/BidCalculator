using Xunit;
using Microsoft.AspNetCore.Mvc;
using BidCalculatorAPI.Controllers;
using BidCalculatorAPI.Models;
using BidCalculatorAPI.Services;
using BidCalculatorAPI.Services.FeeCalculators;

namespace BidCalculatorAPI.Tests
{
    public class CalculateControllerTests
    {
        [Fact]
        public void Calculate_ShouldReturnOkResult_WithBreakdown()
        {
            // Arrange
            var service = new TotalFeeService(
                new BuyerFeeCalculator(),
                new SpecialFeeCalculator(),
                new AssociationFeeCalculator(),
                new StorageFeeCalculator()
            );
            var controller = new CalculateController(service);
            var vehicle = new Vehicle { Price = 10000, Type = "Luxury" };

            // Act
            var result = controller.Calculate(vehicle) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
        }
    }
}