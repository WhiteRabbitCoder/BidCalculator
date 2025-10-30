using Microsoft.AspNetCore.Mvc;
using BidCalculatorAPI.Models;
using BidCalculatorAPI.Services;

namespace BidCalculatorAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CalculateController : ControllerBase
    {
        private readonly TotalFeeService _feeService;

        public CalculateController(TotalFeeService feeService)
        {
            _feeService = feeService;
        }

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