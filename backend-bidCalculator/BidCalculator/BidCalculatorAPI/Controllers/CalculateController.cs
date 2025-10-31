using Microsoft.AspNetCore.Mvc;
using BidCalculatorAPI.Models;
using BidCalculatorAPI.Services;

namespace BidCalculatorAPI.Controllers
{
    /// <summary>
    /// Controller that exposes an endpoint to calculate fees for a vehicle.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class CalculateController : ControllerBase
    {
        private readonly TotalFeeService _feeService;

        public CalculateController(TotalFeeService feeService)
        {
            _feeService = feeService;
        }

        /// <summary>
        /// Calculates the total bid cost for a given vehicle.
        /// </summary>
        /// <remarks>
        /// Example request:
        ///
        ///     POST /api/calculate
        ///     {
        ///         "price": 1000,
        ///         "type": "Common"
        ///     }
        ///
        /// Example response:
        ///
        ///     {
        ///         "buyerFee": 50,
        ///         "specialFee": 20,
        ///         "associationFee": 10,
        ///         "storageFee": 100,
        ///         "total": 1180
        ///     }
        /// </remarks>
        /// <param name="vehicle">Vehicle object containing base price and type.</param>
        /// <returns>Full fee breakdown and total cost.</returns>
        /// <response code="200">Returns the calculated fees.</response>
        /// <response code="400">If the input data is invalid.</response>
        [HttpPost]
        public IActionResult Calculate([FromBody] Vehicle vehicle)
        {
            if (vehicle.Price <= 0 || string.IsNullOrWhiteSpace(vehicle.Type))
                return BadRequest("Invalid vehicle data.");

            var breakdown = _feeService.CalculateBreakdown(vehicle);
            return Ok(breakdown);
        }
    }
}