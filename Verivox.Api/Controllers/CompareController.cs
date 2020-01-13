using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using Verivox.Api.Core.Comparison;
using Verivox.Api.Core.Interfaces;

namespace Verivox.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompareController : ControllerBase
    {
        private readonly ILogger<CompareController> _logger;
        private readonly IProductComparison _productComparison;
        public CompareController(ILogger<CompareController> logger, IProductComparison productComparison)
        {
            _logger = logger;
            _productComparison = productComparison;
        }

        [HttpGet]
        public IActionResult Compare([FromQuery] string consumptionPlans)
        {
            if (string.IsNullOrEmpty(consumptionPlans))
            {
                _logger.LogError("The consumptionPlans parameter is not contain any value.");
                return new BadRequestObjectResult(new { message = "The provided prameters is not correct!", currentDate = DateTime.Now });
            }

            var decimalSplitedPlans = consumptionPlans.Split(',').Select(decimal.Parse).ToList();
            var compareResult = new List<Recomendation>();

            try
            {
                compareResult = _productComparison.Compare(decimalSplitedPlans);
            }
            catch (Exception exception)
            {
                _logger.LogError("There some errors in comparing plans!", exception);
                return NotFound(compareResult);
            }
            _logger.LogError($"The comparison for {consumptionPlans} has been done.");
            return Ok(compareResult);
        }
    }
}