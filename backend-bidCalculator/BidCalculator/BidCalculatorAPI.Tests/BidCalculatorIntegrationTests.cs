using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BidCalculatorAPI.Models;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace BidCalculatorAPI.Tests
{
    public class BidCalculatorIntegrationTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public BidCalculatorIntegrationTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task Calculate_WithValidCommonVehicle_ReturnsCorrectBreakdown()
        {
            // Arrange
            var vehicle = new Vehicle { Price = 398m, Type = "Common" };

            // Act
            var response = await _client.PostAsJsonAsync("/api/calculate", vehicle);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var result = await response.Content.ReadFromJsonAsync<FeeBreakdown>();

            result.Should().NotBeNull();
            result!.BuyerFee.Should().Be(39.80m);
            result.SpecialFee.Should().Be(7.96m);
            result.AssociationFee.Should().Be(5m);
            result.StorageFee.Should().Be(100m);
            result.TotalFees.Should().Be(152.76m);
            result.BidTotal.Should().Be(550.76m);
        }

        [Fact]
        public async Task Calculate_WithValidLuxuryVehicle_ReturnsCorrectBreakdown()
        {
            // Arrange
            var vehicle = new Vehicle { Price = 1800m, Type = "Luxury" };

            // Act
            var response = await _client.PostAsJsonAsync("/api/calculate", vehicle);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var result = await response.Content.ReadFromJsonAsync<FeeBreakdown>();

            result.Should().NotBeNull();
            result!.BuyerFee.Should().Be(180m);
            result.SpecialFee.Should().Be(72m);
            result.AssociationFee.Should().Be(15m);
            result.StorageFee.Should().Be(100m);
            result.TotalFees.Should().Be(367m);
            result.BidTotal.Should().Be(2167m);
        }

        [Theory]
        [InlineData(0, "Common")]
        [InlineData(-100, "Luxury")]
        public async Task Calculate_WithInvalidPrice_ReturnsBadRequest(decimal price, string type)
        {
            // Arrange
            var vehicle = new Vehicle { Price = price, Type = type };

            // Act
            var response = await _client.PostAsJsonAsync("/api/calculate", vehicle);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task Calculate_WithInvalidType_ReturnsBadRequest()
        {
            // Arrange
            var vehicle = new Vehicle { Price = 1000m, Type = "Invalid" };

            // Act
            var response = await _client.PostAsJsonAsync("/api/calculate", vehicle);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task Calculate_WithMissingType_ReturnsBadRequest()
        {
            // Arrange
            var vehicle = new Vehicle { Price = 1000m, Type = "" };

            // Act
            var response = await _client.PostAsJsonAsync("/api/calculate", vehicle);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task Calculate_VerifiesCorsHeaders()
        {
            // Arrange
            var vehicle = new Vehicle { Price = 1000m, Type = "Common" };

            // Act
            var response = await _client.PostAsJsonAsync("/api/calculate", vehicle);

            // Assert
            response.Headers.Should().ContainKey("Access-Control-Allow-Origin");
        }

        [Fact]
        public async Task Calculate_MultipleRequests_ReturnsConsistentResults()
        {
            // Arrange
            var vehicle = new Vehicle { Price = 1100m, Type = "Luxury" };

            // Act
            var response1 = await _client.PostAsJsonAsync("/api/calculate", vehicle);
            var response2 = await _client.PostAsJsonAsync("/api/calculate", vehicle);

            var result1 = await response1.Content.ReadFromJsonAsync<FeeBreakdown>();
            var result2 = await response2.Content.ReadFromJsonAsync<FeeBreakdown>();

            // Assert
            result1.Should().BeEquivalentTo(result2);
        }
    }
}